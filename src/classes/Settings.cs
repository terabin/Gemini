using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Gemini
{
  public static class Settings
  {
    public static bool WindowMaximized { get; set; }
    public static Rectangle WindowBounds { get; set; }
    public static bool AutoHideMenuBar { get; set; }
    public static bool AutoOpen { get; set; }
    public static List<string> RecentlyOpened { get; set; }
    public static bool RecentPriority { get; set; }
    public static bool AutoSaveConfig { get; set; }
    public static bool ProjectConfig { get; set; }
    public static string ProjectDirectory { get; set; }
    public static Serializable.DistracionMode DistractionMode { get; set; }
    public static List<Serializable.Script> OpenScripts { get; set; }
    public static Serializable.Script ActiveScript { get; set; }
    public static ScriptStyle[] ScriptStyles { get; set; }
    public static bool AutoComplete { get; set; }
    public static int AutoCompleteLength { get; set; }
    public static int AutoCompleteFlag { get; set; }
    public static string AutoCompleteCustomWords { get; set; }
    public static List<string> AutoCompleteWords { get; set; }
    public static bool AutoIndent { get; set; }
    public static bool GuideLines { get; set; }
    public static bool LineHighLight { get; set; }
    public static Color LineHighLightColor { get; set; }
    public static bool CodeFolding { get; set; }
    public static bool DebugMode { get; set; }
    public static string RuntimeExecutable { get; set; }
    public static string RuntimeArguments { get; set; }
    public static bool AutoCheckUpdates { get; set; }

    public static void SetDefaults()
    {
      AutoHideMenuBar = true;
      WindowMaximized = false;
      if (Application.OpenForms.Count > 0)
        WindowBounds = Application.OpenForms[0].Bounds;
      else
      {
        int x = (Screen.PrimaryScreen.Bounds.Width - 800) / 2;
        int y = (Screen.PrimaryScreen.Bounds.Height - 600) / 2;
        WindowBounds = new Rectangle(x, y, 800, 600);
      }
      AutoOpen = true;
      RecentlyOpened = new List<string>();
      RecentPriority = false;
      AutoSaveConfig = true;
      ProjectConfig = false;
      DistractionMode = new Serializable.DistracionMode(false, false);
      ScriptStyles = GetScriptStyles();
      AutoComplete = false;
      AutoCompleteLength = 2;
      AutoCompleteFlag = 0;
      AutoCompleteCustomWords = "";
      AutoCompleteWords = new List<string>();
      AutoIndent = true;
      GuideLines = true;
      LineHighLight = false;
      LineHighLightColor = Color.FromArgb(50, 195, 216, 255);
      CodeFolding = true;
      AutoCheckUpdates = false;
    }

    public static void SetLocalDefaults()
    {
      DebugMode = false;
      OpenScripts = new List<Serializable.Script>();
      ActiveScript = new Serializable.Script();
      RuntimeExecutable = "";
      RuntimeArguments = "";
    }

    private static ScriptStyle[] GetScriptStyles()
    {
      using (Font font = new Font("Courier New", 10))
        return new ScriptStyle[] {
        new ScriptStyle("White Space", Color.Black, Color.White, font),
        new ScriptStyle("Brace Match", Color.Purple, Color.Yellow, font),
        new ScriptStyle("Comment Line", Color.Green, Color.White, font),
        new ScriptStyle("Comment Block", Color.Green, Color.White, font),
        new ScriptStyle("Number", Color.DarkRed, Color.White, font),
        new ScriptStyle("Keyword", Color.Blue, Color.White, font),
        new ScriptStyle("Double Quote String", Color.Purple, Color.White, font),
        new ScriptStyle("Single Quote String", Color.MediumVioletRed, Color.White, font),
        new ScriptStyle("Class Name", Color.DarkOrange, Color.White, font),
        new ScriptStyle("Method Name", Color.Black, Color.White, font),
        new ScriptStyle("Operator", Color.DarkCyan, Color.White, font),
        new ScriptStyle("Call", Color.Black, Color.White, font),
        new ScriptStyle("Regular Expression", Color.MediumPurple, Color.White, font),
        new ScriptStyle("Global Variable", Color.Black, Color.White, font),
        new ScriptStyle("Symbol", Color.Orange, Color.White, font),
        new ScriptStyle("Module Name", Color.DarkOrange, Color.White, font),
        new ScriptStyle("Instance Variable", Color.Black, Color.White, font),
        new ScriptStyle("Class Variable", Color.Black, Color.White, font),
        new ScriptStyle("Line Number", Color.Gray, Color.White, font),
        new ScriptStyle("System String", Color.Red, Color.White, font),
      };
    }

    public static void SaveConfiguration(string path = "Gemini.config")
    {
      if (ProjectConfig && ProjectDirectory == Path.GetDirectoryName(Application.ExecutablePath)) return;
      Serializable.Settings saveData = new Serializable.Settings(GetGlobalSaveData(), null);
      if (File.Exists(path))
        File.Delete(path);
      using (Stream stream = File.OpenWrite(path))
        new System.Xml.Serialization.XmlSerializer(typeof(Serializable.GeminiGlobal)).Serialize(stream, saveData);
    }

    public static void SaveLocalConfiguration()
    { SaveLocalConfiguration(ProjectDirectory + "Gemini.config"); }
    public static void SaveLocalConfiguration(string path = null)
    {
      Serializable.Settings saveData;
      if (ProjectConfig && ProjectDirectory == Path.GetDirectoryName(Application.ExecutablePath))
        saveData = new Serializable.Settings(GetGlobalSaveData(), GetProjectSaveData());
      else
        saveData = new Serializable.Settings(null, GetProjectSaveData());
      if (File.Exists(path))
        File.Delete(path);
      using (Stream stream = File.OpenWrite(path))
        new System.Xml.Serialization.XmlSerializer(typeof(Serializable.Settings)).Serialize(stream, saveData);
    }

    private static Serializable.GeminiGlobal GetGlobalSaveData()
    {
      Serializable.GeminiGlobal saveData = new Serializable.GeminiGlobal();
      saveData.WindowMaximized = Application.OpenForms.Count == 0 ? false :
        Application.OpenForms[0].WindowState == FormWindowState.Maximized;
      saveData.WindowBounds = new Serializable.WindowBounds(saveData.WindowMaximized ? WindowBounds : Application.OpenForms[0].Bounds);
      saveData.AutoHideMenuBar = AutoHideMenuBar;
      saveData.DistracionMode = DistractionMode;
      List<Serializable.File> f = new List<Serializable.File>();
      foreach (string s in RecentlyOpened) f.Add(new Serializable.File(s));
      saveData.Files = new Serializable.Files(AutoOpen, f.ToArray());
      saveData.UseAutoIndent = AutoIndent;
      saveData.UseGuideLines = GuideLines;
      saveData.UseLineHighLight = LineHighLight;
      saveData.LineHighLightColor = Serializable.ColorSerializetionHelper.Serialize(LineHighLightColor);
      saveData.UseCodeFolding = CodeFolding;
      saveData.RecentPriority = RecentPriority;
      saveData.AutoSaveConfig = AutoSaveConfig;
      saveData.UseProjectConfig = ProjectConfig;
      saveData.ScriptStyles = ScriptStyles;
      saveData.AutoComplete = new Serializable.AutoComplete(AutoComplete, AutoCompleteLength, AutoCompleteFlag, AutoCompleteCustomWords);
      saveData.AutoCheckUpdates = AutoCheckUpdates;
      return saveData;
    }

    private static Serializable.GeminiProject GetProjectSaveData()
    {
      Serializable.GeminiProject saveData = new Serializable.GeminiProject();
      saveData.DebugMode = DebugMode;
      Serializable.Scripts s = new Serializable.Scripts();
      s.ActiveScript = ActiveScript;
      s.OpenSections = OpenScripts.ToArray();
      saveData.Scripts = s;
      saveData.RuntimeExecutable = RuntimeExecutable;
      saveData.RuntimeArguments = RuntimeArguments;
      return saveData;
    }

    public static void LoadConfiguration(string path = "Gemini.config")
    {
      if (File.Exists(path))
        try
        {
          Serializable.GeminiGlobal saveData = (Serializable.GeminiGlobal)LoadObject(path, 0);
          WindowMaximized = saveData.WindowMaximized;
          WindowBounds = saveData.WindowBounds.Bounds;
          AutoHideMenuBar = saveData.AutoHideMenuBar;
          DistractionMode = saveData.DistracionMode;
          AutoOpen = saveData.Files.AutoOpenProject;
          List<string> tmp = new List<string>();
          foreach (Serializable.File f in saveData.Files.RecentlyOpenedList) tmp.Add(f.Path);
          RecentlyOpened = tmp;
          AutoIndent = saveData.UseAutoIndent;
          GuideLines = saveData.UseGuideLines;
          LineHighLight = saveData.UseLineHighLight;
          LineHighLightColor = Serializable.ColorSerializetionHelper.Deserialize(saveData.LineHighLightColor);
          CodeFolding = saveData.UseCodeFolding;
          RecentPriority = saveData.RecentPriority;
          AutoSaveConfig = saveData.AutoSaveConfig;
          ProjectConfig = saveData.UseProjectConfig;
          ScriptStyles = saveData.ScriptStyles;
          AutoComplete = saveData.AutoComplete.Use;
          AutoCompleteLength = saveData.AutoComplete.Length;
          AutoCompleteFlag = saveData.AutoComplete.Flag;
          AutoCompleteCustomWords = saveData.AutoComplete.CustomWords;
          AutoCheckUpdates = saveData.AutoCheckUpdates;
        }
        catch (Exception)
        {
          SetDefaults();
          DialogResult f = MessageBox.Show("Error accessing local settings file.\nDo you want to continue?",
            "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
          if (f == DialogResult.No)
            Application.Exit();
        }
    }

    public static void LoadLocalConfiguration()
    { LoadLocalConfiguration(ProjectDirectory + "Gemini.config");}

    public static void LoadLocalConfiguration(string path)
    {
      if (File.Exists(path))
        try
        {
          Serializable.GeminiProject saveData = (Serializable.GeminiProject)LoadObject(path, 1);
          OpenScripts = new List<Serializable.Script>(saveData.Scripts.OpenSections);
          ActiveScript = saveData.Scripts.ActiveScript;
          DebugMode = saveData.DebugMode;
          RuntimeExecutable = saveData.RuntimeExecutable;
          RuntimeArguments = saveData.RuntimeArguments;
        }
        catch (Exception)
        {
          SetLocalDefaults();
          DialogResult f = MessageBox.Show("Error accessing local settings file.\nDo you want to continue?",
            "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
          if (f == DialogResult.No)
            Application.Exit();
        }
    }

    private static object LoadObject(string path, int refer)
    {
      Serializable.Settings saveData;
      using (Stream stream = File.OpenRead(path))
        saveData = (Serializable.Settings)new System.Xml.Serialization.XmlSerializer(typeof(Serializable.Settings)).Deserialize(stream);
      if (refer == 0 ) return saveData.Global;
      else if (refer == 1 ) return saveData.Project;
      else return null;
    }
  }

}
