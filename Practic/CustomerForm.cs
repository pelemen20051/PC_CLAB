using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Practic
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }
        private bool IsProductIdValid(int productId)
        {
            string connectionString = "Data Source=DESKTOP-777FV0N\\KAZI2005;Initial Catalog=DB_PC;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Products WHERE Id = @ProductId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductId", productId);

                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxProductId.Text, out int productId))
            {
                MessageBox.Show("Id товара должно быть числом.");
                return;
            }

            if (!IsProductIdValid(productId))
            {
                MessageBox.Show("Товар с указанным Id не найден.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxProductId.Text))
            {
                MessageBox.Show("Введите Id товара.");
                return;
            }

            string connectionString = "Data Source=DESKTOP-777FV0N\\KAZI2005;Initial Catalog=DB_PC;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Orders (CustomerName, Address, Phone, Email, ProductIds) " +
                                   "VALUES (@CustomerName, @Address, @Phone, @Email, @ProductIds)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CustomerName", textBoxName.Text);
                    command.Parameters.AddWithValue("@Address", textBoxAddress.Text);
                    command.Parameters.AddWithValue("@Phone", textBoxPhone.Text);
                    command.Parameters.AddWithValue("@Email", textBoxEmail.Text);
                    command.Parameters.AddWithValue("@ProductIds", textBoxProductId.Text); // Сохраняем Id товара

                    command.ExecuteNonQuery();
                    MessageBox.Show("Заказ успешно оформлен!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
