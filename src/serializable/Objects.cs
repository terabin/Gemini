using System;
using System.Drawing;

namespace Gemini.Serializable
{
  [Serializable]
  public struct SaveData
  {
    public SaveData(object global, object project)
    {
      Settings = global;
      Project = project;
    }

    public object Settings;
    public object Project;
  }

  [Serializable]
  public struct Settings
  {
    public bool AutoCheckUpdates;
    public bool AutoSaveConfig;
    public bool UseProjectConfig;
    public Window WindowBounds;
    public bool WindowMaximized;
    public Files Files;
    public bool AutoHideMenuBar;
    public DistracionMode DistracionMode;
    public AutoComplete AutoComplete;
    public bool UseAutoIndent;
    public bool UseGuideLines;
    public bool UseLineHighLight;
    public string LineHighLightColor;
    public bool UseCodeFolding;
    public bool RecentPriority;
    public ScriptStyle[] ScriptStyles;
  }

  [Serializable]
  public struct AutoComplete
  {
    public AutoComplete(bool u, int l, int f, string c)
    {
      Use = u;
      Length = l;
      Flag = f;
      CustomWords = c;
    }

    public bool Use;
    public int Length;
    public int Flag;
    public string CustomWords;
  }

  [Serializable]
  public struct Files
  {
    public Files(bool open, string[] recent)
    {
      AutoOpenProject = open;
      RecentlyOpenedList = recent;
    }

    public bool AutoOpenProject;
    public string[] RecentlyOpenedList;
  }

  [Serializable]
  public struct DistracionMode
  {
    public DistracionMode(bool use, bool ht)
    {
      Use = use;
      HideToolbar = ht;
    }

    public bool Use;
    public bool HideToolbar;
  }

  [Serializable]
  public struct Window
  {
    public Window(Rectangle rec)
    {
      X = rec.X;
      Y = rec.Y;
      Width = rec.Width;
      Height = rec.Height;
    }

    public int X;
    public int Y;
    public int Width;
    public int Height;

    [Newtonsoft.Json.JsonIgnore()]
    public Rectangle Bounds { get { return new Rectangle(X, Y, Width, Height); } }
  }

  [Serializable]
  public struct Project
  {
    public bool DebugMode;
    public string RuntimeExecutable;
    public string RuntimeArguments;
    public Scripts Scripts;
  }

  [Serializable]
  public struct Scripts
  {
    public Script ActiveScript;
    public Script[] OpenSections;
  }

  [Serializable]
  public struct Script
  {
    public Script(int section, int position)
    {
      Section = section;
      Position = position;
    }

    public int Section;
    public int Position;
  }
}