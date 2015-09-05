using Gemini.Serializable;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Gemini
{
  public static class Settings
  {
    private static bool _saving = false;
    public static bool WindowMaximized { get; set; }
    public static Rectangle WindowBounds { get; set; }
    public static bool MenuVisible { get; set; }
    public static bool AutoOpen { get; set; }
    public static List<string> RecentlyOpened { get; set; }
    public static bool RecentPriority { get; set; }
    public static bool AutoSaveConfig { get; set; }
    public static bool MinimalView { get; set; }
    public static bool OnlyHideScripts { get; set; }
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
    public static bool CustomRuntime { get; set; }
    public static string RuntimeExecutable { get; set; }
    public static string RuntimeArguments { get; set; }
    public static bool AutoCheckUpdates { get; set; }

    public static void SetDefaults()
    {
      MenuVisible = true;
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
      MinimalView = false;
      OnlyHideScripts = false;
      OpenScripts = new List<Serializable.Script>();
      ActiveScript = new Serializable.Script();
      ScriptStyles = GetScriptStyles();
      AutoComplete = false;
      AutoCompleteLength = 2;
      AutoCompleteFlag = 0;
      AutoCompleteCustomWords = "";
      AutoCompleteWords = new List<string>();
      AutoIndent = true;
      GuideLines = true;
      LineHighLight = false;
      LineHighLightColor = Color.FromArgb(32, 0, 0, 0);
      CodeFolding = true;
      DebugMode = true;
      CustomRuntime = false;
      RuntimeExecutable = "Game.exe";
      RuntimeArguments = "";
      AutoCheckUpdates = false;
    }

    private static ScriptStyle[] GetScriptStyles()
    {
      using (Font font = new Font("Courier New", 10))
        return new ScriptStyle[] {
        new ScriptStyle("White Space"        , Color.Black           , Color.White   , font),
        new ScriptStyle("Brace Match"        , Color.Purple          , Color.Yellow  , font),
        new ScriptStyle("Comment Line"       , Color.Green           , Color.White   , font),
        new ScriptStyle("Comment Block"      , Color.Green           , Color.White   , font),
        new ScriptStyle("Number"             , Color.DarkRed         , Color.White   , font),
        new ScriptStyle("Keyword"            , Color.Blue            , Color.White   , font),
        new ScriptStyle("Double Quote String", Color.Purple          , Color.White   , font),
        new ScriptStyle("Single Quote String", Color.MediumVioletRed , Color.White   , font),
        new ScriptStyle("Class Name"         , Color.DarkOrange      , Color.White   , font),
        new ScriptStyle("Method Name"        , Color.Black           , Color.White   , font),
        new ScriptStyle("Operator"           , Color.DarkCyan        , Color.White   , font),
        new ScriptStyle("Call"               , Color.Black           , Color.White   , font),
        new ScriptStyle("Regular Expression" , Color.MediumPurple    , Color.White   , font),
        new ScriptStyle("Global Variable"    , Color.Black           , Color.White   , font),
        new ScriptStyle("Symbol"             , Color.Orange          , Color.White   , font),
        new ScriptStyle("Module Name"        , Color.DarkOrange      , Color.White   , font),
        new ScriptStyle("Instance Variable"  , Color.Black           , Color.White   , font),
        new ScriptStyle("Class Variable"     , Color.Black           , Color.White   , font),
        new ScriptStyle("System String"      , Color.Red             , Color.White   , font),
        new ScriptStyle("Line Number"        , Color.Gray            , Color.White   , font)
      };
    }

    public static void SaveSettings(string path = "Gemini.xml")
    {
      if (_saving) return;
      _saving = true;
      Serializable.Gemini saveData = new Serializable.Gemini();
      saveData.WindowMaximized = Application.OpenForms.Count == 0 ? false :
        Application.OpenForms[0].WindowState == FormWindowState.Maximized;
      saveData.WindowBounds = new WindowBounds(saveData.WindowMaximized ? WindowBounds : Application.OpenForms[0].Bounds);
      saveData.ShowMenu = MenuVisible;
      saveData.MinimalisticView = MinimalView;
      saveData.OnlyHideScripts = OnlyHideScripts;
      List<Serializable.File> f = new List<Serializable.File>();
      foreach (string s in RecentlyOpened) f.Add(new Serializable.File(s));
      saveData.Files = new Serializable.Files(AutoOpen, f.ToArray());
      saveData.UseAutoIndent = AutoIndent;
      saveData.UseGuideLines = GuideLines;
      saveData.UseLineHighLight = LineHighLight;
      saveData.LineHighLightColor = ColorSerializetionHelper.Serialize(LineHighLightColor);
      saveData.UseCodeFolding = CodeFolding;
      saveData.RecentPriority = RecentPriority;
      saveData.AutoSaveConfig = AutoSaveConfig;
      saveData.ScriptStyles = ScriptStyles;
      saveData.AutoComplete = new AutoComplete(AutoComplete, AutoCompleteLength, AutoCompleteFlag, AutoCompleteCustomWords);
      saveData.AutoCheckUpdates = AutoCheckUpdates;
      using (Stream stream = System.IO.File.OpenWrite(path))
        new System.Xml.Serialization.XmlSerializer(typeof(Serializable.Gemini)).Serialize(stream, saveData);
      _saving = false;
    }

    public static void SaveLocalSettings(string path)
    {
      if (_saving) return;
      _saving = true;
      GeminiProject saveData = new GeminiProject();
      saveData.DebugMode = DebugMode;
      Scripts s = new Scripts();
      s.ActiveScript = ActiveScript;
      s.OpenSections = OpenScripts.ToArray();
      saveData.Scripts = s;
      saveData.RuntimeExecutable = RuntimeExecutable;
      saveData.RuntimeArguments = RuntimeArguments;
      using (Stream stream = System.IO.File.OpenWrite(path))
        new System.Xml.Serialization.XmlSerializer(typeof(GeminiProject)).Serialize(stream, saveData);
      _saving = false;
    }

    public static void LoadSettings(string path = "Gemini.xml")
    {
      if (_saving) return;
      _saving = true;
      if (System.IO.File.Exists(path))
        try
        {
          Serializable.Gemini saveData;
          using (Stream stream = System.IO.File.OpenRead(path))
            saveData = (Serializable.Gemini)new System.Xml.Serialization.XmlSerializer(typeof(Serializable.Gemini)).Deserialize(stream);
          WindowMaximized = saveData.WindowMaximized;
          WindowBounds = saveData.WindowBounds.Bounds;
          MenuVisible = saveData.ShowMenu;
          MinimalView = saveData.MinimalisticView;
          OnlyHideScripts = saveData.OnlyHideScripts;
          AutoOpen = saveData.Files.AutoOpenProject;
          List<string> tmp = new List<string>();
          foreach (Serializable.File f in saveData.Files.RecentlyOpenedList) tmp.Add(f.Path);
          RecentlyOpened = tmp;
          AutoIndent = saveData.UseAutoIndent;
          GuideLines = saveData.UseGuideLines;
          LineHighLight = saveData.UseLineHighLight;
          LineHighLightColor = ColorSerializetionHelper.Deserialize(saveData.LineHighLightColor);
          CodeFolding = saveData.UseCodeFolding;
          RecentPriority = saveData.RecentPriority;
          AutoSaveConfig = saveData.AutoSaveConfig;
          ScriptStyles = saveData.ScriptStyles;
          AutoComplete = saveData.AutoComplete.Use;
          AutoCompleteLength = saveData.AutoComplete.Length;
          AutoCompleteFlag = saveData.AutoComplete.Flag;
          AutoCompleteCustomWords = saveData.AutoComplete.CustomWords;
          AutoCheckUpdates = saveData.AutoCheckUpdates;
        }
        catch (Exception)
        {
          DialogResult f = MessageBox.Show("Error accessing settings file.\nDo you want to continue?",
              "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
          if (f == DialogResult.Yes)
            Application.Exit();
          else
            SetDefaults();
        }
      _saving = false;
    }


    public static void LoadLocalSettings(string path)
    {
      if (_saving) return;
      _saving = true;
      if (System.IO.File.Exists(path))
        try
        {
          GeminiProject saveData;
          using (Stream stream = System.IO.File.OpenRead(path))
            saveData = (GeminiProject)new System.Xml.Serialization.XmlSerializer(typeof(GeminiProject)).Deserialize(stream);
          OpenScripts = new List<Serializable.Script>(saveData.Scripts.OpenSections);
          ActiveScript = saveData.Scripts.ActiveScript;
          DebugMode = saveData.DebugMode;
          RuntimeExecutable = saveData.RuntimeExecutable;
          RuntimeArguments = saveData.RuntimeArguments;
        }
        catch (Exception)
        {
          SetDefaults();
          DialogResult f = MessageBox.Show("Error accessing local settings file.\nDo you want to continue?",
              "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
          if (f == DialogResult.No)
            Application.Exit();
        }
      _saving = false;
    }
  }

}

