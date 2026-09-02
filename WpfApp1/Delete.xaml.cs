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
    /// Lógica interna para Delete.xaml
    /// </summary>
    public partial class Delete : Window
    {
        string connectionsString = "Server=localhost;Database=login;Uid=root;Pwd=;";

        public Delete()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ConfirmarDelete_Click(object sender, RoutedEventArgs e)
        {
            string EmailDelete = DeleteEmail.Text;
            
            if (string.IsNullOrEmpty(EmailDelete)) {

                MessageBox.Show("Preencha o campo com o email que deseja ser deletado");
                return;
            }
            try
            {

                string queryverNoBanco = "SELECT COUNT(*) FROM usuarios WHERE email = @email";
                string queryDeleta = "DELECT FROM usuarios WHERE email = @email";

                using (MySqlConnection conexao = new MySqlConnection(connectionsString)) {

                    conexao.Open();
                    using var cmdExiste = new MySqlCommand(queryverNoBanco, conexao);
                    cmdExiste.Parameters.AddWithValue("@email", EmailDelete);
                    try
                    {
                        using var reader = cmdExiste.ExecuteReader();

                        if (reader.Read())
                        {
                            using var deleteEmail = new MySqlCommand(queryDeleta, conexao);
                            deleteEmail.Parameters.AddWithValue("@email",EmailDelete);
                        }
                    }
                    catch{
                        MessageBox.Show("Erro! O email não foi encontrado");
                    }


                }

            }
            catch { }
        }

        private void DeleteEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
