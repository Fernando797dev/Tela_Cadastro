using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

    public partial class Admin : Window
    {
        public string conexao = "Server=localhost;Database=login;Uid=root;Pwd=;";
        public Admin()
        {
            InitializeComponent();
            EscreverTabela();
        }

        private void EscreverTabela()
        {

            try
            {
                using (MySqlConnection conn = new MySqlConnection(conexao))
                {

                    conn.Open();

                    string sql = @"SELECT usuario,id,email FROM usuarios";

                    using MySqlCommand cmd =
                        new MySqlCommand(sql, conn);

                    using MySqlDataAdapter adapter =
                        new MySqlDataAdapter(cmd);

                    DataTable tabela = new DataTable();

                    adapter.Fill(tabela);

                    tabelaAdmin.ItemsSource =
                        tabela.DefaultView;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Erro", MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void tabelaAdmin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {


            Update IrTelaUpdate = new Update();
            IrTelaUpdate.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Delete IrtelaDelete = new Delete();
            IrtelaDelete.Show();
            this.Close();
        }
    }
}
