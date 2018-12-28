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
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			InitializeComponent();
		}

		private void AboutForm_Load(object sender, EventArgs e)
		{
			textBoxAbout.Text = String.Format(Utils.GetString("About_Text"), Environment.NewLine, System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion, DateTime.Now.Year, Utils.website, Utils.appWebsite, Utils.devWebsite);
			linkLabelWebsite.Text = Utils.website;
			linkLabelAppWebsite.Text = Utils.appWebsite;
			linkLabelDevWebsite.Text = Utils.devWebsite;
			buttonClose.Text = Utils.GetString("About_CloseButton");
			this.ActiveControl = null;
		}

		private void pictureBoxLogo_Click(object sender, EventArgs e)
		{
			linkLabelAppWebsite_LinkClicked(sender, null);
		}

		private void linkLabelDevWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				System.Diagnostics.Process.Start(Utils.devWebsite);
			} catch(Exception) { }
		}

		private void linkLabelAppWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				System.Diagnostics.Process.Start(Utils.appWebsite);
			}
			catch (Exception) { }
		}

		private void linkLabelWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				System.Diagnostics.Process.Start(Utils.website);
			}
			catch (Exception) { }
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

	}
}
