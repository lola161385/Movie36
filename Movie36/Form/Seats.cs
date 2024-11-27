using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Movie36
{
    public partial class Seats : Form
    {
        // 데이터 받을 프로퍼티들
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public int TicketCount { get; set; }
        public string ScheduleId { get; set; }

        // 선택된 좌석을 저장할 리스트
        private List<Button> selectedSeats = new List<Button>();

        // 좌석을 클릭할 수 있는 상태인지 확인할 변수
        private bool canSelectSeats = true;

        public Seats()
        {
            InitializeComponent();
        }

        // 예시로 데이터를 표시하거나 사용
        private void Seats_Load(object sender, EventArgs e)
        {
            // DB에서 예약된 좌석 리스트 가져오기
            DBClass db = new DBClass();
            List<string> reservedSeats = db.GetReservedSeats(ScheduleId);

            // 예약된 좌석 버튼 비활성화 및 색상 변경
            UpdateSeatsAvailability(reservedSeats);
            Buybtn.Enabled = false;

            // TicketCount 만큼 좌석 선택을 허용하도록 초기화
            selectedSeats.Clear();
        }

        private void UpdateSeatsAvailability(List<string> reservedSeats)
        {
            // 예약된 좌석 버튼을 비활성화하고 빨간색으로 변경
            foreach (var seat in reservedSeats)
            {
                Button button = GetButtonBySeat(seat);
                if (button != null)
                {
                    button.Enabled = false; // 버튼 비활성화
                    button.BackColor = Color.Red; // 버튼 색상 빨간색으로 변경
                }
            }
        }
        private void btnBuy_Click(object sender, EventArgs e)
        {
            // 사용자 입력값 가져오기
            string customerName = UserName;
            string customerPhone = PhoneNumber;
            int customerCount = TicketCount;
            string scheduleId = ScheduleId;

            // 티켓 저장
            DBClass db = new DBClass();
            bool isTicketSaved = db.SaveTicket(scheduleId, customerName, customerPhone, customerCount, selectedSeats);

            if (isTicketSaved)
            {
                MessageBox.Show("티켓이 성공적으로 구매되었습니다.");

                // 부모 폼(Ticket) 닫기
                if (Owner != null)
                {
                    Owner.Close(); // Ticket 폼 닫기
                }

                this.Close();  // Seats 폼 닫기
            }
            else
            {
                MessageBox.Show("티켓 구매에 실패했습니다. 다시 시도해주세요.");
            }
        }



        // 좌석 이름에 맞는 버튼을 반환하는 메서드
        private Button GetButtonBySeat(string seat)
        {
            switch (seat.ToUpper())
            {
                case "A1": return A1;
                case "A2": return A2;
                case "A3": return A3;
                case "A4": return A4;
                case "B1": return B1;
                case "B2": return B2;
                case "B3": return B3;
                case "B4": return B4;
                case "C1": return C1;
                case "C2": return C2;
                case "C3": return C3;
                case "C4": return C4;
                case "D1": return D1;
                case "D2": return D2;
                case "D3": return D3;
                case "D4": return D4;
                case "E1": return E1;
                case "E2": return E2;
                case "E3": return E3;
                case "E4": return E4;
                default: return null;
            }
        }

        // 버튼 클릭 이벤트 (각 버튼에 추가)
        private void SeatButton_Click(object sender, EventArgs e)
        {
            // 버튼을 클릭할 수 있는 상태인지 확인
            if (!canSelectSeats)
                return;

            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                // 이미 초록색인 버튼을 클릭하면 원래 색으로 돌아가도록 처리
                if (clickedButton.BackColor == Color.Green)
                {
                    // 초록색에서 원래 색으로 변경
                    clickedButton.BackColor = Color.White;
                    selectedSeats.Remove(clickedButton);  // 선택된 좌석 목록에서 제거
                }
                else
                {
                    // 좌석이 초록색으로 변하면서 선택된 좌석 목록에 추가
                    if (selectedSeats.Count < TicketCount)
                    {
                        clickedButton.BackColor = Color.Green;
                        selectedSeats.Add(clickedButton);  // 선택된 좌석 목록에 추가

                        // 선택된 좌석 수가 TicketCount에 도달하면 더 이상 좌석을 선택할 수 없게 설정
                        if (selectedSeats.Count == TicketCount)
                        {
                            Buybtn.Enabled = true;
                            canSelectSeats = false; // 좌석 선택을 더 이상 못 하도록 설정
                        }
                    }
                }
            }
        }

        // 초기화 버튼 클릭 시 좌석 선택 초기화
        private void btnReset_Click(object sender, EventArgs e)
        {
            // 선택된 좌석 목록을 비우고
            selectedSeats.Clear();

            // 버튼 색상 초기화 (초록색에서 원래 색으로)
            foreach (Button button in Controls.OfType<Button>())
            {
                if (button.BackColor == Color.Green)
                {
                    button.BackColor = Color.White;  // 원래 색으로 초기화
                }
            }

            // 좌석 선택 가능 상태로 되돌리기
            canSelectSeats = true;
            Buybtn.Enabled = false;
        }
    }
}
