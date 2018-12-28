namespace MinecraftInstaller
{
	partial class SplashScreen
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
			this.updatingProgressBar = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// updatingProgressBar
			// 
			this.updatingProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.updatingProgressBar.Location = new System.Drawing.Point(0, 290);
			this.updatingProgressBar.MarqueeAnimationSpeed = 50;
			this.updatingProgressBar.Name = "updatingProgressBar";
			this.updatingProgressBar.Size = new System.Drawing.Size(300, 10);
			this.updatingProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.updatingProgressBar.TabIndex = 0;
			this.updatingProgressBar.Visible = false;
			// 
			// SplashScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.BackgroundImage = global::MinecraftInstaller.Properties.Resources.logoBg;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ClientSize = new System.Drawing.Size(300, 300);
			this.ControlBox = false;
			this.Controls.Add(this.updatingProgressBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SplashScreen";
			this.Opacity = 0D;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MinecraftInstaller";
			this.TopMost = true;
			this.TransparencyKey = System.Drawing.Color.White;
			this.Load += new System.EventHandler(this.SplashScreen_Load);
			this.Shown += new System.EventHandler(this.SplashScreen_Shown);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ProgressBar updatingProgressBar;
	}
}