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
                    // 영화 ID만 넘겨서 ChangeMovie 폼 열기
                    using (ChangeMovie ChangeMovieForm = new ChangeMovie(movie.MovieId))
                    {
                        ChangeMovieForm.ShowDialog();

                        // 수정된 후 영화 목록 갱신
                        flowLayoutPanel1.Controls.Clear();
                        LoadMovies();
                    }
                };


                moviePanel.Controls.Add(posterBox);
                moviePanel.Controls.Add(titleLabel);
                flowLayoutPanel1.Controls.Add(moviePanel); // FlowLayoutPanel에 추가
            }
        }
    }
}
