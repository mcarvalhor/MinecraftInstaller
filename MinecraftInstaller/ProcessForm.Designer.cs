namespace MinecraftInstaller
{
	partial class ProcessForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessForm));
			this.labelText = new System.Windows.Forms.Label();
			this.progressBarMarquee = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// labelText
			// 
			this.labelText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelText.Location = new System.Drawing.Point(0, 0);
			this.labelText.Name = "labelText";
			this.labelText.Size = new System.Drawing.Size(294, 86);
			this.labelText.TabIndex = 0;
			this.labelText.Text = "Aguarde um momento...";
			this.labelText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// progressBarMarquee
			// 
			this.progressBarMarquee.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.progressBarMarquee.Location = new System.Drawing.Point(0, 86);
			this.progressBarMarquee.Name = "progressBarMarquee";
			this.progressBarMarquee.Size = new System.Drawing.Size(294, 35);
			this.progressBarMarquee.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.progressBarMarquee.TabIndex = 1;
			// 
			// ProcessForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(294, 121);
			this.Controls.Add(this.labelText);
			this.Controls.Add(this.progressBarMarquee);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "ProcessForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MinecraftInstaller";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProcessForm_FormClosing);
			this.Load += new System.EventHandler(this.ProcessForm_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label labelText;
		private System.Windows.Forms.ProgressBar progressBarMarquee;
	}
}