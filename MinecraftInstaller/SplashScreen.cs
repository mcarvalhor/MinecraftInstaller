using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace MinecraftInstaller
{
	public partial class SplashScreen : Form
	{
		public SplashScreen()
		{
			InitializeComponent();
		}

		private WebClient checkUpdateStream, updateStream;
		private string updateTempFile;
		private bool requiredUpdate;

		private void SplashScreen_Load(object sender, EventArgs e)
		{
			checkUpdateStream = new WebClient();
			checkUpdateStream.DownloadProgressChanged += new DownloadProgressChangedEventHandler(CheckUpdateProgress);
			checkUpdateStream.DownloadStringCompleted += new DownloadStringCompletedEventHandler(CheckUpdateCompleted);
			checkUpdateStream.DownloadStringAsync(new Uri(Utils.checkUpdateURL));
		}

		private void SplashScreen_Shown(object sender, EventArgs e)
		{
			double i;
			for(i = 0; i <= 1; i += 0.01)
			{
				this.Opacity = i;
				Application.DoEvents();
				System.Threading.Thread.Sleep(8);
			}
		}

		private void Start()
		{
			this.Visible = false;
			if(Utils.IsInstalled())
			{
				new HomeForm().ShowDialog();
			} else
			{
				new InstallForm().ShowDialog();
			}
			this.Close();
		}

		public void Finish()
		{
			this.Close();
		}

		private void CheckUpdateProgress(object sender, DownloadProgressChangedEventArgs e)
		{
			if (e.TotalBytesToReceive > Utils.maxCheckUpdateBytes)
			{
				checkUpdateStream.CancelAsync();
			}
		}

		private void CheckUpdateCompleted(object sender, DownloadStringCompletedEventArgs e)
		{
			String resultStr, downloadURI;
			if (e.Cancelled || e.Error != null)
			{
				Start();
				return;
			}

			resultStr = e.Result;
			if(string.IsNullOrWhiteSpace(resultStr))
			{
				Start();
				return;
			}

			downloadURI = resultStr.Substring(1).Trim();

			if (resultStr.StartsWith("1")) // atualização obrigatória
			{
				if (string.IsNullOrWhiteSpace(downloadURI))
				{
					try
					{
						System.Diagnostics.Process.Start(Utils.website);
					}
					catch (Exception) { }
					MessageBox.Show(String.Format(Utils.GetString("Splash_RequiredUpdateDownload"), Environment.NewLine, Utils.website),
						Utils.GetString("Splash_RequiredUpdateDownloadTitle"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
					Finish();
					return;
				}
				else
				{
					updateStream = new WebClient();
					updateStream.DownloadProgressChanged += new DownloadProgressChangedEventHandler(UpdateProgress);
					updateStream.DownloadFileCompleted += new AsyncCompletedEventHandler(UpdateCompleted);
					this.requiredUpdate = true;
					updatingProgressBar.Visible = true;
					this.updateTempFile = Utils.GetTempFile();
					updateStream.DownloadFileAsync(new Uri(downloadURI), this.updateTempFile);
					return;
				}
			}
			else if(resultStr.StartsWith("2")) // Atualização opcional
			{
				if (string.IsNullOrWhiteSpace(downloadURI))
				{
					try
					{
						System.Diagnostics.Process.Start(Utils.website);
					}
					catch (Exception) { }
					MessageBox.Show(String.Format(Utils.GetString("Splash_UpdateDownload"), Environment.NewLine),
						Utils.GetString("Splash_UpdateDownloadTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
				}
				else
				{
					if (MessageBox.Show(String.Format(Utils.GetString("Splash_UpdateQuestion"), Environment.NewLine),
						Utils.GetString("Splash_UpdateQuestionTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
					{
						updateStream = new WebClient();
						updateStream.DownloadProgressChanged += new DownloadProgressChangedEventHandler(UpdateProgress);
						updateStream.DownloadFileCompleted += new AsyncCompletedEventHandler(UpdateCompleted);
						this.requiredUpdate = false;
						updatingProgressBar.Visible = true;
						this.updateTempFile = Utils.GetTempFile();
						updateStream.DownloadFileAsync(new Uri(downloadURI), this.updateTempFile);
						return;
					}
				}
			}
			Start();
		}

		private void UpdateProgress(object sender, DownloadProgressChangedEventArgs e)
		{
			if (e.TotalBytesToReceive > Utils.maxUpdateBytes)
			{
				updatingProgressBar.Style = ProgressBarStyle.Marquee;
				updateStream.CancelAsync();
				return;
			}
			if(e.TotalBytesToReceive < 1 || e.BytesReceived > e.TotalBytesToReceive)
			{
				updatingProgressBar.Style = ProgressBarStyle.Marquee;
				return;
			}
			updatingProgressBar.Style = ProgressBarStyle.Blocks;
			updatingProgressBar.Maximum = 10000;
			updatingProgressBar.Value = (int) ((e.BytesReceived / (double) e.TotalBytesToReceive) * 10000);
		}

		private void UpdateCompleted(object sender, AsyncCompletedEventArgs e)
		{
			System.Diagnostics.ProcessStartInfo processStartInfo;
			System.Diagnostics.Process process;

			updateStream.Dispose();
			if (e.Cancelled || e.Error != null)
			{
				if (this.requiredUpdate)
				{
					try
					{
						System.Diagnostics.Process.Start(Utils.website);
					}
					catch (Exception) { }
					MessageBox.Show(String.Format(Utils.GetString("Splash_RequiredUpdateError"), Environment.NewLine, Utils.website),
						Utils.GetString("Splash_RequiredUpdateErrorTitle"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
					Finish();
				}
				else
				{
					try
					{
						System.Diagnostics.Process.Start(Utils.website);
					}
					catch (Exception) { }
					MessageBox.Show(String.Format(Utils.GetString("Splash_UpdateError"), Environment.NewLine, Utils.website),
						Utils.GetString("Splash_UpdateErrorTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
					Finish();
				}
				return;
			}
			if (this.requiredUpdate)
			{
				if(MessageBox.Show(String.Format(Utils.GetString("Splash_RequiredUpdateDownloaded"), Environment.NewLine),
						Utils.GetString("Splash_RequiredUpdateDownloadedTitle"), MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
				{
					MessageBox.Show(String.Format(Utils.GetString("Splash_RequiredUpdateCancelled"), Environment.NewLine),
						Utils.GetString("Splash_RequiredUpdateCancelledTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
					Finish();
					return;
				}
			}
			System.IO.File.Move(this.updateTempFile, this.updateTempFile + ".exe");
			this.updateTempFile += ".exe";
			process = new System.Diagnostics.Process();
			processStartInfo = new System.Diagnostics.ProcessStartInfo();
			//processStartInfo.UseShellExecute = false;
			processStartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
			processStartInfo.FileName = "cmd.exe";
			processStartInfo.Arguments = "/C taskkill /PID " + System.Diagnostics.Process.GetCurrentProcess().Id + " & \"" + this.updateTempFile + "\"";
			process.StartInfo = processStartInfo;
			process.Start();
			Finish();
		}
	}
}
