using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace InterfaceUser
{


    public partial class Form1 : Form
    {

        public Form1()
        {

            InitializeComponent();
            LoadProductList();
 

        }
        List<Product> productList = new List<Product>();
        List<Product> cart = new List<Product>();
        private void LoadProductList()
        {

            productList.Add(new Product("C:\\Path\\To\\Image1.jpg", "Giày Nam", 5, 1000000));
            productList.Add(new Product("C:\\Path\\To\\Image2.jpg", "Áo Thun", 3, 500000));

            foreach (var product in productList)
            {
                dataGridView1.Rows.Add(product.Img, product.Name, product.Quantity, product.Price);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int index = dataGridView1.CurrentRow.Index;

                if (index >= 0 && index < productList.Count)
                {
                    Product selectedProduct = productList[index];

                    var existingProduct = cart.FirstOrDefault(p => p.Name == selectedProduct.Name);

                    if (existingProduct != null)
                    {
                        existingProduct.Quantity += selectedProduct.Quantity;
                        existingProduct.Price += selectedProduct.Price * (decimal)selectedProduct.Quantity;
                    }
                    else
                    {
                        cart.Add(new Product(selectedProduct.Img, selectedProduct.Name, selectedProduct.Quantity, selectedProduct.Price * (decimal)selectedProduct.Quantity));
                    }
                    UpdateCartView();
                }
                else
                {
                    MessageBox.Show("Sản phẩm không hợp lệ.", "Lỗi");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để thêm vào giỏ hàng.", "Thông báo");
            }
        }
        private void UpdateCartView()
        {
            dataGridView2.Rows.Clear();
            foreach (var item in cart)
            {
                dataGridView2.Rows.Add(item.Img, item.Name, item.Quantity, item.Price);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                int index = dataGridView2.CurrentRow.Index;

                if (index >= 0 && index < cart.Count)
                {
                    cart.RemoveAt(index);

                    UpdateCartView();
                }
                else
                {
                    MessageBox.Show("Sản phẩm không hợp lệ.", "Lỗi");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa khỏi giỏ hàng.", "Thông báo");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanh toan thanh cong");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
    public class Product
    {
        public String Img { get; set; }
        public String Name { get; set; }
        public double Quantity { get; set; }
        public decimal Price { get; set; }
        public Product(string img, string name, double quantity, decimal price ) { 
            Img = img;
            Name = name;
            Quantity = quantity;
            Price = price;
        }
 
    }
}
