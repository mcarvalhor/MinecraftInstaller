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
			this.buttonExport = new System.Windows.Forms.Button();
			this.buttonImport = new System.Windows.Forms.Button();
			this.buttonPlay = new System.Windows.Forms.Button();
			this.tableLayoutPanelOptions = new System.Windows.Forms.TableLayoutPanel();
			this.linkLabelAbout = new System.Windows.Forms.LinkLabel();
			this.linkLabelUninstall = new System.Windows.Forms.LinkLabel();
			this.linkLabelReinstall = new System.Windows.Forms.LinkLabel();
			this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
			this.backgroundWorkerUninstall = new System.ComponentModel.BackgroundWorker();
			this.backgroundWorkerImport = new System.ComponentModel.BackgroundWorker();
			this.backgroundWorkerExport = new System.ComponentModel.BackgroundWorker();
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
			this.mainTableLayout.Controls.Add(this.buttonExport, 0, 3);
			this.mainTableLayout.Controls.Add(this.buttonImport, 0, 2);
			this.mainTableLayout.Controls.Add(this.buttonPlay, 0, 1);
			this.mainTableLayout.Controls.Add(this.tableLayoutPanelOptions, 0, 4);
			this.mainTableLayout.Controls.Add(this.pictureBoxLogo, 0, 0);
			this.mainTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainTableLayout.Location = new System.Drawing.Point(0, 0);
			this.mainTableLayout.Name = "mainTableLayout";
			this.mainTableLayout.RowCount = 5;
			this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
			this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.mainTableLayout.Size = new System.Drawing.Size(404, 361);
			this.mainTableLayout.TabIndex = 0;
			// 
			// buttonExport
			// 
			this.buttonExport.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonExport.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonExport.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
			this.buttonExport.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.WindowText;
			this.buttonExport.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.WindowFrame;
			this.buttonExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonExport.ForeColor = System.Drawing.SystemColors.Control;
			this.buttonExport.Location = new System.Drawing.Point(10, 272);
			this.buttonExport.Margin = new System.Windows.Forms.Padding(10);
			this.buttonExport.Name = "buttonExport";
			this.buttonExport.Size = new System.Drawing.Size(384, 37);
			this.buttonExport.TabIndex = 4;
			this.buttonExport.Text = "Salvar progresso...";
			this.buttonExport.UseVisualStyleBackColor = true;
			this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
			// 
			// buttonImport
			// 
			this.buttonImport.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonImport.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonImport.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
			this.buttonImport.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.WindowText;
			this.buttonImport.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.WindowFrame;
			this.buttonImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonImport.ForeColor = System.Drawing.SystemColors.Control;
			this.buttonImport.Location = new System.Drawing.Point(10, 215);
			this.buttonImport.Margin = new System.Windows.Forms.Padding(10);
			this.buttonImport.Name = "buttonImport";
			this.buttonImport.Size = new System.Drawing.Size(384, 37);
			this.buttonImport.TabIndex = 4;
			this.buttonImport.Text = "Carregar progresso...";
			this.buttonImport.UseVisualStyleBackColor = true;
			this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
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
			this.buttonPlay.Size = new System.Drawing.Size(384, 95);
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
			this.tableLayoutPanelOptions.Location = new System.Drawing.Point(3, 322);
			this.tableLayoutPanelOptions.Name = "tableLayoutPanelOptions";
			this.tableLayoutPanelOptions.RowCount = 1;
			this.tableLayoutPanelOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelOptions.Size = new System.Drawing.Size(398, 36);
			this.tableLayoutPanelOptions.TabIndex = 1;
			// 
			// linkLabelAbout
			// 
			this.linkLabelAbout.ActiveLinkColor = System.Drawing.SystemColors.Info;
			this.linkLabelAbout.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.linkLabelAbout.AutoSize = true;
			this.linkLabelAbout.LinkColor = System.Drawing.SystemColors.Control;
			this.linkLabelAbout.Location = new System.Drawing.Point(311, 11);
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
			this.linkLabelUninstall.Location = new System.Drawing.Point(169, 11);
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
			this.linkLabelReinstall.Location = new System.Drawing.Point(41, 11);
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
			// backgroundWorkerUninstall
			// 
			this.backgroundWorkerUninstall.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerUninstall_DoWork);
			this.backgroundWorkerUninstall.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerUninstall_RunWorkerCompleted);
			// 
			// backgroundWorkerImport
			// 
			this.backgroundWorkerImport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerImport_DoWork);
			this.backgroundWorkerImport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerImport_RunWorkerCompleted);
			// 
			// backgroundWorkerExport
			// 
			this.backgroundWorkerExport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerExport_DoWork);
			this.backgroundWorkerExport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerExport_RunWorkerCompleted);
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
		private System.Windows.Forms.Button buttonExport;
		private System.Windows.Forms.Button buttonImport;
		private System.ComponentModel.BackgroundWorker backgroundWorkerUninstall;
		private System.ComponentModel.BackgroundWorker backgroundWorkerImport;
		private System.ComponentModel.BackgroundWorker backgroundWorkerExport;
	}
}

