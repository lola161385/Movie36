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

                string movieName = MovieName.Text;
                string movieRating = MovieRating.SelectedItem?.ToString();
                string movieType = MovieType.Text;
                string movieProducer = Movieproducer.Text;
                string moviePerformer = MoviePerformer.Text;
                DateTime movieReleaseDate = MovieRelesedate.Value;
                string movieOverview = MovieOverview.Text;
                string moviePoster = pictureBox1.ImageLocation;
                string movieStatus = "Active";

                DBClass db = new DBClass();
                if (db.InsertMovie(movieName, movieRating, movieType, movieProducer,
                                   moviePerformer, movieReleaseDate, movieOverview, moviePoster, movieStatus))
                {
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
