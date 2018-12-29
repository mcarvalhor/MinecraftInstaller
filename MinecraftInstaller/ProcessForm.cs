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
	public partial class ProcessForm : Form
	{
		public ProcessForm()
		{
			InitializeComponent();
		}

		private bool close;

		private void ProcessForm_Load(object sender, EventArgs e)
		{
			this.close = false;
			labelText.Text = String.Format(Utils.GetString("Process_Text"), Environment.NewLine);
		}

		private void ProcessForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!this.close)
			{
				e.Cancel = true;
				System.Media.SystemSounds.Beep.Play();
			}
		}

		public void Finished()
		{
			this.close = true;
			this.Close();
		}

	}
}
