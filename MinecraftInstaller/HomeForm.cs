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

		private ProcessForm processDialog;

		private void HomeForm_Load(object sender, EventArgs e)
		{
			buttonPlay.Text = Utils.GetString("Home_PlayButton");
			buttonImport.Text = Utils.GetString("Home_ImportButton");
			buttonExport.Text = Utils.GetString("Home_ExportButton");
			linkLabelReinstall.Text = Utils.GetString("Home_ReinstallButton");
			linkLabelUninstall.Text = Utils.GetString("Home_UninstallButton");
			linkLabelAbout.Text = Utils.GetString("Home_AboutButton");
			processDialog = null;
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

		private void buttonImport_Click(object sender, EventArgs e)
		{
			OpenFileDialog openDiag;
			openDiag = new OpenFileDialog();
			openDiag.CheckFileExists = true;
			openDiag.CheckPathExists = true;
			openDiag.DefaultExt = "mipf";
			openDiag.DereferenceLinks = true;
			openDiag.Filter = "All Files (*.*)|*.*|Minecraft Installer Progress File (*.mipf)|*.mipf";
			openDiag.FilterIndex = 2;
			openDiag.Multiselect = false;
			openDiag.SupportMultiDottedExtensions = true;
			openDiag.Title = Utils.GetString("Home_ImportChooserTitle");
			if(openDiag.ShowDialog() == DialogResult.OK)
			{
				if (MessageBox.Show(String.Format(Utils.GetString("Home_ImportAlert"), Environment.NewLine), Utils.GetString("Home_ImportAlertTitle"), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.OK)
				{
					this.Hide();
					this.processDialog = new ProcessForm();
					backgroundWorkerImport.RunWorkerAsync(openDiag.FileName); // Utils.Import(string)
					this.processDialog.ShowDialog();
				}
			}
			openDiag.Dispose();
		}

		private void buttonExport_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveDiag;
			saveDiag = new SaveFileDialog();
			saveDiag.AddExtension = true;
			saveDiag.DefaultExt = "mipf";
			saveDiag.Filter = "All Files (*.*)|*.*|Minecraft Installer Progress File (*.mipf)|*.mipf";
			saveDiag.FilterIndex = 2;
			saveDiag.OverwritePrompt = false;
			saveDiag.SupportMultiDottedExtensions = true;
			saveDiag.Title = Utils.GetString("Home_ExportChooserTitle");
			if (saveDiag.ShowDialog() == DialogResult.OK)
			{
				this.Hide();
				this.processDialog = new ProcessForm();
				backgroundWorkerExport.RunWorkerAsync(saveDiag.FileName); // Utils.Export(string)
				this.processDialog.ShowDialog();
			}
			saveDiag.Dispose();
		}

		private void linkLabelReinstall_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			InstallForm diag;
			this.Hide();
			diag = new InstallForm();
			diag.ShowDialog();
			diag.Dispose();
			this.Show();
		}

		private void linkLabelUninstall_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (MessageBox.Show(String.Format(Utils.GetString("Home_UninstallConfirm"), Environment.NewLine), Utils.GetString("Home_UninstallConfirmTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				this.Hide();
				this.processDialog = new ProcessForm();
				backgroundWorkerUninstall.RunWorkerAsync(true); // Utils.Uninstall(bool)
				this.processDialog.ShowDialog();
			}
		}

		private void linkLabelAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			AboutForm diag;
			this.Hide();
			diag = new AboutForm();
			diag.ShowDialog();
			diag.Dispose();
			this.Show();
		}

		private void backgroundWorkerUninstall_DoWork(object sender, DoWorkEventArgs e)
		{
			e.Result = Utils.Uninstall((bool) e.Argument);
		}

		private void backgroundWorkerUninstall_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			System.Diagnostics.ProcessStartInfo processStartInfo;
			System.Diagnostics.Process process;
			bool result;

			this.processDialog.Finished();
			this.processDialog.Dispose();
			this.processDialog = null;

			result = (bool) e.Result;
			if(result)
			{
				process = new System.Diagnostics.Process();
				processStartInfo = new System.Diagnostics.ProcessStartInfo();
				//processStartInfo.UseShellExecute = false;
				processStartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
				processStartInfo.FileName = "cmd.exe";
				processStartInfo.Arguments = "/C taskkill /PID " + System.Diagnostics.Process.GetCurrentProcess().Id + " & rmdir \"" + Utils.GetAppFolder() + "\" /S /Q & rmdir \"" + Utils.GetPath() + "\" /S /Q";
				process.StartInfo = processStartInfo;
				MessageBox.Show(String.Format(Utils.GetString("Home_UninstallSuccess"), Environment.NewLine), Utils.GetString("Home_UninstallSuccessTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
				process.Start();
			} else
			{
				MessageBox.Show(String.Format(Utils.GetString("Home_UninstallError"), Environment.NewLine), Utils.GetString("Home_UninstallErrorTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
			Program.instanceMutex.ReleaseMutex();
			Application.Exit();
		}

		private void backgroundWorkerImport_DoWork(object sender, DoWorkEventArgs e)
		{
			e.Result = Utils.ImportProgress((string) e.Argument);
		}

		private void backgroundWorkerImport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			bool result;

			this.processDialog.Finished();
			this.processDialog.Dispose();
			this.processDialog = null;

			result = (bool)e.Result;
			if (result)
			{
				MessageBox.Show(String.Format(Utils.GetString("Home_ImportSuccess"), Environment.NewLine), Utils.GetString("Home_ImportSuccessTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
			}
			else
			{
				MessageBox.Show(String.Format(Utils.GetString("Home_ImportError"), Environment.NewLine), Utils.GetString("Home_ImportErrorTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}

			this.Show();
		}

		private void backgroundWorkerExport_DoWork(object sender, DoWorkEventArgs e)
		{
			e.Result = Utils.ExportProgress((string) e.Argument);
		}

		private void backgroundWorkerExport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			bool result;

			this.processDialog.Finished();
			this.processDialog.Dispose();
			this.processDialog = null;

			result = (bool)e.Result;
			if (result)
			{
				MessageBox.Show(String.Format(Utils.GetString("Home_ExportSuccess"), Environment.NewLine), Utils.GetString("Home_ExportSuccessTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
			}
			else
			{
				MessageBox.Show(String.Format(Utils.GetString("Home_ExportError"), Environment.NewLine), Utils.GetString("Home_ExportErrorTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}

			this.Show();
		}
	}
}
