using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Movie36
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        //버튼 클릭시 발생하는 이벤트
        private void enroll_movieBtn_Click(object sender, EventArgs e)
        {
            OpenEmovie();
        }
        private void enroll_screenBtn_Click(object sender, EventArgs e)
        {
            OpenEscreen();
        }
        private void enroll_foodBtn_Click(object sender, EventArgs e)
        {
            OpenEfood();
        }
        private void enroll_scheduleBtn_Click(object sender, EventArgs e)
        {
            OpenEschedule();
        }
        private void ticketBtn_Click(object sender, EventArgs e)
        {
            OpenTicket();
        }
        private void order_foodBtn_Click(object sender, EventArgs e)
        {
            OpenOfood();
        }
        private void Invent_movieBtn_Click(object sender, EventArgs e)
        {
            OpenINVmovie();
        }

        //폼 여는 함수
        private void OpenEmovie()
        {
            this.Hide();
            Emovie newEmovie = new Emovie();
            newEmovie.FormClosed += new FormClosedEventHandler(CLosedEmovie);
            newEmovie.ShowDialog();
        }
        private void OpenEscreen()
        {
            this.Hide();
            Escreen newEscreen = new Escreen();
            newEscreen.FormClosed += new FormClosedEventHandler(CLosedEscreen);
            newEscreen.ShowDialog();
        }
        private void OpenEfood()
        {
            this.Hide();
            Efood newEfood = new Efood();
            newEfood.FormClosed += new FormClosedEventHandler(CLosedEfood);
            newEfood.ShowDialog();
        }
        private void OpenEschedule()
        {
            this.Hide();
            Eschedule newEschedule = new Eschedule();
            newEschedule.FormClosed += new FormClosedEventHandler(CLosedEschedule);
            newEschedule.ShowDialog();
        }
        private void OpenTicket()
        {
            this.Hide();
            Ticket newTicket = new Ticket();
            newTicket.FormClosed += new FormClosedEventHandler(CLosedTicket);
            newTicket.ShowDialog();
        }
        private void OpenOfood()
        {
            this.Hide();
            Ofood newOfood = new Ofood();
            newOfood.FormClosed += new FormClosedEventHandler(CLosedOfood);
            newOfood.ShowDialog();
        }
        private void OpenINVmovie()
        {
            this.Hide();
            INVmovie newINVmovie = new INVmovie();
            newINVmovie.FormClosed += new FormClosedEventHandler(CLosedINVmovie);
            newINVmovie.ShowDialog();
        }

        // Emovie폼이 닫히면 main폼이 다시 열리는 함수
        private void CLosedEmovie(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        private void CLosedEscreen(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        private void CLosedEfood(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        private void CLosedEschedule(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        private void CLosedTicket(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        private void CLosedOfood(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        private void CLosedINVmovie(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
