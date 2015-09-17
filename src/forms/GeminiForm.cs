using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using IronRuby.Builtins;
using ScintillaNet;

/*\
 *  ######  ###### ##     ## ###### ##    ## ######
 * ##    ## ##     ###   ###   ##   ###   ##   ##
 * ##       ##     #### ####   ##   ####  ##   ##
 * ##  ###  ####   ## ### ##   ##   ## ## ##   ##
 * ##    ## ##     ##     ##   ##   ##  ####   ##
 * ##    ## ##     ##     ##   ##   ##   ###   ##
 *  ######  ###### ##     ## ###### ##    ## ######
\*/
namespace Gemini
{
  public partial class GeminiForm : Form
  {
    [DllImport("User32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);


    /*\
     * ####### ##         ##        ##
     * ##                 ##        ##
     * ##      ###  ####  ##        ##  ######
     * #####   ##  ##  ## ##    ###### ##
     * ##      ##  ###### ##   ##   ##  #####
     * ##      ##  ##     ##   ##   ##      ##
     * ##      ##   #####  ###  ###### ######
     * ======================================
    \*/
    #region Fields and Properties

    private string _projectDirectory = "";
    private string _projectScriptPath = "";
    private string _projectScriptsFolderPath = "";
    private string _projectEngine = "";

    private Regex _invalidRegex = new Regex(@"[^A-Za-z0-9 +\-_=.,!@#$%^&();'(){}[\]]+",
      RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.CultureInvariant);
    private Regex _fileNameRegex = new Regex(@"([A-Za-z0-9 +\-_=.,!@#$%^&();'(){}[\]]+)\.([A-Za-z0-9]{8})\.rb",
      RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.CultureInvariant);

    private bool _projectNeedSave = false;
    private bool _saving = false;
    private byte[] _projectLastSave;
    private List<Script> _scripts = new List<Script>();

    private bool _updatingText = false;

    private List<int> _usedSections = new List<int>();
    private List<int> _oldSections = new List<int>();

    private FindReplaceDialog _findReplaceDialog = new FindReplaceDialog();
    private Process _charmap = new Process();

    #endregion

    /*\
     *  ######                           ##                                ##
     * ##                                ##                                ##
     * ##       ######  #######   ###### #######  ######  ##    ##  ###### #######  ######   ######
     * ##      ##    ## ##    ## ##      ##      ##    ## ##    ## ##      ##      ##    ## ##    ##
     * ##      ##    ## ##    ##  #####  ##      ##       ##    ## ##      ##      ##    ## ##
     * ##      ##    ## ##    ##      ## ##   ## ##       ##    ## ##      ##   ## ##    ## ##
     *  ######  ######  ##    ## ######   #####  ##        ######   ######  #####   ######  ##
     * =============================================================================================
    \*/
    #region Contructor

    /// <summary>
    /// Initializes form components, child forms, and the Ruby engine.
    /// </summary>
    [EnvironmentPermission(SecurityAction.LinkDemand, Unrestricted = true)]
    public GeminiForm(string[] args)
    {
      InitializeComponent();
      Icon = Icon.FromHandle(Properties.Resources.gemini.GetHicon());
      Ruby.CreateRuntime();
      Settings.SetDefaults();
      Settings.SetLocalDefaults();
      Settings.LoadSettings();
      ApplySettings();
      UpdateMenusEnabled();
      string[] files = { };
      if (args.Length > 0 && IsProject(args[0]))
        OpenProject(args[0]);
      else if (Settings.RecentPriority && Settings.AutoOpen && Settings.RecentlyOpened.Count > 0)
        OpenRecentProject(0, false);
      else if (Settings.AutoOpen && IsProject(files = Directory.GetFiles(Application.StartupPath)))
      {
        foreach (string file in files)
          if (IsProject(file))
          {
            OpenProject(file);
            return;
          }
        if (Settings.RecentlyOpened.Count > 0)
          OpenRecentProject(0, false);
      }
      else if (Settings.AutoOpen && Settings.RecentlyOpened.Count > 0)
        OpenRecentProject(0, false);
    }

    /// <summary>
    /// Applies all changes that are configured in the settings
    /// </summary>
    private void ApplySettings()
    {
      UpdateSettingsState();
      UpdateRecentProjectList();
      UpdateAutoCompleteWords();
      foreach (Script script in _scripts)
      {
        script.UpdateSettings();
        script.SetStyle();
      }
      if (Settings.AutoHideMenuBar && menuMain_menuStrip.Visible) MenuBarDeactivate();
      else MenuBarActive();
      Bounds = Settings.WindowBounds;
      if (Settings.WindowMaximized)
        WindowState = FormWindowState.Maximized;
    }

    #endregion

    /*\
     * #######                                  #######                            ##
     * ##                                       ##                                 ##
     * ##       ######   ######  ##### ###      ##      ##     ##  #####  #######  ######
     * #####   ##    ## ##    ## ##  ##  ##     #####   ##     ## ##   ## ##    ## ##
     * ##      ##    ## ##       ##  ##  ##     ##       ##   ##  ####### ##    ## ##
     * ##      ##    ## ##       ##  ##  ##     ##        ## ##   ##      ##    ## ##  ##
     * ##       ######  ##       ##  ##  ##     #######    ###     #####  ##    ##  ####
     * ==================================================================================
    \*/
    #region Main Form Events

    /// <summary>
    /// Cleans up resources and saves the state of the current settings for next time
    /// </summary>
    private void GeminiForm_Closing(object sender, FormClosingEventArgs e)
    {
      if (!CloseProject(true))
      {
        e.Cancel = true;
        return;
      }
      if (Settings.AutoSaveConfig)
        SaveConfiguration(false);
      try { _charmap.Kill(); } catch { }
    }

    private void GeminiForm_KeyDown(object sender, KeyEventArgs e)
    {
      if (Settings.AutoHideMenuBar && menuMain_menuStrip.Visible && e.Alt) MenuBarDeactivate();
      else if (Settings.AutoHideMenuBar && e.Alt) MenuBarActive();
    }

    /// <summary>
    /// Automatically rewrite the latest save when the script file is overwritten by another program
    /// </summary>
    private void fileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
    {
      scriptsFileWatcher.EnableRaisingEvents = false;
      DateTime t = DateTime.Now;
      while ((DateTime.Now - t).TotalMilliseconds < 1000)
        try
        {
          File.WriteAllBytes(_projectScriptPath, _projectLastSave);
          break;
        }
        catch { }
      scriptsFileWatcher.EnableRaisingEvents = true;
    }

    #endregion

    /*\
     * ##     ##                                   ##               ##
     * ###   ###                                   ##
     * #### ####  #####  #######  ##    ##  ###### #######  ######  ### ######
     * ## ### ## ##   ## ##    ## ##    ## ##      ##      ##    ## ##  ##   ##
     * ##     ## ####### ##    ## ##    ##  #####  ##      ##       ##  ##   ##
     * ##     ## ##      ##    ## ##    ##      ## ##   ## ##       ##  ######
     * ##     ##  #####  ##    ##  ######  ######   #####  ##       ##  ##
     * =================================================================##=====
    \*/
    #region Menu Strip Events

    private void menuMain_menuStrip_Leave(object sender, EventArgs e)
    {
      if (Settings.AutoHideMenuBar) MenuBarDeactivate();
    }

    private void MenuBarActive()
    {
      menuMain_menuStrip.Visible = true;
    }

    private void MenuBarDeactivate()
    {
      menuMain_menuStrip.Visible = false;
    }

    #endregion

    /*\
     * ##     ##                               #######
     * ###   ###                               ##
     * #### ####  #####  #######  ##    ##     ##
     * ## ### ## ##   ## ##    ## ##    ##     #####
     * ##     ## ####### ##    ## ##    ##     ##
     * ##     ## ##      ##    ## ##    ##     ##      ###
     * ##     ##  #####  ##    ##  ######      ##      ###
     * ===================================================
    \*/
    #region Menu File Events

    private void mainMenu_ToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
    {
      UpdateMenusEnabled();
    }

    private void mainMenu_ToolStripMenuItem_NewProjectRMXP_Click(object sender, EventArgs e)
    {
      using (NewProjectForm dialog = new NewProjectForm("RMXP"))
        if (dialog.ShowDialog() == DialogResult.OK)
          CreateProject("RMXP", dialog.GameTitle, dialog.ProjectDirectory, dialog.IncludeLibrary, dialog.OpenProject);
    }

    private void mainMenu_ToolStripMenuItem_NewProjectRMVX_Click(object sender, EventArgs e)
    {
      using (NewProjectForm dialog = new NewProjectForm("RMVX"))
        if (dialog.ShowDialog() == DialogResult.OK)
          CreateProject("RMVX", dialog.GameTitle, dialog.ProjectDirectory, dialog.IncludeLibrary, dialog.OpenProject);
    }

    private void mainMenu_ToolStripMenuItem_NewProjectRMVXAce_Click(object sender, EventArgs e)
    {
      using (NewProjectForm dialog = new NewProjectForm("RMVXAce"))
        if (dialog.ShowDialog() == DialogResult.OK)
          CreateProject("RMVXAce", dialog.GameTitle, dialog.ProjectDirectory, dialog.IncludeLibrary, dialog.OpenProject);
    }

    /// <summary>
    /// Starts open dialog for opening RMXP/RMVX project files
    /// </summary>
    private void mainMenu_ToolStripMenuItem_OpenProject_Click(object sender, EventArgs e)
    {
      using (OpenFileDialog dialog = new OpenFileDialog())
      {
        dialog.Filter = "RPG Makers Projects & Scripts|*.rxproj;*.rvproj;*.rvproj2;*.rxdata;*.rvdata;*.rvdata2|" +
                            "RMXP Project|*.rxproj|RMVX Project|*.rvproj|RMVXAce Project|*.rvproj2|" +
                            "RMXP Script|*.rxdata|RMVX Script|*.rvdata|RMVXAce Script|*.rvdata2|" +
                            "All Documents|*.*";
        dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        dialog.Title = "Open Game Project...";
        if (dialog.ShowDialog() == DialogResult.OK)
          OpenProject(dialog.FileName);
      }
    }

    /// <summary>
    /// Opens the selected recent document after ensuring it still exists
    /// </summary>
    private void mainMenu_ToolStripMenuItem_OpenRecentProject_Click(object sender, EventArgs e)
    {
      OpenRecentProject(menuMain_dropFile_itemOpenRecent.DropDownItems.IndexOf((ToolStripItem)sender), true);
    }

    private void mainMenu_ToolStripMenuItem_CloseProject_Click(object sender, EventArgs e)
    {
      CloseProject(true);
    }

    /// <summary>
    /// Updates the text of each script, then Marshals it using Ruby
    /// </summary>
    private void mainMenu_ToolStripMenuItem_SaveProject_Click(object sender, EventArgs e)
    {
      SaveScripts();
    }

    private void menuMain_dropFile_itemImportScripts_Click(object sender, EventArgs e)
    {
      ImportScriptsFrom(scriptsView.SelectedNode, false, Directory.GetFiles(_projectScriptsFolderPath));
    }

    /// <summary>
    /// Imports an existing text document or .rb file into the editor, adding it to the Scipt list
    /// </summary>
    private void menuMain_dropFile_itemImportScriptsFrom_Click(object sender, EventArgs e)
    {
      using (OpenFileDialog dialog = new OpenFileDialog())
      {
        dialog.Filter = "Ruby Script|*.rb|Text Document|*.txt|All Documents|*.*";
        dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        dialog.Title = "Import Scripts...";
        dialog.Multiselect = true;
        DialogResult result = dialog.ShowDialog();
        if (result == DialogResult.OK)
          ImportScriptsFrom(scriptsView.SelectedNode, true, dialog.FileNames);
      }
    }

    private void menuMain_dropFile_itemExport_Click(object sender, EventArgs e)
    {
      ExportScripts();
    }

    private void mainMenu_ToolStripMenuItem_ExportScriptsRMData_Click(object sender, EventArgs e)
    {
      using (SaveFileDialog dialog = new SaveFileDialog())
      {
        dialog.FileName = Path.GetFileName(_projectScriptPath);
        dialog.Filter = _projectEngine + " Scripts|*" + Path.GetExtension(_projectScriptPath) + "|All Documents|*.*";
        dialog.InitialDirectory = _projectDirectory;
        dialog.Title = "Export Scripts...";
        if (dialog.ShowDialog() == DialogResult.OK)
          SaveScripts(dialog.FileName);
      }
    }

    /// <summary>
    /// Exports the scripts with a .txt extension
    /// </summary>
    private void mainMenu_ToolStripMenuItem_ExportScriptsText_Click(object sender, EventArgs e)
    {
      ExportScriptsTo(".txt");
    }

    /// <summary>
    /// Exports the scripts with an .rb extension
    /// </summary>
    private void mainMenu_ToolStripMenuItem_ExportScriptsRuby_Click(object sender, EventArgs e)
    {
      ExportScriptsTo(".rb");
    }

    private void mainMenu_ToolStripMenuItem_SaveSettings_Click(object sender, EventArgs e)
    {
      SaveConfiguration(true);
    }

    /// <summary>
    /// Toggles auto-save of configuration when the program exits
    /// </summary>
    private void mainMenu_ToolStripMenuItem_AutoSaveSettings_Click(object sender, EventArgs e)
    {
      Settings.AutoSaveConfig = !Settings.AutoSaveConfig;
      UpdateSettingsState();
      menuMain_dropFile.ShowDropDown();
      menuMain_dropSettings_itemSaveSettings.ShowDropDown();
      menuMain_dropSettings_itemAutoSaveSettings.Select();
    }

    /// <summary>
    /// Load default settings.
    /// </summary>
    private void mainMenu_ToolStripMenuItem_DeleteSettings_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Are you sure you want to delete all settings?",
          "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
        return;
      Settings.SetDefaults();
      ApplySettings();
    }

    /// <summary>
    /// Exits the application
    /// </summary>
    private void mainMenu_ToolStripMenuItem_Exit_Click(object sender, EventArgs e)
    {
      Close();
    }

    #endregion

    /*\
     * ##     ##                               #######
     * ###   ###                               ##
     * #### ####  #####  #######  ##    ##     ##
     * ## ### ## ##   ## ##    ## ##    ##     #####
     * ##     ## ####### ##    ## ##    ##     ##
     * ##     ## ##      ##    ## ##    ##     ##      ###
     * ##     ##  #####  ##    ##  ######      ####### ###
     * ===================================================
    \*/
    #region Menu Edit Events

    private void mainMenu_ToolStripMenuItem_Undo_Click(object sender, EventArgs e)
    {
      Script script = GetActiveScript();
      if (script != null)
        script.Scintilla.Commands.Execute(BindableCommand.Undo);
    }

    private void mainMenu_ToolStripMenuItem_Redo_Click(object sender, EventArgs e)
    {
      Script script = GetActiveScript();
      if (script != null)
        script.Scintilla.Commands.Execute(BindableCommand.Redo);
    }

    private void mainMenu_ToolStripMenuItem_Cut_Click(object sender, EventArgs e)
    {
      Script script = GetActiveScript();
      if (script != null)
        script.Scintilla.Commands.Execute(BindableCommand.Cut);
    }

    private void mainMenu_ToolStripMenuItem_Copy_Click(object sender, EventArgs e)
    {
      Script script = GetActiveScript();
      if (script != null)
        script.Scintilla.Commands.Execute(BindableCommand.Copy);
    }

    private void mainMenu_ToolStripMenuItem_Paste_Click(object sender, EventArgs e)
    {
      Script script = GetActiveScript();
      if (script != null)
        script.Scintilla.Commands.Execute(BindableCommand.Paste);
    }

    private void mainMenu_ToolStripMenuItem_Delete_Click(object sender, EventArgs e)
    {
      Script script = GetActiveScript();
      if (script != null)
        script.Scintilla.Commands.Execute(BindableCommand.DeleteBack);
    }

    private void mainMenu_ToolStripMenuItem_SelectAll_Click(object sender, EventArgs e)
    {
      Script script = GetActiveScript();
      if (script != null)
        script.Scintilla.Commands.Execute(BindableCommand.SelectAll);
    }

    /// <summary>
    /// Opens the quick-find dialog
    /// </summary>
    private void mainMenu_ToolStripMenuItem_IncrementalSearch_Click(object sender, EventArgs e)
    {
      Script script = GetActiveScript();
      if (script != null)
      {
        script.Scintilla.Commands.Execute(BindableCommand.IncrementalSearch);
        Point p = script.Scintilla.PointToClient(MousePosition);
        if (script.Scintilla.Bounds.Contains(p))
          script.Scintilla.FindReplace.IncrementalSearcher.Location = p;
      }
    }

    /// <summary>
    /// Opens the find/replace dialog with the Find tab selected
    /// </summary>
    private void mainMenu_ToolStripMenuItem_Find_Click(object sender, EventArgs e)
    {
      ShowFind();
    }

    /// <summary>
    /// Opens the find/replace dialog with the Replace tab selected
    /// </summary>
    private void mainMenu_ToolStripMenuItem_Replace_Click(object sender, EventArgs e)
    {
      ShowReplace();
    }

    /// <summary>
    /// Opens the dialog for the "goto line"
    /// </summary>
    private void mainMenu_ToolStripMenuItem_GoToLine_Click(object sender, EventArgs e)
    {
      Script script = GetActiveScript();
      if (script != null)
        script.Scintilla.Commands.Execute(BindableCommand.ShowGoTo);
    }

    private void mainMenu_ToolStripMenuItem_ToggleComment_Click(object sender, EventArgs e)
    {
      Script script = GetActiveScript();
      if (script != null)
        script.Scintilla.Commands.Execute(BindableCommand.ToggleLineComment);
    }

    /// <summary>
    /// Batch comments all selected lines
    /// </summary>
    private void mainMenu_ToolStripMenuItem_Comment_Click(object sender, EventArgs e)
    {
      Script script = GetActiveScript();
      if (script != null)
        script.Scintilla.Commands.Execute(BindableCommand.LineComment);
    }

    /// <summary>
    /// Batch uncomments all selected lines
    /// </summary>
    private void mainMenu_ToolStripMenuItem_UnComment_Click(object sender, EventArgs e)
    {
      Script script = GetActiveScript();
      if (script != null)
        script.Scintilla.Commands.Execute(BindableCommand.LineUncomment);
    }

    /// <summary>
    /// Initiates the function to apply the proper structuring to the open script
    /// </summary>
    private void mainMenu_ToolStripMenuItem_StructureScriptCurrent_Click(object sender, EventArgs e)
    {
      Script script = GetActiveScript();
      if (script != null)
        script.StructureScript();
    }

    /// <summary>
    /// Applies the restructuring to all scripts that are opened currently
    /// </summary>
    private void mainMenu_ToolStripMenuItem_StructureScriptOpen_Click(object sender, EventArgs e)
    {
      Enabled = false;
      foreach (Script script in _scripts)
        if (script.Opened)
          script.StructureScript();
      Enabled = true;
    }

    /// <summary>
    /// Applies the restructuring to all scripts
    /// </summary>
    private void mainMenu_ToolStripMenuItem_StructureScriptAll_Click(object sender, EventArgs e)
    {
      Enabled = false;
      foreach (Script script in _scripts)
        script.StructureScript();
      UpdateNames();
      Enabled = true;
    }

    private void mainMenu_ToolStripMenuItem_RemoveEmptyLinesCurrent_Click(object sender, EventArgs e)
    {
      Script script = GetActiveScript();
      if (script != null)
        script.RemoveEmptyLines();
    }

    private void mainMenu_ToolStripMenuItem_RemoveEmptyLinesOpen_Click(object sender, EventArgs e)
    {
      Enabled = false;
      foreach (Script script in _scripts)
        if (script.Opened)
          script.RemoveEmptyLines();
      Enabled = true;
    }

    private void mainMenu_ToolStripMenuItem_RemoveEmptyLinesAll_Click(object sender, EventArgs e)
    {
      Enabled = false;
      foreach (Script script in _scripts)
        script.RemoveEmptyLines();
      UpdateNames();
      Enabled = true;
    }

    #endregion

    /*\
     * ##     ##                                ######
     * ###   ###                               ##
     * #### ####  #####  #######  ##    ##     ##
     * ## ### ## ##   ## ##    ## ##    ##      ######
     * ##     ## ####### ##    ## ##    ##           ##
     * ##     ## ##      ##    ## ##    ##           ## ###
     * ##     ##  #####  ##    ##  ######      #######  ###
     * ====================================================
    \*/
    #region Menu Settings Events

    private void menuMain_dropSettings_itemProjectSettings_Click(object sender, EventArgs e)
    {
      if (Settings.ProjectConfig)
      {
        DialogResult result = MessageBox.Show("Do you want to save the local configuration now?", "Save configuration?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (result == DialogResult.Yes)
          SaveLocalConfiguration();
      }
      else if (File.Exists(_projectDirectory + "GeminiLocal.xml"))
      {
        DialogResult result = MessageBox.Show("There was found a configuration in the project folder, do you want to load it now?", "Load configuration?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        if (result == DialogResult.Yes)
          LoadLocalConfiguration();
      }
      Settings.ProjectConfig = !Settings.ProjectConfig;
      UpdateSettingsState();
      menuMain_dropSettings.ShowDropDown();
      menuMain_dropSettings_itemConfiguration.ShowDropDown();
      menuMain_dropSettings_itemProjectSettings.Select();
    }

    private void menuMain_dropSetting_itemAutoHideMenuBar_Click(object sender, EventArgs e)
    {
      Settings.AutoHideMenuBar = !Settings.AutoHideMenuBar;
      if (Settings.AutoHideMenuBar && menuMain_menuStrip.Visible) MenuBarDeactivate();
      else MenuBarActive();
      UpdateSettingsState();
    }

    private void menuMain_dropSettings_itemHideToolbar_Click(object sender, EventArgs e)
    {
      Settings.DistractionMode = new Serializable.DistracionMode(Settings.DistractionMode.Use, !Settings.DistractionMode.HideToolbar);
      UpdateSettingsState();
    }

    private void menuMain_dropSettings_itemPioritizeRecent_Click(object sender, EventArgs e)
    {
      Settings.RecentPriority = !Settings.RecentPriority;
      if (sender == menuMain_dropSettings_itemPioritizeRecent)
      {
        menuMain_dropSettings.ShowDropDown();
        autoOpenToolStripMenuItem.ShowDropDown();
        menuMain_dropSettings_itemPioritizeRecent.Select();
      }
      UpdateSettingsState();
    }

    private void menuMain_dropSettings_itemAutoOpenProject_Click(object sender, EventArgs e)
    {
      Settings.AutoOpen = !Settings.AutoOpen;
      UpdateSettingsState();
      menuMain_dropSettings.ShowDropDown();
      autoOpenToolStripMenuItem.Select();
    }

    private void menuMain_dropGame_itemCustomRuntime_Click(object sender, EventArgs e)
    {
      using (RunVarsForm dialog = new RunVarsForm())
        if (dialog.ShowDialog() == DialogResult.OK)
        {
          Settings.RuntimeExecutable = dialog.Executable;
          Settings.RuntimeArguments = dialog.Arguments;
        }
    }

    private void menuMain_dropSettings_itemToggleDistractionMode_Click(object sender, EventArgs e)
    {
      Settings.DistractionMode = new Serializable.DistracionMode(!Settings.DistractionMode.Use, Settings.DistractionMode.HideToolbar);
      UpdateSettingsState();
    }

    /// <summary>
    /// Displays the style editor dialog
    /// </summary>
    private void menuMain_dropSettings_itemStylesConfig_Click(object sender, EventArgs e)
    {
      using (StyleEditorForm dialog = new StyleEditorForm())
        if (dialog.ShowDialog() == DialogResult.OK)
        {
          Settings.ScriptStyles = dialog.Styles;
          foreach (Script script in _scripts)
            script.SetStyle();
        }
    }

    /// <summary>
    /// Calls the dialog for configuring the autocomplete function
    /// </summary>
    private void mainMenu_ToolStripMenuItem_AutoCompleteConfig_Click(object sender, EventArgs e)
    {
      using (AutoCompleteForm dialog = new AutoCompleteForm())
        if (dialog.ShowDialog() == DialogResult.OK)
        {
          Settings.AutoCompleteLength = (int)dialog.numericUpDownCharacters.Value;
          Settings.AutoCompleteCustomWords = dialog.textBoxList.Text;
          Settings.AutoCompleteFlag = 0;
          for (int i = 0; i < dialog.checkedListBoxGroups.Items.Count; i++)
            if (dialog.checkedListBoxGroups.GetItemChecked(i))
              Settings.AutoCompleteFlag |= 1 << i;
          UpdateAutoCompleteWords();
        }
    }

    /// <summary>
    /// Toggles auto-complete on/off
    /// </summary>
    private void mainMenu_ToolStripMenuItem_AutoComplete_Click(object sender, EventArgs e)
    {
      Settings.AutoComplete = !Settings.AutoComplete;
      UpdateSettingsState();
      if (Settings.AutoComplete && Settings.AutoCompleteFlag == 0)
      {
        DialogResult result = MessageBox.Show("Auto-complete word list is empty, would you like to configure it now?",
          "Configuration Required", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        if (result == DialogResult.Yes)
          mainMenu_ToolStripMenuItem_AutoCompleteConfig_Click(sender, e);
      }
      else if (sender == menuMain_dropSettings_itemAutoC)
      {
        menuMain_dropSettings.ShowDropDown();
        menuMain_dropSettings_itemAutoC.Select();
      }
    }

    /// <summary>
    /// Toggles the guide-lines on/off
    /// </summary>
    private void mainMenu_ToolStripMenuItem_IndentGuides_Click(object sender, EventArgs e)
    {
      Settings.GuideLines = !Settings.GuideLines;
      UpdateSettingsState();
      foreach (Script script in _scripts)
        script.UpdateSettings();
      if (sender == menuMain_dropSettings_itemIndentGuides)
      {
        menuMain_dropSettings.ShowDropDown();
        menuMain_dropSettings_itemIndentGuides.Select();
      }
    }

    /// <summary>
    /// Toggles auto-indenting on/off
    /// </summary>
    private void mainMenu_ToolStripMenuItem_AutoIndent_Click(object sender, EventArgs e)
    {
      Settings.AutoIndent = !Settings.AutoIndent;
      UpdateSettingsState();
      foreach (Script script in _scripts)
        script.UpdateSettings();
      if (sender == menuMain_dropSettings_itemAutoIndent)
      {
        menuMain_dropSettings.ShowDropDown();
        menuMain_dropSettings_itemAutoIndent.Select();
      }
    }

    /// <summary>
    /// Toggles the line highlighter on/off
    /// </summary>
    private void mainMenu_ToolStripMenuItem_LineHighlight_Click(object sender, EventArgs e)
    {
      Settings.LineHighLight = !Settings.LineHighLight;
      UpdateSettingsState();
      foreach (Script script in _scripts)
        script.UpdateSettings();
      if (sender == menuMain_dropSettings_itemHighlight)
      {
        menuMain_dropSettings.ShowDropDown();
        menuMain_dropSettings_itemHighlight.Select();
      }
    }

    /// <summary>
    /// Opens the dialog for changing the color/opacity of the line highlighter
    /// </summary>
    private void mainMenu_ToolStripMenuItem_HighlightColor_Click(object sender, EventArgs e)
    {
      using (ColorChooserForm dialog = new ColorChooserForm())
      {
        dialog.Color = Settings.LineHighLightColor;
        if (dialog.ShowDialog() == DialogResult.OK)
        {
          Settings.LineHighLightColor = dialog.Color;
          foreach (Script script in _scripts)
            script.UpdateSettings();
        }
      }
    }

    private void mainMenu_ToolStripMenuItem_CodeFolding_Click(object sender, EventArgs e)
    {
      Settings.CodeFolding = !Settings.CodeFolding;
      UpdateSettingsState();
      foreach (Script script in _scripts)
        script.UpdateSettings();
      if (sender == menuMain_dropSettings_itemFolding)
      {
        menuMain_dropSettings.ShowDropDown();
        menuMain_dropSettings_itemFolding.Select();
      }
    }

    private void menuMain_dropSettings_itemUpdateSections_Click(object sender, EventArgs e)
    {
      DialogResult result = MessageBox.Show("If you proceed, all scripts will be saved with new sections. Proceed?",
          "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
      if (result == DialogResult.No)
        return;
      string _text, _file;
      int i = 0;
      bool folder = _projectScriptsFolderPath != "" && Directory.Exists(_projectScriptsFolderPath);
      TreeNode node;
      List<string> files = !folder ? new List<string>() : new List<string>(Directory.GetFiles(_projectScriptsFolderPath, "*.rb", SearchOption.TopDirectoryOnly));
      scriptsView.BeginUpdate();
      foreach (Script s in _scripts)
      {
        _oldSections.Add(s.Section);
        _usedSections.Remove(s.Section);
        s.Section = GetRandomSection();
        (node = GetNodeBySection(_oldSections[i])).Name = string.Format("{0:00000000}", s.Section);
        node.ToolTipText = s.Name + " - " + string.Format("{0:00000000}", s.Section);
        if (folder)
        {
          _file = files.Find(delegate (string str)
          {
            return Regex.IsMatch(str, string.Format("{0:00000000}",
              _oldSections[i]), RegexOptions.Singleline | RegexOptions.CultureInvariant);
          });
          if (!string.IsNullOrEmpty(_file))
          {
            _text = File.ReadAllText(_file);
            File.Delete(_file);
            File.WriteAllText(_projectScriptsFolderPath + s.Name + "." + string.Format("{0:00000000}", s.Section) + ".rb", _text);
          }
        }
        i++;
      }
      scriptsView.EndUpdate();
      _oldSections.Clear();
      SaveScripts();
    }

    #endregion

    /*\
     * ##     ##                                ######
     * ###   ###                               ##    ##
     * #### ####  #####  #######  ##    ##     ##
     * ## ### ## ##   ## ##    ## ##    ##     ##  ###
     * ##     ## ####### ##    ## ##    ##     ##    ##
     * ##     ## ##      ##    ## ##    ##     ##    ## ###
     * ##     ##  #####  ##    ##  ######       ######  ###
     * ====================================================
    \*/
    #region Menu Game Events

    private void mainMenu_ToolStripMenuItem_Help_Click(object sender, EventArgs e)
    {
      string projectEngine = _projectEngine.Replace("RM", "RPG");
      if (!File.Exists(projectEngine + ".chm"))
        CopyResource("Gemini.files.help." + projectEngine + ".chm", projectEngine + ".chm");
      Help.ShowHelp(this, projectEngine + ".chm");
    }

    /// <summary>
    /// Event raised that will begin execution of the game. Runs in test mode and auto-saves if configured to do so.
    /// </summary>
    private void menuMain_dropGame_itemRun_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(_projectScriptsFolderPath))
      {
        MessageBox.Show("You cannot test the game when editing a '.r*data' file.\nTo do so you must open the project's '.r*proj' file.",
            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }
      if (NeedSave())
      {
        DialogResult result = MessageBox.Show("Save changes before running?",
          "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        if (result == DialogResult.Cancel) return;
        else if (result == DialogResult.Yes)
          SaveScripts();
      }
      string arguments = "";
      if (!Settings.DebugMode) arguments = "";
      else if (!string.IsNullOrEmpty(Settings.RuntimeArguments)) arguments = Settings.RuntimeArguments;
      else if (_projectEngine == "RMXP") arguments = "debug";
      else if (_projectEngine == "RMVX") arguments = "test";
      else if (_projectEngine == "RMVXAce") arguments = "console test";
      try { Process.Start(_projectDirectory + Settings.RuntimeExecutable, arguments); }
      catch { MessageBox.Show("Cannot run game.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
    }

    private void mainMenu_ToolStripMenuItem_Debug_Click(object sender, EventArgs e)
    {
      Settings.DebugMode = !Settings.DebugMode;
      UpdateSettingsState();
      if (sender == menuMain_dropGame_itemDebug)
      {
        menuMain_dropGame.ShowDropDown();
        menuMain_dropGame_itemDebug.Select();
      }
    }

    private void mainMenu_ToolStripMenuItem_ProjectFolder_Click(object sender, EventArgs e)
    {
      if (_projectDirectory == "") return;
      Process.Start(_projectDirectory);
    }

    #endregion

    /*\
     * ##     ##                                  ###
     * ###   ###                                 ## ##
     * #### ####  #####  #######  ##    ##      ##   ##
     * ## ### ## ##   ## ##    ## ##    ##     ##     ##
     * ##     ## ####### ##    ## ##    ##     #########
     * ##     ## ##      ##    ## ##    ##     ##     ## ###
     * ##     ##  #####  ##    ##  ######      ##     ## ###
     * =====================================================
    \*/
    #region Menu About Events

    private void mainMenu_ToolStripMenuItem_VersionHistory_Click(object sender, EventArgs e)
    {
      Process.Start("https://github.com/revam/Gemini/blob/master/CHANGELOG.md");
    }

    private void mainMenu_ToolStripMenuItem_AboutGemini_Click(object sender, EventArgs e)
    {
      using (AboutForm dialog = new AboutForm())
        dialog.ShowDialog();
    }

    #endregion

    /*\
     * #######      ## ##  ##
     * ##           ##     ##
     * ##           ## ### #######  ######   ######
     * #####    ###### ##  ##      ##    ## ##    ##
     * ##      ##   ## ##  ##      ##    ## ##
     * ##      ##   ## ##  ##   ## ##    ## ##
     * #######  ###### ##   #####   ######  ##
     * ==
    \*/
    #region Script Editor Events

    /// <summary>
    /// Opens the native Character Map for creating special Unicode characters
    /// </summary>
    private void scriptsEditor_ToolStripButton_SpecialChars_Click(object sender, EventArgs e)
    {
      _charmap.StartInfo.FileName = "charmap.exe";
      try
      {
        if (!_charmap.HasExited)
        {
          SetForegroundWindow(_charmap.MainWindowHandle);
          return;
        }
      }
      catch { }
      try { _charmap.Start(); }
      catch
      {
        MessageBox.Show("\"C:/Windows/System32/charmap.exe\" could not be found on the system.",
            "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void scriptsEditor_ToolStripMenuItem_FindNext_Click(object sender, EventArgs e)
    {
      _findReplaceDialog.FindNext();
    }

    private void scriptsEditor_ToolStripMenuItem_FindPrevious_Click(object sender, EventArgs e)
    {
      _findReplaceDialog.FindPrevious();
    }

    private void scriptsEditor_ToolStripMenuItem_AddWordToAutoComplete_Click(object sender, EventArgs e)
    {
      Script script = GetActiveScript();
      if (script != null)
      {
        List<string> words = new List<string>();
        if (script.Scintilla.Selection.Length == 0)
        {
          string word = script.Scintilla.GetWordFromPosition(script.Scintilla.CurrentPos);
          if (word.Length > 1)
            words.Add(word);
        }
        else
          for (int pos = script.Scintilla.Selection.Range.Start; pos < script.Scintilla.Selection.Range.End; pos++)
          {
            string word = script.Scintilla.GetWordFromPosition(pos);
            if (word.Length > 1 && !words.Contains(word))
              words.Add(word);
          }
        if (words.Count > 0)
        {
          Settings.AutoCompleteCustomWords += " " + string.Join(" ", words);
          UpdateAutoCompleteWords();
        }
      }
    }

    private void scriptsEditor_TabControl_GotFocus(object sender, EventArgs e)
    {
      Script script = GetActiveScript();
      if (script != null)
        script.Scintilla.Focus();
    }

    /// <summary>
    /// Updates the labels accordingly with the activated script
    /// </summary>
    private void scriptsEditor_TabControl_SelectedIndexChanged(object sender, EventArgs e)
    {
      Script script = GetActiveScript();
      if (script == null)
        _findReplaceDialog.Hide();
      else
      {
        _findReplaceDialog.Scintilla = script.Scintilla;
      }
      UpdateScriptStatus();
    }

    private void scriptsEditor_TabControl_TabPageRemoving(object sender, TabControlCancelEventArgs e)
    {
      Script script = _scripts.Find(delegate (Script s) { return s.Opened && s.TabPage == e.TabPage; });
      if (script == null) return;
      if (script.NeedApplyChanges)
      {
        DialogResult result = MessageBox.Show(
            "Apply changes to this script before closing?\r\n\r\nNote: This does not save the data permanently",
            "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        if (result == DialogResult.Yes)
          script.ApplyChanges();
        else if (result == DialogResult.Cancel)
        {
          e.Cancel = true;
          return;
        }
      }
      script.Dispose();
      UpdateNames();
      UpdateMenusEnabled();
    }

    /// <summary>
    /// Enables/disables the comment controls depending on the selection, as well as the selection length label.
    /// </summary>
    private void Scintilla_Changed(object sender, EventArgs e)
    {
      UpdateScriptStatus();
      UpdateMenusEnabled();
      UpdateName(GetActiveScript());
    }

    #endregion

    /*\
     *  ######                  ##          ##           ######                                  ##
     * ##                                   ##          ##                                       ##
     * ##       ######  ######  ### ######  #######     ##       #####   #####   ######   ###### ## ####
     *  #####  ##      ##    ## ##  ##   ## ##           #####  ##   ##      ## ##    ## ##      ###   ##
     *      ## ##      ##       ##  ##   ## ##               ## #######  ###### ##       ##      ##    ##
     *      ## ##      ##       ##  ######  ##   ##          ## ##      ##   ## ##       ##      ##    ##
     * ######   ###### ##       ##  ##       #####      ######   #####  ####### ##        ###### ##    ##
     * ==================================================================================================
    \*/
    #region Script Search Events

    private void searches_ToolStripButton_Click(object sender, EventArgs e)
    {
      Search((SearchControl)((ToolStripButton)sender).GetCurrentParent().Parent);
    }

    /// <summary>
    /// Goes to the line in the script of the clicked result
    /// </summary>
    private void searches_ListView_ItemActivate(object sender, EventArgs e)
    {
      SearchResult result = (SearchResult)((ListView)sender).SelectedItems[0];
      if (ScriptExistBySection(result.Section))
      {
        OpenScript(result.Section);
        GetScriptBySection(result.Section).Scintilla.GoTo.Line(result.Line);
      }
    }

    private void searches_TabControl_ControlRemoved(object sender, ControlEventArgs e)
    {
      if (searches_TabControl.TabCount == 1)
        splitView.Panel2Collapsed = true;
    }

    #endregion

    /*\
     * ##     ## ##
     * ##     ##
     * ##     ## ###  #####  ##       ##
     * ##     ## ##  ##   ## ##       ##
     *  ##   ##  ##  ####### ##   #   ##
     *   ## ##   ##  ##       ## ### ##
     *    ###    ##   #####    ### ###
     * =================================
    \*/
    #region Scripts View Events

    private void scriptsView_MouseDown(object sender, MouseEventArgs e)
    {
      if (scriptsView.SelectedNode != null && e.Button == MouseButtons.Left && e.Clicks == 2 && scriptsView.SelectedNode.Level == 1)
        scriptsView_itemOpen_Click(sender, e);
    }

    private void scriptsView_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter) scriptsView_itemOpen_Click(sender, e);
      else if (e.KeyCode == Keys.Delete) scriptsView_contextMenu_itemDelete_Click(sender, e);
    }

    private void scriptsView_AfterSelect(object sender, TreeViewEventArgs e)
    {
      _updatingText = true;
      scriptName.Text = e.Node.Text;
      _updatingText = false;
      UpdateMenusEnabled();
    }

    /// <summary>
    /// Either opens a new page of the selected script, or selects the appropriate tab if it is already open.
    /// </summary>
    private void scriptsView_itemOpen_Click(object sender, EventArgs e)
    {
      if (scriptsView.SelectedNode == null) return;
      if (scriptsView.SelectedNode.Level == 0)
      {
        if (scriptsView.SelectedNode.Nodes.Count > 5)
        {
          DialogResult result = MessageBox.Show("Do you want to open all the scripts in this group? (" +
            scriptsView.SelectedNode.Nodes.Count + ")", "Warning; Proceed?", MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);
          if (result == DialogResult.No) return;
        }
        foreach (TreeNode node in scriptsView.SelectedNode.Nodes)
          OpenScript(int.Parse(node.Name));
      }
      else
        OpenScript(int.Parse(scriptsView.SelectedNode.Name));
    }

    /// <summary>
    /// Inserts a new Script control at index
    /// </summary>
    private void scriptsView_contextMenu_itemInsert_Click(object sender, EventArgs e)
    {
      using (InsertForm dialog = new InsertForm())
        if (dialog.ShowDialog() == DialogResult.OK)
          if (dialog.AddNew)
            InsertNode(scriptsView.SelectedNode, true, dialog.Title, "");
          else
            ImportScriptsFrom(scriptsView.SelectedNode, true, dialog.Paths);
    }

    /// <summary>
    /// Removes currently selected script from list, and copies to clipboard
    /// </summary>
    private void scriptsView_contextMenu_itemCut_Click(object sender, EventArgs e)
    {
      scriptsView_contextMenu_itemCopy_Click(sender, e);
      scriptsView_contextMenu_itemDelete_Click(sender, e);
    }

    /// <summary>
    /// Copies selected script to the clipboard
    /// </summary>
    private void scriptsView_contextMenu_itemCopy_Click(object sender, EventArgs e)
    {
      int section = int.Parse(scriptsView.SelectedNode.Name);
      if (section >= 0)
      {
        SetClipboardScript(GetScriptBySection(section));
        UpdateMenusEnabled();
      }
    }

    /// <summary>
    /// Paste the script from the clipboard to the selected index
    /// </summary>
    private void scriptsView_contextMenu_itemPaste_Click(object sender, EventArgs e)
    {
      RubyArray rmScript = GetClipboardScript();
      if (rmScript != null)
        InsertNode(scriptsView.SelectedNode, true, rmScript);
    }

    /// <summary>
    /// Deletes the currently selectefd script
    /// </summary>
    private void scriptsView_contextMenu_itemDelete_Click(object sender, EventArgs e)
    {
      TreeNode node = scriptsView.SelectedNode;
      if (node.Level == 0)
      {
        if (node.Nodes.Count > 0)
        {
          DialogResult result = MessageBox.Show(
            "Are you sure you want to delete this Script Group?",
            "Warning; Prossed?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
          if (result == DialogResult.No) return;
        }
        DeleteNodeGroup(node);
      }
      else
        DeleteNode(node.Name);
    }

    /// <summary>
    /// Exports the currently selected script
    /// </summary>
    private void scriptsView_contextMenu_itemExport_Click(object sender, EventArgs e)
    {
      TreeNode node = scriptsView.SelectedNode;
      if (node.Level == 0)
        ExportScriptGroup(node);
      else
        ExportScript(int.Parse(node.Name));
    }

    /// <summary>
    /// Moves selected scripts order up one in the list
    /// </summary>
    private void scriptsView_contextMenu_itemMoveUp_Click(object sender, EventArgs e)
    {
      TreeNode node = scriptsView.SelectedNode;
      int index = node.Index;
      scriptsView.BeginUpdate();
      if (node.Level == 0 && index > 0)
      {
        scriptsView.Nodes.RemoveAt(index);
        scriptsView.Nodes.Insert(index - 1, node);
        scriptsView.SelectedNode = scriptsView.Nodes[index - 1];
      }
      else if (node.Level == 1)
      {
        int pIndex = node.Parent.Index;
        if (index == 0 && pIndex > 0)
        {
          scriptsView.Nodes[pIndex].Nodes.RemoveAt(index);
          scriptsView.Nodes[pIndex - 1].Nodes.Add(node);
          scriptsView.SelectedNode = scriptsView.Nodes[pIndex - 1].LastNode;
        }
        else if (index > 0)
        {
          scriptsView.Nodes[pIndex].Nodes.RemoveAt(index);
          scriptsView.Nodes[pIndex].Nodes.Insert(index - 1, node);
          scriptsView.SelectedNode = scriptsView.Nodes[pIndex].Nodes[index - 1];
        }
      }
      else { scriptsView.EndUpdate(); return; }
      _projectNeedSave = true;
      UpdateNames();
      scriptsView.EndUpdate();
    }

    /// <summary>
    /// Moves selected scripts order down one in the list
    /// </summary>
    private void scriptsView_contextMenu_itemMoveDown_Click(object sender, EventArgs e)
    {
      TreeNode node = scriptsView.SelectedNode;
      int index = scriptsView.SelectedNode.Index;
      scriptsView.BeginUpdate();
      if (node.Level == 0 && index >= 0 && index < scriptsView.Nodes.Count - 1)
      {
        scriptsView.Nodes.RemoveAt(index);
        scriptsView.Nodes.Insert(index + 1, node);
        scriptsView.SelectedNode = scriptsView.Nodes[index + 1];
      }
      else if (node.Level == 1)
      {
        int pIndex = scriptsView.SelectedNode.Parent.Index;
        if (index == scriptsView.Nodes[pIndex].Nodes.Count - 1 && pIndex < scriptsView.Nodes.Count - 1)
        {
          scriptsView.Nodes[pIndex].Nodes.RemoveAt(index);
          scriptsView.Nodes[pIndex + 1].Nodes.Insert(0, node);
          scriptsView.SelectedNode = scriptsView.Nodes[pIndex + 1].FirstNode;
        }
        else if (index >= 0 && index < scriptsView.Nodes[pIndex].Nodes.Count - 1)
        {
          scriptsView.Nodes[pIndex].Nodes.RemoveAt(index);
          scriptsView.Nodes[pIndex].Nodes.Insert(index + 1, node);
          scriptsView.SelectedNode = scriptsView.Nodes[pIndex].Nodes[index + 1];

        }
      }
      else { scriptsView.EndUpdate(); return; }
      _projectNeedSave = true;
      UpdateNames();
      scriptsView.EndUpdate();
    }

    /// <summary>
    /// Creates/Focuses the search form for the scripts
    /// </summary>
    private void scriptsView_contextMenu_itemBatchSearch_Click(object sender, EventArgs e)
    {
      ShowSearch();
    }

    /// <summary>
    /// Applies name change to all open documents and script title when text is changed
    /// </summary>
    private void scriptName_TextChanged(object sender, EventArgs e)
    {
      if (_updatingText) return;
      scriptName.Text = _invalidRegex.Replace(scriptName.Text, "");
      scriptName.Select(scriptName.Text.Length, 0);
      int section = int.Parse(scriptsView.SelectedNode.Name);
      if (section >= 0 && (scriptsView.SelectedNode.Level == 0 ?
        GetNodeBySection(section).Text : GetScriptBySection(section).Name) != scriptName.Text)
      {
        Script s;
        if (scriptsView.SelectedNode.Level == 0)
          scriptsView.SelectedNode.Text = scriptName.Text;
        else if ((s = GetScriptBySection(section)) != null)
        {
          s.Name = scriptName.Text;
          UpdateName(s);
        }
        _projectNeedSave = true;
      }
    }

    #endregion

    /*\
     * ######                     ##                 ##
     * ##   ##                                       ##
     * ##   ##  ######   ######  ###  #####   ###### #######
     * ######  ##    ## ##    ##  ## ##   ## ##      ##
     * ##      ##       ##    ##  ## ####### ##      ##
     * ##      ##       ##    ##  ## ##      ##      ##   ##
     * ##      ##        ######   ##  #####   ######  #####
     * ==========================##=========================
    \*/
    #region Project Methods

    private void CreateProject(string engine, string title, string directory, bool library, bool open)
    {
      try
      {
        directory += @"\";
        if (engine == "RMXP")
        {
          foreach (string dir in Properties.Resources.RMXP_Directories.Split(' '))
            Directory.CreateDirectory(directory + dir);
          string data = "Gemini.files.RMXP.Data.";
          foreach (string resource in Assembly.GetExecutingAssembly().GetManifestResourceNames())
            if (resource.StartsWith(data))
              CopyResource(resource, directory + @"Data\" + resource.Remove(0, data.Length));
          CopyResource("Gemini.files.RMXP.Game.exe", directory + "Game.exe");
          if (library)
            CopyResource("Gemini.files.RMXP.RGSS104E.dll", directory + "RGSS104E.dll");
          File.WriteAllText(directory + "Game.ini", "[Game]\r\nRTP1=Standard\r\nLibrary=RGSS104E.dll\r\nScripts=Data\\Scripts.rxdata\r\nTitle=" + title);
          File.WriteAllText(directory + "Game.rxproj", "RPGXP 1.04");
          if (open)
            OpenProject(directory + "Game.rxproj");
        }
        else if (engine == "RMVX")
        {
          foreach (string dir in Properties.Resources.RMVX_Directories.Split(' '))
            Directory.CreateDirectory(directory + dir);
          string data = "Gemini.files.RMVX.Data.";
          foreach (string resource in Assembly.GetExecutingAssembly().GetManifestResourceNames())
            if (resource.StartsWith(data))
              CopyResource(resource, directory + @"Data\" + resource.Remove(0, data.Length));
          CopyResource("Gemini.files.RMVX.Game.exe", directory + "Game.exe");
          if (library)
            CopyResource("Gemini.files.RMVX.RGSS202E.dll", directory + "RGSS202E.dll");
          File.WriteAllText(directory + "Game.ini", "[Game]\r\nRTP=RPGVX\r\nLibrary=RGSS202E.dll\r\nScripts=Data\\Scripts.rvdata\r\nTitle=" + title);
          File.WriteAllText(directory + "Game.rvproj", "RPGVX 1.00");
          if (open)
            OpenProject(directory + "Game.rvproj");
        }
        else if (engine == "RMVXAce")
        {
          foreach (string dir in Properties.Resources.RMVXAce_Directories.Split(' '))
            Directory.CreateDirectory(directory + dir);
          string data = "Gemini.files.RMVXAce.Data.";
          foreach (string resource in Assembly.GetExecutingAssembly().GetManifestResourceNames())
            if (resource.StartsWith(data))
              CopyResource(resource, directory + @"Data\" + resource.Remove(0, data.Length));
          CopyResource("Gemini.files.RMVXAce.Game.exe", directory + "Game.exe");
          if (library)
            CopyResource("Gemini.files.RMVXAce.RGSS301.dll", directory + @"System\RGSS301.dll");
          File.WriteAllText(directory + "Game.ini", "[Game]\r\nRTP=RPGVXAce\r\nLibrary=System\\RGSS301.dll\r\nScripts=Data\\Scripts.rvdata2\r\nTitle=" + title);
          File.WriteAllText(directory + "Game.rvproj2", "RPGVXAce 1.02");
          if (open)
            OpenProject(directory + "Game.rvproj2");
        }
      }
      catch
      {
        MessageBox.Show("Failed to create new project.\nPlease make sure that you have sufficient privileges to create files at the specified directory.",
            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void OpenProject(string projectPath)
    {
      if (!CloseProject(true)) return;
      _projectDirectory = Path.GetDirectoryName(projectPath) + @"\";
      switch (Path.GetExtension(projectPath))
      {
        case ".rxproj":
          _projectEngine = "RMXP";
          _projectScriptPath = GetScriptsPath();
          _projectScriptsFolderPath = _projectDirectory + @"Scripts\";
          break;
        case ".rvproj":
          _projectEngine = "RMVX";
          _projectScriptPath = GetScriptsPath();
          _projectScriptsFolderPath = _projectDirectory + @"Scripts\";
          break;
        case ".rvproj2":
          _projectEngine = "RMVXAce";
          _projectScriptPath = GetScriptsPath();
          _projectScriptsFolderPath = _projectDirectory + @"Scripts\";
          break;
        case ".rxdata":
          _projectEngine = "RMXP";
          _projectScriptPath = projectPath;
          break;
        case ".rvdata":
          _projectEngine = "RMVX";
          _projectScriptPath = projectPath;
          break;
        case ".rvdata2":
          _projectEngine = "RMVXAce";
          _projectScriptPath = projectPath;
          break;
      }
      Enabled = false;
      if (LoadScripts())
      {
        LoadLocalConfiguration();
        AddRecentProject(projectPath);
        UpdateTitle(projectPath);
        UpdateMenusEnabled();
        UpdateSettingsState();
        UpdateAutoCompleteWords();
        scriptName.TextChanged += new EventHandler(scriptName_TextChanged);
      }
      else
        CloseProject(false);
      Enabled = true;
    }

    private void OpenRecentProject(int id, bool showErrorMessage)
    {
      if (id < 0 || id >= Settings.RecentlyOpened.Count) return;
      string path = Settings.RecentlyOpened[id];
      if (File.Exists(path))
        OpenProject(path);
      else
      {
        if (showErrorMessage)
          MessageBox.Show("File no longer exists and will be removed from the list.",
              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        Settings.RecentlyOpened.RemoveAt(id);
        UpdateRecentProjectList();
      }
    }

    /// <summary>
    /// Adds an entry to the recent file lists, ensuring there are no duplicates
    /// </summary>
    /// <param name="projectPath">The path of the file to add</param>
    /// <param name="ext">The extension of the file, which determines the icon</param>
    private void AddRecentProject(string path)
    {
      if (Settings.RecentlyOpened.Contains(path))
        Settings.RecentlyOpened.Remove(path);
      else if (Settings.RecentlyOpened.Count > 8)
        Settings.RecentlyOpened.RemoveAt(8);
      Settings.RecentlyOpened.Insert(0, path);
      UpdateRecentProjectList();
    }

    private bool CloseProject(bool showSaveMessage)
    {
      if (showSaveMessage && NeedSave())
      {
        DialogResult result = MessageBox.Show("Save changes before closing?",
          "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        if (result == DialogResult.Cancel)
          return false;
        else if (result == DialogResult.Yes)
          SaveScripts();
      }

      scriptName.TextChanged -= scriptName_TextChanged;
      scriptsFileWatcher.EnableRaisingEvents = false;

      SaveLocalConfiguration();

      foreach (Script script in _scripts)
        script.Dispose();
      _scripts.Clear();
      _usedSections.Clear();
      scriptsEditor_tabs.TabPages.Clear();
      scriptsView.Nodes.Clear();
      scriptName.ResetText();
      _projectDirectory = _projectScriptPath = _projectScriptsFolderPath = _projectEngine = "";
      _projectNeedSave = false;
      _projectLastSave = null;
      UpdateTitle();
      UpdateMenusEnabled();
      return true;
    }

    private bool IsProject(params string[] filenames)
    {
      foreach (string filename in filenames)
      {
        string ext = Path.GetExtension(filename);
        if (ext == ".rxproj" || ext == ".rvproj" || ext == ".rvproj2" ||
            ext == ".rxdata" || ext == ".rvdata" || ext == ".rvdata2")
          return true;
      }
      return false;
    }

    private void SaveConfiguration(bool showMessage)
    {
      try
      {
        Settings.SaveSettings();
        SaveLocalConfiguration();
        if (showMessage)
          MessageBox.Show("Configuration was successfully saved.", "Message");
      }
      catch
      {
        if (showMessage)
          MessageBox.Show("An error occurred attempting to save the configuration.\nPlease ensure that you have write access to:\n\t" +
            Application.StartupPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void SaveLocalConfiguration()
    {
      if (Settings.ProjectConfig && !string.IsNullOrEmpty(_projectScriptsFolderPath))
      {
        Script s;
        if (GetActiveScript() != null)
          Settings.ActiveScript = new Serializable.Script((s = GetActiveScript()).Section, s.Scintilla.CurrentPos);
        for (int i = 0; i < scriptsEditor_tabs.TabCount; i++)
          Settings.OpenScripts.Add(new Serializable.Script((s =
            _scripts.Find(delegate (Script t) { return t.Opened && t.TabPage == scriptsEditor_tabs.TabPages[i]; })).Section,
            s.Scintilla.CurrentPos));
        Settings.SaveLocalSettings(_projectDirectory + "GeminiLocal.xml");
      }
    }

    private void LoadLocalConfiguration()
    {
      if (Settings.ProjectConfig && !string.IsNullOrEmpty(_projectScriptsFolderPath))
      {
        Settings.SetLocalDefaults();
        Settings.LoadLocalSettings(_projectDirectory + "GeminiLocal.xml");
        if (Settings.OpenScripts.Count > 0)
          foreach (Serializable.Script s in Settings.OpenScripts)
            if (ScriptExistBySection(s.Section))
              OpenScript(s.Section, s.Position);
        if (ScriptExistBySection(Settings.ActiveScript.Section))
          scriptsEditor_tabs.SelectedTab = GetScriptBySection(Settings.ActiveScript.Section).TabPage;
        Settings.OpenScripts.Clear();
      }
    }

    #endregion

    /*\
     *  ######                  ##          ##
     * ##                                   ##
     * ##       ######  ######  ### ######  #######
     *  #####  ##      ##    ## ##  ##   ## ##
     *      ## ##      ##       ##  ##   ## ##
     *      ## ##      ##       ##  ######  ##   ##
     * ######   ###### ##       ##  ##       #####
     * =============================##===========
    \*/
    #region Script Methods

    /// <summary>
    /// Returns the currently active script
    /// </summary>
    /// <returns>The active script if there is one, else null</returns>
    private Script GetActiveScript()
    {
      return _scripts.Find(delegate (Script s) { return s.Opened && s.TabPage == scriptsEditor_tabs.SelectedTab; });
    }

    /// <summary>
    /// Ensure the file exists and is in the proper format, then loads the game's scripts
    /// </summary>
    private bool LoadScripts()
    {
      if (File.Exists(_projectScriptPath))
        try
        {
          RubyArray rmScripts = (RubyArray)Ruby.MarshalLoad(_projectLastSave = File.ReadAllBytes(_projectScriptPath));
          scriptsView.BeginUpdate();
          for (int i = 0; i < rmScripts.Count; i++)
            InsertNode(scriptsView.SelectedNode, true, rmScripts[i]);
          scriptsView.SelectedNode = scriptsView.TopNode;
          scriptsView.EndUpdate();
          _projectNeedSave = false;
          scriptsFileWatcher.Path = Path.GetDirectoryName(_projectScriptPath);
          scriptsFileWatcher.Filter = Path.GetFileName(_projectScriptPath);
          scriptsFileWatcher.EnableRaisingEvents = true;
          return true;
        }
        catch
        {
          MessageBox.Show("An error occurred when loading the scripts.\r\nPlease make sure the data is in the correct format.",
            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      else
        MessageBox.Show("Cannot locate script file\r\n" + _projectScriptPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return false;
    }

    private void SaveScripts()
    { SaveScripts(_projectScriptPath); }
    private void SaveScripts(string path)
    {
      Console.WriteLine("Starting...");
      if (_saving || path == "") return;
      _saving = true;
      Console.WriteLine("Saving...");
      bool saveCopy = path != _projectScriptPath;
      scriptsFileWatcher.EnableRaisingEvents = false;
      RubyArray data = new RubyArray();
      foreach (TreeNode rootNode in scriptsView.Nodes)
      {
        data[data.Count] = new Script(GetRandomSection(false), "", " ").RMScript;
        data[data.Count] = new Script(GetRandomSection(false), "▼ " + rootNode.Text, "").RMScript;
        foreach (TreeNode node in rootNode.Nodes)
        {
          if (!saveCopy)
          {
            GetScriptBySection(int.Parse(node.Name)).ApplyChanges();
            GetScriptBySection(int.Parse(node.Name)).NeedSave = false;
          }
          data[data.Count] = GetScriptBySection(int.Parse(node.Name)).RMScript;
        }
      }
      data[data.Count] = new Script(GetRandomSection(false), "", " ").RMScript;
      byte[] save = Ruby.MarshalDump(data);
      try
      {
        File.WriteAllBytes(path, save);
        scriptsFileWatcher.EnableRaisingEvents = true;
      }
      catch
      {
        MessageBox.Show("An error occurred attempting to save the scripts.\nPlease ensure that you have write access to:\n\t" +
            Path.GetDirectoryName(path), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      _saving = false;
      if (!saveCopy)
      {
        _projectLastSave = save;
        _projectNeedSave = false;
      }
    }

    private void DeleteScript(int section)
    {
      if (ScriptExistBySection(section))
        _scripts.Remove(GetScriptBySection(section));
    }

    /// <summary>
    /// Creates a new tab
    /// </summary>
    /// <param name="section">The script that will be loaded into the page</param>
    private void OpenScript(int section)
    {
      OpenScript(section, 0);
    }

    /// <summary>
    /// Creates a new tab
    /// </summary>
    /// <param name="section">The script that will be loaded into the page</param>
    /// <param name="position">The cursor position in the script</param>
    /// <param name="anchor">The selection anchor</param>
    private void OpenScript(int section, int position)
    {
      int index = _scripts.IndexOf(GetScriptBySection(section));
      if (!_scripts[index].Opened)
      {
        _scripts[index].Scintilla.ContextMenuStrip = scriptsEditor_ContextMenuStrip;
        _scripts[index].Scintilla.SelectionChanged += new EventHandler(Scintilla_Changed);
        if (position >= 0 && position < _scripts[index].Scintilla.TextLength)
          _scripts[index].Scintilla.CurrentPos = position;
        _scripts[index].Scintilla.TextChanged += new EventHandler<EventArgs>(Scintilla_Changed);
        scriptsEditor_tabs.TabPages.Add(_scripts[index].TabPage);
      }
      scriptsEditor_tabs.SelectedTab = _scripts[index].TabPage;
      UpdateMenusEnabled();
    }

    /// <summary>
    /// Imports the scripts from the given paths
    /// </summary>
    /// <param name="node">the selected <see cref="TreeNode"/></param>
    /// <param name="paths">A string-array with paths to import from</param>
    private void ImportScriptsFrom(TreeNode node, bool selectLast, string[] paths)
    {
      if (node == null)
      {
        if (!NodeExistByName("Materials"))
        {
          MessageBox.Show("The project seems to be missing a 'Materials' Script Group.",
            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
        node = GetNodeByName("Materials");
      }
      scriptsView.BeginUpdate();
      foreach (string path in paths)
        if (File.Exists(path))
          try
          {
            if (_fileNameRegex.IsMatch(path) && ScriptExistBySection(int.Parse(_fileNameRegex.Match(path).Captures[1].Value)))
              UpdateScriptBySection(int.Parse(_fileNameRegex.Match(path).Captures[1].Value),
                _fileNameRegex.Match(path).Captures[0].Value, File.ReadAllText(path));
            else if (_fileNameRegex.IsMatch(path))
              InsertNode(node, selectLast, _fileNameRegex.Match(path).Captures[0].Value,
                _fileNameRegex.Match(path).Captures[1].Value, File.ReadAllText(path));
            else
              InsertNode(node, selectLast, Path.GetFileNameWithoutExtension(path), File.ReadAllText(path));
            if (node.Level == 1)
              node = node.NextNode;
          }
          catch
          {
            MessageBox.Show("There was an error while importing from '" + path + "'.",
              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
      scriptsView.EndUpdate();
      _projectNeedSave = true;
    }

    /// <summary>
    /// Exports the scripts using the passed filed extension to determine the file type
    /// </summary>
    /// <param name="extension">The extension to save the files as</param>
    private void ExportScriptsTo(string extenction)
    {
      using (FolderBrowserDialog dialog = new FolderBrowserDialog())
      {
        dialog.ShowNewFolderButton = true;
        dialog.RootFolder = Environment.SpecialFolder.MyDocuments;
        dialog.Description = "Choose folder...";
        if (dialog.ShowDialog() == DialogResult.OK)
        {
          Enabled = false;
          try
          {
            int i = 0;
            for (int j = 0; j < scriptsView.Nodes.Count; j++)
            {
              string filename = String.Format("{0:000} - ", i);
              File.WriteAllText(dialog.SelectedPath + "/" + filename + extenction, "");
              i++;
              filename = String.Format("{0:000} - {1}", i, "▼ " + scriptsView.Nodes[j].Text);
              filename = _invalidRegex.Replace(filename, "");
              File.WriteAllText(dialog.SelectedPath + "/" + filename + extenction, "");
              i++;
              for (int k = 0; k < scriptsView.Nodes[j].Nodes.Count; k++)
              {
                filename = String.Format("{0:000} - {1}", i, scriptsView.Nodes[j].Nodes[k].Text);
                filename = _invalidRegex.Replace(filename, "");
                File.WriteAllText(dialog.SelectedPath + "/" + filename + extenction,
                  GetScriptBySection(int.Parse(scriptsView.Nodes[j].Nodes[k].Name)).Text);
                i++;
              }
            }
          }
          catch
          {
            MessageBox.Show("An error occurred, the export has been stopped.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          Enabled = true;
        }
      }
    }

    /// <summary>
    /// Export the given Script to a file
    /// </summary>
    /// <param name="section">The Script section</param>
    private void ExportScript(int section)
    {
      if (!Directory.Exists(_projectScriptsFolderPath))
        Directory.CreateDirectory(_projectScriptsFolderPath);
      if (ScriptExistBySection(section))
        try
        {
          Script script = GetScriptBySection(section);
          File.WriteAllText(_projectScriptsFolderPath + script.Name + "." + string.Format("{0:00000000}", script.Section) + ".rb", script.Text);
        }
        catch
        {
          Script script = GetScriptBySection(section);
          MessageBox.Show("An error occurred while exporting the script; '" + script.Name + " - " + script.Section + ".rb'",
            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void DeleteExportedScript(int section)
    {
      try
      {
        Script script = GetScriptBySection(section);
        if (File.Exists(_projectScriptsFolderPath + script.Name + "." + string.Format("{0:00000000}", script.Section) + ".rb"))
          File.Delete(_projectScriptsFolderPath + script.Name + "." + string.Format("{0:00000000}", script.Section) + ".rb");
      }
      catch
      {
        MessageBox.Show("An error occurred while deleting script-file.",
          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    /// <summary>
    /// Export all the Scripts in an Script Group to files in the Project Scripts Folder
    /// </summary>
    /// <param name="node">The selected node. Must be a Group Node</param>
    private void ExportScriptGroup(TreeNode rootNode)
    {
      if (rootNode.Level != 0) return;
      foreach (TreeNode node in rootNode.Nodes)
        ExportScript(int.Parse(node.Name));
    }

    /// <summary>
    /// Exports all the Scripts to the Project Scripts Folder
    /// </summary>
    private void ExportScripts()
    {
      foreach (TreeNode rootNode in scriptsView.Nodes)
        foreach (TreeNode node in rootNode.Nodes)
          ExportScript(int.Parse(node.Name));
    }

    /// <summary>
    /// Get the Script by the given section number
    /// </summary>
    /// <param name="section">Section to locate script from</param>
    /// <returns></returns>
    private Script GetScriptBySection(int section)
    {
      return _scripts.Find(delegate (Script s) { return s.Section == section; });
    }

    private void SetScript(Script s)
    {
      if (_scripts.Exists(delegate (Script d) { return d.Section == s.Section; }))
        _scripts[_scripts.FindIndex(delegate (Script d) { return d.Section == s.Section; })] = s;
    }

    private bool ScriptExistBySection(int section)
    {
      foreach (Script script in _scripts)
        if (script.Section == section)
          return true;
      return false;
    }

    private void UpdateScriptBySection(int section, string name, string value)
    {
      Script script = GetScriptBySection(section);
      if (script.Name != name.Trim())
        script.Name = name.Trim();
      script.Scintilla.Text = value;
      script.ApplyChanges();
      if (!script.Opened)
        script.Dispose();
    }

    #endregion

    /*\
     * ##    ##               ##
     * ###   ##               ##
     * ####  ##  ######   ######  #####
     * ## ## ## ##    ## ##   ## ##   ##
     * ##  #### ##    ## ##   ## #######
     * ##   ### ##    ## ##   ## ##
     * ##    ##  ######   ######  #####
    \*/
    #region Node Methods

    /// <summary>
    /// Adds a new node to the TreeView
    /// </summary>
    /// <param name="selectedNode">The <see cref="TreeNode"/> currently selected</param>
    /// <param name="index">The insert index</param>
    /// <param name="select">If the inserted node schould be selected</param>
    /// <param name="args">(<see cref="RubyArray"/> rmScript) or (<see cref="string"/> name, <see cref="string"/> text)</param>
    private void InsertNode(TreeNode selectedNode, bool select, params object[] args)
    { InsertNode(selectedNode, selectedNode == null ? -1 : selectedNode.Index + 1, select, args); }
    private void InsertNode(TreeNode selectedNode, int index, bool select, params object[] args)
    {
      Script script;
      if (args.Length == 1)
      {
        RubyArray rmScript = (RubyArray)args[0];
        rmScript[0] = int.Parse(rmScript[0].ToString());
        Console.WriteLine();
        script = new Script(rmScript);
        script.Section = GetSection(script);
      }
      else if (args.Length == 2)
        script = new Script(GetRandomSection(), (string)args[0], (string)args[1]);
      else return;
      script.Name.Trim();
      TreeNode node = new TreeNode();
      node.Name = string.Format("{0:00000000}", script.Section);
      node.Text = script.Name.Replace("▼ ", "");
      node.ToolTipText = (script.Name.StartsWith("▼ ") ? "" : node.Name + " - ") + node.Text;
      if (script.Name.StartsWith("▼ "))
      {
        if (selectedNode != null && selectedNode.Level == 1)
          index = selectedNode.Parent.Index + 1;
        else if (index < 0)
          index = scriptsView.Nodes.Count;
        scriptsView.Nodes.Insert(index, node);
      }
      else if (script.Name == "" & script.Text.Trim() == "")
        return;
      else if (script.Name != "")
      {
        if (selectedNode.Level == 0)
          scriptsView.Nodes[selectedNode.Index].Nodes.Add(node);
        else if (selectedNode.Level == 1)
        {
          if (index < 0)
            index = scriptsView.Nodes[selectedNode.Index].Nodes.Count;
          selectedNode = selectedNode.Parent;
          scriptsView.Nodes[selectedNode.Index].Nodes.Insert(index, node);
        }
        else return;
        _scripts.Add(script);
      }
      else return;
      if (select)
        scriptsView.SelectedNode = node;
      _projectNeedSave = true;
    }

    private void DeleteNode(string section)
    { DeleteNode(int.Parse(section)); }
    private void DeleteNode(int section)
    {
      TreeNode node = GetNodeBySection(section);
      if (node == null) return;
      scriptsView.Nodes[node.Parent.Index].Nodes.Remove(node);
      DeleteScript(section);
      _projectNeedSave = true;
    }

    /// <summary>
    /// Delete all the <see cref="TreeNode"/>s and <see cref="Script"/>s from a Script Group
    /// </summary>
    /// <param name="rootNode">The given Node. Must be a Group Node.</param>
    private void DeleteNodeGroup(TreeNode rootNode)
    {
      if (rootNode.Level != 0) return;
      scriptsView.BeginUpdate();
      Enabled = false;
      for (int i = 0; i < rootNode.Nodes.Count; i++)
      {
        TreeNode node = rootNode.LastNode;
        DeleteNode(node.Name);
      }

      scriptsView.Nodes.Remove(rootNode);
      Enabled = true;
      scriptsView.EndUpdate();
    }

    private string GetNameBySection(int section)
    {
      return scriptsView.Nodes.Find(string.Format("{0:00000000}", section), true)[0].Text;
    }

    /// <summary>
    /// Retrives the TreeNode corresponding to the given section number if any, else return null.
    /// </summary>
    /// <param name="section">The section number to search for</param>
    /// <returns></returns>
    private TreeNode GetNodeBySection(int section)
    {
      return scriptsView.Nodes.Find(string.Format("{0:00000000}", section), true)[0];
    }

    /// <summary>
    /// Retrives the first TreeNode corresponding to the given name if any, else return null. Accepts Regex
    /// </summary>
    /// <param name="regexName">The name to search for</param>
    /// <returns>The TreeNode to use</returns>
    private TreeNode GetNodeByName(string regexName)
    {
      foreach (TreeNode rootNode in scriptsView.Nodes)
        if (Regex.IsMatch(rootNode.Text, regexName))
          return rootNode;
        else
          foreach (TreeNode node in rootNode.Nodes)
            if (Regex.IsMatch(node.Text, regexName))
              return node;
      return null;
    }

    /// <summary>
    /// Search for any TreeNodes correspondig to the given name. Accepts Regex
    /// </summary>
    /// <param name="name">The name to search for</param>
    /// <returns>The TreeNode to use</returns>
    private bool NodeExistByName(string regexName)
    {
      foreach (TreeNode rootNode in scriptsView.Nodes)
        if (Regex.IsMatch(rootNode.Text, regexName))
          return true;
        else
          foreach (TreeNode node in rootNode.Nodes)
            if (Regex.IsMatch(node.Text, regexName))
              return true;
      return false;
    }

    #endregion

    /*\
     *  ###### ##   ##          ##                                     ##
     * ##      ##               ##                                     ##
     * ##      ##   ### ######  ##       ######   #####   ######   ######
     * ##      ##   ##  ##   ## ######  ##    ##      ## ##    ## ##   ##
     * ##      ##   ##  ##   ## ##   ## ##    ##  ###### ##       ##   ##
     * ##      ##   ##  ######  ##   ## ##    ## ##   ## ##       ##   ##
     *  ######  ### ##  ##      ######   ######  ####### ##        ######
     * =================##===============================================
    \*/
    #region Clipboard Methods

    /// <summary>
    /// Get a script from the clipboard
    /// </summary>
    /// <returns>A script if there is one, else null</returns>
    private RubyArray GetClipboardScript()
    {
      String format = ClipboardContainsScript();
      if (format != null)
        try
        {
          MemoryStream stream = (MemoryStream)System.Windows.Forms.Clipboard.GetData(format);
          byte[] data = new byte[4];
          stream.Read(data, 0, data.Length);
          data = new byte[BitConverter.ToInt32(data, 0)];
          stream.Read(data, 0, data.Length);
          return (RubyArray)Ruby.MarshalLoad(data);
        }
        catch
        {
          MessageBox.Show("Clipboard error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      return null;
    }

    /// <summary>
    /// Set the passed script to the clipboard in the current project format
    /// </summary>
    /// <param name="script">The script to copy</param>
    private void SetClipboardScript(Script script)
    {
      RubyArray rmScript = script.RMScript;
      if (script.NeedApplyChanges)
        rmScript = new RubyArray() { rmScript[0], rmScript[1], Ruby.ZlibDeflate(script.Text) };
      byte[] data = Ruby.MarshalDump(rmScript);
      MemoryStream stream = new MemoryStream();
      stream.Write(BitConverter.GetBytes(data.Length), 0, 4);
      stream.Write(data, 0, data.Length);
      string format = "";
      if (_projectEngine == "RMXP") format = "RPGXP SCRIPT";
      else if (_projectEngine == "RMVX") format = "RPGVX SCRIPT";
      else if (_projectEngine == "RMVXAce") format = "VX Ace SCRIPT";
      System.Windows.Forms.Clipboard.SetData(format, stream);
    }

    /// <summary>
    /// Check if the clipboard contains a script
    /// </summary>
    /// <returns>The script format if there is one, else null</returns>
    private string ClipboardContainsScript()
    {
      foreach (string format in new string[] { "RPGXP SCRIPT", "RPGVX SCRIPT", "VX Ace SCRIPT" })
        if (System.Windows.Forms.Clipboard.ContainsData(format))
          return format;
      return null;
    }

    #endregion

    /*\
     *  ######                                  ##
     * ##                                       ##
     * ##       #####   #####   ######   ###### ## ####
     *  #####  ##   ##      ## ##    ## ##      ###   ##
     *      ## #######  ###### ##       ##      ##    ##
     *      ## ##      ##   ## ##       ##      ##    ##
     * ######   #####  ####### ##        ###### ##    ##
     * =================================================
    \*/
    #region Search Methods

    private void ShowFind()
    {
      Script script = GetActiveScript();
      if (script == null) return;
      _findReplaceDialog.Scintilla = script.Scintilla;
      if (!_findReplaceDialog.Visible)
        _findReplaceDialog.Show(this);
      _findReplaceDialog.tabAll.SelectedTab = _findReplaceDialog.tabAll.TabPages["tpgFind"];
      ScintillaNet.Range selRange = _findReplaceDialog.Scintilla.Selection.Range;
      if (selRange.IsMultiLine)
        _findReplaceDialog.chkSearchSelectionF.Checked = true;
      else if (selRange.Length > 0)
        _findReplaceDialog.cboFindF.Text = selRange.Text;
      _findReplaceDialog.cboFindF.Select();
      _findReplaceDialog.cboFindF.SelectAll();
    }

    private void ShowReplace()
    {
      Script script = GetActiveScript();
      if (script == null) return;
      _findReplaceDialog.Scintilla = script.Scintilla;
      if (!_findReplaceDialog.Visible)
        _findReplaceDialog.Show(this);
      _findReplaceDialog.tabAll.SelectedTab = _findReplaceDialog.tabAll.TabPages["tpgReplace"];
      ScintillaNet.Range selRange = _findReplaceDialog.Scintilla.Selection.Range;
      if (selRange.IsMultiLine)
        _findReplaceDialog.chkSearchSelectionR.Checked = true;
      else if (selRange.Length > 0)
        _findReplaceDialog.cboFindR.Text = selRange.Text;
      _findReplaceDialog.cboFindR.Select();
      _findReplaceDialog.cboFindR.SelectAll();
    }

    private void ShowSearch()
    {
      TabPage tabPage = new TabPage("New Search");
      SearchControl searchControl = new SearchControl();
      searchControl.toolStripButton_Search.Click += new EventHandler(searches_ToolStripButton_Click);
      searchControl.listView_Results.ItemActivate += new EventHandler(searches_ListView_ItemActivate);
      tabPage.Controls.Add(searchControl);
      searches_TabControl.TabPages.Add(tabPage);
      searches_TabControl.SelectedTab = tabPage;
      splitView.Panel2Collapsed = false;
      if (splitView.Panel2.ClientSize.Height < 200)
        splitView.SplitterDistance -= 200 - splitView.Panel2.ClientSize.Height;
      searchControl.toolStripTextBox_SearchString.Focus();
    }

    private void Search(SearchControl control)
    {
      // Set appropriate flag
      SearchFlags flags = SearchFlags.Empty;
      if (control.toolStripMenuItem_RegExp.Checked)
        flags |= SearchFlags.RegExp;
      if (control.toolStripMenuItem_MatchCase.Checked)
        flags |= SearchFlags.MatchCase;
      if (control.toolStripMenuItem_WholeWord.Checked)
        flags |= SearchFlags.WholeWord;
      if (control.toolStripMenuItem_WordStart.Checked)
        flags |= SearchFlags.WordStart;
      // Determine search location
      List<Script> searchLocation = new List<Script>();
      if (control.toolStripComboBox_Scope.SelectedIndex == 0)
      {
        Script script = GetActiveScript();
        if (script != null)
          searchLocation.Add(script);
      }
      else if (control.toolStripComboBox_Scope.SelectedIndex == 1)
      {
        foreach (Script script in _scripts)
          if (script.Opened)
            searchLocation.Add(script);
      }
      else
        searchLocation = _scripts;
      // Execute search
      if (searchLocation.Count > 0)
      {
        control.listView_Results.Items.Clear();
        control.Parent.Text = control.toolStripTextBox_SearchString.Text;
        control.label_Statistics.Text = "Searching...";
        control.label_Statistics.Update();
        int scriptCount = 0;
        Enabled = false;
        foreach (Script script in searchLocation)
        {
          SearchResult[] results = script.Search(control.toolStripTextBox_SearchString.Text, flags);
          if (results.Length > 0)
          {
            scriptCount++;
            control.listView_Results.Items.AddRange(results);
            control.label_Statistics.Text = string.Format(@"{0} result{1} found in {2} script{3}.",
                control.listView_Results.Items.Count, control.listView_Results.Items.Count > 1 ? "s" : "",
                scriptCount, scriptCount > 1 ? "s" : "");
            control.label_Statistics.Update();
          }
        }
        Enabled = true;
        if (scriptCount == 0)
          control.label_Statistics.Text = "No matching results were found in the search.";
      }
      else
        control.label_Statistics.Text = "There is currently no open document to search.";
    }

    #endregion

    /*\
     * ##     ## ##
     * ###   ###
     * #### #### ###  ######  ######
     * ## ### ## ##  ##      ##
     * ##     ## ##   #####  ##
     * ##     ## ##       ## ##      ###
     * ##     ## ##  ######   ###### ###
     * =================================
    \*/
    #region Misc Methods

    /// <summary>
    /// Copies an embedded resource to an external place on the hard-drive
    /// </summary>
    /// <param name="path">The path the resource will be saved to</param>
    private void CopyResource(string resource, string path)
    {
      using (Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
      using (FileStream resourceFile = new FileStream(path, FileMode.Create))
      {
        if (s == null) return;
        byte[] b = new byte[s.Length + 1];
        s.Read(b, 0, Convert.ToInt32(s.Length));
        resourceFile.Write(b, 0, Convert.ToInt32(b.Length - 1));
        resourceFile.Flush();
      }
    }

    /// <summary>
    /// Reads the game's Game.ini file and retrieves the title of the game, then returns it
    /// </summary>
    private string GetGameTitle()
    {
      string ini = _projectDirectory + "Game.ini";
      if (File.Exists(ini))
        foreach (string line in File.ReadAllLines(ini))
          if (line.StartsWith("Title="))
            return line.Replace("Title=", "").Trim();
      return "Untitled";
    }

    /// <summary>
    /// Reads the game's Game.ini file and retrieves the scripts path, then returns it
    /// </summary>
    private string GetScriptsPath()
    {
      string ini = _projectDirectory + "Game.ini";
      if (File.Exists(ini))
        foreach (string line in File.ReadAllLines(ini))
          if (line.StartsWith("Scripts="))
            return _projectDirectory + line.Replace("Scripts=", "").Trim();
      if (_projectEngine == "RMXP") return _projectDirectory + @"Data\Scripts.rxdata";
      else if (_projectEngine == "RMVX") return _projectDirectory + @"Data\Scripts.rvdata";
      else if (_projectEngine == "RMVXAce") return _projectDirectory + @"Data\Scripts.rvdata2";
      return "";
    }

    /// <summary>
    /// Retrieves either the given <see cref="Script.Section"/> or a non-repeatable random integer
    /// </summary>
    /// <param name="script"><see cref="Script"/> to check</param>
    /// <returns><see cref="Script.Section"/> / Random integer</returns>
    private int GetSection(Script script)
    {
      if (script.Section != 0 && script.Section.ToString().Length < 9)
      {
        _usedSections.Add(script.Section);
        return script.Section;
      }
      return GetRandomSection();
    }

    /// <summary>
    /// Retrieves a non-repeatable random integer
    /// </summary>
    /// <returns>Random integer</returns>
    private int GetRandomSection()
    { return GetRandomSection(true); }

    /// <summary>
    /// Retrieves a non-repeatable random integer
    /// </summary>
    /// <param name="add">Whether or not to add it to <see cref="_usedSections"/> list</param>
    /// <returns>Random integer</returns>
    private int GetRandomSection(bool add)
    {
      Random random = new Random();
      int section;
      do section = random.Next(99999999);
      while (_usedSections.Contains(section));
      if (add)
        _usedSections.Add(section);
      return section;
    }

    public static string WildcardPatternToRegexPattern(string pattern)
    {
      return string.Format("^{0}$", Regex.Escape(pattern.Replace('/', Path.DirectorySeparatorChar)).Replace(@"\*", ".*").Replace(@"\?", "."));
    }

    private bool NeedSave()
    {
      if (_projectNeedSave)
        return true;
      foreach (Script script in _scripts)
        if (script.NeedSave)
          return true;
      return false;
    }

    #endregion

    /*\
     * ##     ##              ##         ##
     * ##     ##              ##         ##
     * ##     ## ######       ##  #####  #######  #####
     * ##     ## ##   ##  ######      ## ##      ##   ##
     * ##     ## ##   ## ##   ##  ###### ##      #######
     * ##     ## ######  ##   ## ##   ## ##   ## ##
     *  #######  ##       ###### #######  #####   #####
     * ==========##=====================================
    \*/
    #region Update Methods

    private void UpdateAutoCompleteWords()
    {
      string words = "";
      if ((Settings.AutoCompleteFlag & (1 << 0)) != 0)
      {
        if (_projectEngine == "RMXP") words += global::Gemini.Properties.Resources.Ruby181_Constants + " ";
        else if (_projectEngine == "RMVX") words += global::Gemini.Properties.Resources.Ruby181_Constants + " ";
        else if (_projectEngine == "RMVXAce") words += global::Gemini.Properties.Resources.Ruby192_Constants + " ";
      }
      if ((Settings.AutoCompleteFlag & (1 << 1)) != 0)
        words += global::Gemini.Properties.Resources.Ruby_Keywords + " ";
      if ((Settings.AutoCompleteFlag & (1 << 2)) != 0)
      {
        if (_projectEngine == "RMXP") words += global::Gemini.Properties.Resources.Ruby181_KernelFunctions + " ";
        else if (_projectEngine == "RMVX") words += global::Gemini.Properties.Resources.Ruby181_KernelFunctions + " ";
        else if (_projectEngine == "RMVXAce") words += global::Gemini.Properties.Resources.Ruby192_KernelFunctions + " ";
      }
      if ((Settings.AutoCompleteFlag & (1 << 3)) != 0)
      {
        if (_projectEngine == "RMXP") words += global::Gemini.Properties.Resources.RMXP_Constants + " ";
        else if (_projectEngine == "RMVX") words += global::Gemini.Properties.Resources.RMVX_Constants + " ";
        else if (_projectEngine == "RMVXAce") words += global::Gemini.Properties.Resources.RMVXAce_Constants + " ";
      }
      if ((Settings.AutoCompleteFlag & (1 << 4)) != 0)
      {
        if (_projectEngine == "RMXP") words += global::Gemini.Properties.Resources.RMXP_Globals + " ";
        else if (_projectEngine == "RMVX") words += global::Gemini.Properties.Resources.RMVX_Globals + " ";
        else if (_projectEngine == "RMVXAce") words += global::Gemini.Properties.Resources.RMVXAce_Globals + " ";
      }
      if ((Settings.AutoCompleteFlag & (1 << 5)) != 0)
        words += Settings.AutoCompleteCustomWords;
      Settings.AutoCompleteWords.Clear();
      foreach (string word in words.Split(' '))
        if (word.Length != 0 && !Settings.AutoCompleteWords.Contains(word))
          Settings.AutoCompleteWords.Add(word);
      Settings.AutoCompleteWords.Sort();
    }

    private void UpdateTitle(string projectPath = "")
    {
      if (_projectEngine == "")
        Text = "Gemini";
      else if (_projectScriptsFolderPath == "")
        Text = _projectEngine + " - " + projectPath;
      else
        Text = _projectEngine + " - " + GetGameTitle() + " - " + projectPath;
      Bitmap icon = null;
      if (_projectEngine == "RMXP") icon = Properties.Resources.rmxp_script;
      else if (_projectEngine == "RMVX") icon = Properties.Resources.rmvx_script;
      else if (_projectEngine == "RMVXAce") icon = Properties.Resources.rmvxace_script;
      menuMain_dropFile_itemExoprtToRMData.Image = icon;
    }

    private void UpdateRecentProjectList()
    {
      while (menuMain_dropFile_itemOpenRecent.DropDownItems.Count > 0)
        menuMain_dropFile_itemOpenRecent.DropDownItems.RemoveAt(0);
      foreach (string path in Settings.RecentlyOpened)
      {
        string ext = Path.GetExtension(path);
        Bitmap icon = null;
        if (ext == ".rxproj") icon = Properties.Resources.rmxp_icon;
        else if (ext == ".rvproj") icon = Properties.Resources.rmvx_icon;
        else if (ext == ".rvproj2") icon = Properties.Resources.rmvxace_icon;
        else if (ext == ".rxdata") icon = Properties.Resources.rmxp_script;
        else if (ext == ".rvdata") icon = Properties.Resources.rmvx_script;
        else if (ext == ".rvdata2") icon = Properties.Resources.rmvxace_script;
        ToolStripMenuItem item = new ToolStripMenuItem(path, icon, new EventHandler(mainMenu_ToolStripMenuItem_OpenRecentProject_Click));
        menuMain_dropFile_itemOpenRecent.DropDownItems.Add(item);
      }
    }

    private void UpdateMenusEnabled()
    {
      Script script = GetActiveScript();
      bool project = _projectEngine != "";
      bool scriptsFolder = project && _projectScriptsFolderPath != "";
      bool editor = project && script != null;
      bool editorSelection = editor && script.Scintilla.Selection.Length > 0;
      bool editorUndo = editor && script.Scintilla.UndoRedo.CanUndo;
      bool editorRedo = editor && script.Scintilla.UndoRedo.CanRedo;
      bool editorPaste = editor && script.Scintilla.Clipboard.CanPaste;
      bool viewSelection = project && scriptsView.SelectedNode != null;
      bool viewMoveUp = viewSelection &&
        ((scriptsView.SelectedNode.Level == 1 && scriptsView.SelectedNode.Parent.Index > 0) || scriptsView.SelectedNode.Index > 0);
      bool viewMoveDown = viewSelection &&
        ((scriptsView.SelectedNode.Level == 1 && (scriptsView.SelectedNode.Parent.Index <
        scriptsView.Nodes.Count - 1 || scriptsView.SelectedNode.Index <
        scriptsView.Nodes[scriptsView.SelectedNode.Parent.Index].Nodes.Count - 1)) ||
        (scriptsView.SelectedNode.Level == 0 && scriptsView.SelectedNode.Index < scriptsView.Nodes.Count - 1));
      bool viewPaste = project && ClipboardContainsScript() != null;
      bool viewCopy = viewSelection && scriptsView.SelectedNode.Level == 1;

      menuMain_dropFile_itemClose.Enabled = project;
      menuMain_dropFile_itemSave.Enabled = project;
      menuMain_dropFile_itemImport.Enabled = project;
      menuMain_dropFile_itemExportTo.Enabled = project;

      menuMain_dropEdit_itemUndo.Enabled = editorUndo;
      menuMain_dropEdit_itemRedo.Enabled = editorRedo;
      menuMain_dropEdit_itemCut.Enabled = editorSelection;
      menuMain_dropEdit_itemCopy.Enabled = editorSelection;
      menuMain_dropEdit_itemPaste.Enabled = editorPaste;
      menuMain_dropEdit_itemDelete.Enabled = editorSelection;
      menuMain_dropEdit_itemSelectAll.Enabled = editor;
      menuMain_dropEdit_itemBatchSearch.Enabled = project;
      menuMain_dropEdit_itemIncrementalSearch.Enabled = editor;
      menuMain_dropEdit_itemFind.Enabled = editor;
      menuMain_dropEdit_itemReplace.Enabled = editor;
      menuMain_dropEdit_itemGoTo.Enabled = editor;
      menuMain_dropEdit_itemBatchComment.Enabled = project;
      menuMain_dropEdit_itemComment.Enabled = editor;
      menuMain_dropEdit_itemUnComment.Enabled = editor;
      menuMain_dropEdit_itemToggleComment.Enabled = editor;
      menuMain_dropEdit_itemStructureScript.Enabled = project;
      menuMain_dropEdit_itemSScriptCurrent.Enabled = editor;
      menuMain_dropEdit_itemSScriptOpen.Enabled = editor;
      menuMain_dropEdit_itemSScriptAll.Enabled = project;
      menuMain_dropEdit_itemRemoveEmpty.Enabled = project;
      menuMain_dropEdit_itemRemoveEmptyCurrent.Enabled = editor;
      menuMain_dropEdit_itemRemoveEmptyOpen.Enabled = editor;
      menuMain_dropEdit_itemRemoveEmptyAll.Enabled = project;

      menuMain_dropSettings_itemUpdateSections.Enabled = scriptsFolder;

      menuMain_dropGame_itemHelp.Enabled = project;
      menuMain_dropGame_itemRun.Enabled = project;
      menuMain_dropGame_itemRunWithF12.Enabled = project;
      menuMain_dropGame_itemDebug.Enabled = project;
      menuMain_dropGame_itemProjectFolder.Enabled = project;

      scriptsEditor_ToolStripMenuItem_AddWordToAutoComplete.Enabled = editor;

      scriptName.Enabled = viewSelection;
      toolsView_itemImport.Enabled = scriptsFolder;
      toolsView_itemExport.Enabled = scriptsFolder;
      scriptsView_contextMenu_itemOpen.Enabled = viewSelection;
      scriptsView_contextMenu_itemInsert.Enabled = project;
      scriptsView_contextMenu_itemCut.Enabled = viewCopy;
      scriptsView_contextMenu_itemCopy.Enabled = viewCopy;
      scriptsView_contextMenu_itemPaste.Enabled = viewPaste;
      scriptsView_contextMenu_itemDelete.Enabled = viewSelection;
      scriptsView_contextMenu_itemMoveUp.Enabled = viewMoveUp;
      scriptsView_contextMenu_itemMoveDown.Enabled = viewMoveDown;

      // below are just duplicates

      scriptsView_contextMenu_itemBatchSearch.Enabled = menuMain_dropEdit_itemBatchSearch.Enabled;

      toolsView_itemInsert.Enabled = scriptsView_contextMenu_itemInsert.Enabled;
      toolsView_itemDelete.Enabled = scriptsView_contextMenu_itemDelete.Enabled;
      toolsView_itemMoveUp.Enabled = scriptsView_contextMenu_itemMoveUp.Enabled;
      toolsView_itemMoveDown.Enabled = scriptsView_contextMenu_itemMoveDown.Enabled;
      toolsView_itemBatchSearch.Enabled = menuMain_dropEdit_itemBatchSearch.Enabled;

      scriptsEditor_ToolStripMenuItem_Undo.Enabled = menuMain_dropEdit_itemUndo.Enabled;
      scriptsEditor_ToolStripMenuItem_Redo.Enabled = menuMain_dropEdit_itemRedo.Enabled;
      scriptsEditor_ToolStripMenuItem_Cut.Enabled = menuMain_dropEdit_itemCut.Enabled;
      scriptsEditor_ToolStripMenuItem_Copy.Enabled = menuMain_dropEdit_itemCopy.Enabled;
      scriptsEditor_ToolStripMenuItem_Paste.Enabled = menuMain_dropEdit_itemPaste.Enabled;
      scriptsEditor_ToolStripMenuItem_Delete.Enabled = menuMain_dropEdit_itemDelete.Enabled;
      scriptsEditor_ToolStripMenuItem_SelectAll.Enabled = menuMain_dropEdit_itemSelectAll.Enabled;
      scriptsEditor_ToolStripMenuItem_IncrementalSearch.Enabled = menuMain_dropEdit_itemIncrementalSearch.Enabled;
      scriptsEditor_ToolStripMenuItem_Find.Enabled = menuMain_dropEdit_itemFind.Enabled;
      scriptsEditor_ToolStripMenuItem_FindNext.Enabled = menuMain_dropEdit_itemFind.Enabled;
      scriptsEditor_ToolStripMenuItem_FindPrevious.Enabled = menuMain_dropEdit_itemFind.Enabled;
      scriptsEditor_ToolStripMenuItem_Replace.Enabled = menuMain_dropEdit_itemReplace.Enabled;
      scriptsEditor_ToolStripMenuItem_GoToLine.Enabled = menuMain_dropEdit_itemGoTo.Enabled;
      scriptsEditor_ToolStripMenuItem_Comment.Enabled = menuMain_dropEdit_itemToggleComment.Enabled;

      toolsEditor_itemSaveProject.Enabled = menuMain_dropFile_itemSave.Enabled;
      toolsEditor_itemSearch.Enabled = menuMain_dropEdit_itemIncrementalSearch.Enabled;
      toolsEditor_itemFind.Enabled = menuMain_dropEdit_itemFind.Enabled;
      toolsEditor_itemReplace.Enabled = menuMain_dropEdit_itemReplace.Enabled;
      toolsEditor_itemGoToLine.Enabled = menuMain_dropEdit_itemGoTo.Enabled;
      toolsEditor_itemComment.Enabled = menuMain_dropEdit_itemToggleComment.Enabled;
      toolsEditor_itemStructureScript.Enabled = menuMain_dropEdit_itemSScriptCurrent.Enabled;
      toolsEditor_itemRemoveLines.Enabled = menuMain_dropEdit_itemRemoveEmptyCurrent.Enabled;
      toolsEditor_itemRun.Enabled = menuMain_dropGame_itemRunWithF12.Enabled;
      toolsEditor_itemDebug.Enabled = menuMain_dropGame_itemDebug.Enabled;
      toolsEditor_itemProjectFolder.Enabled = menuMain_dropGame_itemProjectFolder.Enabled;
      toolsEditor_itemCloseProject.Enabled = menuMain_dropFile_itemClose.Enabled;
    }

    private void UpdateSettingsState()
    {
      bool project = _projectScriptsFolderPath != "";

      splitMain.Panel1Collapsed = Settings.DistractionMode.Use;
      toolsEditor_toolStrip.Visible = !Settings.DistractionMode.HideToolbar || !Settings.DistractionMode.Use;
      if (Settings.DistractionMode.Use)
        menuMain_dropSettings_itemToggleDistractionMode.Image = Properties.Resources.reduce;
      else
        menuMain_dropSettings_itemToggleDistractionMode.Image = Properties.Resources.expand;

      if (Settings.AutoHideMenuBar)
      {
        menuMain_menuStrip.Leave += menuMain_menuStrip_Leave;
      }
      else
      {
        menuMain_menuStrip.Leave -= menuMain_menuStrip_Leave;
      }

      menuMain_dropSettings_itemAutoHideMenuBar.Checked = Settings.AutoHideMenuBar;
      menuMain_dropSettings_itemProjectSettings.Checked = Settings.ProjectConfig;
      menuMain_dropSettings_itemHideToolbar.Checked = Settings.DistractionMode.HideToolbar;
      autoOpenToolStripMenuItem.Checked = Settings.AutoOpen;
      menuMain_dropSettings_itemPioritizeRecent.Checked = Settings.RecentPriority;
      menuMain_dropSettings_itemAutoSaveSettings.Checked = Settings.AutoSaveConfig;
      menuMain_dropSettings_itemAutoC.Checked = Settings.AutoComplete;
      toolsEditor_itemAutoC.Checked = Settings.AutoComplete;
      menuMain_dropSettings_itemAutoIndent.Checked = Settings.AutoIndent;
      toolsEditor_itemAutoIndent.Checked = Settings.AutoIndent;
      menuMain_dropSettings_itemIndentGuides.Checked = Settings.GuideLines;
      toolsEditor_itemIndentGuides.Checked = Settings.GuideLines;
      menuMain_dropSettings_itemHighlight.Checked = Settings.LineHighLight;
      toolsEditor_itemHighlight.Checked = Settings.LineHighLight;
      menuMain_dropSettings_itemFolding.Checked = Settings.CodeFolding;
      toolsEditor_itemFolding.Checked = Settings.CodeFolding;
      menuMain_dropGame_itemDebug.Checked = Settings.DebugMode;
      toolsEditor_itemDebug.Checked = Settings.DebugMode;
    }

    private void UpdateScriptStatus()
    {
      Script script = GetActiveScript();
      scriptsEditor_StatusStrip_itemCharacters.Text = script == null ? "" :
          string.Format("{0}:{1} {2}", script.Scintilla.Caret.LineNumber + 1,
          script.Scintilla.Caret.Position - script.Scintilla.Lines[script.Scintilla.Caret.LineNumber].StartPosition + 1,
          (script.Scintilla.Selection.Length == 0 ? "" : "(" + script.Scintilla.Selection.Length + ")"));
    }

    private void UpdateName(Script s)
    {
      if (s.TabName != GetNodeBySection(s.Section).Text)
        GetNodeBySection(s.Section).Text = s.TabName;
    }

    private void UpdateNames()
    {
      Script s;
      scriptsView.BeginUpdate();
      foreach (TreeNode rootNode in scriptsView.Nodes)
        foreach (TreeNode node in rootNode.Nodes)
          if (node.Text != (s = GetScriptBySection(int.Parse(node.Name))).TabName)
            node.Text = s.TabName;
      scriptsView.EndUpdate();
    }

    #endregion

  }
}
