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
    public partial class Eschedule : Form
    {
        public Eschedule()
        {
            InitializeComponent();
            LoadMoviesToComboBox(comboBox1);
            LoadScreenToComboBox(comboBox3);
            LoadSchedules();
        }

        public void LoadMoviesToComboBox(ComboBox comboBox)
        {
            DBClass db = new DBClass();
            DataTable movieTable = db.GetMovieDataTableForComboBox();

            // ComboBox에 DataTable 바인딩
            comboBox.DataSource = movieTable;
            comboBox.DisplayMember = "MOVIE_NAME"; // 표시될 텍스트 (영화 이름)
            comboBox.ValueMember = "MOVIE_ID";    // 내부적으로 사용할 값 (영화 ID)
        }

        public void LoadScreenToComboBox(ComboBox comboBox)
        {
            DBClass db = new DBClass();
            DataTable screenTable = db.GetScreenDataTableForComboBox();

            comboBox.DataSource = screenTable;
            comboBox.DisplayMember = "SCREEN_NAME";
            comboBox.ValueMember = "SCREEN_ID";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 입력값을 가져오기
            string scheduleDate = dateTimePicker1.Value.ToString("yyyy-MM-dd"); // 예: 2024-11-26
            string showTime = comboBox2.SelectedItem.ToString(); // 상영 시간 (예: "09-12")
            string movieId = comboBox1.SelectedValue.ToString(); // 선택한 영화 ID
            string screenId = comboBox3.SelectedValue.ToString(); // 선택한 상영관 ID

            DBClass db = new DBClass();

            // 중복 체크
            bool scheduleExists = db.IsScheduleExists(scheduleDate, showTime, screenId);

            if (scheduleExists)
            {
                MessageBox.Show("이미 동일한 날짜, 상영관, 시간의 스케줄이 존재합니다. 다른 시간으로 등록해주세요.");
            }
            else
            {
                string scheduleId = GenerateScheduleId(); // 스케줄 ID를 생성하는 로직 추가
                bool isInserted = db.InsertSchedule(scheduleId, scheduleDate, showTime, movieId, screenId);

                if (isInserted)
                {
                    MessageBox.Show("스케줄이 성공적으로 등록되었습니다.");
                    LoadSchedules();
                }
                else
                {
                    MessageBox.Show("스케줄 등록에 실패했습니다.");
                }
            }
        }

        // 스케줄 삭제 버튼 클릭 이벤트
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // DataGridView에서 선택된 행 확인
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // 선택된 행에서 SCHEDULE_ID 가져오기
                string scheduleId = dataGridView1.SelectedRows[0].Cells["SCHEDULE_ID"].Value.ToString();

                // 삭제 확인 메시지
                DialogResult result = MessageBox.Show($"정말로 스케줄 ID {scheduleId}를 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    DBClass db = new DBClass();
                    bool isDeleted = db.DeleteSchedule(scheduleId);

                    if (isDeleted)
                    {
                        MessageBox.Show("스케줄이 성공적으로 삭제되었습니다.");
                        LoadSchedules(); // 삭제 후 스케줄 리스트 다시 로드
                    }
                    else
                    {
                        MessageBox.Show("스케줄 삭제에 실패했습니다.");
                    }
                }
            }
            else
            {
                MessageBox.Show("삭제할 스케줄을 선택해주세요.");
            }
        }

        // 스케줄을 DataGridView에 로드하는 함수
        public void LoadSchedules()
        {
            DBClass db = new DBClass();
            DataTable scheduleTable = db.GetSchedules();

            // DataGridView에 DataTable 바인딩
            dataGridView1.DataSource = scheduleTable;
        }

        // 스캐쥴 id 생성 함수
        private string GenerateScheduleId()
        {
            string scheduleDate = DateTime.Now.ToString("yyyyMMdd"); // 현재 날짜 (yyyyMMdd)
            string showTime = comboBox2.SelectedItem.ToString().Replace("-", ""); // 상영시간 (09-12, 13-16 등)
            string screenId = comboBox3.SelectedValue.ToString(); // 선택한 상영관 ID
            string screenCode = screenId; // 상영관 ID를 그대로 사용

            // 스케줄 ID 생성: S + "yyyyMMdd" + 상영시간 + 상영관ID + 스크린ID
            return "S" + scheduleDate + showTime + screenCode;
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
