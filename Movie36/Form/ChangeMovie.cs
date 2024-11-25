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
    public partial class ChangeMovie : Form
    {
        private Movie currentMovie; // 현재 영화 데이터
        private DBClass db;         // DBClass 인스턴스

        // MovieID를 받아서 영화 정보를 DB에서 가져오는 생성자
        public ChangeMovie(int movieId)
        {
            InitializeComponent();
            db = new DBClass(); // DB 연결
            currentMovie = db.GetMovieById(movieId); // MovieID로 영화 정보를 DB에서 가져옴
            LoadMovieData();
        }

        // 영화 데이터를 폼에 로드하는 메서드
        private void LoadMovieData()
        {
            if (currentMovie != null)
            {
                MovieName.Text = currentMovie.MovieName;
                MovieType.Text = currentMovie.MovieType;
                Movieproducer.Text = currentMovie.MovieProducer;
                MoviePerformer.Text = currentMovie.MoviePerformer;
                MovieRating.SelectedItem = currentMovie.MovieRating;

                // ReleaseDate가 유효한 범위 내에 있는지 체크
                DateTime releaseDate = currentMovie.ReleaseDate;
                if (releaseDate < MovieRelesedate.MinDate || releaseDate > MovieRelesedate.MaxDate)
                {
                    MovieRelesedate.Value = DateTime.Today; // 유효하지 않으면 오늘 날짜로 설정
                }
                else
                {
                    MovieRelesedate.Value = releaseDate;
                }

                MovieOverview.Text = currentMovie.MovieOverview;
                pictureBox1.ImageLocation = currentMovie.MoviePoster;
            }
        }

        // DB에서 MovieID로 영화 정보를 가져오는 메서드
        private Movie GetMovieById(int movieId)
        {
            List<Movie> movies = db.GetMovies(); // DB에서 모든 영화 목록을 가져옴
            return movies.FirstOrDefault(m => m.MovieId == movieId); // MovieID로 영화 찾기
        }

        // savebtn_Click 메서드
        private void savebtn_Click(object sender, EventArgs e)
        {
            // 입력 값 유효성 검사
            if (string.IsNullOrWhiteSpace(MovieName.Text) || string.IsNullOrWhiteSpace(MovieType.Text))
            {
                MessageBox.Show("영화 제목과 장르는 필수 입력 항목입니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 영화 객체 생성 및 업데이트 호출
            currentMovie.MovieName = MovieName.Text;
            currentMovie.MovieType = MovieType.Text;
            currentMovie.MovieProducer = Movieproducer.Text;
            currentMovie.MoviePerformer = MoviePerformer.Text;
            currentMovie.MovieRating = MovieRating.SelectedItem?.ToString() ?? "N/A";

            // ReleaseDate가 유효한 범위 내에 있는지 체크 후 값 설정
            DateTime releaseDate = MovieRelesedate.Value;
            if (releaseDate < MovieRelesedate.MinDate || releaseDate > MovieRelesedate.MaxDate)
            {
                releaseDate = DateTime.Today; // 유효하지 않으면 오늘 날짜로 설정
            }
            currentMovie.ReleaseDate = releaseDate;

            currentMovie.MovieOverview = MovieOverview.Text;
            currentMovie.MoviePoster = pictureBox1.ImageLocation; // 변경된 포스터 경로 저장

            bool isUpdated = db.UpdateMovie(currentMovie); // DB 업데이트

            // 결과 메시지
            if (isUpdated)
            {
                this.Close();
                MessageBox.Show("영화 정보가 성공적으로 수정되었습니다.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("영화 정보 수정 중 오류가 발생했습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 이미지 선택 버튼 클릭 이벤트 (imgbtn_Click)
        private void imgbtn_Click(object sender, EventArgs e)
        {
            // 파일 대화상자를 통해 이미지를 선택
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp", // 허용된 이미지 파일 형식
                Title = "Select a Movie Poster" // 대화상자 제목
            };

            // 사용자가 이미지를 선택하면
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 선택한 이미지를 pictureBox1에 표시
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                pictureBox1.ImageLocation = openFileDialog.FileName; // 이미지 경로 저장
            }
        }
    }



}
