﻿namespace Movie36
{
    partial class main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.enroll_movieBtn = new System.Windows.Forms.Button();
            this.enroll_screenBtn = new System.Windows.Forms.Button();
            this.enroll_foodBtn = new System.Windows.Forms.Button();
            this.enroll_scheduleBtn = new System.Windows.Forms.Button();
            this.ticketBtn = new System.Windows.Forms.Button();
            this.order_foodBtn = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // enroll_movieBtn
            // 
            this.enroll_movieBtn.Location = new System.Drawing.Point(240, 137);
            this.enroll_movieBtn.Name = "enroll_movieBtn";
            this.enroll_movieBtn.Size = new System.Drawing.Size(75, 75);
            this.enroll_movieBtn.TabIndex = 0;
            this.enroll_movieBtn.Text = "영화등록";
            this.enroll_movieBtn.UseVisualStyleBackColor = true;
            this.enroll_movieBtn.Click += new System.EventHandler(this.enroll_movieBtn_Click);
            // 
            // enroll_screenBtn
            // 
            this.enroll_screenBtn.Location = new System.Drawing.Point(240, 218);
            this.enroll_screenBtn.Name = "enroll_screenBtn";
            this.enroll_screenBtn.Size = new System.Drawing.Size(75, 75);
            this.enroll_screenBtn.TabIndex = 1;
            this.enroll_screenBtn.Text = "상영관";
            this.enroll_screenBtn.UseVisualStyleBackColor = true;
            this.enroll_screenBtn.Click += new System.EventHandler(this.enroll_screenBtn_Click);
            // 
            // enroll_foodBtn
            // 
            this.enroll_foodBtn.Location = new System.Drawing.Point(321, 137);
            this.enroll_foodBtn.Name = "enroll_foodBtn";
            this.enroll_foodBtn.Size = new System.Drawing.Size(75, 75);
            this.enroll_foodBtn.TabIndex = 2;
            this.enroll_foodBtn.Text = "음식등록";
            this.enroll_foodBtn.UseVisualStyleBackColor = true;
            this.enroll_foodBtn.Click += new System.EventHandler(this.enroll_foodBtn_Click);
            // 
            // enroll_scheduleBtn
            // 
            this.enroll_scheduleBtn.Location = new System.Drawing.Point(321, 218);
            this.enroll_scheduleBtn.Name = "enroll_scheduleBtn";
            this.enroll_scheduleBtn.Size = new System.Drawing.Size(75, 75);
            this.enroll_scheduleBtn.TabIndex = 3;
            this.enroll_scheduleBtn.Text = "상영시간표";
            this.enroll_scheduleBtn.UseVisualStyleBackColor = true;
            this.enroll_scheduleBtn.Click += new System.EventHandler(this.enroll_scheduleBtn_Click);
            // 
            // ticketBtn
            // 
            this.ticketBtn.Location = new System.Drawing.Point(402, 137);
            this.ticketBtn.Name = "ticketBtn";
            this.ticketBtn.Size = new System.Drawing.Size(75, 75);
            this.ticketBtn.TabIndex = 4;
            this.ticketBtn.Text = "티켓구매";
            this.ticketBtn.UseVisualStyleBackColor = true;
            this.ticketBtn.Click += new System.EventHandler(this.ticketBtn_Click);
            // 
            // order_foodBtn
            // 
            this.order_foodBtn.Location = new System.Drawing.Point(402, 218);
            this.order_foodBtn.Name = "order_foodBtn";
            this.order_foodBtn.Size = new System.Drawing.Size(75, 75);
            this.order_foodBtn.TabIndex = 5;
            this.order_foodBtn.Text = "음식주문";
            this.order_foodBtn.UseVisualStyleBackColor = true;
            this.order_foodBtn.Click += new System.EventHandler(this.order_foodBtn_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(483, 137);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 75);
            this.button7.TabIndex = 6;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(483, 218);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 75);
            this.button8.TabIndex = 7;
            this.button8.Text = "button8";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.order_foodBtn);
            this.Controls.Add(this.ticketBtn);
            this.Controls.Add(this.enroll_scheduleBtn);
            this.Controls.Add(this.enroll_foodBtn);
            this.Controls.Add(this.enroll_screenBtn);
            this.Controls.Add(this.enroll_movieBtn);
            this.Name = "main";
            this.Text = "메인화면";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button enroll_movieBtn;
        private System.Windows.Forms.Button enroll_screenBtn;
        private System.Windows.Forms.Button enroll_foodBtn;
        private System.Windows.Forms.Button enroll_scheduleBtn;
        private System.Windows.Forms.Button ticketBtn;
        private System.Windows.Forms.Button order_foodBtn;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
    }
}
