namespace Movie36
{
    partial class INVmovie
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.AddMoviebtn = new System.Windows.Forms.Button();
            this.Closedbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(64, 32);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(665, 328);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // AddMoviebtn
            // 
            this.AddMoviebtn.Location = new System.Drawing.Point(557, 366);
            this.AddMoviebtn.Name = "AddMoviebtn";
            this.AddMoviebtn.Size = new System.Drawing.Size(81, 72);
            this.AddMoviebtn.TabIndex = 1;
            this.AddMoviebtn.Text = "영화 등록";
            this.AddMoviebtn.UseVisualStyleBackColor = true;
            this.AddMoviebtn.Click += new System.EventHandler(this.AddMoviebtn_Click);
            // 
            // Closedbtn
            // 
            this.Closedbtn.Location = new System.Drawing.Point(648, 366);
            this.Closedbtn.Name = "Closedbtn";
            this.Closedbtn.Size = new System.Drawing.Size(81, 72);
            this.Closedbtn.TabIndex = 2;
            this.Closedbtn.Text = "닫기";
            this.Closedbtn.UseVisualStyleBackColor = true;
            this.Closedbtn.Click += new System.EventHandler(this.Closedbtn_Click);
            // 
            // INVmovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Closedbtn);
            this.Controls.Add(this.AddMoviebtn);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "INVmovie";
            this.Text = "INVmovie";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button AddMoviebtn;
        private System.Windows.Forms.Button Closedbtn;
    }
}