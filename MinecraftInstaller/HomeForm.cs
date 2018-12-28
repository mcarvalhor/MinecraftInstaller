using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MinecraftInstaller
{
	public partial class HomeForm : Form
	{
		public HomeForm()
		{
			InitializeComponent();
		}

		private void HomeForm_Load(object sender, EventArgs e)
		{
			buttonPlay.Text = Utils.GetString("Home_PlayButton");
			linkLabelReinstall.Text = Utils.GetString("Home_ReinstallButton");
			linkLabelUninstall.Text = Utils.GetString("Home_UninstallButton");
			linkLabelAbout.Text = Utils.GetString("Home_AboutButton");
		}

		private void pictureBoxLogo_Click(object sender, EventArgs e)
		{
			try
			{
				System.Diagnostics.Process.Start(Utils.appWebsite);
			}
			catch (Exception) { }
		}

		private void buttonPlay_Click(object sender, EventArgs e)
		{
			System.Diagnostics.ProcessStartInfo processStartInfo;
			System.Diagnostics.Process process;
			string appPath;
			
			this.Hide();
			try
			{
				appPath = Utils.GetAppPath();
				if (!System.IO.File.Exists(appPath))
				{
					MessageBox.Show(String.Format(Utils.GetString("Home_StartNotFound"), Environment.NewLine), Utils.GetString("Home_StartNotFoundTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					this.Show();
					return;
				}
				process = new System.Diagnostics.Process();
				processStartInfo = new System.Diagnostics.ProcessStartInfo();
				processStartInfo.FileName = appPath;
				process.StartInfo = processStartInfo;
				process.Start();
				process.WaitForExit();
			}
			catch (Exception) {
				MessageBox.Show(String.Format(Utils.GetString("Home_StartError"), Environment.NewLine), Utils.GetString("Home_StartErrorTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
			this.Show();
		}

		private void linkLabelReinstall_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.Hide();
			new InstallForm().ShowDialog();
			this.Show();
		}

		private void linkLabelUninstall_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.ProcessStartInfo processStartInfo;
			System.Diagnostics.Process process;
			if (MessageBox.Show(String.Format(Utils.GetString("Home_UninstallConfirm"), Environment.NewLine), Utils.GetString("Home_UninstallConfirmTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				this.Hide();
				if(Utils.Uninstall(true))
				{
					MessageBox.Show(String.Format(Utils.GetString("Home_UninstallSuccess"), Environment.NewLine), Utils.GetString("Home_UninstallSuccessTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
					process = new System.Diagnostics.Process();
					processStartInfo = new System.Diagnostics.ProcessStartInfo();
					//processStartInfo.UseShellExecute = false;
					processStartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
					processStartInfo.FileName = "cmd.exe";
					processStartInfo.Arguments = "/C taskkill /PID " + System.Diagnostics.Process.GetCurrentProcess().Id + " & rmdir \"" + Utils.GetPath() + "\" /S /Q & rmdir \"" + Utils.GetAppFolder() + "\" /S /Q";
					process.StartInfo = processStartInfo;
					process.Start();
				} else
				{
					MessageBox.Show(String.Format(Utils.GetString("Home_UninstallError"), Environment.NewLine), Utils.GetString("Home_UninstallErrorTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				}
				Program.instanceMutex.ReleaseMutex();
				Application.Exit();
			}
		}

		private void linkLabelAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.Hide();
			new AboutForm().ShowDialog();
			this.Show();
		}

	}
}
