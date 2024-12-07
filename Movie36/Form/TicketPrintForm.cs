using Oracle.DataAccess.Client;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Movie36
{
    public partial class TicketPrintForm : Form
    {
        private string ticketId;
        private DBClass dbClass;

        public TicketPrintForm(string ticketId)
        {
            InitializeComponent();
            this.ticketId = ticketId;
            dbClass = new DBClass();
        }

        private void TicketPrintForm_Load(object sender, EventArgs e)
        {
            LoadTicketDetails();
        }

        // 티켓 상세 정보를 로드하고 출력
        private void LoadTicketDetails()
        {
            try
            {
                DataRow ticketDetails = dbClass.GetTicketDetails(ticketId);
                if (ticketDetails != null)
                {
                    lblMovieTitle.Text = ticketDetails["MOVIE_NAME"].ToString();
                    lblCustomerName.Text = ticketDetails["CUSTOMER_NAME"].ToString();
                    lblShowTime.Text = $"{ticketDetails["SHOW_TIME"]} / {Convert.ToDateTime(ticketDetails["SCHEDULE_DATE"]).ToShortDateString()}";
                    lblScreenName.Text = ticketDetails["SCREEN_NAME"].ToString();
                    lblScreenType.Text = ticketDetails["SCREEN_TYPE"].ToString();
                    lblSeats.Text = ticketDetails["SELECT_SEATS"].ToString();

                    // 포스터 이미지 로드
                    string posterPath = ticketDetails["MOVIE_POSTER"].ToString();
                    if (!string.IsNullOrWhiteSpace(posterPath) && System.IO.File.Exists(posterPath))
                    {
                        pbMoviePoster.Image = Image.FromFile(posterPath);
                        pbMoviePoster.SizeMode = PictureBoxSizeMode.StretchImage;  // 이미지를 PictureBox 크기에 맞게 왜곡하여 설정
                    }
                    else
                    {
                        pbMoviePoster.Image = null; // 이미지가 없을 경우 기본값
                    }
                }
                else
                {
                    MessageBox.Show("티켓 정보를 불러올 수 없습니다.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("티켓 상세 정보를 로드하는 중 오류 발생: " + ex.Message);
                this.Close();
            }
        }
    }
}
