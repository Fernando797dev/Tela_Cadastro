using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Lógica interna para Update.xaml
    /// </summary>
    public partial class Update : Window
    {
        string connectionString = "Server=localhost;Database = login;Uid = root;Pwd=;";
        public Update()
        {
            InitializeComponent();
        }

        private void Coletar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ConfirmarUpdate_Click(object sender, RoutedEventArgs e)
        {
            using(MySqlConnection conexao = new MySqlConnection(conexao))
            {

                conexao.Open();
                string query = "SELECT "
            }
        }
    }
}
