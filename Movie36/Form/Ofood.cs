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
    public partial class Ofood : Form
    {
        private Dictionary<string, (int quantity, int price)> foodQuantities = new Dictionary<string, (int, int)>();
        private int totalPrice = 0; // 총 금액 변수

        public Ofood()
        {
            InitializeComponent();
            LoadFoods();
            InitializeShoppingCart(); // 장바구니 UI 초기화
        }

        private void LoadFoods()
        {
            DBClass db = new DBClass();
            List<Food> foods = db.GetFoods();

            flowLayoutPanel1.Controls.Clear();
            foodQuantities.Clear(); // 기존 데이터 초기화
            totalPrice = 0; // 총 금액 초기화

            foreach (var food in foods)
            {
                int price;

                // 문자열에서 정수로 변환
                if (!int.TryParse(food.foodPrice, out price))
                {
                    MessageBox.Show($"'{food.foodName}'의 가격 정보를 처리할 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue; // 변환 실패 시 해당 항목 건너뜁니다.
                }

                if (!foodQuantities.ContainsKey(food.foodName))
                    foodQuantities[food.foodName] = (0, price); // 초기 수량과 가격 설정

                Panel foodPanel = new Panel
                {
                    Width = 160,
                    Height = 250,
                    Margin = new Padding(10)
                };

                PictureBox posterBox = new PictureBox
                {
                    ImageLocation = food.foodImage,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Width = 150,
                    Height = 150,
                    Dock = DockStyle.Top,
                    Cursor = Cursors.Hand
                };

                posterBox.Click += (sender, e) => AddToCart(food.foodName);

                Label titleLabel = new Label
                {
                    Text = food.foodName,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Height = 30,
                    Width = 150,
                    Location = new Point(5, 160)
                };

                Label priceLabel = new Label
                {
                    Text = "가격: " + price,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Height = 30,
                    Width = 150,
                    Location = new Point(5, 195)
                };

                foodPanel.Controls.Add(posterBox);
                foodPanel.Controls.Add(titleLabel);
                foodPanel.Controls.Add(priceLabel);

                flowLayoutPanel1.Controls.Add(foodPanel);
            }
        }


        private void InitializeShoppingCart()
        {
            ListBox listBoxCart = new ListBox
            {
                Name = "listBoxCart",
                Width = 300,
                Height = 300,
                Location = new Point(400, 10)
            };
            Controls.Add(listBoxCart);

            Button removeButton = new Button
            {
                Text = "항목 -1",
                Location = new Point(400, 320),
                Height = 50,
                Width = 50
            };
            removeButton.Click += (sender, e) => RemoveFromCart(listBoxCart);
            Controls.Add(removeButton);

            Label totalLabel = new Label
            {
                Name = "totalLabel",
                Text = "총 금액: 0원",
                Location = new Point(400, 380),
                Width = 300,
                Height = 30,
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            Controls.Add(totalLabel);
        }

        private void AddToCart(string foodName)
        {
            if (foodQuantities.ContainsKey(foodName))
            {
                foodQuantities[foodName] = (foodQuantities[foodName].quantity + 1, foodQuantities[foodName].price);
                totalPrice += foodQuantities[foodName].price;
            }
            UpdateShoppingCart();
        }

        private void UpdateShoppingCart()
        {
            ListBox listBoxCart = Controls.Find("listBoxCart", true).FirstOrDefault() as ListBox;
            Label totalLabel = Controls.Find("totalLabel", true).FirstOrDefault() as Label;

            if (listBoxCart == null || totalLabel == null) return;

            listBoxCart.Items.Clear();
            foreach (var item in foodQuantities)
            {
                if (item.Value.quantity > 0)
                {
                    listBoxCart.Items.Add($"{item.Key} - {item.Value.quantity}개 - {item.Value.price * item.Value.quantity}원");
                }
            }

            totalLabel.Text = $"총 금액: {totalPrice}원";
        }

        private void RemoveFromCart(ListBox listBoxCart)
        {
            if (listBoxCart.SelectedItem == null) return;

            string selectedItem = listBoxCart.SelectedItem.ToString();
            string foodName = selectedItem.Split('-')[0].Trim();

            if (foodQuantities.ContainsKey(foodName) && foodQuantities[foodName].quantity > 0)
            {
                totalPrice -= foodQuantities[foodName].price;
                foodQuantities[foodName] = (foodQuantities[foodName].quantity - 1, foodQuantities[foodName].price);

                if (foodQuantities[foodName].quantity == 0)
                {
                    foodQuantities.Remove(foodName);
                }
            }

            UpdateShoppingCart();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            string paymentMethod = "CreditCard"; // 결제 방식 (예: 카드 결제)

            try
            {
                db.SaveOrder(paymentMethod, foodQuantities);
                MessageBox.Show("구매가 완료되었습니다!", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadFoods(); // UI 초기화
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"구매 중 오류가 발생했습니다: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
