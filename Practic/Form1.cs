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

    public partial class CatalogForm : Form
    {
        
        public static List<string> Cart = new List<string>();

        public CatalogForm()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            // Создаем корневые узлы категорий
            TreeNode computersNode = new TreeNode("Компьютеры");
            TreeNode laptopsNode = new TreeNode("Ноутбуки");
            TreeNode keyboardsNode = new TreeNode("Клавиатуры");
            TreeNode miceNode = new TreeNode("Мыши");

            string connectionString = "Data Source=DESKTOP-777FV0N\\KAZI2005;Initial Catalog=DB_PC;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Name, Category FROM Products";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string product = $"{reader["Id"]}: {reader["Name"]}";
                    string category = reader["Category"].ToString();

                    // Добавляем товары в соответствующую категорию
                    switch (category)
                    {
                        case "Компьютеры":
                            computersNode.Nodes.Add(product);
                            break;
                        case "Ноутбуки":
                            laptopsNode.Nodes.Add(product);
                            break;
                        case "Клавиатуры":
                            keyboardsNode.Nodes.Add(product);
                            break;
                        case "Мыши":
                            miceNode.Nodes.Add(product);
                            break;
                    }
                }
            }

            // Добавляем категории в TreeView
            treeViewProducts.Nodes.Add(computersNode);
            treeViewProducts.Nodes.Add(laptopsNode);
            treeViewProducts.Nodes.Add(keyboardsNode);
            treeViewProducts.Nodes.Add(miceNode);

        }

        private void buttonAddToCart_Click(object sender, EventArgs e)
        {
            if (treeViewProducts.SelectedNode != null && treeViewProducts.SelectedNode.Level == 1) // Проверяем, что выбран товар, а не категория
            {
                Cart.Add(treeViewProducts.SelectedNode.Text);
                MessageBox.Show("Товар добавлен в корзину.");
            }
            else
            {
                MessageBox.Show("Выберите товар.");
            }
        }

        private void buttonViewCart_Click(object sender, EventArgs e)
        {
            CartForm cartForm = new CartForm();
            cartForm.Show();
        }
    }
}
