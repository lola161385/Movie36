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
            this.enroll_foodBtn = new System.Windows.Forms.Button();
            this.enroll_scheduleBtn = new System.Windows.Forms.Button();
            this.ticketBtn = new System.Windows.Forms.Button();
            this.order_foodBtn = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.Check_orderbtn = new System.Windows.Forms.Button();
            this.ticketprintbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // enroll_foodBtn
            // 
            this.enroll_foodBtn.Location = new System.Drawing.Point(102, 153);
            this.enroll_foodBtn.Name = "enroll_foodBtn";
            this.enroll_foodBtn.Size = new System.Drawing.Size(75, 75);
            this.enroll_foodBtn.TabIndex = 2;
            this.enroll_foodBtn.Text = "음식등록";
            this.enroll_foodBtn.UseVisualStyleBackColor = true;
            this.enroll_foodBtn.Click += new System.EventHandler(this.enroll_foodBtn_Click);
            // 
            // enroll_scheduleBtn
            // 
            this.enroll_scheduleBtn.Location = new System.Drawing.Point(142, 72);
            this.enroll_scheduleBtn.Name = "enroll_scheduleBtn";
            this.enroll_scheduleBtn.Size = new System.Drawing.Size(75, 75);
            this.enroll_scheduleBtn.TabIndex = 3;
            this.enroll_scheduleBtn.Text = "상영시간표";
            this.enroll_scheduleBtn.UseVisualStyleBackColor = true;
            this.enroll_scheduleBtn.Click += new System.EventHandler(this.enroll_scheduleBtn_Click);
            // 
            // ticketBtn
            // 
            this.ticketBtn.Location = new System.Drawing.Point(223, 72);
            this.ticketBtn.Name = "ticketBtn";
            this.ticketBtn.Size = new System.Drawing.Size(75, 75);
            this.ticketBtn.TabIndex = 4;
            this.ticketBtn.Text = "티켓구매";
            this.ticketBtn.UseVisualStyleBackColor = true;
            this.ticketBtn.Click += new System.EventHandler(this.ticketBtn_Click);
            // 
            // order_foodBtn
            // 
            this.order_foodBtn.Location = new System.Drawing.Point(183, 153);
            this.order_foodBtn.Name = "order_foodBtn";
            this.order_foodBtn.Size = new System.Drawing.Size(75, 75);
            this.order_foodBtn.TabIndex = 5;
            this.order_foodBtn.Text = "음식주문";
            this.order_foodBtn.UseVisualStyleBackColor = true;
            this.order_foodBtn.Click += new System.EventHandler(this.order_foodBtn_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(61, 72);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 75);
            this.button7.TabIndex = 6;
            this.button7.Text = "영화목록";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Invent_movieBtn_Click);
            // 
            // Check_orderbtn
            // 
            this.Check_orderbtn.Location = new System.Drawing.Point(264, 153);
            this.Check_orderbtn.Name = "Check_orderbtn";
            this.Check_orderbtn.Size = new System.Drawing.Size(75, 75);
            this.Check_orderbtn.TabIndex = 7;
            this.Check_orderbtn.Text = "음식주문 확인";
            this.Check_orderbtn.UseVisualStyleBackColor = true;
            this.Check_orderbtn.Click += new System.EventHandler(this.Check_orderbtn_Click);
            // 
            // ticketprintbtn
            // 
            this.ticketprintbtn.Location = new System.Drawing.Point(304, 72);
            this.ticketprintbtn.Name = "ticketprintbtn";
            this.ticketprintbtn.Size = new System.Drawing.Size(75, 75);
            this.ticketprintbtn.TabIndex = 8;
            this.ticketprintbtn.Text = "티켓 출력";
            this.ticketprintbtn.UseVisualStyleBackColor = true;
            this.ticketprintbtn.Click += new System.EventHandler(this.ticket_listbtn_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 300);
            this.Controls.Add(this.ticketprintbtn);
            this.Controls.Add(this.Check_orderbtn);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.order_foodBtn);
            this.Controls.Add(this.ticketBtn);
            this.Controls.Add(this.enroll_scheduleBtn);
            this.Controls.Add(this.enroll_foodBtn);
            this.Name = "main";
            this.Text = "메인화면";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button enroll_foodBtn;
        private System.Windows.Forms.Button enroll_scheduleBtn;
        private System.Windows.Forms.Button ticketBtn;
        private System.Windows.Forms.Button order_foodBtn;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button Check_orderbtn;
        private System.Windows.Forms.Button ticketprintbtn;
    }
}

