namespace Gemini
{
    partial class GeminiForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
				_findReplaceDialog.Dispose();
				_charmap.Dispose();
                foreach (Script script in _scripts)
                    script.Dispose();
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.ToolStripSeparator menuMain_dropFile_seperator1;
      System.Windows.Forms.ToolStripSeparator menuMain_dropFile_seperator2;
      System.Windows.Forms.ToolStripSeparator menuMain_dropEdit_seperator1;
      System.Windows.Forms.ToolStripSeparator menuMain_dropEdit_seperator2;
      System.Windows.Forms.ToolStripSeparator menuMain_dropEdit_seperator3;
      System.Windows.Forms.ToolStripSeparator menuMain_dropSettings_seperator3;
      System.Windows.Forms.ToolStripSeparator menuMain_dropAbout_seperator1;
      System.Windows.Forms.ToolStripSeparator toolStripSeparator22;
      System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
      System.Windows.Forms.ToolStripSeparator scriptsView_contextMenu_seperator1;
      System.Windows.Forms.ToolStripSeparator scriptsView_contextMenu_seperator2;
      System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
      System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
      System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
      System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
      System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
      System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
      System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
      System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
      System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeminiForm));
      this.menuMain_menuStrip = new System.Windows.Forms.MenuStrip();
      this.menuMain_dropFile = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropFile_itemNew = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropFile_itemNewRMXP = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropFile_itemNewRMVX = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropFile_itemNewRMVXAce = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropFile_itemOpen = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropFile_itemOpenRecent = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropFile_itemSave = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropFile_itemClose = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropFile_itemImport = new System.Windows.Forms.ToolStripMenuItem();
      this.defaultFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.browseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropFile_itemExportTo = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropFile_itemExportToFolder = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropFile_itemExoprtToRMData = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropFile_itemExportToText = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropFile_itemExportToRuby = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropFile_itemExit = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropEdit = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropEdit_itemUndo = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropEdit_itemRedo = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropEdit_itemCut = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropEdit_itemCopy = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropEdit_itemPaste = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropEdit_itemDelete = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropEdit_itemSelectAll = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropEdit_itemBatchSearch = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropEdit_itemIncrementalSearch = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropEdit_itemFind = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropEdit_itemReplace = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropEdit_itemGoTo = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropEdit_itemBatchComment = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropEdit_itemToggleComment = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropEdit_itemComment = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropEdit_itemUnComment = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropEdit_itemStructureScript = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropEdit_itemSScriptCurrent = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropEdit_itemSScriptOpen = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropEdit_itemSScriptAll = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropEdit_itemRemoveEmpty = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropEdit_itemRemoveEmptyCurrent = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropEdit_itemRemoveEmptyOpen = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropEdit_itemRemoveEmptyAll = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropSettings = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropSettings_itemAutoOpenProject = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropSettings_itemPioritizeRecent = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.menuMain_dropSettings_itemMinimalView = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropSettings_itemHideScripts = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropSettings_itemMenuVisible = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropSettings_seperator1 = new System.Windows.Forms.ToolStripSeparator();
      this.menuMain_dropSettings_itemUpdateSections = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropSettings_itemCustomRuntime = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropSettings_seperator2 = new System.Windows.Forms.ToolStripSeparator();
      this.menuMain_dropSettings_itemStylesConfig = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropSettings_itemAutoCConfig = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropSettings_itemAutoC = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropSettings_itemAutoIndent = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropSettings_itemIndentGuides = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropSettings_itemFolding = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropSettings_itemHighlight = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropSettings_itemHighlightColor = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropSettings_seperator4 = new System.Windows.Forms.ToolStripSeparator();
      this.menuMain_dropSettings_itemSaveSettings = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropSettings_itemAutoSaveSettings = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropSettings_itemClearSettings = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropGame = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropGame_itemHelp = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropGame_itemRun = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropGame_itemRunWithF12 = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropGame_itemDebug = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropGame_itemProjectFolder = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropAbout = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropAbout_itemVersionHistory = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropAbout_itemAboutGemini = new System.Windows.Forms.ToolStripMenuItem();
      this.scriptsView = new System.Windows.Forms.TreeView();
      this.scriptsView_contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.scriptsView_contextMenu_itemOpen = new System.Windows.Forms.ToolStripMenuItem();
      this.scriptsView_contextMenu_itemInsert = new System.Windows.Forms.ToolStripMenuItem();
      this.scriptsView_contextMenu_itemCut = new System.Windows.Forms.ToolStripMenuItem();
      this.scriptsView_contextMenu_itemCopy = new System.Windows.Forms.ToolStripMenuItem();
      this.scriptsView_contextMenu_itemPaste = new System.Windows.Forms.ToolStripMenuItem();
      this.scriptsView_contextMenu_itemDelete = new System.Windows.Forms.ToolStripMenuItem();
      this.scriptsView_contextMenu_itemMoveUp = new System.Windows.Forms.ToolStripMenuItem();
      this.scriptsView_contextMenu_itemMoveDown = new System.Windows.Forms.ToolStripMenuItem();
      this.scriptsView_contextMenu_itemBatchSearch = new System.Windows.Forms.ToolStripMenuItem();
      this.toolsView_toolStrip = new System.Windows.Forms.ToolStrip();
      this.toolsView_itemExport = new System.Windows.Forms.ToolStripButton();
      this.toolsView_itemImport = new System.Windows.Forms.ToolStripButton();
      this.toolsView_itemInsert = new System.Windows.Forms.ToolStripButton();
      this.toolsView_itemDelete = new System.Windows.Forms.ToolStripButton();
      this.toolsView_itemMoveUp = new System.Windows.Forms.ToolStripButton();
      this.toolsView_itemMoveDown = new System.Windows.Forms.ToolStripButton();
      this.toolsView_itemBatchSearch = new System.Windows.Forms.ToolStripButton();
      this.scriptName = new System.Windows.Forms.TextBox();
      this.scriptsEditpr_statusStrip = new System.Windows.Forms.StatusStrip();
      this.scriptsEditor_StatusStrip_itemCharacters = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolsEditor_toolStrip = new System.Windows.Forms.ToolStrip();
      this.toolsEditor_itemSaveProject = new System.Windows.Forms.ToolStripButton();
      this.toolsEditor_itemOpenProject = new System.Windows.Forms.ToolStripButton();
      this.toolsEditor_itemSpecialChars = new System.Windows.Forms.ToolStripButton();
      this.toolsEditor_itemStyleConfig = new System.Windows.Forms.ToolStripButton();
      this.toolsEditor_itemAutoCConfig = new System.Windows.Forms.ToolStripButton();
      this.toolsEditor_itemAutoC = new System.Windows.Forms.ToolStripButton();
      this.toolsEditor_itemAutoIndent = new System.Windows.Forms.ToolStripButton();
      this.toolsEditor_itemIndentGuides = new System.Windows.Forms.ToolStripButton();
      this.toolsEditor_itemFolding = new System.Windows.Forms.ToolStripButton();
      this.toolsEditor_itemHighlight = new System.Windows.Forms.ToolStripButton();
      this.toolsEditor_itemHighlightColor = new System.Windows.Forms.ToolStripButton();
      this.toolsEditor_itemSearch = new System.Windows.Forms.ToolStripButton();
      this.toolsEditor_itemFind = new System.Windows.Forms.ToolStripButton();
      this.toolsEditor_itemReplace = new System.Windows.Forms.ToolStripButton();
      this.toolsEditor_itemGoToLine = new System.Windows.Forms.ToolStripButton();
      this.toolsEditor_itemComment = new System.Windows.Forms.ToolStripButton();
      this.toolsEditor_itemStructureScript = new System.Windows.Forms.ToolStripButton();
      this.toolsEditor_itemRemoveLines = new System.Windows.Forms.ToolStripButton();
      this.toolsEditor_itemRun = new System.Windows.Forms.ToolStripButton();
      this.toolsEditor_itemDebug = new System.Windows.Forms.ToolStripButton();
      this.toolsEditor_itemProjectFolder = new System.Windows.Forms.ToolStripButton();
      this.toolsEditor_itemCloseProject = new System.Windows.Forms.ToolStripButton();
      this.toolTip = new System.Windows.Forms.ToolTip(this.components);
      this.scriptsEditor_ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.scriptsEditor_ToolStripMenuItem_Undo = new System.Windows.Forms.ToolStripMenuItem();
      this.scriptsEditor_ToolStripMenuItem_Redo = new System.Windows.Forms.ToolStripMenuItem();
      this.scriptsEditor_ToolStripMenuItem_Cut = new System.Windows.Forms.ToolStripMenuItem();
      this.scriptsEditor_ToolStripMenuItem_Copy = new System.Windows.Forms.ToolStripMenuItem();
      this.scriptsEditor_ToolStripMenuItem_Paste = new System.Windows.Forms.ToolStripMenuItem();
      this.scriptsEditor_ToolStripMenuItem_Delete = new System.Windows.Forms.ToolStripMenuItem();
      this.scriptsEditor_ToolStripMenuItem_SelectAll = new System.Windows.Forms.ToolStripMenuItem();
      this.scriptsEditor_ToolStripMenuItem_IncrementalSearch = new System.Windows.Forms.ToolStripMenuItem();
      this.scriptsEditor_ToolStripMenuItem_Find = new System.Windows.Forms.ToolStripMenuItem();
      this.scriptsEditor_ToolStripMenuItem_FindNext = new System.Windows.Forms.ToolStripMenuItem();
      this.scriptsEditor_ToolStripMenuItem_FindPrevious = new System.Windows.Forms.ToolStripMenuItem();
      this.scriptsEditor_ToolStripMenuItem_Replace = new System.Windows.Forms.ToolStripMenuItem();
      this.scriptsEditor_ToolStripMenuItem_GoToLine = new System.Windows.Forms.ToolStripMenuItem();
      this.scriptsEditor_ToolStripMenuItem_Comment = new System.Windows.Forms.ToolStripMenuItem();
      this.scriptsEditor_ToolStripMenuItem_AddWordToAutoComplete = new System.Windows.Forms.ToolStripMenuItem();
      this.scriptsFileWatcher = new System.IO.FileSystemWatcher();
      this.splitView = new System.Windows.Forms.SplitContainer();
      this.groupSearches = new System.Windows.Forms.GroupBox();
      this.splitMain = new System.Windows.Forms.SplitContainer();
      this.groupScripts = new System.Windows.Forms.GroupBox();
      this.scriptsEditor_tabs = new Gemini.AdvancedTabControl();
      this.searches_TabControl = new Gemini.AdvancedTabControl();
      this.menuMain_dropAbout_itemUpdate = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropAbout_itemUpdateNow = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropAbout_seperator2 = new System.Windows.Forms.ToolStripSeparator();
      this.menuMain_dropAbout_itemUpdateCheckOn = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMain_dropAbout_itemUpdateCheckOff = new System.Windows.Forms.ToolStripMenuItem();
      menuMain_dropFile_seperator1 = new System.Windows.Forms.ToolStripSeparator();
      menuMain_dropFile_seperator2 = new System.Windows.Forms.ToolStripSeparator();
      menuMain_dropEdit_seperator1 = new System.Windows.Forms.ToolStripSeparator();
      menuMain_dropEdit_seperator2 = new System.Windows.Forms.ToolStripSeparator();
      menuMain_dropEdit_seperator3 = new System.Windows.Forms.ToolStripSeparator();
      menuMain_dropSettings_seperator3 = new System.Windows.Forms.ToolStripSeparator();
      menuMain_dropAbout_seperator1 = new System.Windows.Forms.ToolStripSeparator();
      toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
      toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
      scriptsView_contextMenu_seperator1 = new System.Windows.Forms.ToolStripSeparator();
      scriptsView_contextMenu_seperator2 = new System.Windows.Forms.ToolStripSeparator();
      toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
      toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
      toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
      toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
      toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
      toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
      toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
      toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
      toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
      this.menuMain_menuStrip.SuspendLayout();
      this.scriptsView_contextMenu.SuspendLayout();
      this.toolsView_toolStrip.SuspendLayout();
      this.scriptsEditpr_statusStrip.SuspendLayout();
      this.toolsEditor_toolStrip.SuspendLayout();
      this.scriptsEditor_ContextMenuStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.scriptsFileWatcher)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitView)).BeginInit();
      this.splitView.Panel1.SuspendLayout();
      this.splitView.Panel2.SuspendLayout();
      this.splitView.SuspendLayout();
      this.groupSearches.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
      this.splitMain.Panel1.SuspendLayout();
      this.splitMain.Panel2.SuspendLayout();
      this.splitMain.SuspendLayout();
      this.groupScripts.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuMain_dropFile_seperator1
      // 
      menuMain_dropFile_seperator1.Name = "menuMain_dropFile_seperator1";
      menuMain_dropFile_seperator1.Size = new System.Drawing.Size(180, 6);
      // 
      // menuMain_dropFile_seperator2
      // 
      menuMain_dropFile_seperator2.Name = "menuMain_dropFile_seperator2";
      menuMain_dropFile_seperator2.Size = new System.Drawing.Size(180, 6);
      // 
      // menuMain_dropEdit_seperator1
      // 
      menuMain_dropEdit_seperator1.Name = "menuMain_dropEdit_seperator1";
      menuMain_dropEdit_seperator1.Size = new System.Drawing.Size(210, 6);
      // 
      // menuMain_dropEdit_seperator2
      // 
      menuMain_dropEdit_seperator2.Name = "menuMain_dropEdit_seperator2";
      menuMain_dropEdit_seperator2.Size = new System.Drawing.Size(210, 6);
      // 
      // menuMain_dropEdit_seperator3
      // 
      menuMain_dropEdit_seperator3.Name = "menuMain_dropEdit_seperator3";
      menuMain_dropEdit_seperator3.Size = new System.Drawing.Size(210, 6);
      // 
      // menuMain_dropSettings_seperator3
      // 
      menuMain_dropSettings_seperator3.Name = "menuMain_dropSettings_seperator3";
      menuMain_dropSettings_seperator3.Size = new System.Drawing.Size(197, 6);
      // 
      // menuMain_dropAbout_seperator1
      // 
      menuMain_dropAbout_seperator1.Name = "menuMain_dropAbout_seperator1";
      menuMain_dropAbout_seperator1.Size = new System.Drawing.Size(151, 6);
      // 
      // toolStripSeparator22
      // 
      toolStripSeparator22.Name = "toolStripSeparator22";
      toolStripSeparator22.Size = new System.Drawing.Size(6, 25);
      // 
      // toolStripSeparator20
      // 
      toolStripSeparator20.Name = "toolStripSeparator20";
      toolStripSeparator20.Size = new System.Drawing.Size(6, 25);
      // 
      // scriptsView_contextMenu_seperator1
      // 
      scriptsView_contextMenu_seperator1.Name = "scriptsView_contextMenu_seperator1";
      scriptsView_contextMenu_seperator1.Size = new System.Drawing.Size(197, 6);
      // 
      // scriptsView_contextMenu_seperator2
      // 
      scriptsView_contextMenu_seperator2.Name = "scriptsView_contextMenu_seperator2";
      scriptsView_contextMenu_seperator2.Size = new System.Drawing.Size(197, 6);
      // 
      // toolStripSeparator8
      // 
      toolStripSeparator8.Name = "toolStripSeparator8";
      toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
      // 
      // toolStripSeparator9
      // 
      toolStripSeparator9.Name = "toolStripSeparator9";
      toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
      // 
      // toolStripSeparator10
      // 
      toolStripSeparator10.Name = "toolStripSeparator10";
      toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
      // 
      // toolStripSeparator11
      // 
      toolStripSeparator11.Name = "toolStripSeparator11";
      toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
      // 
      // toolStripSeparator5
      // 
      toolStripSeparator5.Name = "toolStripSeparator5";
      toolStripSeparator5.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
      toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
      // 
      // toolStripSeparator15
      // 
      toolStripSeparator15.Name = "toolStripSeparator15";
      toolStripSeparator15.Size = new System.Drawing.Size(204, 6);
      // 
      // toolStripSeparator14
      // 
      toolStripSeparator14.Name = "toolStripSeparator14";
      toolStripSeparator14.Size = new System.Drawing.Size(204, 6);
      // 
      // toolStripSeparator13
      // 
      toolStripSeparator13.Name = "toolStripSeparator13";
      toolStripSeparator13.Size = new System.Drawing.Size(204, 6);
      // 
      // toolStripSeparator12
      // 
      toolStripSeparator12.Name = "toolStripSeparator12";
      toolStripSeparator12.Size = new System.Drawing.Size(204, 6);
      // 
      // menuMain_menuStrip
      // 
      this.menuMain_menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMain_dropFile,
            this.menuMain_dropEdit,
            this.menuMain_dropSettings,
            this.menuMain_dropGame,
            this.menuMain_dropAbout});
      this.menuMain_menuStrip.Location = new System.Drawing.Point(0, 0);
      this.menuMain_menuStrip.Name = "menuMain_menuStrip";
      this.menuMain_menuStrip.Size = new System.Drawing.Size(784, 24);
      this.menuMain_menuStrip.TabIndex = 0;
      this.menuMain_menuStrip.Text = "mainMenu_MenuStrip";
      // 
      // menuMain_dropFile
      // 
      this.menuMain_dropFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMain_dropFile_itemNew,
            this.menuMain_dropFile_itemOpen,
            this.menuMain_dropFile_itemOpenRecent,
            this.menuMain_dropFile_itemSave,
            this.menuMain_dropFile_itemClose,
            menuMain_dropFile_seperator1,
            this.menuMain_dropFile_itemImport,
            this.menuMain_dropFile_itemExportTo,
            menuMain_dropFile_seperator2,
            this.menuMain_dropFile_itemExit});
      this.menuMain_dropFile.Name = "menuMain_dropFile";
      this.menuMain_dropFile.Size = new System.Drawing.Size(37, 20);
      this.menuMain_dropFile.Text = "File";
      this.menuMain_dropFile.DropDownOpening += new System.EventHandler(this.mainMenu_ToolStripMenuItem_DropDownOpening);
      // 
      // menuMain_dropFile_itemNew
      // 
      this.menuMain_dropFile_itemNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMain_dropFile_itemNewRMXP,
            this.menuMain_dropFile_itemNewRMVX,
            this.menuMain_dropFile_itemNewRMVXAce});
      this.menuMain_dropFile_itemNew.Image = global::Gemini.Properties.Resources.file;
      this.menuMain_dropFile_itemNew.Name = "menuMain_dropFile_itemNew";
      this.menuMain_dropFile_itemNew.Size = new System.Drawing.Size(183, 22);
      this.menuMain_dropFile_itemNew.Text = "New Project";
      this.menuMain_dropFile_itemNew.ToolTipText = "Create a new RPG Maker project";
      // 
      // menuMain_dropFile_itemNewRMXP
      // 
      this.menuMain_dropFile_itemNewRMXP.Image = global::Gemini.Properties.Resources.rmxp_icon;
      this.menuMain_dropFile_itemNewRMXP.Name = "menuMain_dropFile_itemNewRMXP";
      this.menuMain_dropFile_itemNewRMXP.Size = new System.Drawing.Size(167, 22);
      this.menuMain_dropFile_itemNewRMXP.Text = "RPG Maker XP";
      this.menuMain_dropFile_itemNewRMXP.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_NewProjectRMXP_Click);
      // 
      // menuMain_dropFile_itemNewRMVX
      // 
      this.menuMain_dropFile_itemNewRMVX.Image = global::Gemini.Properties.Resources.rmvx_icon;
      this.menuMain_dropFile_itemNewRMVX.Name = "menuMain_dropFile_itemNewRMVX";
      this.menuMain_dropFile_itemNewRMVX.Size = new System.Drawing.Size(167, 22);
      this.menuMain_dropFile_itemNewRMVX.Text = "RPG Maker VX";
      this.menuMain_dropFile_itemNewRMVX.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_NewProjectRMVX_Click);
      // 
      // menuMain_dropFile_itemNewRMVXAce
      // 
      this.menuMain_dropFile_itemNewRMVXAce.Image = global::Gemini.Properties.Resources.rmvxace_icon;
      this.menuMain_dropFile_itemNewRMVXAce.Name = "menuMain_dropFile_itemNewRMVXAce";
      this.menuMain_dropFile_itemNewRMVXAce.Size = new System.Drawing.Size(167, 22);
      this.menuMain_dropFile_itemNewRMVXAce.Text = "RPG Maker VX Ace";
      this.menuMain_dropFile_itemNewRMVXAce.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_NewProjectRMVXAce_Click);
      // 
      // menuMain_dropFile_itemOpen
      // 
      this.menuMain_dropFile_itemOpen.Image = global::Gemini.Properties.Resources.open_file;
      this.menuMain_dropFile_itemOpen.Name = "menuMain_dropFile_itemOpen";
      this.menuMain_dropFile_itemOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.menuMain_dropFile_itemOpen.Size = new System.Drawing.Size(183, 22);
      this.menuMain_dropFile_itemOpen.Text = "Open Project";
      this.menuMain_dropFile_itemOpen.ToolTipText = "Open a recent or an existing project";
      this.menuMain_dropFile_itemOpen.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_OpenProject_Click);
      // 
      // menuMain_dropFile_itemOpenRecent
      // 
      this.menuMain_dropFile_itemOpenRecent.Image = global::Gemini.Properties.Resources.history;
      this.menuMain_dropFile_itemOpenRecent.Name = "menuMain_dropFile_itemOpenRecent";
      this.menuMain_dropFile_itemOpenRecent.Size = new System.Drawing.Size(183, 22);
      this.menuMain_dropFile_itemOpenRecent.Text = "Open Recent...";
      // 
      // menuMain_dropFile_itemSave
      // 
      this.menuMain_dropFile_itemSave.Image = global::Gemini.Properties.Resources.save;
      this.menuMain_dropFile_itemSave.Name = "menuMain_dropFile_itemSave";
      this.menuMain_dropFile_itemSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.menuMain_dropFile_itemSave.Size = new System.Drawing.Size(183, 22);
      this.menuMain_dropFile_itemSave.Text = "Save Project";
      this.menuMain_dropFile_itemSave.ToolTipText = "Save the current project";
      this.menuMain_dropFile_itemSave.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_SaveProject_Click);
      // 
      // menuMain_dropFile_itemClose
      // 
      this.menuMain_dropFile_itemClose.Image = global::Gemini.Properties.Resources.close;
      this.menuMain_dropFile_itemClose.Name = "menuMain_dropFile_itemClose";
      this.menuMain_dropFile_itemClose.Size = new System.Drawing.Size(183, 22);
      this.menuMain_dropFile_itemClose.Text = "Close Project";
      this.menuMain_dropFile_itemClose.ToolTipText = "Close the current project";
      this.menuMain_dropFile_itemClose.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_CloseProject_Click);
      // 
      // menuMain_dropFile_itemImport
      // 
      this.menuMain_dropFile_itemImport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultFolderToolStripMenuItem,
            this.browseToolStripMenuItem});
      this.menuMain_dropFile_itemImport.Image = global::Gemini.Properties.Resources.import;
      this.menuMain_dropFile_itemImport.Name = "menuMain_dropFile_itemImport";
      this.menuMain_dropFile_itemImport.Size = new System.Drawing.Size(183, 22);
      this.menuMain_dropFile_itemImport.Text = "Import Scripts from...";
      this.menuMain_dropFile_itemImport.ToolTipText = "Quick Import from Scripts Folder";
      // 
      // defaultFolderToolStripMenuItem
      // 
      this.defaultFolderToolStripMenuItem.Image = global::Gemini.Properties.Resources.folder_closed;
      this.defaultFolderToolStripMenuItem.Name = "defaultFolderToolStripMenuItem";
      this.defaultFolderToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.defaultFolderToolStripMenuItem.Text = "Default Folder";
      this.defaultFolderToolStripMenuItem.Click += new System.EventHandler(this.menuMain_dropFile_itemImportScripts_Click);
      // 
      // browseToolStripMenuItem
      // 
      this.browseToolStripMenuItem.Image = global::Gemini.Properties.Resources.folder_open;
      this.browseToolStripMenuItem.Name = "browseToolStripMenuItem";
      this.browseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.browseToolStripMenuItem.Text = "Browse";
      this.browseToolStripMenuItem.Click += new System.EventHandler(this.menuMain_dropFile_itemImportScriptsFrom_Click);
      // 
      // menuMain_dropFile_itemExportTo
      // 
      this.menuMain_dropFile_itemExportTo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMain_dropFile_itemExportToFolder,
            this.menuMain_dropFile_itemExoprtToRMData,
            this.menuMain_dropFile_itemExportToText,
            this.menuMain_dropFile_itemExportToRuby});
      this.menuMain_dropFile_itemExportTo.Image = global::Gemini.Properties.Resources.export;
      this.menuMain_dropFile_itemExportTo.Name = "menuMain_dropFile_itemExportTo";
      this.menuMain_dropFile_itemExportTo.Size = new System.Drawing.Size(183, 22);
      this.menuMain_dropFile_itemExportTo.Text = "Export Scripts to...";
      this.menuMain_dropFile_itemExportTo.ToolTipText = "Export scripts to external files";
      // 
      // menuMain_dropFile_itemExportToFolder
      // 
      this.menuMain_dropFile_itemExportToFolder.Image = global::Gemini.Properties.Resources.folder_closed;
      this.menuMain_dropFile_itemExportToFolder.Name = "menuMain_dropFile_itemExportToFolder";
      this.menuMain_dropFile_itemExportToFolder.Size = new System.Drawing.Size(154, 22);
      this.menuMain_dropFile_itemExportToFolder.Text = "Default Folder";
      this.menuMain_dropFile_itemExportToFolder.Click += new System.EventHandler(this.menuMain_dropFile_itemExport_Click);
      // 
      // menuMain_dropFile_itemExoprtToRMData
      // 
      this.menuMain_dropFile_itemExoprtToRMData.Name = "menuMain_dropFile_itemExoprtToRMData";
      this.menuMain_dropFile_itemExoprtToRMData.Size = new System.Drawing.Size(154, 22);
      this.menuMain_dropFile_itemExoprtToRMData.Text = "RM Data File";
      this.menuMain_dropFile_itemExoprtToRMData.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_ExportScriptsRMData_Click);
      // 
      // menuMain_dropFile_itemExportToText
      // 
      this.menuMain_dropFile_itemExportToText.Image = global::Gemini.Properties.Resources.text_icon;
      this.menuMain_dropFile_itemExportToText.Name = "menuMain_dropFile_itemExportToText";
      this.menuMain_dropFile_itemExportToText.Size = new System.Drawing.Size(154, 22);
      this.menuMain_dropFile_itemExportToText.Text = "Text Documents";
      this.menuMain_dropFile_itemExportToText.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_ExportScriptsText_Click);
      // 
      // menuMain_dropFile_itemExportToRuby
      // 
      this.menuMain_dropFile_itemExportToRuby.Image = global::Gemini.Properties.Resources.ruby_icon;
      this.menuMain_dropFile_itemExportToRuby.Name = "menuMain_dropFile_itemExportToRuby";
      this.menuMain_dropFile_itemExportToRuby.Size = new System.Drawing.Size(154, 22);
      this.menuMain_dropFile_itemExportToRuby.Text = "Ruby Scripts";
      this.menuMain_dropFile_itemExportToRuby.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_ExportScriptsRuby_Click);
      // 
      // menuMain_dropFile_itemExit
      // 
      this.menuMain_dropFile_itemExit.Image = global::Gemini.Properties.Resources.exit;
      this.menuMain_dropFile_itemExit.Name = "menuMain_dropFile_itemExit";
      this.menuMain_dropFile_itemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
      this.menuMain_dropFile_itemExit.Size = new System.Drawing.Size(183, 22);
      this.menuMain_dropFile_itemExit.Text = "Exit";
      this.menuMain_dropFile_itemExit.ToolTipText = "Exit Gemini";
      this.menuMain_dropFile_itemExit.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_Exit_Click);
      // 
      // menuMain_dropEdit
      // 
      this.menuMain_dropEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMain_dropEdit_itemUndo,
            this.menuMain_dropEdit_itemRedo,
            menuMain_dropEdit_seperator1,
            this.menuMain_dropEdit_itemCut,
            this.menuMain_dropEdit_itemCopy,
            this.menuMain_dropEdit_itemPaste,
            this.menuMain_dropEdit_itemDelete,
            this.menuMain_dropEdit_itemSelectAll,
            menuMain_dropEdit_seperator2,
            this.menuMain_dropEdit_itemBatchSearch,
            this.menuMain_dropEdit_itemIncrementalSearch,
            this.menuMain_dropEdit_itemFind,
            this.menuMain_dropEdit_itemReplace,
            this.menuMain_dropEdit_itemGoTo,
            menuMain_dropEdit_seperator3,
            this.menuMain_dropEdit_itemBatchComment,
            this.menuMain_dropEdit_itemStructureScript,
            this.menuMain_dropEdit_itemRemoveEmpty});
      this.menuMain_dropEdit.Name = "menuMain_dropEdit";
      this.menuMain_dropEdit.Size = new System.Drawing.Size(39, 20);
      this.menuMain_dropEdit.Text = "Edit";
      this.menuMain_dropEdit.DropDownOpening += new System.EventHandler(this.mainMenu_ToolStripMenuItem_DropDownOpening);
      // 
      // menuMain_dropEdit_itemUndo
      // 
      this.menuMain_dropEdit_itemUndo.Image = global::Gemini.Properties.Resources.undo;
      this.menuMain_dropEdit_itemUndo.Name = "menuMain_dropEdit_itemUndo";
      this.menuMain_dropEdit_itemUndo.ShortcutKeyDisplayString = "Ctrl + Z";
      this.menuMain_dropEdit_itemUndo.Size = new System.Drawing.Size(213, 22);
      this.menuMain_dropEdit_itemUndo.Text = "Undo";
      this.menuMain_dropEdit_itemUndo.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_Undo_Click);
      // 
      // menuMain_dropEdit_itemRedo
      // 
      this.menuMain_dropEdit_itemRedo.Image = global::Gemini.Properties.Resources.redo;
      this.menuMain_dropEdit_itemRedo.Name = "menuMain_dropEdit_itemRedo";
      this.menuMain_dropEdit_itemRedo.ShortcutKeyDisplayString = "Ctrl + Y";
      this.menuMain_dropEdit_itemRedo.Size = new System.Drawing.Size(213, 22);
      this.menuMain_dropEdit_itemRedo.Text = "Redo";
      this.menuMain_dropEdit_itemRedo.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_Redo_Click);
      // 
      // menuMain_dropEdit_itemCut
      // 
      this.menuMain_dropEdit_itemCut.Image = global::Gemini.Properties.Resources.cut;
      this.menuMain_dropEdit_itemCut.Name = "menuMain_dropEdit_itemCut";
      this.menuMain_dropEdit_itemCut.ShortcutKeyDisplayString = "Ctrl + X";
      this.menuMain_dropEdit_itemCut.Size = new System.Drawing.Size(213, 22);
      this.menuMain_dropEdit_itemCut.Text = "Cut";
      this.menuMain_dropEdit_itemCut.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_Cut_Click);
      // 
      // menuMain_dropEdit_itemCopy
      // 
      this.menuMain_dropEdit_itemCopy.Image = global::Gemini.Properties.Resources.copy;
      this.menuMain_dropEdit_itemCopy.Name = "menuMain_dropEdit_itemCopy";
      this.menuMain_dropEdit_itemCopy.ShortcutKeyDisplayString = "Ctrl + C";
      this.menuMain_dropEdit_itemCopy.Size = new System.Drawing.Size(213, 22);
      this.menuMain_dropEdit_itemCopy.Text = "Copy";
      this.menuMain_dropEdit_itemCopy.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_Copy_Click);
      // 
      // menuMain_dropEdit_itemPaste
      // 
      this.menuMain_dropEdit_itemPaste.Image = global::Gemini.Properties.Resources.paste;
      this.menuMain_dropEdit_itemPaste.Name = "menuMain_dropEdit_itemPaste";
      this.menuMain_dropEdit_itemPaste.ShortcutKeyDisplayString = "Ctrl + V";
      this.menuMain_dropEdit_itemPaste.Size = new System.Drawing.Size(213, 22);
      this.menuMain_dropEdit_itemPaste.Text = "Paste";
      this.menuMain_dropEdit_itemPaste.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_Paste_Click);
      // 
      // menuMain_dropEdit_itemDelete
      // 
      this.menuMain_dropEdit_itemDelete.Image = global::Gemini.Properties.Resources.delete_alt;
      this.menuMain_dropEdit_itemDelete.Name = "menuMain_dropEdit_itemDelete";
      this.menuMain_dropEdit_itemDelete.ShortcutKeyDisplayString = "Suppr";
      this.menuMain_dropEdit_itemDelete.Size = new System.Drawing.Size(213, 22);
      this.menuMain_dropEdit_itemDelete.Text = "Delete";
      this.menuMain_dropEdit_itemDelete.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_Delete_Click);
      // 
      // menuMain_dropEdit_itemSelectAll
      // 
      this.menuMain_dropEdit_itemSelectAll.Image = global::Gemini.Properties.Resources.select_all;
      this.menuMain_dropEdit_itemSelectAll.Name = "menuMain_dropEdit_itemSelectAll";
      this.menuMain_dropEdit_itemSelectAll.ShortcutKeyDisplayString = "Ctrl + A";
      this.menuMain_dropEdit_itemSelectAll.Size = new System.Drawing.Size(213, 22);
      this.menuMain_dropEdit_itemSelectAll.Text = "Select All";
      this.menuMain_dropEdit_itemSelectAll.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_SelectAll_Click);
      // 
      // menuMain_dropEdit_itemBatchSearch
      // 
      this.menuMain_dropEdit_itemBatchSearch.Image = global::Gemini.Properties.Resources.find3;
      this.menuMain_dropEdit_itemBatchSearch.Name = "menuMain_dropEdit_itemBatchSearch";
      this.menuMain_dropEdit_itemBatchSearch.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.F)));
      this.menuMain_dropEdit_itemBatchSearch.Size = new System.Drawing.Size(213, 22);
      this.menuMain_dropEdit_itemBatchSearch.Text = "Batch Search";
      this.menuMain_dropEdit_itemBatchSearch.Visible = false;
      this.menuMain_dropEdit_itemBatchSearch.Click += new System.EventHandler(this.scriptsView_contextMenu_itemBatchSearch_Click);
      // 
      // menuMain_dropEdit_itemIncrementalSearch
      // 
      this.menuMain_dropEdit_itemIncrementalSearch.Image = global::Gemini.Properties.Resources.find2;
      this.menuMain_dropEdit_itemIncrementalSearch.Name = "menuMain_dropEdit_itemIncrementalSearch";
      this.menuMain_dropEdit_itemIncrementalSearch.ShortcutKeyDisplayString = "Ctrl + I";
      this.menuMain_dropEdit_itemIncrementalSearch.Size = new System.Drawing.Size(213, 22);
      this.menuMain_dropEdit_itemIncrementalSearch.Text = "Incremental Search";
      this.menuMain_dropEdit_itemIncrementalSearch.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_IncrementalSearch_Click);
      // 
      // menuMain_dropEdit_itemFind
      // 
      this.menuMain_dropEdit_itemFind.Image = global::Gemini.Properties.Resources.find;
      this.menuMain_dropEdit_itemFind.Name = "menuMain_dropEdit_itemFind";
      this.menuMain_dropEdit_itemFind.ShortcutKeyDisplayString = "Ctrl + F";
      this.menuMain_dropEdit_itemFind.Size = new System.Drawing.Size(213, 22);
      this.menuMain_dropEdit_itemFind.Text = "Find";
      this.menuMain_dropEdit_itemFind.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_Find_Click);
      // 
      // menuMain_dropEdit_itemReplace
      // 
      this.menuMain_dropEdit_itemReplace.Image = global::Gemini.Properties.Resources.replace;
      this.menuMain_dropEdit_itemReplace.Name = "menuMain_dropEdit_itemReplace";
      this.menuMain_dropEdit_itemReplace.ShortcutKeyDisplayString = "Ctrl + H";
      this.menuMain_dropEdit_itemReplace.Size = new System.Drawing.Size(213, 22);
      this.menuMain_dropEdit_itemReplace.Text = "Replace";
      this.menuMain_dropEdit_itemReplace.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_Replace_Click);
      // 
      // menuMain_dropEdit_itemGoTo
      // 
      this.menuMain_dropEdit_itemGoTo.Image = ((System.Drawing.Image)(resources.GetObject("menuMain_dropEdit_itemGoTo.Image")));
      this.menuMain_dropEdit_itemGoTo.Name = "menuMain_dropEdit_itemGoTo";
      this.menuMain_dropEdit_itemGoTo.ShortcutKeyDisplayString = "Ctrl + G";
      this.menuMain_dropEdit_itemGoTo.Size = new System.Drawing.Size(213, 22);
      this.menuMain_dropEdit_itemGoTo.Text = "Go To Line";
      this.menuMain_dropEdit_itemGoTo.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_GoToLine_Click);
      // 
      // menuMain_dropEdit_itemBatchComment
      // 
      this.menuMain_dropEdit_itemBatchComment.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMain_dropEdit_itemToggleComment,
            this.menuMain_dropEdit_itemComment,
            this.menuMain_dropEdit_itemUnComment});
      this.menuMain_dropEdit_itemBatchComment.Image = global::Gemini.Properties.Resources.comment;
      this.menuMain_dropEdit_itemBatchComment.Name = "menuMain_dropEdit_itemBatchComment";
      this.menuMain_dropEdit_itemBatchComment.Size = new System.Drawing.Size(213, 22);
      this.menuMain_dropEdit_itemBatchComment.Text = "Batch Comment Selection";
      this.menuMain_dropEdit_itemBatchComment.ToolTipText = "Comment selected lines";
      // 
      // menuMain_dropEdit_itemToggleComment
      // 
      this.menuMain_dropEdit_itemToggleComment.Name = "menuMain_dropEdit_itemToggleComment";
      this.menuMain_dropEdit_itemToggleComment.ShortcutKeyDisplayString = "Ctrl + Q";
      this.menuMain_dropEdit_itemToggleComment.Size = new System.Drawing.Size(155, 22);
      this.menuMain_dropEdit_itemToggleComment.Text = "Toggle";
      this.menuMain_dropEdit_itemToggleComment.ToolTipText = "Toggle comment on selected lines";
      this.menuMain_dropEdit_itemToggleComment.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_ToggleComment_Click);
      // 
      // menuMain_dropEdit_itemComment
      // 
      this.menuMain_dropEdit_itemComment.Name = "menuMain_dropEdit_itemComment";
      this.menuMain_dropEdit_itemComment.Size = new System.Drawing.Size(155, 22);
      this.menuMain_dropEdit_itemComment.Text = "Comment";
      this.menuMain_dropEdit_itemComment.ToolTipText = "Add comment on selected lines";
      this.menuMain_dropEdit_itemComment.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_Comment_Click);
      // 
      // menuMain_dropEdit_itemUnComment
      // 
      this.menuMain_dropEdit_itemUnComment.Name = "menuMain_dropEdit_itemUnComment";
      this.menuMain_dropEdit_itemUnComment.Size = new System.Drawing.Size(155, 22);
      this.menuMain_dropEdit_itemUnComment.Text = "Uncomment";
      this.menuMain_dropEdit_itemUnComment.ToolTipText = "Remove comment on selected lines";
      this.menuMain_dropEdit_itemUnComment.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_UnComment_Click);
      // 
      // menuMain_dropEdit_itemStructureScript
      // 
      this.menuMain_dropEdit_itemStructureScript.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMain_dropEdit_itemSScriptCurrent,
            this.menuMain_dropEdit_itemSScriptOpen,
            this.menuMain_dropEdit_itemSScriptAll});
      this.menuMain_dropEdit_itemStructureScript.Image = global::Gemini.Properties.Resources.outline;
      this.menuMain_dropEdit_itemStructureScript.Name = "menuMain_dropEdit_itemStructureScript";
      this.menuMain_dropEdit_itemStructureScript.Size = new System.Drawing.Size(213, 22);
      this.menuMain_dropEdit_itemStructureScript.Text = "Structure Script";
      this.menuMain_dropEdit_itemStructureScript.ToolTipText = "Apply proper structure to script";
      // 
      // menuMain_dropEdit_itemSScriptCurrent
      // 
      this.menuMain_dropEdit_itemSScriptCurrent.Name = "menuMain_dropEdit_itemSScriptCurrent";
      this.menuMain_dropEdit_itemSScriptCurrent.Size = new System.Drawing.Size(113, 22);
      this.menuMain_dropEdit_itemSScriptCurrent.Text = "Current";
      this.menuMain_dropEdit_itemSScriptCurrent.ToolTipText = "Current script";
      this.menuMain_dropEdit_itemSScriptCurrent.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_StructureScriptCurrent_Click);
      // 
      // menuMain_dropEdit_itemSScriptOpen
      // 
      this.menuMain_dropEdit_itemSScriptOpen.Name = "menuMain_dropEdit_itemSScriptOpen";
      this.menuMain_dropEdit_itemSScriptOpen.Size = new System.Drawing.Size(113, 22);
      this.menuMain_dropEdit_itemSScriptOpen.Text = "Open";
      this.menuMain_dropEdit_itemSScriptOpen.ToolTipText = "All scripts open in the tab control";
      this.menuMain_dropEdit_itemSScriptOpen.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_StructureScriptOpen_Click);
      // 
      // menuMain_dropEdit_itemSScriptAll
      // 
      this.menuMain_dropEdit_itemSScriptAll.Name = "menuMain_dropEdit_itemSScriptAll";
      this.menuMain_dropEdit_itemSScriptAll.Size = new System.Drawing.Size(113, 22);
      this.menuMain_dropEdit_itemSScriptAll.Text = "All";
      this.menuMain_dropEdit_itemSScriptAll.ToolTipText = "All loaded scripts";
      this.menuMain_dropEdit_itemSScriptAll.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_StructureScriptAll_Click);
      // 
      // menuMain_dropEdit_itemRemoveEmpty
      // 
      this.menuMain_dropEdit_itemRemoveEmpty.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMain_dropEdit_itemRemoveEmptyCurrent,
            this.menuMain_dropEdit_itemRemoveEmptyOpen,
            this.menuMain_dropEdit_itemRemoveEmptyAll});
      this.menuMain_dropEdit_itemRemoveEmpty.Image = global::Gemini.Properties.Resources.emptyspace;
      this.menuMain_dropEdit_itemRemoveEmpty.Name = "menuMain_dropEdit_itemRemoveEmpty";
      this.menuMain_dropEdit_itemRemoveEmpty.Size = new System.Drawing.Size(213, 22);
      this.menuMain_dropEdit_itemRemoveEmpty.Text = "Remove Empty Lines";
      this.menuMain_dropEdit_itemRemoveEmpty.ToolTipText = "Remove Empty Lines";
      // 
      // menuMain_dropEdit_itemRemoveEmptyCurrent
      // 
      this.menuMain_dropEdit_itemRemoveEmptyCurrent.Name = "menuMain_dropEdit_itemRemoveEmptyCurrent";
      this.menuMain_dropEdit_itemRemoveEmptyCurrent.Size = new System.Drawing.Size(113, 22);
      this.menuMain_dropEdit_itemRemoveEmptyCurrent.Text = "Current";
      this.menuMain_dropEdit_itemRemoveEmptyCurrent.ToolTipText = "Current script";
      this.menuMain_dropEdit_itemRemoveEmptyCurrent.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_RemoveEmptyLinesCurrent_Click);
      // 
      // menuMain_dropEdit_itemRemoveEmptyOpen
      // 
      this.menuMain_dropEdit_itemRemoveEmptyOpen.Name = "menuMain_dropEdit_itemRemoveEmptyOpen";
      this.menuMain_dropEdit_itemRemoveEmptyOpen.Size = new System.Drawing.Size(113, 22);
      this.menuMain_dropEdit_itemRemoveEmptyOpen.Text = "Open";
      this.menuMain_dropEdit_itemRemoveEmptyOpen.ToolTipText = "All scripts open in the tab control";
      this.menuMain_dropEdit_itemRemoveEmptyOpen.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_RemoveEmptyLinesOpen_Click);
      // 
      // menuMain_dropEdit_itemRemoveEmptyAll
      // 
      this.menuMain_dropEdit_itemRemoveEmptyAll.Name = "menuMain_dropEdit_itemRemoveEmptyAll";
      this.menuMain_dropEdit_itemRemoveEmptyAll.Size = new System.Drawing.Size(113, 22);
      this.menuMain_dropEdit_itemRemoveEmptyAll.Text = "All";
      this.menuMain_dropEdit_itemRemoveEmptyAll.ToolTipText = "All loaded scripts";
      this.menuMain_dropEdit_itemRemoveEmptyAll.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_RemoveEmptyLinesAll_Click);
      // 
      // menuMain_dropSettings
      // 
      this.menuMain_dropSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMain_dropSettings_itemAutoOpenProject,
            this.toolStripSeparator1,
            this.menuMain_dropSettings_itemMinimalView,
            this.menuMain_dropSettings_itemHideScripts,
            this.menuMain_dropSettings_itemMenuVisible,
            this.menuMain_dropSettings_seperator1,
            this.menuMain_dropSettings_itemUpdateSections,
            this.menuMain_dropSettings_itemCustomRuntime,
            this.menuMain_dropSettings_seperator2,
            this.menuMain_dropSettings_itemStylesConfig,
            this.menuMain_dropSettings_itemAutoCConfig,
            menuMain_dropSettings_seperator3,
            this.menuMain_dropSettings_itemAutoC,
            this.menuMain_dropSettings_itemAutoIndent,
            this.menuMain_dropSettings_itemIndentGuides,
            this.menuMain_dropSettings_itemFolding,
            this.menuMain_dropSettings_itemHighlight,
            this.menuMain_dropSettings_seperator4,
            this.menuMain_dropSettings_itemSaveSettings,
            this.menuMain_dropSettings_itemClearSettings});
      this.menuMain_dropSettings.Name = "menuMain_dropSettings";
      this.menuMain_dropSettings.Size = new System.Drawing.Size(61, 20);
      this.menuMain_dropSettings.Text = "Settings";
      // 
      // menuMain_dropSettings_itemAutoOpenProject
      // 
      this.menuMain_dropSettings_itemAutoOpenProject.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMain_dropSettings_itemPioritizeRecent});
      this.menuMain_dropSettings_itemAutoOpenProject.Image = global::Gemini.Properties.Resources.history;
      this.menuMain_dropSettings_itemAutoOpenProject.Name = "menuMain_dropSettings_itemAutoOpenProject";
      this.menuMain_dropSettings_itemAutoOpenProject.Size = new System.Drawing.Size(200, 22);
      this.menuMain_dropSettings_itemAutoOpenProject.Text = "Auto-Open";
      this.menuMain_dropSettings_itemAutoOpenProject.ToolTipText = "Toggle auto loading of either the first local project or the last used project on" +
    " start";
      this.menuMain_dropSettings_itemAutoOpenProject.Click += new System.EventHandler(this.menuMain_dropSettings_itemAutoOpenProject_Click);
      // 
      // menuMain_dropSettings_itemPioritizeRecent
      // 
      this.menuMain_dropSettings_itemPioritizeRecent.Name = "menuMain_dropSettings_itemPioritizeRecent";
      this.menuMain_dropSettings_itemPioritizeRecent.Size = new System.Drawing.Size(200, 22);
      this.menuMain_dropSettings_itemPioritizeRecent.Text = "Prioritize Recent Projects";
      this.menuMain_dropSettings_itemPioritizeRecent.ToolTipText = "Recent projects takes priority and are checked before local projects";
      this.menuMain_dropSettings_itemPioritizeRecent.Click += new System.EventHandler(this.menuMain_dropSettings_itemPioritizeRecent_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(197, 6);
      // 
      // menuMain_dropSettings_itemMinimalView
      // 
      this.menuMain_dropSettings_itemMinimalView.Name = "menuMain_dropSettings_itemMinimalView";
      this.menuMain_dropSettings_itemMinimalView.ShortcutKeyDisplayString = "";
      this.menuMain_dropSettings_itemMinimalView.ShortcutKeys = System.Windows.Forms.Keys.F6;
      this.menuMain_dropSettings_itemMinimalView.Size = new System.Drawing.Size(200, 22);
      this.menuMain_dropSettings_itemMinimalView.Text = "Minimalistic View";
      this.menuMain_dropSettings_itemMinimalView.ToolTipText = "Hides the Scripts View and Editor Toolbar";
      this.menuMain_dropSettings_itemMinimalView.Click += new System.EventHandler(this.menuMain_dropSettings_itemShowScripts_Click);
      // 
      // menuMain_dropSettings_itemHideScripts
      // 
      this.menuMain_dropSettings_itemHideScripts.Name = "menuMain_dropSettings_itemHideScripts";
      this.menuMain_dropSettings_itemHideScripts.ShortcutKeys = System.Windows.Forms.Keys.F7;
      this.menuMain_dropSettings_itemHideScripts.Size = new System.Drawing.Size(200, 22);
      this.menuMain_dropSettings_itemHideScripts.Text = "Always show toolbar";
      this.menuMain_dropSettings_itemHideScripts.ToolTipText = "Always show the Editor Toolbar";
      this.menuMain_dropSettings_itemHideScripts.Click += new System.EventHandler(this.menuMain_dropSettings_itemHideScripts_Click);
      // 
      // menuMain_dropSettings_itemMenuVisible
      // 
      this.menuMain_dropSettings_itemMenuVisible.Name = "menuMain_dropSettings_itemMenuVisible";
      this.menuMain_dropSettings_itemMenuVisible.ShortcutKeyDisplayString = " Alt";
      this.menuMain_dropSettings_itemMenuVisible.Size = new System.Drawing.Size(200, 22);
      this.menuMain_dropSettings_itemMenuVisible.Text = "Show MenuStrip";
      this.menuMain_dropSettings_itemMenuVisible.Click += new System.EventHandler(this.menuMain_dropSetting_itemMenuVisible_Click);
      // 
      // menuMain_dropSettings_seperator1
      // 
      this.menuMain_dropSettings_seperator1.Name = "menuMain_dropSettings_seperator1";
      this.menuMain_dropSettings_seperator1.Size = new System.Drawing.Size(197, 6);
      // 
      // menuMain_dropSettings_itemUpdateSections
      // 
      this.menuMain_dropSettings_itemUpdateSections.Image = global::Gemini.Properties.Resources.select_all;
      this.menuMain_dropSettings_itemUpdateSections.Name = "menuMain_dropSettings_itemUpdateSections";
      this.menuMain_dropSettings_itemUpdateSections.Size = new System.Drawing.Size(200, 22);
      this.menuMain_dropSettings_itemUpdateSections.Text = "Update Sections";
      this.menuMain_dropSettings_itemUpdateSections.Click += new System.EventHandler(this.menuMain_dropSettings_itemUpdateSections_Click);
      // 
      // menuMain_dropSettings_itemCustomRuntime
      // 
      this.menuMain_dropSettings_itemCustomRuntime.Image = global::Gemini.Properties.Resources.play;
      this.menuMain_dropSettings_itemCustomRuntime.Name = "menuMain_dropSettings_itemCustomRuntime";
      this.menuMain_dropSettings_itemCustomRuntime.Size = new System.Drawing.Size(200, 22);
      this.menuMain_dropSettings_itemCustomRuntime.Text = "Custom Runtime";
      this.menuMain_dropSettings_itemCustomRuntime.Click += new System.EventHandler(this.menuMain_dropGame_itemCustomRuntime_Click);
      // 
      // menuMain_dropSettings_seperator2
      // 
      this.menuMain_dropSettings_seperator2.Name = "menuMain_dropSettings_seperator2";
      this.menuMain_dropSettings_seperator2.Size = new System.Drawing.Size(197, 6);
      // 
      // menuMain_dropSettings_itemStylesConfig
      // 
      this.menuMain_dropSettings_itemStylesConfig.Image = global::Gemini.Properties.Resources.theme;
      this.menuMain_dropSettings_itemStylesConfig.Name = "menuMain_dropSettings_itemStylesConfig";
      this.menuMain_dropSettings_itemStylesConfig.Size = new System.Drawing.Size(200, 22);
      this.menuMain_dropSettings_itemStylesConfig.Text = "Styles Configuration";
      this.menuMain_dropSettings_itemStylesConfig.ToolTipText = "Edit the styles of the editor";
      this.menuMain_dropSettings_itemStylesConfig.Click += new System.EventHandler(this.menuMain_dropSettings_itemStylesConfig_Click);
      // 
      // menuMain_dropSettings_itemAutoCConfig
      // 
      this.menuMain_dropSettings_itemAutoCConfig.Image = global::Gemini.Properties.Resources.tool;
      this.menuMain_dropSettings_itemAutoCConfig.Name = "menuMain_dropSettings_itemAutoCConfig";
      this.menuMain_dropSettings_itemAutoCConfig.Size = new System.Drawing.Size(200, 22);
      this.menuMain_dropSettings_itemAutoCConfig.Text = "Auto-Complete Settings";
      this.menuMain_dropSettings_itemAutoCConfig.ToolTipText = "Configure how the auto-complete bahaves";
      this.menuMain_dropSettings_itemAutoCConfig.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_AutoCompleteConfig_Click);
      // 
      // menuMain_dropSettings_itemAutoC
      // 
      this.menuMain_dropSettings_itemAutoC.Image = global::Gemini.Properties.Resources.text_complete;
      this.menuMain_dropSettings_itemAutoC.Name = "menuMain_dropSettings_itemAutoC";
      this.menuMain_dropSettings_itemAutoC.Size = new System.Drawing.Size(200, 22);
      this.menuMain_dropSettings_itemAutoC.Text = "Auto-Complete";
      this.menuMain_dropSettings_itemAutoC.ToolTipText = "Toggle Auto-Complete";
      this.menuMain_dropSettings_itemAutoC.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_AutoComplete_Click);
      // 
      // menuMain_dropSettings_itemAutoIndent
      // 
      this.menuMain_dropSettings_itemAutoIndent.Image = global::Gemini.Properties.Resources.indent;
      this.menuMain_dropSettings_itemAutoIndent.Name = "menuMain_dropSettings_itemAutoIndent";
      this.menuMain_dropSettings_itemAutoIndent.Size = new System.Drawing.Size(200, 22);
      this.menuMain_dropSettings_itemAutoIndent.Text = "Auto-Indentation";
      this.menuMain_dropSettings_itemAutoIndent.ToolTipText = "Toggle Auto-Indentation";
      this.menuMain_dropSettings_itemAutoIndent.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_AutoIndent_Click);
      // 
      // menuMain_dropSettings_itemIndentGuides
      // 
      this.menuMain_dropSettings_itemIndentGuides.Image = global::Gemini.Properties.Resources.ruler;
      this.menuMain_dropSettings_itemIndentGuides.Name = "menuMain_dropSettings_itemIndentGuides";
      this.menuMain_dropSettings_itemIndentGuides.Size = new System.Drawing.Size(200, 22);
      this.menuMain_dropSettings_itemIndentGuides.Text = "Indent Guides";
      this.menuMain_dropSettings_itemIndentGuides.ToolTipText = "Toggle Indent Guides";
      this.menuMain_dropSettings_itemIndentGuides.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_IndentGuides_Click);
      // 
      // menuMain_dropSettings_itemFolding
      // 
      this.menuMain_dropSettings_itemFolding.Image = global::Gemini.Properties.Resources.fold;
      this.menuMain_dropSettings_itemFolding.Name = "menuMain_dropSettings_itemFolding";
      this.menuMain_dropSettings_itemFolding.Size = new System.Drawing.Size(200, 22);
      this.menuMain_dropSettings_itemFolding.Text = "Code Folding";
      this.menuMain_dropSettings_itemFolding.ToolTipText = "Toggle Code Folding";
      this.menuMain_dropSettings_itemFolding.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_CodeFolding_Click);
      // 
      // menuMain_dropSettings_itemHighlight
      // 
      this.menuMain_dropSettings_itemHighlight.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMain_dropSettings_itemHighlightColor});
      this.menuMain_dropSettings_itemHighlight.Image = global::Gemini.Properties.Resources.highlight;
      this.menuMain_dropSettings_itemHighlight.Name = "menuMain_dropSettings_itemHighlight";
      this.menuMain_dropSettings_itemHighlight.Size = new System.Drawing.Size(200, 22);
      this.menuMain_dropSettings_itemHighlight.Text = "Line Highlighter";
      this.menuMain_dropSettings_itemHighlight.ToolTipText = "Toggle Line Highlighter";
      this.menuMain_dropSettings_itemHighlight.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_LineHighlight_Click);
      // 
      // menuMain_dropSettings_itemHighlightColor
      // 
      this.menuMain_dropSettings_itemHighlightColor.Image = global::Gemini.Properties.Resources.color_wheel;
      this.menuMain_dropSettings_itemHighlightColor.Name = "menuMain_dropSettings_itemHighlightColor";
      this.menuMain_dropSettings_itemHighlightColor.Size = new System.Drawing.Size(154, 22);
      this.menuMain_dropSettings_itemHighlightColor.Text = "Highlight Color";
      this.menuMain_dropSettings_itemHighlightColor.ToolTipText = "Change the color of the line highlighter";
      this.menuMain_dropSettings_itemHighlightColor.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_HighlightColor_Click);
      // 
      // menuMain_dropSettings_seperator4
      // 
      this.menuMain_dropSettings_seperator4.Name = "menuMain_dropSettings_seperator4";
      this.menuMain_dropSettings_seperator4.Size = new System.Drawing.Size(197, 6);
      // 
      // menuMain_dropSettings_itemSaveSettings
      // 
      this.menuMain_dropSettings_itemSaveSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMain_dropSettings_itemAutoSaveSettings});
      this.menuMain_dropSettings_itemSaveSettings.Image = global::Gemini.Properties.Resources.save;
      this.menuMain_dropSettings_itemSaveSettings.Name = "menuMain_dropSettings_itemSaveSettings";
      this.menuMain_dropSettings_itemSaveSettings.Size = new System.Drawing.Size(200, 22);
      this.menuMain_dropSettings_itemSaveSettings.Text = "Save Settings";
      this.menuMain_dropSettings_itemSaveSettings.ToolTipText = "Save current settings";
      this.menuMain_dropSettings_itemSaveSettings.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_SaveSettings_Click);
      // 
      // menuMain_dropSettings_itemAutoSaveSettings
      // 
      this.menuMain_dropSettings_itemAutoSaveSettings.Name = "menuMain_dropSettings_itemAutoSaveSettings";
      this.menuMain_dropSettings_itemAutoSaveSettings.Size = new System.Drawing.Size(171, 22);
      this.menuMain_dropSettings_itemAutoSaveSettings.Text = "Auto-Save Settings";
      this.menuMain_dropSettings_itemAutoSaveSettings.ToolTipText = "Toggle auto-saving of settings on application closing";
      this.menuMain_dropSettings_itemAutoSaveSettings.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_AutoSaveSettings_Click);
      // 
      // menuMain_dropSettings_itemClearSettings
      // 
      this.menuMain_dropSettings_itemClearSettings.Image = global::Gemini.Properties.Resources.delete;
      this.menuMain_dropSettings_itemClearSettings.Name = "menuMain_dropSettings_itemClearSettings";
      this.menuMain_dropSettings_itemClearSettings.Size = new System.Drawing.Size(200, 22);
      this.menuMain_dropSettings_itemClearSettings.Text = "Clear Settings";
      this.menuMain_dropSettings_itemClearSettings.ToolTipText = "Delete current user settings";
      this.menuMain_dropSettings_itemClearSettings.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_DeleteSettings_Click);
      // 
      // menuMain_dropGame
      // 
      this.menuMain_dropGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMain_dropGame_itemHelp,
            this.menuMain_dropGame_itemRun,
            this.menuMain_dropGame_itemRunWithF12,
            this.menuMain_dropGame_itemDebug,
            this.menuMain_dropGame_itemProjectFolder});
      this.menuMain_dropGame.Name = "menuMain_dropGame";
      this.menuMain_dropGame.Size = new System.Drawing.Size(48, 20);
      this.menuMain_dropGame.Text = "Game";
      // 
      // menuMain_dropGame_itemHelp
      // 
      this.menuMain_dropGame_itemHelp.Image = global::Gemini.Properties.Resources.help;
      this.menuMain_dropGame_itemHelp.Name = "menuMain_dropGame_itemHelp";
      this.menuMain_dropGame_itemHelp.ShortcutKeys = System.Windows.Forms.Keys.F1;
      this.menuMain_dropGame_itemHelp.Size = new System.Drawing.Size(188, 22);
      this.menuMain_dropGame_itemHelp.Text = "Help";
      this.menuMain_dropGame_itemHelp.ToolTipText = "Open Help File";
      this.menuMain_dropGame_itemHelp.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_Help_Click);
      // 
      // menuMain_dropGame_itemRun
      // 
      this.menuMain_dropGame_itemRun.Image = global::Gemini.Properties.Resources.play;
      this.menuMain_dropGame_itemRun.Name = "menuMain_dropGame_itemRun";
      this.menuMain_dropGame_itemRun.ShortcutKeyDisplayString = "F5";
      this.menuMain_dropGame_itemRun.ShortcutKeys = System.Windows.Forms.Keys.F5;
      this.menuMain_dropGame_itemRun.Size = new System.Drawing.Size(188, 22);
      this.menuMain_dropGame_itemRun.Text = "Run";
      this.menuMain_dropGame_itemRun.ToolTipText = "Run Game";
      this.menuMain_dropGame_itemRun.Click += new System.EventHandler(this.menuMain_dropGame_itemRun_Click);
      // 
      // menuMain_dropGame_itemRunWithF12
      // 
      this.menuMain_dropGame_itemRunWithF12.Image = global::Gemini.Properties.Resources.play;
      this.menuMain_dropGame_itemRunWithF12.Name = "menuMain_dropGame_itemRunWithF12";
      this.menuMain_dropGame_itemRunWithF12.ShortcutKeyDisplayString = "F5 | F12";
      this.menuMain_dropGame_itemRunWithF12.ShortcutKeys = System.Windows.Forms.Keys.F12;
      this.menuMain_dropGame_itemRunWithF12.Size = new System.Drawing.Size(188, 22);
      this.menuMain_dropGame_itemRunWithF12.Text = "Run with F12";
      this.menuMain_dropGame_itemRunWithF12.ToolTipText = "Run Game";
      this.menuMain_dropGame_itemRunWithF12.Click += new System.EventHandler(this.menuMain_dropGame_itemRun_Click);
      // 
      // menuMain_dropGame_itemDebug
      // 
      this.menuMain_dropGame_itemDebug.Image = global::Gemini.Properties.Resources.debug;
      this.menuMain_dropGame_itemDebug.Name = "menuMain_dropGame_itemDebug";
      this.menuMain_dropGame_itemDebug.ShortcutKeyDisplayString = "F11";
      this.menuMain_dropGame_itemDebug.ShortcutKeys = System.Windows.Forms.Keys.F11;
      this.menuMain_dropGame_itemDebug.Size = new System.Drawing.Size(188, 22);
      this.menuMain_dropGame_itemDebug.Text = "Debug Mode";
      this.menuMain_dropGame_itemDebug.ToolTipText = "Toggle Debug Mode";
      this.menuMain_dropGame_itemDebug.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_Debug_Click);
      // 
      // menuMain_dropGame_itemProjectFolder
      // 
      this.menuMain_dropGame_itemProjectFolder.Image = global::Gemini.Properties.Resources.folder_open;
      this.menuMain_dropGame_itemProjectFolder.Name = "menuMain_dropGame_itemProjectFolder";
      this.menuMain_dropGame_itemProjectFolder.Size = new System.Drawing.Size(188, 22);
      this.menuMain_dropGame_itemProjectFolder.Text = "Open Project Folder";
      this.menuMain_dropGame_itemProjectFolder.ToolTipText = "Open Project Folder";
      this.menuMain_dropGame_itemProjectFolder.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_ProjectFolder_Click);
      // 
      // menuMain_dropAbout
      // 
      this.menuMain_dropAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMain_dropAbout_itemUpdate,
            this.menuMain_dropAbout_itemVersionHistory,
            menuMain_dropAbout_seperator1,
            this.menuMain_dropAbout_itemAboutGemini});
      this.menuMain_dropAbout.Name = "menuMain_dropAbout";
      this.menuMain_dropAbout.Size = new System.Drawing.Size(51, 20);
      this.menuMain_dropAbout.Text = "About";
      // 
      // menuMain_dropAbout_itemVersionHistory
      // 
      this.menuMain_dropAbout_itemVersionHistory.Image = global::Gemini.Properties.Resources.changelog;
      this.menuMain_dropAbout_itemVersionHistory.Name = "menuMain_dropAbout_itemVersionHistory";
      this.menuMain_dropAbout_itemVersionHistory.Size = new System.Drawing.Size(154, 22);
      this.menuMain_dropAbout_itemVersionHistory.Text = "Version History";
      this.menuMain_dropAbout_itemVersionHistory.ToolTipText = "View the changelog between Gemini updates";
      this.menuMain_dropAbout_itemVersionHistory.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_VersionHistory_Click);
      // 
      // menuMain_dropAbout_itemAboutGemini
      // 
      this.menuMain_dropAbout_itemAboutGemini.Image = global::Gemini.Properties.Resources.gemini_ico;
      this.menuMain_dropAbout_itemAboutGemini.Name = "menuMain_dropAbout_itemAboutGemini";
      this.menuMain_dropAbout_itemAboutGemini.Size = new System.Drawing.Size(154, 22);
      this.menuMain_dropAbout_itemAboutGemini.Text = "About Gemini...";
      this.menuMain_dropAbout_itemAboutGemini.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_AboutGemini_Click);
      // 
      // scriptsView
      // 
      this.scriptsView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.scriptsView.ContextMenuStrip = this.scriptsView_contextMenu;
      this.scriptsView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.scriptsView.ItemHeight = 17;
      this.scriptsView.Location = new System.Drawing.Point(3, 19);
      this.scriptsView.Name = "scriptsView";
      this.scriptsView.ShowNodeToolTips = true;
      this.scriptsView.Size = new System.Drawing.Size(174, 468);
      this.scriptsView.TabIndex = 0;
      this.scriptsView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.scriptsView_AfterSelect);
      this.scriptsView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.scriptsView_KeyDown);
      this.scriptsView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.scriptsView_MouseDown);
      // 
      // scriptsView_contextMenu
      // 
      this.scriptsView_contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scriptsView_contextMenu_itemOpen,
            this.scriptsView_contextMenu_itemInsert,
            this.scriptsView_contextMenu_itemCut,
            this.scriptsView_contextMenu_itemCopy,
            this.scriptsView_contextMenu_itemPaste,
            this.scriptsView_contextMenu_itemDelete,
            scriptsView_contextMenu_seperator1,
            this.scriptsView_contextMenu_itemMoveUp,
            this.scriptsView_contextMenu_itemMoveDown,
            scriptsView_contextMenu_seperator2,
            this.scriptsView_contextMenu_itemBatchSearch});
      this.scriptsView_contextMenu.Name = "scriptsList_ContextMenuStrip";
      this.scriptsView_contextMenu.Size = new System.Drawing.Size(201, 214);
      this.scriptsView_contextMenu.Opened += new System.EventHandler(this.mainMenu_ToolStripMenuItem_DropDownOpening);
      // 
      // scriptsView_contextMenu_itemOpen
      // 
      this.scriptsView_contextMenu_itemOpen.Image = global::Gemini.Properties.Resources.OpenFile;
      this.scriptsView_contextMenu_itemOpen.Name = "scriptsView_contextMenu_itemOpen";
      this.scriptsView_contextMenu_itemOpen.ShortcutKeyDisplayString = "Enter";
      this.scriptsView_contextMenu_itemOpen.Size = new System.Drawing.Size(200, 22);
      this.scriptsView_contextMenu_itemOpen.Text = "Open";
      this.scriptsView_contextMenu_itemOpen.Click += new System.EventHandler(this.scriptsView_itemOpen_Click);
      // 
      // scriptsView_contextMenu_itemInsert
      // 
      this.scriptsView_contextMenu_itemInsert.Image = global::Gemini.Properties.Resources.add;
      this.scriptsView_contextMenu_itemInsert.Name = "scriptsView_contextMenu_itemInsert";
      this.scriptsView_contextMenu_itemInsert.ShortcutKeys = System.Windows.Forms.Keys.Insert;
      this.scriptsView_contextMenu_itemInsert.Size = new System.Drawing.Size(200, 22);
      this.scriptsView_contextMenu_itemInsert.Text = "Insert";
      this.scriptsView_contextMenu_itemInsert.Click += new System.EventHandler(this.scriptsView_contextMenu_itemInsert_Click);
      // 
      // scriptsView_contextMenu_itemCut
      // 
      this.scriptsView_contextMenu_itemCut.Image = global::Gemini.Properties.Resources.cut;
      this.scriptsView_contextMenu_itemCut.Name = "scriptsView_contextMenu_itemCut";
      this.scriptsView_contextMenu_itemCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
      this.scriptsView_contextMenu_itemCut.Size = new System.Drawing.Size(200, 22);
      this.scriptsView_contextMenu_itemCut.Text = "Cut";
      this.scriptsView_contextMenu_itemCut.Click += new System.EventHandler(this.scriptsView_contextMenu_itemCut_Click);
      // 
      // scriptsView_contextMenu_itemCopy
      // 
      this.scriptsView_contextMenu_itemCopy.Image = global::Gemini.Properties.Resources.copy;
      this.scriptsView_contextMenu_itemCopy.Name = "scriptsView_contextMenu_itemCopy";
      this.scriptsView_contextMenu_itemCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
      this.scriptsView_contextMenu_itemCopy.Size = new System.Drawing.Size(200, 22);
      this.scriptsView_contextMenu_itemCopy.Text = "Copy";
      this.scriptsView_contextMenu_itemCopy.Click += new System.EventHandler(this.scriptsView_contextMenu_itemCopy_Click);
      // 
      // scriptsView_contextMenu_itemPaste
      // 
      this.scriptsView_contextMenu_itemPaste.Image = global::Gemini.Properties.Resources.paste;
      this.scriptsView_contextMenu_itemPaste.Name = "scriptsView_contextMenu_itemPaste";
      this.scriptsView_contextMenu_itemPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
      this.scriptsView_contextMenu_itemPaste.Size = new System.Drawing.Size(200, 22);
      this.scriptsView_contextMenu_itemPaste.Text = "Paste";
      this.scriptsView_contextMenu_itemPaste.Click += new System.EventHandler(this.scriptsView_contextMenu_itemPaste_Click);
      // 
      // scriptsView_contextMenu_itemDelete
      // 
      this.scriptsView_contextMenu_itemDelete.Image = global::Gemini.Properties.Resources.delete;
      this.scriptsView_contextMenu_itemDelete.Name = "scriptsView_contextMenu_itemDelete";
      this.scriptsView_contextMenu_itemDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
      this.scriptsView_contextMenu_itemDelete.Size = new System.Drawing.Size(200, 22);
      this.scriptsView_contextMenu_itemDelete.Text = "Delete";
      this.scriptsView_contextMenu_itemDelete.Click += new System.EventHandler(this.scriptsView_contextMenu_itemDelete_Click);
      // 
      // scriptsView_contextMenu_itemMoveUp
      // 
      this.scriptsView_contextMenu_itemMoveUp.Image = global::Gemini.Properties.Resources.smallArrow_up;
      this.scriptsView_contextMenu_itemMoveUp.Name = "scriptsView_contextMenu_itemMoveUp";
      this.scriptsView_contextMenu_itemMoveUp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
      this.scriptsView_contextMenu_itemMoveUp.Size = new System.Drawing.Size(200, 22);
      this.scriptsView_contextMenu_itemMoveUp.Text = "Move Up";
      this.scriptsView_contextMenu_itemMoveUp.Click += new System.EventHandler(this.scriptsView_contextMenu_itemMoveUp_Click);
      // 
      // scriptsView_contextMenu_itemMoveDown
      // 
      this.scriptsView_contextMenu_itemMoveDown.Image = global::Gemini.Properties.Resources.smallArrow_down;
      this.scriptsView_contextMenu_itemMoveDown.Name = "scriptsView_contextMenu_itemMoveDown";
      this.scriptsView_contextMenu_itemMoveDown.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
      this.scriptsView_contextMenu_itemMoveDown.Size = new System.Drawing.Size(200, 22);
      this.scriptsView_contextMenu_itemMoveDown.Text = "Move Down";
      this.scriptsView_contextMenu_itemMoveDown.Click += new System.EventHandler(this.scriptsView_contextMenu_itemMoveDown_Click);
      // 
      // scriptsView_contextMenu_itemBatchSearch
      // 
      this.scriptsView_contextMenu_itemBatchSearch.Image = global::Gemini.Properties.Resources.find3;
      this.scriptsView_contextMenu_itemBatchSearch.Name = "scriptsView_contextMenu_itemBatchSearch";
      this.scriptsView_contextMenu_itemBatchSearch.ShortcutKeyDisplayString = "Ctrl+Maj+F";
      this.scriptsView_contextMenu_itemBatchSearch.Size = new System.Drawing.Size(200, 22);
      this.scriptsView_contextMenu_itemBatchSearch.Text = "Find...";
      this.scriptsView_contextMenu_itemBatchSearch.Click += new System.EventHandler(this.scriptsView_contextMenu_itemBatchSearch_Click);
      // 
      // toolsView_toolStrip
      // 
      this.toolsView_toolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.toolsView_toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.toolsView_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsView_itemExport,
            this.toolsView_itemImport,
            toolStripSeparator22,
            this.toolsView_itemInsert,
            this.toolsView_itemDelete,
            toolStripSeparator20,
            this.toolsView_itemMoveUp,
            this.toolsView_itemMoveDown,
            this.toolsView_itemBatchSearch});
      this.toolsView_toolStrip.Location = new System.Drawing.Point(3, 513);
      this.toolsView_toolStrip.Name = "toolsView_toolStrip";
      this.toolsView_toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      this.toolsView_toolStrip.Size = new System.Drawing.Size(174, 25);
      this.toolsView_toolStrip.TabIndex = 6;
      this.toolsView_toolStrip.Text = "toolStrip1";
      // 
      // toolsView_itemExport
      // 
      this.toolsView_itemExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolsView_itemExport.Image = global::Gemini.Properties.Resources.export;
      this.toolsView_itemExport.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolsView_itemExport.Name = "toolsView_itemExport";
      this.toolsView_itemExport.Size = new System.Drawing.Size(23, 22);
      this.toolsView_itemExport.Text = "Quick Export Script";
      // 
      // toolsView_itemImport
      // 
      this.toolsView_itemImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolsView_itemImport.Image = global::Gemini.Properties.Resources.import;
      this.toolsView_itemImport.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolsView_itemImport.Name = "toolsView_itemImport";
      this.toolsView_itemImport.Size = new System.Drawing.Size(23, 22);
      this.toolsView_itemImport.Text = "Quick Import Script";
      // 
      // toolsView_itemInsert
      // 
      this.toolsView_itemInsert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolsView_itemInsert.Image = global::Gemini.Properties.Resources.add;
      this.toolsView_itemInsert.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolsView_itemInsert.Name = "toolsView_itemInsert";
      this.toolsView_itemInsert.Size = new System.Drawing.Size(23, 22);
      this.toolsView_itemInsert.Text = "Insert New Script (Ins)";
      this.toolsView_itemInsert.Click += new System.EventHandler(this.scriptsView_contextMenu_itemInsert_Click);
      // 
      // toolsView_itemDelete
      // 
      this.toolsView_itemDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolsView_itemDelete.Image = global::Gemini.Properties.Resources.delete;
      this.toolsView_itemDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolsView_itemDelete.Name = "toolsView_itemDelete";
      this.toolsView_itemDelete.Size = new System.Drawing.Size(23, 22);
      this.toolsView_itemDelete.Text = "Delete Script (Suppr)";
      this.toolsView_itemDelete.Click += new System.EventHandler(this.scriptsView_contextMenu_itemDelete_Click);
      // 
      // toolsView_itemMoveUp
      // 
      this.toolsView_itemMoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolsView_itemMoveUp.Image = global::Gemini.Properties.Resources.smallArrow_up;
      this.toolsView_itemMoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolsView_itemMoveUp.Name = "toolsView_itemMoveUp";
      this.toolsView_itemMoveUp.Size = new System.Drawing.Size(23, 22);
      this.toolsView_itemMoveUp.Text = "Move Script Up (Ctrl+Up)";
      this.toolsView_itemMoveUp.Click += new System.EventHandler(this.scriptsView_contextMenu_itemMoveUp_Click);
      // 
      // toolsView_itemMoveDown
      // 
      this.toolsView_itemMoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolsView_itemMoveDown.Image = global::Gemini.Properties.Resources.smallArrow_down;
      this.toolsView_itemMoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolsView_itemMoveDown.Name = "toolsView_itemMoveDown";
      this.toolsView_itemMoveDown.Size = new System.Drawing.Size(23, 22);
      this.toolsView_itemMoveDown.Text = "Move Script Down (Ctrl+Down)";
      this.toolsView_itemMoveDown.Click += new System.EventHandler(this.scriptsView_contextMenu_itemMoveDown_Click);
      // 
      // toolsView_itemBatchSearch
      // 
      this.toolsView_itemBatchSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.toolsView_itemBatchSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolsView_itemBatchSearch.Image = global::Gemini.Properties.Resources.find3;
      this.toolsView_itemBatchSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolsView_itemBatchSearch.Name = "toolsView_itemBatchSearch";
      this.toolsView_itemBatchSearch.Size = new System.Drawing.Size(23, 22);
      this.toolsView_itemBatchSearch.Text = "New Search (Ctrl+Maj+F)";
      this.toolsView_itemBatchSearch.Click += new System.EventHandler(this.scriptsView_contextMenu_itemBatchSearch_Click);
      // 
      // scriptName
      // 
      this.scriptName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.scriptName.Location = new System.Drawing.Point(4, 490);
      this.scriptName.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
      this.scriptName.Name = "scriptName";
      this.scriptName.Size = new System.Drawing.Size(174, 20);
      this.scriptName.TabIndex = 1;
      this.toolTip.SetToolTip(this.scriptName, "Edit title of script");
      // 
      // scriptsEditpr_statusStrip
      // 
      this.scriptsEditpr_statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scriptsEditor_StatusStrip_itemCharacters});
      this.scriptsEditpr_statusStrip.Location = new System.Drawing.Point(0, 517);
      this.scriptsEditpr_statusStrip.Name = "scriptsEditpr_statusStrip";
      this.scriptsEditpr_statusStrip.Size = new System.Drawing.Size(598, 22);
      this.scriptsEditpr_statusStrip.SizingGrip = false;
      this.scriptsEditpr_statusStrip.TabIndex = 2;
      this.scriptsEditpr_statusStrip.Text = "scriptsEditor_StatusStrip";
      // 
      // scriptsEditor_StatusStrip_itemCharacters
      // 
      this.scriptsEditor_StatusStrip_itemCharacters.Name = "scriptsEditor_StatusStrip_itemCharacters";
      this.scriptsEditor_StatusStrip_itemCharacters.Size = new System.Drawing.Size(0, 17);
      this.scriptsEditor_StatusStrip_itemCharacters.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // toolsEditor_toolStrip
      // 
      this.toolsEditor_toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.toolsEditor_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsEditor_itemSaveProject,
            this.toolsEditor_itemOpenProject,
            toolStripSeparator8,
            this.toolsEditor_itemSpecialChars,
            this.toolsEditor_itemStyleConfig,
            this.toolsEditor_itemAutoCConfig,
            toolStripSeparator9,
            this.toolsEditor_itemAutoC,
            this.toolsEditor_itemAutoIndent,
            this.toolsEditor_itemIndentGuides,
            this.toolsEditor_itemFolding,
            this.toolsEditor_itemHighlight,
            this.toolsEditor_itemHighlightColor,
            toolStripSeparator10,
            this.toolsEditor_itemSearch,
            this.toolsEditor_itemFind,
            this.toolsEditor_itemReplace,
            this.toolsEditor_itemGoToLine,
            toolStripSeparator11,
            this.toolsEditor_itemComment,
            this.toolsEditor_itemStructureScript,
            this.toolsEditor_itemRemoveLines,
            toolStripSeparator5,
            this.toolsEditor_itemRun,
            this.toolsEditor_itemDebug,
            this.toolsEditor_itemProjectFolder,
            this.toolsEditor_itemCloseProject});
      this.toolsEditor_toolStrip.Location = new System.Drawing.Point(0, 0);
      this.toolsEditor_toolStrip.Name = "toolsEditor_toolStrip";
      this.toolsEditor_toolStrip.Padding = new System.Windows.Forms.Padding(0);
      this.toolsEditor_toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      this.toolsEditor_toolStrip.Size = new System.Drawing.Size(598, 25);
      this.toolsEditor_toolStrip.TabIndex = 1;
      this.toolsEditor_toolStrip.Text = "scriptsEditor_ToolStrip";
      // 
      // toolsEditor_itemSaveProject
      // 
      this.toolsEditor_itemSaveProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolsEditor_itemSaveProject.Image = global::Gemini.Properties.Resources.save;
      this.toolsEditor_itemSaveProject.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolsEditor_itemSaveProject.Name = "toolsEditor_itemSaveProject";
      this.toolsEditor_itemSaveProject.Size = new System.Drawing.Size(23, 22);
      this.toolsEditor_itemSaveProject.Text = "Save Project (Ctrl+S)";
      this.toolsEditor_itemSaveProject.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_SaveProject_Click);
      // 
      // toolsEditor_itemOpenProject
      // 
      this.toolsEditor_itemOpenProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolsEditor_itemOpenProject.Image = global::Gemini.Properties.Resources.open_file;
      this.toolsEditor_itemOpenProject.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolsEditor_itemOpenProject.Name = "toolsEditor_itemOpenProject";
      this.toolsEditor_itemOpenProject.Size = new System.Drawing.Size(23, 22);
      this.toolsEditor_itemOpenProject.Text = "Open Project (Ctrl+O)";
      this.toolsEditor_itemOpenProject.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_OpenProject_Click);
      // 
      // toolsEditor_itemSpecialChars
      // 
      this.toolsEditor_itemSpecialChars.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolsEditor_itemSpecialChars.Image = global::Gemini.Properties.Resources.charmap;
      this.toolsEditor_itemSpecialChars.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolsEditor_itemSpecialChars.Name = "toolsEditor_itemSpecialChars";
      this.toolsEditor_itemSpecialChars.Size = new System.Drawing.Size(23, 22);
      this.toolsEditor_itemSpecialChars.Text = "Special Characters";
      this.toolsEditor_itemSpecialChars.Click += new System.EventHandler(this.scriptsEditor_ToolStripButton_SpecialChars_Click);
      // 
      // toolsEditor_itemStyleConfig
      // 
      this.toolsEditor_itemStyleConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolsEditor_itemStyleConfig.Image = global::Gemini.Properties.Resources.theme;
      this.toolsEditor_itemStyleConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolsEditor_itemStyleConfig.Name = "toolsEditor_itemStyleConfig";
      this.toolsEditor_itemStyleConfig.Size = new System.Drawing.Size(23, 22);
      this.toolsEditor_itemStyleConfig.Text = "Style Configuration";
      this.toolsEditor_itemStyleConfig.Click += new System.EventHandler(this.menuMain_dropSettings_itemStylesConfig_Click);
      // 
      // toolsEditor_itemAutoCConfig
      // 
      this.toolsEditor_itemAutoCConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolsEditor_itemAutoCConfig.Image = global::Gemini.Properties.Resources.tool;
      this.toolsEditor_itemAutoCConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolsEditor_itemAutoCConfig.Name = "toolsEditor_itemAutoCConfig";
      this.toolsEditor_itemAutoCConfig.Size = new System.Drawing.Size(23, 22);
      this.toolsEditor_itemAutoCConfig.Text = "Auto-Complete Configuration";
      this.toolsEditor_itemAutoCConfig.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_AutoCompleteConfig_Click);
      // 
      // toolsEditor_itemAutoC
      // 
      this.toolsEditor_itemAutoC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolsEditor_itemAutoC.Image = global::Gemini.Properties.Resources.text_complete;
      this.toolsEditor_itemAutoC.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolsEditor_itemAutoC.Name = "toolsEditor_itemAutoC";
      this.toolsEditor_itemAutoC.Size = new System.Drawing.Size(23, 22);
      this.toolsEditor_itemAutoC.Text = "Toggle Auto-Complete";
      this.toolsEditor_itemAutoC.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_AutoComplete_Click);
      // 
      // toolsEditor_itemAutoIndent
      // 
      this.toolsEditor_itemAutoIndent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolsEditor_itemAutoIndent.Image = global::Gemini.Properties.Resources.indent;
      this.toolsEditor_itemAutoIndent.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolsEditor_itemAutoIndent.Name = "toolsEditor_itemAutoIndent";
      this.toolsEditor_itemAutoIndent.Size = new System.Drawing.Size(23, 22);
      this.toolsEditor_itemAutoIndent.Text = "Toggle Auto-Indentation";
      this.toolsEditor_itemAutoIndent.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_AutoIndent_Click);
      // 
      // toolsEditor_itemIndentGuides
      // 
      this.toolsEditor_itemIndentGuides.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolsEditor_itemIndentGuides.Image = global::Gemini.Properties.Resources.ruler;
      this.toolsEditor_itemIndentGuides.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolsEditor_itemIndentGuides.Name = "toolsEditor_itemIndentGuides";
      this.toolsEditor_itemIndentGuides.Size = new System.Drawing.Size(23, 22);
      this.toolsEditor_itemIndentGuides.Text = "Toggle Indent Guide";
      this.toolsEditor_itemIndentGuides.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_IndentGuides_Click);
      // 
      // toolsEditor_itemFolding
      // 
      this.toolsEditor_itemFolding.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolsEditor_itemFolding.Image = global::Gemini.Properties.Resources.fold;
      this.toolsEditor_itemFolding.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolsEditor_itemFolding.Name = "toolsEditor_itemFolding";
      this.toolsEditor_itemFolding.Size = new System.Drawing.Size(23, 22);
      this.toolsEditor_itemFolding.Text = "Toggle Code Folding";
      this.toolsEditor_itemFolding.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_CodeFolding_Click);
      // 
      // toolsEditor_itemHighlight
      // 
      this.toolsEditor_itemHighlight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolsEditor_itemHighlight.Image = global::Gemini.Properties.Resources.highlight;
      this.toolsEditor_itemHighlight.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolsEditor_itemHighlight.Name = "toolsEditor_itemHighlight";
      this.toolsEditor_itemHighlight.Size = new System.Drawing.Size(23, 22);
      this.toolsEditor_itemHighlight.Text = "Toggle Line Highlighter";
      this.toolsEditor_itemHighlight.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_LineHighlight_Click);
      // 
      // toolsEditor_itemHighlightColor
      // 
      this.toolsEditor_itemHighlightColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolsEditor_itemHighlightColor.Image = global::Gemini.Properties.Resources.color_wheel;
      this.toolsEditor_itemHighlightColor.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolsEditor_itemHighlightColor.Name = "toolsEditor_itemHighlightColor";
      this.toolsEditor_itemHighlightColor.Size = new System.Drawing.Size(23, 22);
      this.toolsEditor_itemHighlightColor.Text = "Highlight Color";
      this.toolsEditor_itemHighlightColor.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_HighlightColor_Click);
      // 
      // toolsEditor_itemSearch
      // 
      this.toolsEditor_itemSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolsEditor_itemSearch.Image = global::Gemini.Properties.Resources.find2;
      this.toolsEditor_itemSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolsEditor_itemSearch.Name = "toolsEditor_itemSearch";
      this.toolsEditor_itemSearch.Size = new System.Drawing.Size(23, 22);
      this.toolsEditor_itemSearch.Text = "Incremental Search (Ctrl+I)";
      this.toolsEditor_itemSearch.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_IncrementalSearch_Click);
      // 
      // toolsEditor_itemFind
      // 
      this.toolsEditor_itemFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolsEditor_itemFind.Image = global::Gemini.Properties.Resources.find;
      this.toolsEditor_itemFind.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolsEditor_itemFind.Name = "toolsEditor_itemFind";
      this.toolsEditor_itemFind.Size = new System.Drawing.Size(23, 22);
      this.toolsEditor_itemFind.Text = "Find (Ctrl+F)";
      this.toolsEditor_itemFind.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_Find_Click);
      // 
      // toolsEditor_itemReplace
      // 
      this.toolsEditor_itemReplace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolsEditor_itemReplace.Image = global::Gemini.Properties.Resources.replace;
      this.toolsEditor_itemReplace.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolsEditor_itemReplace.Name = "toolsEditor_itemReplace";
      this.toolsEditor_itemReplace.Size = new System.Drawing.Size(23, 22);
      this.toolsEditor_itemReplace.Text = "Replace (Ctrl+H)";
      this.toolsEditor_itemReplace.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_Replace_Click);
      // 
      // toolsEditor_itemGoToLine
      // 
      this.toolsEditor_itemGoToLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolsEditor_itemGoToLine.Image = ((System.Drawing.Image)(resources.GetObject("toolsEditor_itemGoToLine.Image")));
      this.toolsEditor_itemGoToLine.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolsEditor_itemGoToLine.Name = "toolsEditor_itemGoToLine";
      this.toolsEditor_itemGoToLine.Size = new System.Drawing.Size(23, 22);
      this.toolsEditor_itemGoToLine.Text = "Go To Line (Ctrl+G)";
      this.toolsEditor_itemGoToLine.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_GoToLine_Click);
      // 
      // toolsEditor_itemComment
      // 
      this.toolsEditor_itemComment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolsEditor_itemComment.Image = global::Gemini.Properties.Resources.comment;
      this.toolsEditor_itemComment.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolsEditor_itemComment.Name = "toolsEditor_itemComment";
      this.toolsEditor_itemComment.Size = new System.Drawing.Size(23, 22);
      this.toolsEditor_itemComment.Text = "Toggle comment (Ctrl+Q)";
      this.toolsEditor_itemComment.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_ToggleComment_Click);
      // 
      // toolsEditor_itemStructureScript
      // 
      this.toolsEditor_itemStructureScript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolsEditor_itemStructureScript.Image = global::Gemini.Properties.Resources.outline;
      this.toolsEditor_itemStructureScript.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolsEditor_itemStructureScript.Name = "toolsEditor_itemStructureScript";
      this.toolsEditor_itemStructureScript.Size = new System.Drawing.Size(23, 22);
      this.toolsEditor_itemStructureScript.Text = "Structure Script";
      this.toolsEditor_itemStructureScript.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_StructureScriptCurrent_Click);
      // 
      // toolsEditor_itemRemoveLines
      // 
      this.toolsEditor_itemRemoveLines.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolsEditor_itemRemoveLines.Image = global::Gemini.Properties.Resources.emptyspace;
      this.toolsEditor_itemRemoveLines.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolsEditor_itemRemoveLines.Name = "toolsEditor_itemRemoveLines";
      this.toolsEditor_itemRemoveLines.Size = new System.Drawing.Size(23, 22);
      this.toolsEditor_itemRemoveLines.Text = "Remove Empty Lines";
      this.toolsEditor_itemRemoveLines.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_RemoveEmptyLinesCurrent_Click);
      // 
      // toolsEditor_itemRun
      // 
      this.toolsEditor_itemRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolsEditor_itemRun.Image = global::Gemini.Properties.Resources.play;
      this.toolsEditor_itemRun.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolsEditor_itemRun.Name = "toolsEditor_itemRun";
      this.toolsEditor_itemRun.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
      this.toolsEditor_itemRun.Size = new System.Drawing.Size(23, 22);
      this.toolsEditor_itemRun.Text = "Run Game (F5|F12)";
      this.toolsEditor_itemRun.Click += new System.EventHandler(this.menuMain_dropGame_itemRun_Click);
      // 
      // toolsEditor_itemDebug
      // 
      this.toolsEditor_itemDebug.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolsEditor_itemDebug.Image = global::Gemini.Properties.Resources.debug;
      this.toolsEditor_itemDebug.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolsEditor_itemDebug.Name = "toolsEditor_itemDebug";
      this.toolsEditor_itemDebug.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
      this.toolsEditor_itemDebug.Size = new System.Drawing.Size(23, 22);
      this.toolsEditor_itemDebug.Text = "Toggle Debug Mode";
      this.toolsEditor_itemDebug.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_Debug_Click);
      // 
      // toolsEditor_itemProjectFolder
      // 
      this.toolsEditor_itemProjectFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolsEditor_itemProjectFolder.Image = global::Gemini.Properties.Resources.folder_open;
      this.toolsEditor_itemProjectFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolsEditor_itemProjectFolder.Name = "toolsEditor_itemProjectFolder";
      this.toolsEditor_itemProjectFolder.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
      this.toolsEditor_itemProjectFolder.Size = new System.Drawing.Size(23, 22);
      this.toolsEditor_itemProjectFolder.Text = "Open Project Folder";
      this.toolsEditor_itemProjectFolder.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_ProjectFolder_Click);
      // 
      // toolsEditor_itemCloseProject
      // 
      this.toolsEditor_itemCloseProject.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.toolsEditor_itemCloseProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolsEditor_itemCloseProject.Image = global::Gemini.Properties.Resources.close;
      this.toolsEditor_itemCloseProject.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolsEditor_itemCloseProject.Name = "toolsEditor_itemCloseProject";
      this.toolsEditor_itemCloseProject.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
      this.toolsEditor_itemCloseProject.Size = new System.Drawing.Size(23, 22);
      this.toolsEditor_itemCloseProject.Text = "Close Project";
      this.toolsEditor_itemCloseProject.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_CloseProject_Click);
      // 
      // scriptsEditor_ContextMenuStrip
      // 
      this.scriptsEditor_ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scriptsEditor_ToolStripMenuItem_Undo,
            this.scriptsEditor_ToolStripMenuItem_Redo,
            toolStripSeparator15,
            this.scriptsEditor_ToolStripMenuItem_Cut,
            this.scriptsEditor_ToolStripMenuItem_Copy,
            this.scriptsEditor_ToolStripMenuItem_Paste,
            this.scriptsEditor_ToolStripMenuItem_Delete,
            this.scriptsEditor_ToolStripMenuItem_SelectAll,
            toolStripSeparator14,
            this.scriptsEditor_ToolStripMenuItem_IncrementalSearch,
            this.scriptsEditor_ToolStripMenuItem_Find,
            this.scriptsEditor_ToolStripMenuItem_FindNext,
            this.scriptsEditor_ToolStripMenuItem_FindPrevious,
            this.scriptsEditor_ToolStripMenuItem_Replace,
            this.scriptsEditor_ToolStripMenuItem_GoToLine,
            toolStripSeparator13,
            this.scriptsEditor_ToolStripMenuItem_Comment,
            toolStripSeparator12,
            this.scriptsEditor_ToolStripMenuItem_AddWordToAutoComplete});
      this.scriptsEditor_ContextMenuStrip.Name = "scriptsEditor_ContextMenuStrip";
      this.scriptsEditor_ContextMenuStrip.Size = new System.Drawing.Size(208, 358);
      this.scriptsEditor_ContextMenuStrip.Opened += new System.EventHandler(this.mainMenu_ToolStripMenuItem_DropDownOpening);
      // 
      // scriptsEditor_ToolStripMenuItem_Undo
      // 
      this.scriptsEditor_ToolStripMenuItem_Undo.Image = global::Gemini.Properties.Resources.undo;
      this.scriptsEditor_ToolStripMenuItem_Undo.Name = "scriptsEditor_ToolStripMenuItem_Undo";
      this.scriptsEditor_ToolStripMenuItem_Undo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
      this.scriptsEditor_ToolStripMenuItem_Undo.Size = new System.Drawing.Size(207, 22);
      this.scriptsEditor_ToolStripMenuItem_Undo.Text = "Undo";
      this.scriptsEditor_ToolStripMenuItem_Undo.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_Undo_Click);
      // 
      // scriptsEditor_ToolStripMenuItem_Redo
      // 
      this.scriptsEditor_ToolStripMenuItem_Redo.Image = global::Gemini.Properties.Resources.redo;
      this.scriptsEditor_ToolStripMenuItem_Redo.Name = "scriptsEditor_ToolStripMenuItem_Redo";
      this.scriptsEditor_ToolStripMenuItem_Redo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
      this.scriptsEditor_ToolStripMenuItem_Redo.Size = new System.Drawing.Size(207, 22);
      this.scriptsEditor_ToolStripMenuItem_Redo.Text = "Redo";
      this.scriptsEditor_ToolStripMenuItem_Redo.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_Redo_Click);
      // 
      // scriptsEditor_ToolStripMenuItem_Cut
      // 
      this.scriptsEditor_ToolStripMenuItem_Cut.Image = global::Gemini.Properties.Resources.cut;
      this.scriptsEditor_ToolStripMenuItem_Cut.Name = "scriptsEditor_ToolStripMenuItem_Cut";
      this.scriptsEditor_ToolStripMenuItem_Cut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
      this.scriptsEditor_ToolStripMenuItem_Cut.Size = new System.Drawing.Size(207, 22);
      this.scriptsEditor_ToolStripMenuItem_Cut.Text = "Cut";
      this.scriptsEditor_ToolStripMenuItem_Cut.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_Cut_Click);
      // 
      // scriptsEditor_ToolStripMenuItem_Copy
      // 
      this.scriptsEditor_ToolStripMenuItem_Copy.Image = global::Gemini.Properties.Resources.copy;
      this.scriptsEditor_ToolStripMenuItem_Copy.Name = "scriptsEditor_ToolStripMenuItem_Copy";
      this.scriptsEditor_ToolStripMenuItem_Copy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
      this.scriptsEditor_ToolStripMenuItem_Copy.Size = new System.Drawing.Size(207, 22);
      this.scriptsEditor_ToolStripMenuItem_Copy.Text = "Copy";
      this.scriptsEditor_ToolStripMenuItem_Copy.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_Copy_Click);
      // 
      // scriptsEditor_ToolStripMenuItem_Paste
      // 
      this.scriptsEditor_ToolStripMenuItem_Paste.Image = global::Gemini.Properties.Resources.paste;
      this.scriptsEditor_ToolStripMenuItem_Paste.Name = "scriptsEditor_ToolStripMenuItem_Paste";
      this.scriptsEditor_ToolStripMenuItem_Paste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
      this.scriptsEditor_ToolStripMenuItem_Paste.Size = new System.Drawing.Size(207, 22);
      this.scriptsEditor_ToolStripMenuItem_Paste.Text = "Paste";
      this.scriptsEditor_ToolStripMenuItem_Paste.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_Paste_Click);
      // 
      // scriptsEditor_ToolStripMenuItem_Delete
      // 
      this.scriptsEditor_ToolStripMenuItem_Delete.Image = global::Gemini.Properties.Resources.delete_alt;
      this.scriptsEditor_ToolStripMenuItem_Delete.Name = "scriptsEditor_ToolStripMenuItem_Delete";
      this.scriptsEditor_ToolStripMenuItem_Delete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
      this.scriptsEditor_ToolStripMenuItem_Delete.Size = new System.Drawing.Size(207, 22);
      this.scriptsEditor_ToolStripMenuItem_Delete.Text = "Delete";
      this.scriptsEditor_ToolStripMenuItem_Delete.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_Delete_Click);
      // 
      // scriptsEditor_ToolStripMenuItem_SelectAll
      // 
      this.scriptsEditor_ToolStripMenuItem_SelectAll.Image = global::Gemini.Properties.Resources.select_all;
      this.scriptsEditor_ToolStripMenuItem_SelectAll.Name = "scriptsEditor_ToolStripMenuItem_SelectAll";
      this.scriptsEditor_ToolStripMenuItem_SelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
      this.scriptsEditor_ToolStripMenuItem_SelectAll.Size = new System.Drawing.Size(207, 22);
      this.scriptsEditor_ToolStripMenuItem_SelectAll.Text = "Select All";
      this.scriptsEditor_ToolStripMenuItem_SelectAll.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_SelectAll_Click);
      // 
      // scriptsEditor_ToolStripMenuItem_IncrementalSearch
      // 
      this.scriptsEditor_ToolStripMenuItem_IncrementalSearch.Image = global::Gemini.Properties.Resources.find2;
      this.scriptsEditor_ToolStripMenuItem_IncrementalSearch.Name = "scriptsEditor_ToolStripMenuItem_IncrementalSearch";
      this.scriptsEditor_ToolStripMenuItem_IncrementalSearch.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
      this.scriptsEditor_ToolStripMenuItem_IncrementalSearch.Size = new System.Drawing.Size(207, 22);
      this.scriptsEditor_ToolStripMenuItem_IncrementalSearch.Text = "Incremental Search";
      this.scriptsEditor_ToolStripMenuItem_IncrementalSearch.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_IncrementalSearch_Click);
      // 
      // scriptsEditor_ToolStripMenuItem_Find
      // 
      this.scriptsEditor_ToolStripMenuItem_Find.Image = global::Gemini.Properties.Resources.find;
      this.scriptsEditor_ToolStripMenuItem_Find.Name = "scriptsEditor_ToolStripMenuItem_Find";
      this.scriptsEditor_ToolStripMenuItem_Find.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
      this.scriptsEditor_ToolStripMenuItem_Find.Size = new System.Drawing.Size(207, 22);
      this.scriptsEditor_ToolStripMenuItem_Find.Text = "Find...";
      this.scriptsEditor_ToolStripMenuItem_Find.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_Find_Click);
      // 
      // scriptsEditor_ToolStripMenuItem_FindNext
      // 
      this.scriptsEditor_ToolStripMenuItem_FindNext.Image = global::Gemini.Properties.Resources.next;
      this.scriptsEditor_ToolStripMenuItem_FindNext.Name = "scriptsEditor_ToolStripMenuItem_FindNext";
      this.scriptsEditor_ToolStripMenuItem_FindNext.ShortcutKeys = System.Windows.Forms.Keys.F3;
      this.scriptsEditor_ToolStripMenuItem_FindNext.Size = new System.Drawing.Size(207, 22);
      this.scriptsEditor_ToolStripMenuItem_FindNext.Text = "Find Next...";
      this.scriptsEditor_ToolStripMenuItem_FindNext.Click += new System.EventHandler(this.scriptsEditor_ToolStripMenuItem_FindNext_Click);
      // 
      // scriptsEditor_ToolStripMenuItem_FindPrevious
      // 
      this.scriptsEditor_ToolStripMenuItem_FindPrevious.Image = global::Gemini.Properties.Resources.previous;
      this.scriptsEditor_ToolStripMenuItem_FindPrevious.Name = "scriptsEditor_ToolStripMenuItem_FindPrevious";
      this.scriptsEditor_ToolStripMenuItem_FindPrevious.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F3)));
      this.scriptsEditor_ToolStripMenuItem_FindPrevious.Size = new System.Drawing.Size(207, 22);
      this.scriptsEditor_ToolStripMenuItem_FindPrevious.Text = "Find Previous...";
      this.scriptsEditor_ToolStripMenuItem_FindPrevious.Click += new System.EventHandler(this.scriptsEditor_ToolStripMenuItem_FindPrevious_Click);
      // 
      // scriptsEditor_ToolStripMenuItem_Replace
      // 
      this.scriptsEditor_ToolStripMenuItem_Replace.Image = global::Gemini.Properties.Resources.replace;
      this.scriptsEditor_ToolStripMenuItem_Replace.Name = "scriptsEditor_ToolStripMenuItem_Replace";
      this.scriptsEditor_ToolStripMenuItem_Replace.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
      this.scriptsEditor_ToolStripMenuItem_Replace.Size = new System.Drawing.Size(207, 22);
      this.scriptsEditor_ToolStripMenuItem_Replace.Text = "Replace...";
      this.scriptsEditor_ToolStripMenuItem_Replace.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_Replace_Click);
      // 
      // scriptsEditor_ToolStripMenuItem_GoToLine
      // 
      this.scriptsEditor_ToolStripMenuItem_GoToLine.Image = ((System.Drawing.Image)(resources.GetObject("scriptsEditor_ToolStripMenuItem_GoToLine.Image")));
      this.scriptsEditor_ToolStripMenuItem_GoToLine.Name = "scriptsEditor_ToolStripMenuItem_GoToLine";
      this.scriptsEditor_ToolStripMenuItem_GoToLine.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
      this.scriptsEditor_ToolStripMenuItem_GoToLine.Size = new System.Drawing.Size(207, 22);
      this.scriptsEditor_ToolStripMenuItem_GoToLine.Text = "Go To...";
      this.scriptsEditor_ToolStripMenuItem_GoToLine.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_GoToLine_Click);
      // 
      // scriptsEditor_ToolStripMenuItem_Comment
      // 
      this.scriptsEditor_ToolStripMenuItem_Comment.Image = global::Gemini.Properties.Resources.comment;
      this.scriptsEditor_ToolStripMenuItem_Comment.Name = "scriptsEditor_ToolStripMenuItem_Comment";
      this.scriptsEditor_ToolStripMenuItem_Comment.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
      this.scriptsEditor_ToolStripMenuItem_Comment.Size = new System.Drawing.Size(207, 22);
      this.scriptsEditor_ToolStripMenuItem_Comment.Text = "Comment";
      this.scriptsEditor_ToolStripMenuItem_Comment.Click += new System.EventHandler(this.mainMenu_ToolStripMenuItem_ToggleComment_Click);
      // 
      // scriptsEditor_ToolStripMenuItem_AddWordToAutoComplete
      // 
      this.scriptsEditor_ToolStripMenuItem_AddWordToAutoComplete.Image = global::Gemini.Properties.Resources.text_complete;
      this.scriptsEditor_ToolStripMenuItem_AddWordToAutoComplete.Name = "scriptsEditor_ToolStripMenuItem_AddWordToAutoComplete";
      this.scriptsEditor_ToolStripMenuItem_AddWordToAutoComplete.Size = new System.Drawing.Size(207, 22);
      this.scriptsEditor_ToolStripMenuItem_AddWordToAutoComplete.Text = "Add to Auto-Complete";
      this.scriptsEditor_ToolStripMenuItem_AddWordToAutoComplete.Click += new System.EventHandler(this.scriptsEditor_ToolStripMenuItem_AddWordToAutoComplete_Click);
      // 
      // scriptsFileWatcher
      // 
      this.scriptsFileWatcher.EnableRaisingEvents = true;
      this.scriptsFileWatcher.NotifyFilter = System.IO.NotifyFilters.LastWrite;
      this.scriptsFileWatcher.SynchronizingObject = this;
      this.scriptsFileWatcher.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Changed);
      // 
      // splitView
      // 
      this.splitView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitView.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
      this.splitView.Location = new System.Drawing.Point(2, 2);
      this.splitView.Name = "splitView";
      this.splitView.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitView.Panel1
      // 
      this.splitView.Panel1.Controls.Add(this.scriptsEditor_tabs);
      this.splitView.Panel1.Controls.Add(this.scriptsEditpr_statusStrip);
      this.splitView.Panel1.Controls.Add(this.toolsEditor_toolStrip);
      this.splitView.Panel1MinSize = 200;
      // 
      // splitView.Panel2
      // 
      this.splitView.Panel2.Controls.Add(this.groupSearches);
      this.splitView.Panel2Collapsed = true;
      this.splitView.Panel2MinSize = 0;
      this.splitView.Size = new System.Drawing.Size(598, 539);
      this.splitView.SplitterDistance = 349;
      this.splitView.SplitterWidth = 8;
      this.splitView.TabIndex = 3;
      // 
      // groupSearches
      // 
      this.groupSearches.Controls.Add(this.searches_TabControl);
      this.groupSearches.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupSearches.Location = new System.Drawing.Point(0, 0);
      this.groupSearches.Name = "groupSearches";
      this.groupSearches.Size = new System.Drawing.Size(150, 46);
      this.groupSearches.TabIndex = 0;
      this.groupSearches.TabStop = false;
      this.groupSearches.Text = "Searches";
      // 
      // splitMain
      // 
      this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.splitMain.Location = new System.Drawing.Point(0, 24);
      this.splitMain.Name = "splitMain";
      // 
      // splitMain.Panel1
      // 
      this.splitMain.Panel1.Controls.Add(this.groupScripts);
      this.splitMain.Panel1MinSize = 180;
      // 
      // splitMain.Panel2
      // 
      this.splitMain.Panel2.Controls.Add(this.splitView);
      this.splitMain.Panel2.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
      this.splitMain.Panel2MinSize = 500;
      this.splitMain.Size = new System.Drawing.Size(784, 541);
      this.splitMain.SplitterDistance = 180;
      this.splitMain.TabIndex = 0;
      // 
      // groupScripts
      // 
      this.groupScripts.Controls.Add(this.toolsView_toolStrip);
      this.groupScripts.Controls.Add(this.scriptsView);
      this.groupScripts.Controls.Add(this.scriptName);
      this.groupScripts.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupScripts.Location = new System.Drawing.Point(0, 0);
      this.groupScripts.Name = "groupScripts";
      this.groupScripts.Size = new System.Drawing.Size(180, 541);
      this.groupScripts.TabIndex = 7;
      this.groupScripts.TabStop = false;
      this.groupScripts.Text = "Scripts";
      // 
      // scriptsEditor_tabs
      // 
      this.scriptsEditor_tabs.AllowDrop = true;
      this.scriptsEditor_tabs.Dock = System.Windows.Forms.DockStyle.Fill;
      this.scriptsEditor_tabs.Location = new System.Drawing.Point(0, 25);
      this.scriptsEditor_tabs.Name = "scriptsEditor_tabs";
      this.scriptsEditor_tabs.SelectedIndex = 0;
      this.scriptsEditor_tabs.Size = new System.Drawing.Size(598, 492);
      this.scriptsEditor_tabs.TabIndex = 0;
      this.scriptsEditor_tabs.SelectedIndexChanged += new System.EventHandler(this.scriptsEditor_TabControl_SelectedIndexChanged);
      this.scriptsEditor_tabs.GotFocus += new System.EventHandler(this.scriptsEditor_TabControl_GotFocus);
      // 
      // searches_TabControl
      // 
      this.searches_TabControl.AllowDrop = true;
      this.searches_TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.searches_TabControl.HotTrack = true;
      this.searches_TabControl.Location = new System.Drawing.Point(3, 16);
      this.searches_TabControl.Name = "searches_TabControl";
      this.searches_TabControl.SelectedIndex = 0;
      this.searches_TabControl.Size = new System.Drawing.Size(144, 27);
      this.searches_TabControl.TabIndex = 0;
      this.searches_TabControl.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.searches_TabControl_ControlRemoved);
      // 
      // menuMain_dropAbout_itemUpdate
      // 
      this.menuMain_dropAbout_itemUpdate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMain_dropAbout_itemUpdateNow,
            this.menuMain_dropAbout_seperator2,
            this.menuMain_dropAbout_itemUpdateCheckOn,
            this.menuMain_dropAbout_itemUpdateCheckOff});
      this.menuMain_dropAbout_itemUpdate.Image = global::Gemini.Properties.Resources.update;
      this.menuMain_dropAbout_itemUpdate.Name = "menuMain_dropAbout_itemUpdate";
      this.menuMain_dropAbout_itemUpdate.Size = new System.Drawing.Size(154, 22);
      this.menuMain_dropAbout_itemUpdate.Text = "Updates...";
      // 
      // menuMain_dropAbout_itemUpdateNow
      // 
      this.menuMain_dropAbout_itemUpdateNow.Image = global::Gemini.Properties.Resources.update;
      this.menuMain_dropAbout_itemUpdateNow.Name = "menuMain_dropAbout_itemUpdateNow";
      this.menuMain_dropAbout_itemUpdateNow.Size = new System.Drawing.Size(219, 22);
      this.menuMain_dropAbout_itemUpdateNow.Text = "Check for Updates now";
      // 
      // menuMain_dropAbout_seperator2
      // 
      this.menuMain_dropAbout_seperator2.Name = "menuMain_dropAbout_seperator2";
      this.menuMain_dropAbout_seperator2.Size = new System.Drawing.Size(216, 6);
      // 
      // menuMain_dropAbout_itemUpdateCheckOn
      // 
      this.menuMain_dropAbout_itemUpdateCheckOn.Name = "menuMain_dropAbout_itemUpdateCheckOn";
      this.menuMain_dropAbout_itemUpdateCheckOn.Size = new System.Drawing.Size(219, 22);
      this.menuMain_dropAbout_itemUpdateCheckOn.Text = "Auto-check for updates ON";
      this.menuMain_dropAbout_itemUpdateCheckOn.ToolTipText = "Automaticly check for updates at startup";
      // 
      // menuMain_dropAbout_itemUpdateCheckOff
      // 
      this.menuMain_dropAbout_itemUpdateCheckOff.Name = "menuMain_dropAbout_itemUpdateCheckOff";
      this.menuMain_dropAbout_itemUpdateCheckOff.Size = new System.Drawing.Size(219, 22);
      this.menuMain_dropAbout_itemUpdateCheckOff.Text = "Auto-check for updates OFF";
      this.menuMain_dropAbout_itemUpdateCheckOff.ToolTipText = "No check at startup";
      // 
      // GeminiForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(784, 565);
      this.Controls.Add(this.splitMain);
      this.Controls.Add(this.menuMain_menuStrip);
      this.KeyPreview = true;
      this.MainMenuStrip = this.menuMain_menuStrip;
      this.MinimumSize = new System.Drawing.Size(800, 600);
      this.Name = "GeminiForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "Gemini";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GeminiForm_Closing);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GeminiForm_KeyDown);
      this.menuMain_menuStrip.ResumeLayout(false);
      this.menuMain_menuStrip.PerformLayout();
      this.scriptsView_contextMenu.ResumeLayout(false);
      this.toolsView_toolStrip.ResumeLayout(false);
      this.toolsView_toolStrip.PerformLayout();
      this.scriptsEditpr_statusStrip.ResumeLayout(false);
      this.scriptsEditpr_statusStrip.PerformLayout();
      this.toolsEditor_toolStrip.ResumeLayout(false);
      this.toolsEditor_toolStrip.PerformLayout();
      this.scriptsEditor_ContextMenuStrip.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.scriptsFileWatcher)).EndInit();
      this.splitView.Panel1.ResumeLayout(false);
      this.splitView.Panel1.PerformLayout();
      this.splitView.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitView)).EndInit();
      this.splitView.ResumeLayout(false);
      this.groupSearches.ResumeLayout(false);
      this.splitMain.Panel1.ResumeLayout(false);
      this.splitMain.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
      this.splitMain.ResumeLayout(false);
      this.groupScripts.ResumeLayout(false);
      this.groupScripts.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain_menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropFile;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropSettings;
        private System.Windows.Forms.TextBox scriptName;
        private System.Windows.Forms.ContextMenuStrip scriptsView_contextMenu;
        private System.Windows.Forms.ToolStripMenuItem scriptsView_contextMenu_itemInsert;
        private System.Windows.Forms.ToolStripMenuItem scriptsView_contextMenu_itemCut;
        private System.Windows.Forms.ToolStripMenuItem scriptsView_contextMenu_itemCopy;
        private System.Windows.Forms.ToolStripMenuItem scriptsView_contextMenu_itemPaste;
        private System.Windows.Forms.ToolStripMenuItem scriptsView_contextMenu_itemDelete;
        private System.Windows.Forms.ToolStripMenuItem scriptsView_contextMenu_itemMoveUp;
        private System.Windows.Forms.ToolStripMenuItem scriptsView_contextMenu_itemMoveDown;
        private System.Windows.Forms.ToolStripMenuItem scriptsView_contextMenu_itemBatchSearch;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropFile_itemOpen;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropFile_itemSave;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropFile_itemExit;
        private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.ToolStrip toolsEditor_toolStrip;
        private System.Windows.Forms.ToolStripButton toolsEditor_itemComment;
		private System.Windows.Forms.ToolStripButton toolsEditor_itemRun;
		private System.Windows.Forms.ToolStripButton toolsEditor_itemAutoC;
		private System.Windows.Forms.ToolStripButton toolsEditor_itemAutoIndent;
		private System.Windows.Forms.StatusStrip scriptsEditpr_statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel scriptsEditor_StatusStrip_itemCharacters;
		private System.Windows.Forms.ToolStripMenuItem menuMain_dropSettings_itemStylesConfig;
		private System.Windows.Forms.ToolStripMenuItem menuMain_dropFile_itemNew;
		private System.Windows.Forms.ToolStripMenuItem menuMain_dropFile_itemNewRMXP;
		private System.Windows.Forms.ToolStripMenuItem menuMain_dropFile_itemNewRMVX;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropAbout;
		private System.Windows.Forms.ToolStripMenuItem menuMain_dropSettings_itemAutoC;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropSettings_itemIndentGuides;
		private System.Windows.Forms.ToolStripMenuItem menuMain_dropSettings_itemAutoIndent;
		private System.Windows.Forms.ToolStripButton toolsEditor_itemHighlight;
		private System.Windows.Forms.ToolStripButton toolsEditor_itemAutoCConfig;
        private System.Windows.Forms.ToolStripButton toolsEditor_itemSaveProject;
        private System.Windows.Forms.ToolStripButton toolsEditor_itemCloseProject;
        private System.Windows.Forms.ToolStripButton toolsEditor_itemStyleConfig;
		private System.Windows.Forms.ToolStripButton toolsEditor_itemSearch;
        private System.Windows.Forms.ToolStripButton toolsEditor_itemFind;
		private System.Windows.Forms.ToolStripButton toolsEditor_itemGoToLine;
		private System.Windows.Forms.ToolStripButton toolsEditor_itemIndentGuides;
		private System.Windows.Forms.ToolStripMenuItem menuMain_dropSettings_itemAutoCConfig;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropSettings_itemHighlight;
		private System.Windows.Forms.ToolStripButton toolsEditor_itemHighlightColor;
		private System.Windows.Forms.ToolStripMenuItem menuMain_dropSettings_itemHighlightColor;
		private System.Windows.Forms.ToolStripButton toolsEditor_itemSpecialChars;
		private System.Windows.Forms.ToolStripButton toolsEditor_itemOpenProject;
		private System.Windows.Forms.ContextMenuStrip scriptsEditor_ContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem scriptsEditor_ToolStripMenuItem_Undo;
        private System.Windows.Forms.ToolStripMenuItem scriptsEditor_ToolStripMenuItem_Redo;
		private System.Windows.Forms.ToolStripMenuItem scriptsEditor_ToolStripMenuItem_Cut;
		private System.Windows.Forms.ToolStripMenuItem scriptsEditor_ToolStripMenuItem_Copy;
		private System.Windows.Forms.ToolStripMenuItem scriptsEditor_ToolStripMenuItem_Paste;
        private System.Windows.Forms.ToolStripMenuItem scriptsEditor_ToolStripMenuItem_Delete;
		private System.Windows.Forms.ToolStripMenuItem scriptsEditor_ToolStripMenuItem_Find;
		private System.Windows.Forms.ToolStripMenuItem scriptsEditor_ToolStripMenuItem_IncrementalSearch;
		private System.Windows.Forms.ToolStripMenuItem scriptsEditor_ToolStripMenuItem_FindNext;
		private System.Windows.Forms.ToolStripMenuItem scriptsEditor_ToolStripMenuItem_FindPrevious;
        private System.Windows.Forms.ToolStripMenuItem scriptsEditor_ToolStripMenuItem_Replace;
        private System.Windows.Forms.ToolStripMenuItem scriptsEditor_ToolStripMenuItem_Comment;
		private System.Windows.Forms.ToolStripMenuItem scriptsEditor_ToolStripMenuItem_GoToLine;
        private System.Windows.Forms.ToolStripButton toolsEditor_itemReplace;
		private System.Windows.Forms.ToolStripButton toolsEditor_itemStructureScript;
		private System.Windows.Forms.ToolStripMenuItem menuMain_dropFile_itemExportTo;
		private System.Windows.Forms.ToolStripMenuItem menuMain_dropFile_itemExportToText;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropFile_itemExportToRuby;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropAbout_itemAboutGemini;
		private System.Windows.Forms.ToolStripMenuItem scriptsEditor_ToolStripMenuItem_AddWordToAutoComplete;
		private System.Windows.Forms.ToolStripMenuItem menuMain_dropAbout_itemVersionHistory;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropSettings_itemFolding;
        private System.Windows.Forms.ToolStripButton toolsEditor_itemProjectFolder;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropFile_itemNewRMVXAce;
        private System.Windows.Forms.ToolStripMenuItem scriptsEditor_ToolStripMenuItem_SelectAll;
        private System.Windows.Forms.ToolStripButton toolsEditor_itemDebug;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropFile_itemClose;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropGame;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropGame_itemRunWithF12;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropGame_itemDebug;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropGame_itemProjectFolder;
        private System.Windows.Forms.ToolStripButton toolsEditor_itemFolding;
        private System.Windows.Forms.ToolStripButton toolsEditor_itemRemoveLines;
        private System.Windows.Forms.ToolStripMenuItem scriptsView_contextMenu_itemOpen;
        private System.IO.FileSystemWatcher scriptsFileWatcher;
        private System.Windows.Forms.SplitContainer splitView;
        private AdvancedTabControl scriptsEditor_tabs;
        private System.Windows.Forms.GroupBox groupSearches;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropFile_itemExoprtToRMData;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropGame_itemHelp;
        private System.Windows.Forms.ToolStrip toolsView_toolStrip;
        private System.Windows.Forms.ToolStripButton toolsView_itemImport;
        private System.Windows.Forms.ToolStripButton toolsView_itemInsert;
        private System.Windows.Forms.ToolStripButton toolsView_itemMoveUp;
        private System.Windows.Forms.ToolStripButton toolsView_itemMoveDown;
        private System.Windows.Forms.ToolStripButton toolsView_itemDelete;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropEdit;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropEdit_itemSelectAll;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropEdit_itemIncrementalSearch;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropEdit_itemFind;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropEdit_itemReplace;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropEdit_itemGoTo;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropEdit_itemBatchComment;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropEdit_itemToggleComment;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropEdit_itemComment;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropEdit_itemUnComment;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropEdit_itemStructureScript;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropEdit_itemSScriptCurrent;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropEdit_itemSScriptOpen;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropEdit_itemSScriptAll;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropEdit_itemRemoveEmpty;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropEdit_itemRemoveEmptyCurrent;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropEdit_itemRemoveEmptyOpen;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropEdit_itemRemoveEmptyAll;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropEdit_itemUndo;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropEdit_itemRedo;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropEdit_itemCut;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropEdit_itemCopy;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropEdit_itemPaste;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropEdit_itemDelete;
        private System.Windows.Forms.ToolStripMenuItem menuMain_dropEdit_itemBatchSearch;
        private System.Windows.Forms.ToolStripButton toolsView_itemBatchSearch;
    private System.Windows.Forms.TreeView scriptsView;
    private System.Windows.Forms.ToolStripButton toolsView_itemExport;
    private System.Windows.Forms.ToolStripMenuItem menuMain_dropSettings_itemAutoOpenProject;
    private System.Windows.Forms.ToolStripSeparator menuMain_dropSettings_seperator2;
    private System.Windows.Forms.ToolStripMenuItem menuMain_dropFile_itemImport;
    private System.Windows.Forms.ToolStripSeparator menuMain_dropSettings_seperator4;
    private System.Windows.Forms.ToolStripMenuItem menuMain_dropSettings_itemUpdateSections;
    private System.Windows.Forms.ToolStripMenuItem menuMain_dropSettings_itemCustomRuntime;
    private System.Windows.Forms.ToolStripMenuItem menuMain_dropGame_itemRun;
    private System.Windows.Forms.ToolStripSeparator menuMain_dropSettings_seperator1;
    private System.Windows.Forms.ToolStripMenuItem menuMain_dropSettings_itemSaveSettings;
    private System.Windows.Forms.ToolStripMenuItem menuMain_dropSettings_itemClearSettings;
    private System.Windows.Forms.SplitContainer splitMain;
    private System.Windows.Forms.ToolStripMenuItem menuMain_dropSettings_itemPioritizeRecent;
    private System.Windows.Forms.ToolStripMenuItem menuMain_dropSettings_itemAutoSaveSettings;
    private System.Windows.Forms.ToolStripMenuItem menuMain_dropSettings_itemMinimalView;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem menuMain_dropSettings_itemMenuVisible;
    private System.Windows.Forms.GroupBox groupScripts;
    private System.Windows.Forms.ToolStripMenuItem menuMain_dropSettings_itemHideScripts;
    private System.Windows.Forms.ToolStripMenuItem menuMain_dropFile_itemOpenRecent;
    private System.Windows.Forms.ToolStripMenuItem defaultFolderToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem browseToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem menuMain_dropFile_itemExportToFolder;
    private AdvancedTabControl searches_TabControl;
    private System.Windows.Forms.ToolStripMenuItem menuMain_dropAbout_itemUpdate;
    private System.Windows.Forms.ToolStripMenuItem menuMain_dropAbout_itemUpdateNow;
    private System.Windows.Forms.ToolStripSeparator menuMain_dropAbout_seperator2;
    private System.Windows.Forms.ToolStripMenuItem menuMain_dropAbout_itemUpdateCheckOn;
    private System.Windows.Forms.ToolStripMenuItem menuMain_dropAbout_itemUpdateCheckOff;
  }
}

