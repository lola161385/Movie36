namespace Movie36
{
    partial class Efood
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
            this.FoodName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FoodCategory = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FoodPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.foodDescription = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.imageBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.FoodQuantity = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FoodQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // FoodName
            // 
            this.FoodName.Location = new System.Drawing.Point(149, 108);
            this.FoodName.Margin = new System.Windows.Forms.Padding(7);
            this.FoodName.Name = "FoodName";
            this.FoodName.Size = new System.Drawing.Size(223, 39);
            this.FoodName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "상품명";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 184);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "분류";
            // 
            // FoodCategory
            // 
            this.FoodCategory.Location = new System.Drawing.Point(149, 225);
            this.FoodCategory.Margin = new System.Windows.Forms.Padding(7);
            this.FoodCategory.Name = "FoodCategory";
            this.FoodCategory.Size = new System.Drawing.Size(223, 39);
            this.FoodCategory.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(149, 310);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 27);
            this.label3.TabIndex = 5;
            this.label3.Text = "가격";
            // 
            // FoodPrice
            // 
            this.FoodPrice.Location = new System.Drawing.Point(149, 351);
            this.FoodPrice.Margin = new System.Windows.Forms.Padding(7);
            this.FoodPrice.Name = "FoodPrice";
            this.FoodPrice.Size = new System.Drawing.Size(223, 39);
            this.FoodPrice.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(149, 556);
            this.label4.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 27);
            this.label4.TabIndex = 7;
            this.label4.Text = "설명";
            // 
            // foodDescription
            // 
            this.foodDescription.Location = new System.Drawing.Point(153, 590);
            this.foodDescription.Margin = new System.Windows.Forms.Padding(7);
            this.foodDescription.Name = "foodDescription";
            this.foodDescription.Size = new System.Drawing.Size(614, 211);
            this.foodDescription.TabIndex = 8;
            this.foodDescription.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(149, 443);
            this.label5.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 27);
            this.label5.TabIndex = 10;
            this.label5.Text = "수량";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(439, 108);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(334, 380);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(434, 68);
            this.label6.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 27);
            this.label6.TabIndex = 12;
            this.label6.Text = "상품 이미지";
            // 
            // imageBtn
            // 
            this.imageBtn.Location = new System.Drawing.Point(514, 502);
            this.imageBtn.Margin = new System.Windows.Forms.Padding(7);
            this.imageBtn.Name = "imageBtn";
            this.imageBtn.Size = new System.Drawing.Size(171, 52);
            this.imageBtn.TabIndex = 13;
            this.imageBtn.Text = "불러오기";
            this.imageBtn.UseVisualStyleBackColor = true;
            this.imageBtn.Click += new System.EventHandler(this.imageBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(153, 846);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(7);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(619, 92);
            this.saveBtn.TabIndex = 14;
            this.saveBtn.Text = "등록";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // FoodQuantity
            // 
            this.FoodQuantity.Location = new System.Drawing.Point(149, 479);
            this.FoodQuantity.Margin = new System.Windows.Forms.Padding(7);
            this.FoodQuantity.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.FoodQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FoodQuantity.Name = "FoodQuantity";
            this.FoodQuantity.Size = new System.Drawing.Size(229, 39);
            this.FoodQuantity.TabIndex = 15;
            this.FoodQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Efood
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 1012);
            this.Controls.Add(this.FoodQuantity);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.imageBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.foodDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FoodPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FoodCategory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FoodName);
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "Efood";
            this.Text = "Efood";
            this.Load += new System.EventHandler(this.Efood_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FoodQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FoodName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FoodCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FoodPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox foodDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button imageBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.NumericUpDown FoodQuantity;
    }
}