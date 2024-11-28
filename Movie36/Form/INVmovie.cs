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
    public partial class INVmovie : Form
    {
        public INVmovie()
        {
            InitializeComponent();
            LoadMovies();
        }

        private void OpenEmovie()
        {
            this.Hide();
            Emovie newEmovie = new Emovie();
            newEmovie.FormClosed += new FormClosedEventHandler(CLosedEmovie);
            newEmovie.ShowDialog();
        }

        private void CLosedEmovie(object sender, FormClosedEventArgs e)
        {
            this.Show();
            LoadMovies(); // 영화 등록 후 목록 갱신
        }

        private void AddMoviebtn_Click(object sender, EventArgs e)
        {
            OpenEmovie();
        }

        private void Closedbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadMovies()
        {
            // DB에서 영화 데이터 가져오기
            DBClass db = new DBClass();
            List<Movie> movies = db.GetMovies();

            flowLayoutPanel1.Controls.Clear(); // 기존 목록을 비우고 새로 고침

            foreach (var movie in movies)
            {
                // 영화 아이템 생성
                Panel moviePanel = new Panel
                {
                    Width = 160,
                    Height = 250,
                    Margin = new Padding(10)
                };

                PictureBox posterBox = new PictureBox
                {
                    ImageLocation = movie.MoviePoster,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Width = 150,
                    Height = 210,
                    Dock = DockStyle.Top
                };

                Label titleLabel = new Label
                {
                    Text = movie.MovieName,
                    Dock = DockStyle.Bottom,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Height = 40,
                    AutoEllipsis = true
                };

                posterBox.Click += (s, e) =>
                {
                    using (ChangeMovie ChangeMovieForm = new ChangeMovie(movie.MovieId))
                    {
                        ChangeMovieForm.ShowDialog();
                        flowLayoutPanel1.Controls.Clear(); // 목록 비우기
                        LoadMovies(); // 목록 새로고침
                    }
                };

                moviePanel.Controls.Add(posterBox);
                moviePanel.Controls.Add(titleLabel);
                flowLayoutPanel1.Controls.Add(moviePanel); // FlowLayoutPanel에 추가
            }
        }
    }

}
