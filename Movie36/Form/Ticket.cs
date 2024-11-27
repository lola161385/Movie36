using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Movie36
{
    public partial class Ticket : Form
    {
        private DBClass dbClass; // DBClass 객체
        private Movie selectedMovie; // 선택된 영화 정보

        public Ticket()
        {
            InitializeComponent();
            dbClass = new DBClass(); // DBClass 인스턴스 생성
        }

        private void Ticket_Load(object sender, EventArgs e)
        {
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value.Date;

            // DBClass 메서드 호출
            var movies = dbClass.GetMoviesByDate(selectedDate);

            DisplayMoviesInFlowPanel(movies);
        }

        private void DisplayMoviesInFlowPanel(List<Movie> movies)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var movie in movies)
            {
                Panel moviePanel = new Panel
                {
                    Size = new Size(120, 200),
                    BorderStyle = BorderStyle.FixedSingle
                };

                PictureBox posterBox = new PictureBox
                {
                    Size = new Size(120, 150),
                    ImageLocation = movie.MoviePoster,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                // 포스터 클릭 시 이벤트 처리
                posterBox.Click += (sender, e) =>
                {
                    selectedMovie = movie;  // 클릭된 영화 정보를 저장
                    string scheduleId = selectedMovie.ScheduleId;

                    // 예약된 좌석 수 가져오기
                    int bookedSeats = dbClass.GetBookedSeatsCount(scheduleId);
                    int availableSeats = 20 - bookedSeats;  // 20에서 예약된 좌석 수를 빼서 남은 좌석 수 계산

                    // seatsLabel에 남은 좌석 수 표시
                    seats_label.Text = $"{availableSeats}";


                    // screen_label에 상영관 이름 표시
                    string screenName = dbClass.GetScreenNameByScheduleId(scheduleId);
                    screen_label.Text = screenName;
                };

                moviePanel.Controls.Add(posterBox);

                Label titleLabel = new Label
                {
                    Text = movie.MovieName,
                    Dock = DockStyle.Bottom,
                    TextAlign = ContentAlignment.MiddleCenter,
                    AutoSize = false,
                    Height = 20
                };

                Label showTimeLabel = new Label
                {
                    Text = "상영시간: " + movie.ShowTime,
                    Dock = DockStyle.Bottom,
                    TextAlign = ContentAlignment.MiddleCenter,
                    AutoSize = false,
                    Height = 20
                };

                moviePanel.Controls.Add(titleLabel);
                moviePanel.Controls.Add(showTimeLabel);

                flowLayoutPanel1.Controls.Add(moviePanel);
            }
        }

        private void buy_ticketbtn_Click(object sender, EventArgs e)
        {
            // 입력된 정보들 가져오기
            string userName = textBox1.Text;
            string phoneNumber = textBox2.Text;

            // 빈칸 체크
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(phoneNumber))
            {
                MessageBox.Show("이름과 전화번호를 모두 입력해주세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // 빈칸이 있으면 함수 종료
            }

            int ticketCount = (int)numericUpDown1.Value;

            // 선택된 영화가 있다면 ScheduleId를 가져오기
            if (selectedMovie != null)
            {
                string scheduleId = selectedMovie.ScheduleId; // 선택된 영화의 ScheduleId

                // 예약된 좌석 수 가져오기
                int bookedSeats = dbClass.GetBookedSeatsCount(scheduleId);
                int availableSeats = 20 - bookedSeats;  // 총 20좌석 중 예약된 좌석을 빼서 계산

                // 선택한 티켓 수가 남은 좌석 수를 초과하면 경고 메시지 표시
                if (ticketCount > availableSeats)
                {
                    MessageBox.Show($"선택한 티켓 수는 남은 좌석 수({availableSeats})보다 많을 수 없습니다.", "좌석 부족", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // 조건을 만족하지 않으면 종료
                }

                // Seats 폼 생성 및 데이터 전달
                Seats seatsForm = new Seats
                {
                    UserName = userName,
                    PhoneNumber = phoneNumber,
                    TicketCount = ticketCount,
                    ScheduleId = scheduleId,
                    Owner = this // Ticket 폼을 Seats에 전달
                };

                // Seats 폼을 보여주기
                seatsForm.Show();
            }
            else
            {
                MessageBox.Show("영화를 선택해주세요.", "영화 선택 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }

}
