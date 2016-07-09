using System;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

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
  public partial class UpdateChannelForm : Form
  {
    private WebClient _webClient = new WebClient();

    private const string DEFAULTCHANNEL = "master";

    private string _current = "";
    public string Current {  get { return _current; } }

    private List<string> _channels = new List<string>();
    public List<string> Channels { get { return _channels;} }

    public UpdateChannelForm()
    {
      InitializeComponent();
      UpdateList();
      labelBranch.Text += Settings.UpdateChannel;
      buttonUpdate_Click(null, null);
    }

    private void Branches_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
      if (e.Cancelled || e.Error != null)
        labelInfo.Text = "List retrival failed";
      else
      {
        JArray branches = JArray.Parse(e.Result);
        List<string> list = new List<string>();
        for (int i = 0; i < branches.Count; i++)
        {
          JToken branch = branches[i];
          list.Add((string)branch["name"]);
        }
        _channels = list;
        UpdateList();
        labelInfo.Text = "List retrived";
      }
    }

    private void UpdateList()
    {
      listBox.Items.Clear();
      foreach (string branch in Settings.UpdateChannels)
      {
        listBox.Items.Add(branch);
      }

      // If we didn't retrive any lists, or is otherwise empty, abort.
      if (listBox.Items.Count == 0)
        return;

      // If our current channel is among the availale channels, select it.
      if (Settings.UpdateChannels.Contains(Settings.UpdateChannel))
        listBox.SelectedItem = Settings.UpdateChannel;
      // Otherwise select DEFAULTCHANNEL.
      else
        listBox.SelectedItem = DEFAULTCHANNEL;
    }

    private void buttonUpdate_Click(object sender, EventArgs e)
    {
      labelInfo.Text = "Retriving list...";
      _webClient.CancelAsync();
      _webClient.Headers.Add(HttpRequestHeader.Accept, "application/json");
      _webClient.Headers.Add(HttpRequestHeader.UserAgent, Settings.UserAgent);
      _webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(Branches_DownloadStringCompleted);
      _webClient.DownloadStringAsync(new Uri(@"https://api.github.com/repos/revam/gemini/branches"));
    }

    private void UpdateForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      // TODO: Add check for valid branch name?
      _webClient.CancelAsync();
    }

    private void listBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      _current = (string)listBox.SelectedItem;
    }
  }
}
