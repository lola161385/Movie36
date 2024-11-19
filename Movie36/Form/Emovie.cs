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
    public partial class Emovie : Form
    {
        public Emovie()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                // 유효성 검사
                if (string.IsNullOrWhiteSpace(MovieName.Text) ||
                    string.IsNullOrWhiteSpace(MovieType.Text) ||
                    string.IsNullOrWhiteSpace(Movieproducer.Text) ||
                    string.IsNullOrWhiteSpace(MoviePerformer.Text) ||
                    string.IsNullOrWhiteSpace(MovieOverview.Text) ||
                    MovieRating.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(pictureBox1.ImageLocation))
                {
                    MessageBox.Show("모든 필드를 입력해 주세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 폼에서 입력값 가져오기
                string movieName = MovieName.Text;
                string movieRating = MovieRating.SelectedItem?.ToString();
                string movieType = MovieType.Text;
                string movieProducer = Movieproducer.Text;
                string moviePerformer = MoviePerformer.Text;
                DateTime movieReleaseDate = MovieRelesedate.Value;
                string movieOverview = MovieOverview.Text;
                string moviePoster = pictureBox1.ImageLocation; // 이미지 경로
                string movieStatus = "Active"; // 기본 상태값
                int movieId = new Random().Next(1, 10000); // 임시 ID 생성 (추후 고유 ID 생성 방식 적용)

                // DBClass의 InsertMovie 호출
                DBClass db = new DBClass();
                if (db.InsertMovie(movieId, movieName, movieRating, movieType, movieProducer,
                                   moviePerformer, movieReleaseDate, movieOverview, moviePoster, movieStatus))
                {
                    // 삽입 성공 시 폼 닫기
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void imgbtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.ImageLocation = openFileDialog.FileName;
                }
            }
        }

    }
}
