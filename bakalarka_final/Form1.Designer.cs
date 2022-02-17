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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.count_L = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.faceCount_L = new System.Windows.Forms.Label();
            this.minFaceSize = new System.Windows.Forms.TrackBar();
            this.minFaceSize_L = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minFaceSize)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(615, 404);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(634, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // count_L
            // 
            this.count_L.AutoSize = true;
            this.count_L.Location = new System.Drawing.Point(634, 39);
            this.count_L.Name = "count_L";
            this.count_L.Size = new System.Drawing.Size(35, 13);
            this.count_L.TabIndex = 2;
            this.count_L.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(634, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(634, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "label3";
            // 
            // faceCount_L
            // 
            this.faceCount_L.AutoSize = true;
            this.faceCount_L.Location = new System.Drawing.Point(675, 361);
            this.faceCount_L.Name = "faceCount_L";
            this.faceCount_L.Size = new System.Drawing.Size(35, 13);
            this.faceCount_L.TabIndex = 5;
            this.faceCount_L.Text = "label4";
            // 
            // minFaceSize
            // 
            this.minFaceSize.Location = new System.Drawing.Point(646, 185);
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
            this.minFaceSize_L.Location = new System.Drawing.Point(643, 217);
            this.minFaceSize_L.Name = "minFaceSize_L";
            this.minFaceSize_L.Size = new System.Drawing.Size(13, 13);
            this.minFaceSize_L.TabIndex = 7;
            this.minFaceSize_L.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.minFaceSize_L);
            this.Controls.Add(this.minFaceSize);
            this.Controls.Add(this.faceCount_L);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.count_L);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minFaceSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label count_L;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label faceCount_L;
        private System.Windows.Forms.Label minFaceSize_L;
        private System.Windows.Forms.TrackBar minFaceSize;
    }
}

