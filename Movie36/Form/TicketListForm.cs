using Oracle.DataAccess.Client;
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
    public partial class TicketListForm : Form
    {
        private DBClass dbClass;
        private DataTable allTicketsTable; // 모든 티켓 데이터를 저장

        public TicketListForm()
        {
            InitializeComponent();
            dbClass = new DBClass();
        }

        private void TicketListForm_Load(object sender, EventArgs e)
        {
            LoadTickets();
        }

        // 모든 티켓 리스트 로드
        private void LoadTickets()
        {
            try
            {
                allTicketsTable = dbClass.GetTickets(); // DB에서 모든 티켓 데이터를 로드
                dgvTickets.DataSource = allTicketsTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("티켓 리스트 로드 오류: " + ex.Message);
            }
        }

        // 검색 버튼 클릭 시 필터링
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchKeyword = txtSearchCustomer.Text.Trim();
            if (string.IsNullOrWhiteSpace(searchKeyword))
            {
                dgvTickets.DataSource = allTicketsTable; // 검색어가 비어 있으면 전체 데이터 표시
            }
            else
            {
                DataView filteredView = new DataView(allTicketsTable)
                {
                    RowFilter = $"CUSTOMER_NAME LIKE '%{searchKeyword}%'"
                };
                dgvTickets.DataSource = filteredView;
            }
        }

        // 출력 버튼 클릭
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvTickets.SelectedRows.Count > 0)
            {
                string ticketId = dgvTickets.SelectedRows[0].Cells["TICKET_ID"].Value.ToString();
                ShowTicketDetails(ticketId);
            }
            else
            {
                MessageBox.Show("출력할 티켓을 선택하세요.");
            }
        }

        // 티켓 상세 정보 출력
        private void ShowTicketDetails(string ticketId)
        {
            TicketPrintForm printForm = new TicketPrintForm(ticketId);
            printForm.ShowDialog();
        }

        private void txtSearchCustomer_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
