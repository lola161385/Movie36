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
    public partial class CheckOrderFood : Form
    {
        private DBClass db;

        public CheckOrderFood()
        {
            InitializeComponent();
            db = new DBClass(); // DBClass 객체 생성
        }

        private void CheckOrderFood_Load(object sender, EventArgs e)
        {
            // 폼 로드 시 주문 목록 불러오기
            LoadOrders();
        }

        // 주문 목록 불러오는 함수
        private void LoadOrders()
        {
            DataTable dt = db.LoadOrders();
            orderDataGridView.DataSource = dt; // DataGridView에 데이터 바인딩
        }

        // 선택된 주문의 상세 정보를 불러오는 함수
        private void LoadOrderDetails(string orderId)
        {
            DataTable dt = db.LoadOrderDetails(orderId);
            orderDetailsDataGridView.DataSource = dt; // 주문 상세 정보 표시
        }

        // 주문 목록에서 셀 클릭 시 상세 정보 로드
        private void orderDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string orderId = orderDataGridView.Rows[e.RowIndex].Cells["ORDER_ID"].Value.ToString();
                LoadOrderDetails(orderId); // 선택한 주문의 상세 정보를 불러옴
            }
        }

        // '상세 보기' 버튼 클릭 시 주문 상세 정보 로드
        private void orderDetailsButton_Click(object sender, EventArgs e)
        {
            if (orderDataGridView.SelectedRows.Count > 0)
            {
                string orderId = orderDataGridView.SelectedRows[0].Cells["ORDER_ID"].Value.ToString();
                LoadOrderDetails(orderId);
            }
        }
    }

}
