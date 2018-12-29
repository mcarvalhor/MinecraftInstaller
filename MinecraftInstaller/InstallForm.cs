using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MinecraftInstaller
{
	public partial class InstallForm : Form
	{
		public InstallForm()
		{
			InitializeComponent();
		}

		private ProcessForm processDialog;

		private void InstallForm_Load(object sender, EventArgs e)
		{
			string savedUsername, savedUsernamePath;
			Regex savedUsernameRegex;
			Match savedUsernameMatch;
			Random rnd;

			try
			{
				savedUsernamePath = System.IO.Path.Combine(Utils.GetAppFolder(), Utils.appDefinitionsPath);
				if(System.IO.File.Exists(savedUsernamePath))
				{
					savedUsername = System.IO.File.ReadAllText(savedUsernamePath);
					savedUsernameRegex = new Regex(@"username\.names:\s*\[\s*([a-zA-Z0-9_]+)\s*(,\s*[a-zA-Z0-9]+\s*)*\]");
					savedUsernameMatch = savedUsernameRegex.Match(savedUsername);
					if(savedUsernameMatch.Success)
					{
						savedUsername = savedUsernameMatch.Groups[1].Value.Trim();
						if (String.IsNullOrWhiteSpace(savedUsername))
						{
							savedUsername = null;
						}
					} else
					{
						savedUsername = null;
					}
				} else
				{
					savedUsername = null;
				}
			} catch(Exception exc)
			{
				savedUsername = null;
				Console.Error.WriteLine("Could not get current saved username: " + exc.ToString());
			}

			if(savedUsername == null)
			{
				rnd = new Random();
				savedUsername = "Player_" + rnd.Next();
			}
			
			textBoxUser.Text = savedUsername;
			checkBoxIcon.Checked = true;
			labelInfo.Text = String.Format(Utils.GetString("Install_Info"), Environment.NewLine);
			labelTextInfo.Text = Utils.GetString("Install_UsernameFieldText");
			labelTextDescription.Text = String.Format(Utils.GetString("Install_UsernameFieldDescription"), Environment.NewLine);
			checkBoxIcon.Text = Utils.GetString("Install_DesktopFieldText");
			linkLabelClose.Text = Utils.GetString("Install_ButtonClose");
			buttonConfirm.Text = Utils.GetString("Install_ButtonConfirm");
		}

		private void pictureBoxLogo_Click(object sender, EventArgs e)
		{
			try
			{
				System.Diagnostics.Process.Start(Utils.appWebsite);
			}
			catch (Exception) { }
		}

		private void linkLabelClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.Close();
		}

		private void buttonConfirm_Click(object sender, EventArgs e)
		{
			Match regexMatch;

			if (String.IsNullOrWhiteSpace(textBoxUser.Text))
			{
				MessageBox.Show(String.Format(Utils.GetString("Install_UsernameRequired"), Environment.NewLine), Utils.GetString("Install_UsernameRequiredTitle"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
				return;
			}

			textBoxUser.Text = textBoxUser.Text.Trim();
			if (String.IsNullOrWhiteSpace(textBoxUser.Text))
			{
				MessageBox.Show(String.Format(Utils.GetString("Install_UsernameRequired"), Environment.NewLine), Utils.GetString("Install_UsernameRequiredTitle"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
				return;
			}

			regexMatch = Regex.Match(textBoxUser.Text, @"^[A-Za-z0-9_]+$", RegexOptions.IgnoreCase);
			if (!regexMatch.Success)
			{
				MessageBox.Show(String.Format(Utils.GetString("Install_InvalidUsername"), Environment.NewLine), Utils.GetString("Install_InvalidUsernameTitle"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
				return;
			}

			this.Hide();
			this.processDialog = new ProcessForm();
			backgroundWorkerInstall.RunWorkerAsync(new object[] { textBoxUser.Text, checkBoxIcon.Checked, Utils.GetString("Install_Lang") }); // Utils.Install(string, bool, string);
			this.processDialog.ShowDialog();
		}

		private void backgroundWorkerInstall_DoWork(object sender, DoWorkEventArgs e)
		{
			object[] arguments;

			arguments = (object[]) e.Argument;
			e.Result = Utils.Install((string) arguments[0], (bool) arguments[1], (string) arguments[2]);
		}

		private void backgroundWorkerInstall_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			bool result;

			this.processDialog.Finished();
			this.processDialog.Dispose();
			this.processDialog = null;

			result = (bool) e.Result;
			if (result)
			{
				MessageBox.Show(String.Format(Utils.GetString("Install_Success"), Environment.NewLine), Utils.GetString("Install_SuccessTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
			} else
			{
				MessageBox.Show(String.Format(Utils.GetString("Install_Error"), Environment.NewLine), Utils.GetString("Install_ErrorTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
			Program.instanceMutex.ReleaseMutex();
			Application.Restart();
		}
	}
}
