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
    public partial class Efood : Form
    {
        public Efood()
        {
            InitializeComponent();
        }

        private void Efood_Load(object sender, EventArgs e)
        {

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(FoodName.Text) ||
                    string.IsNullOrWhiteSpace(FoodCategory.Text) ||
                    string.IsNullOrWhiteSpace(FoodPrice.Text) ||
                    string.IsNullOrWhiteSpace(FoodQuantity.Text) ||
                    string.IsNullOrWhiteSpace(pictureBox1.ImageLocation))
                {
                    MessageBox.Show("모든 필드를 입력해 주세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string foodName = FoodName.Text;
                string foodCategory = FoodCategory.Text;
                string foodQuantity = FoodQuantity.Text;
                string foodPrice = FoodPrice.Text;
                string foodImage = pictureBox1.ImageLocation;
                string foodDesc = foodDescription.Text;

                DBClass db = new DBClass();
                if (db.InsertFood(foodName, foodCategory, foodPrice, foodQuantity,
                                      foodImage, foodDesc))
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void imageBtn_Click(object sender, EventArgs e)
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
