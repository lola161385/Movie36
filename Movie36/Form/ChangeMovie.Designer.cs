namespace Movie36
{
    partial class ChangeMovie
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
            this.savebtn = new System.Windows.Forms.Button();
            this.imgbtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.MovieType = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.MovieOverview = new System.Windows.Forms.RichTextBox();
            this.MovieRelesedate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.MovieRating = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Movieproducer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MoviePerformer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MovieName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(308, 314);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(150, 101);
            this.savebtn.TabIndex = 37;
            this.savebtn.Text = "수정";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // imgbtn
            // 
            this.imgbtn.Location = new System.Drawing.Point(344, 267);
            this.imgbtn.Name = "imgbtn";
            this.imgbtn.Size = new System.Drawing.Size(75, 23);
            this.imgbtn.TabIndex = 36;
            this.imgbtn.Text = "불러오기";
            this.imgbtn.UseVisualStyleBackColor = true;
            this.imgbtn.Click += new System.EventHandler(this.imgbtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(308, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 210);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 12);
            this.label7.TabIndex = 34;
            this.label7.Text = "영화 장르";
            // 
            // MovieType
            // 
            this.MovieType.Location = new System.Drawing.Point(22, 101);
            this.MovieType.Name = "MovieType";
            this.MovieType.Size = new System.Drawing.Size(100, 21);
            this.MovieType.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 12);
            this.label6.TabIndex = 32;
            this.label6.Text = "영화 요약";
            // 
            // MovieOverview
            // 
            this.MovieOverview.Location = new System.Drawing.Point(22, 269);
            this.MovieOverview.Name = "MovieOverview";
            this.MovieOverview.Size = new System.Drawing.Size(227, 146);
            this.MovieOverview.TabIndex = 31;
            this.MovieOverview.Text = "";
            // 
            // MovieRelesedate
            // 
            this.MovieRelesedate.Location = new System.Drawing.Point(22, 214);
            this.MovieRelesedate.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.MovieRelesedate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.MovieRelesedate.Name = "MovieRelesedate";
            this.MovieRelesedate.Size = new System.Drawing.Size(227, 21);
            this.MovieRelesedate.TabIndex = 30;
            this.MovieRelesedate.Value = new System.DateTime(2024, 11, 19, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 12);
            this.label5.TabIndex = 29;
            this.label5.Text = "영화 개봉 일자";
            // 
            // MovieRating
            // 
            this.MovieRating.FormattingEnabled = true;
            this.MovieRating.Items.AddRange(new object[] {
            "전체",
            "12세 이상",
            "15세 이상",
            "19세 이상"});
            this.MovieRating.Location = new System.Drawing.Point(149, 37);
            this.MovieRating.Name = "MovieRating";
            this.MovieRating.Size = new System.Drawing.Size(100, 20);
            this.MovieRating.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(147, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 12);
            this.label4.TabIndex = 27;
            this.label4.Text = "영화 관란 등급";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(149, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 26;
            this.label3.Text = "영화 감독";
            // 
            // Movieproducer
            // 
            this.Movieproducer.Location = new System.Drawing.Point(149, 101);
            this.Movieproducer.Name = "Movieproducer";
            this.Movieproducer.Size = new System.Drawing.Size(100, 21);
            this.Movieproducer.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 12);
            this.label2.TabIndex = 24;
            this.label2.Text = "영화 출연자";
            // 
            // MoviePerformer
            // 
            this.MoviePerformer.Location = new System.Drawing.Point(22, 159);
            this.MoviePerformer.Name = "MoviePerformer";
            this.MoviePerformer.Size = new System.Drawing.Size(227, 21);
            this.MoviePerformer.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "영화 제목";
            // 
            // MovieName
            // 
            this.MovieName.Location = new System.Drawing.Point(22, 36);
            this.MovieName.Name = "MovieName";
            this.MovieName.Size = new System.Drawing.Size(100, 21);
            this.MovieName.TabIndex = 21;
            // 
            // ChangeMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 436);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.imgbtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.MovieType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.MovieOverview);
            this.Controls.Add(this.MovieRelesedate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.MovieRating);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Movieproducer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MoviePerformer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MovieName);
            this.Name = "ChangeMovie";
            this.Text = "ChangeMovie";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Button imgbtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox MovieType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox MovieOverview;
        private System.Windows.Forms.DateTimePicker MovieRelesedate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox MovieRating;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Movieproducer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MoviePerformer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MovieName;
    }
}