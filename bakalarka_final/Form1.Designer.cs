namespace bakalarka_final
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.side_L = new System.Windows.Forms.Label();
            this.rectEmpty_L = new System.Windows.Forms.Label();
            this.minFaceSize = new System.Windows.Forms.TrackBar();
            this.minFaceSize_L = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slovakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displaySettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCountLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.developerModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseCameraDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.test = new System.Windows.Forms.Button();
            this.count_L = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minFaceSize)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(615, 404);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // side_L
            // 
            this.side_L.AutoSize = true;
            this.side_L.Location = new System.Drawing.Point(633, 241);
            this.side_L.Name = "side_L";
            this.side_L.Size = new System.Drawing.Size(35, 13);
            this.side_L.TabIndex = 3;
            this.side_L.Text = "label2";
            // 
            // rectEmpty_L
            // 
            this.rectEmpty_L.AutoSize = true;
            this.rectEmpty_L.Location = new System.Drawing.Point(633, 254);
            this.rectEmpty_L.Name = "rectEmpty_L";
            this.rectEmpty_L.Size = new System.Drawing.Size(35, 13);
            this.rectEmpty_L.TabIndex = 4;
            this.rectEmpty_L.Text = "label3";
            // 
            // minFaceSize
            // 
            this.minFaceSize.Location = new System.Drawing.Point(645, 304);
            this.minFaceSize.Maximum = 1000;
            this.minFaceSize.Minimum = 1;
            this.minFaceSize.Name = "minFaceSize";
            this.minFaceSize.Size = new System.Drawing.Size(142, 45);
            this.minFaceSize.TabIndex = 6;
            this.minFaceSize.Value = 1;
            this.minFaceSize.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // minFaceSize_L
            // 
            this.minFaceSize_L.AutoSize = true;
            this.minFaceSize_L.Location = new System.Drawing.Point(655, 288);
            this.minFaceSize_L.Name = "minFaceSize_L";
            this.minFaceSize_L.Size = new System.Drawing.Size(13, 13);
            this.minFaceSize_L.TabIndex = 7;
            this.minFaceSize_L.Text = "0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.deviceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(843, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.slovakToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // slovakToolStripMenuItem
            // 
            this.slovakToolStripMenuItem.Name = "slovakToolStripMenuItem";
            this.slovakToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.slovakToolStripMenuItem.Text = "Slovenčina";
            this.slovakToolStripMenuItem.Click += new System.EventHandler(this.slovakToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displaySettingsToolStripMenuItem,
            this.otherSettingsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // displaySettingsToolStripMenuItem
            // 
            this.displaySettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showCountLineToolStripMenuItem});
            this.displaySettingsToolStripMenuItem.Name = "displaySettingsToolStripMenuItem";
            this.displaySettingsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.displaySettingsToolStripMenuItem.Text = "Display settings";
            // 
            // showCountLineToolStripMenuItem
            // 
            this.showCountLineToolStripMenuItem.CheckOnClick = true;
            this.showCountLineToolStripMenuItem.Name = "showCountLineToolStripMenuItem";
            this.showCountLineToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.showCountLineToolStripMenuItem.Text = "Show count line";
            // 
            // otherSettingsToolStripMenuItem
            // 
            this.otherSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.developerModeToolStripMenuItem});
            this.otherSettingsToolStripMenuItem.Name = "otherSettingsToolStripMenuItem";
            this.otherSettingsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.otherSettingsToolStripMenuItem.Text = "Other settings";
            // 
            // developerModeToolStripMenuItem
            // 
            this.developerModeToolStripMenuItem.CheckOnClick = true;
            this.developerModeToolStripMenuItem.Name = "developerModeToolStripMenuItem";
            this.developerModeToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.developerModeToolStripMenuItem.Text = "Developer mode";
            this.developerModeToolStripMenuItem.CheckedChanged += new System.EventHandler(this.developerModeToolStripMenuItem_CheckedChanged);
            // 
            // deviceToolStripMenuItem
            // 
            this.deviceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseCameraDeviceToolStripMenuItem});
            this.deviceToolStripMenuItem.Name = "deviceToolStripMenuItem";
            this.deviceToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.deviceToolStripMenuItem.Text = "Device";
            // 
            // chooseCameraDeviceToolStripMenuItem
            // 
            this.chooseCameraDeviceToolStripMenuItem.Name = "chooseCameraDeviceToolStripMenuItem";
            this.chooseCameraDeviceToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.chooseCameraDeviceToolStripMenuItem.Text = "Choose camera device";
            this.chooseCameraDeviceToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.chooseCameraDeviceToolStripMenuItem_DropDownItemClicked);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(677, 407);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(110, 23);
            this.test.TabIndex = 10;
            this.test.Text = "test for lang var";
            this.test.UseVisualStyleBackColor = true;
            this.test.Click += new System.EventHandler(this.button2_Click);
            // 
            // count_L
            // 
            this.count_L.AutoSize = true;
            this.count_L.Location = new System.Drawing.Point(771, 202);
            this.count_L.Name = "count_L";
            this.count_L.Size = new System.Drawing.Size(35, 13);
            this.count_L.TabIndex = 2;
            this.count_L.Text = "label1";
            this.count_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(650, 135);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 45);
            this.start.TabIndex = 1;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.button1_Click);
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(731, 135);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 45);
            this.stop.TabIndex = 12;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 490);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.start);
            this.Controls.Add(this.count_L);
            this.Controls.Add(this.test);
            this.Controls.Add(this.minFaceSize_L);
            this.Controls.Add(this.minFaceSize);
            this.Controls.Add(this.rectEmpty_L);
            this.Controls.Add(this.side_L);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minFaceSize)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label side_L;
        private System.Windows.Forms.Label rectEmpty_L;
        private System.Windows.Forms.Label minFaceSize_L;
        private System.Windows.Forms.TrackBar minFaceSize;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem slovakToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem deviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chooseCameraDeviceToolStripMenuItem;
        private System.Windows.Forms.Button test;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displaySettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showCountLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otherSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem developerModeToolStripMenuItem;
        private System.Windows.Forms.Label count_L;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button stop;
    }
}

