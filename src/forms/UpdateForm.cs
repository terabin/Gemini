using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

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
  public partial class UpdateForm : Form
  {

    private WebClient _webClient = new WebClient();

    public UpdateForm()
    {
      InitializeComponent();
      buttonDownload.Visible = labelProgress.Visible = progressBar.Visible = false;
      labelCurrentVersion.Text += ProductVersion;
      _webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(VersionInfo_DownloadStringCompleted);
      _webClient.DownloadStringAsync(new Uri(@"https://raw.githubusercontent.com/revam/Gemini/master/VersionInfo.dat"));
    }

    private void VersionInfo_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
      if (e.Cancelled || e.Error != null)
        labelInfo.Text = "Failed to connect to online server.";
      else if (new Version(ProductVersion) < new Version(e.Result))
      {
        buttonDownload.Visible = true;
        labelInfo.Text = string.Format("Version {0} is available.", e.Result);
        if (Visible == false)
        { // Auto Update
          System.Media.SystemSounds.Asterisk.Play();
          ShowDialog();
        }
        return;
      }
      else
        labelInfo.Text = "Gemini is up to date.";
      if (Visible == false)
        Dispose(true);

    }

    private void buttonDownload_Click(object sender, EventArgs e)
    {
      string name = Process.GetCurrentProcess().ProcessName;
      while (Process.GetProcessesByName(name).Length > 1)
      {
        DialogResult result = MessageBox.Show(
            "Others instances of Gemini are running.\nYou must close them before continuing.",
            "Update", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
        if (result == DialogResult.Cancel)
          return;
      }
      buttonDownload.Visible = false;
      labelProgress.Visible = progressBar.Visible = true;
      _webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(WebClient_DownloadProgressChanged);
      _webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Gemini_DownloadFileCompleted);
      _webClient.DownloadFileAsync(new Uri(@"https://github.com/revam/Gemini/tree/master/builds/release/Gemini.exe"), "Gemini.upd");
    }

    private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
      progressBar.Value = e.ProgressPercentage;
      labelProgress.Text = String.Format("{0}%", e.ProgressPercentage);
    }

    private void Gemini_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
    {
      if (e.Cancelled)
        return;
      else if (e.Error != null)
      {
        labelInfo.Text = "error";
        MessageBox.Show("An unexpected error occurred during the update.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      else
      {
        MessageBox.Show("Download complete!\nGemini will now restart.",
                  "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        DialogResult = DialogResult.OK;
        Close();
      }
    }

    private void UpdateForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      _webClient.CancelAsync();
    }

    public void StartProcess()
    {
      File.WriteAllText("GeminiUpdater.bat",
          "@echo off\r\n" +
          ":Repeat\r\n" +
          "del %1\r\n" +
          "if exist %1 echo Unable to replace Gemini.\r\n" +
          "if exist %1 taskkill /F /IM %1\r\n" +
          "if exist %1 goto Repeat\r\n" +
          "rename Gemini.upd %1\r\n" +
          "start \"\" %1\r\n" +
          "del GeminiUpdater.bat");
      Process.Start("GeminiUpdater.bat", "\"" + Path.GetFileName(Application.ExecutablePath) + "\"");
    }
  }
}
