namespace MinecraftInstaller
{
	partial class HomeForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
			this.mainTableLayout = new System.Windows.Forms.TableLayoutPanel();
			this.buttonPlay = new System.Windows.Forms.Button();
			this.tableLayoutPanelOptions = new System.Windows.Forms.TableLayoutPanel();
			this.linkLabelAbout = new System.Windows.Forms.LinkLabel();
			this.linkLabelUninstall = new System.Windows.Forms.LinkLabel();
			this.linkLabelReinstall = new System.Windows.Forms.LinkLabel();
			this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
			this.mainTableLayout.SuspendLayout();
			this.tableLayoutPanelOptions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
			this.SuspendLayout();
			// 
			// mainTableLayout
			// 
			this.mainTableLayout.BackColor = System.Drawing.Color.Transparent;
			this.mainTableLayout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.mainTableLayout.ColumnCount = 1;
			this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainTableLayout.Controls.Add(this.buttonPlay, 0, 1);
			this.mainTableLayout.Controls.Add(this.tableLayoutPanelOptions, 0, 2);
			this.mainTableLayout.Controls.Add(this.pictureBoxLogo, 0, 0);
			this.mainTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainTableLayout.Location = new System.Drawing.Point(0, 0);
			this.mainTableLayout.Name = "mainTableLayout";
			this.mainTableLayout.RowCount = 3;
			this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
			this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.mainTableLayout.Size = new System.Drawing.Size(404, 361);
			this.mainTableLayout.TabIndex = 0;
			// 
			// buttonPlay
			// 
			this.buttonPlay.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonPlay.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonPlay.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
			this.buttonPlay.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.WindowText;
			this.buttonPlay.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.WindowFrame;
			this.buttonPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonPlay.ForeColor = System.Drawing.SystemColors.Control;
			this.buttonPlay.Location = new System.Drawing.Point(10, 100);
			this.buttonPlay.Margin = new System.Windows.Forms.Padding(10);
			this.buttonPlay.Name = "buttonPlay";
			this.buttonPlay.Size = new System.Drawing.Size(384, 211);
			this.buttonPlay.TabIndex = 0;
			this.buttonPlay.Text = "Jogar";
			this.buttonPlay.UseVisualStyleBackColor = true;
			this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
			// 
			// tableLayoutPanelOptions
			// 
			this.tableLayoutPanelOptions.ColumnCount = 4;
			this.tableLayoutPanelOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
			this.tableLayoutPanelOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
			this.tableLayoutPanelOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
			this.tableLayoutPanelOptions.Controls.Add(this.linkLabelAbout, 3, 0);
			this.tableLayoutPanelOptions.Controls.Add(this.linkLabelUninstall, 2, 0);
			this.tableLayoutPanelOptions.Controls.Add(this.linkLabelReinstall, 1, 0);
			this.tableLayoutPanelOptions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelOptions.Location = new System.Drawing.Point(3, 324);
			this.tableLayoutPanelOptions.Name = "tableLayoutPanelOptions";
			this.tableLayoutPanelOptions.RowCount = 1;
			this.tableLayoutPanelOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelOptions.Size = new System.Drawing.Size(398, 34);
			this.tableLayoutPanelOptions.TabIndex = 1;
			// 
			// linkLabelAbout
			// 
			this.linkLabelAbout.ActiveLinkColor = System.Drawing.SystemColors.Info;
			this.linkLabelAbout.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.linkLabelAbout.AutoSize = true;
			this.linkLabelAbout.LinkColor = System.Drawing.SystemColors.Control;
			this.linkLabelAbout.Location = new System.Drawing.Point(311, 10);
			this.linkLabelAbout.Name = "linkLabelAbout";
			this.linkLabelAbout.Size = new System.Drawing.Size(44, 13);
			this.linkLabelAbout.TabIndex = 0;
			this.linkLabelAbout.TabStop = true;
			this.linkLabelAbout.Text = "Sobre...";
			this.linkLabelAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabelAbout.VisitedLinkColor = System.Drawing.SystemColors.Info;
			this.linkLabelAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAbout_LinkClicked);
			// 
			// linkLabelUninstall
			// 
			this.linkLabelUninstall.ActiveLinkColor = System.Drawing.SystemColors.Info;
			this.linkLabelUninstall.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.linkLabelUninstall.AutoSize = true;
			this.linkLabelUninstall.LinkColor = System.Drawing.SystemColors.Control;
			this.linkLabelUninstall.Location = new System.Drawing.Point(169, 10);
			this.linkLabelUninstall.Name = "linkLabelUninstall";
			this.linkLabelUninstall.Size = new System.Drawing.Size(68, 13);
			this.linkLabelUninstall.TabIndex = 1;
			this.linkLabelUninstall.TabStop = true;
			this.linkLabelUninstall.Text = "Desinstalar...";
			this.linkLabelUninstall.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabelUninstall.VisitedLinkColor = System.Drawing.SystemColors.Info;
			this.linkLabelUninstall.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelUninstall_LinkClicked);
			// 
			// linkLabelReinstall
			// 
			this.linkLabelReinstall.ActiveLinkColor = System.Drawing.SystemColors.Info;
			this.linkLabelReinstall.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.linkLabelReinstall.AutoSize = true;
			this.linkLabelReinstall.LinkColor = System.Drawing.SystemColors.Control;
			this.linkLabelReinstall.Location = new System.Drawing.Point(41, 10);
			this.linkLabelReinstall.Name = "linkLabelReinstall";
			this.linkLabelReinstall.Size = new System.Drawing.Size(63, 13);
			this.linkLabelReinstall.TabIndex = 2;
			this.linkLabelReinstall.TabStop = true;
			this.linkLabelReinstall.Text = "Reinstalar...";
			this.linkLabelReinstall.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabelReinstall.VisitedLinkColor = System.Drawing.SystemColors.Info;
			this.linkLabelReinstall.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelReinstall_LinkClicked);
			// 
			// pictureBoxLogo
			// 
			this.pictureBoxLogo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBoxLogo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBoxLogo.ErrorImage = null;
			this.pictureBoxLogo.Image = global::MinecraftInstaller.Properties.Resources.mcLogo;
			this.pictureBoxLogo.InitialImage = null;
			this.pictureBoxLogo.Location = new System.Drawing.Point(3, 3);
			this.pictureBoxLogo.Name = "pictureBoxLogo";
			this.pictureBoxLogo.Size = new System.Drawing.Size(398, 84);
			this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxLogo.TabIndex = 2;
			this.pictureBoxLogo.TabStop = false;
			this.pictureBoxLogo.Click += new System.EventHandler(this.pictureBoxLogo_Click);
			// 
			// HomeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::MinecraftInstaller.Properties.Resources.background;
			this.ClientSize = new System.Drawing.Size(404, 361);
			this.Controls.Add(this.mainTableLayout);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "HomeForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MinecraftInstaller";
			this.Load += new System.EventHandler(this.HomeForm_Load);
			this.mainTableLayout.ResumeLayout(false);
			this.tableLayoutPanelOptions.ResumeLayout(false);
			this.tableLayoutPanelOptions.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainTableLayout;
		private System.Windows.Forms.Button buttonPlay;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelOptions;
		private System.Windows.Forms.LinkLabel linkLabelAbout;
		private System.Windows.Forms.LinkLabel linkLabelUninstall;
		private System.Windows.Forms.LinkLabel linkLabelReinstall;
		private System.Windows.Forms.PictureBox pictureBoxLogo;
	}
}

