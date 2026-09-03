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
                string queryDeleta = "DELETE FROM usuarios WHERE email = @email";

                using (MySqlConnection conexao = new MySqlConnection(connectionsString)) {

                    conexao.Open();


                   using (var cmdExiste = new MySqlCommand(queryverNoBanco, conexao))
                    {

                        cmdExiste.Parameters.AddWithValue("@email", EmailDelete);
                        long quantidade = Convert.ToInt64(cmdExiste.ExecuteScalar());

                            if(quantidade == 0)
                            {

                                MessageBox.Show("Erro! O usuário não foi encontrado");
                                DeleteEmail.Clear();
                                return;
                            }
                    }

                   using (var DeletarEmail = new MySqlCommand(queryDeleta, conexao)) {

                        DeletarEmail.Parameters.AddWithValue("@email", EmailDelete);
                        DeletarEmail.ExecuteNonQuery();

                        DeleteEmail.Clear();
                        MessageBox.Show("Usuário Deletado com sucesso!!");

                        Admin IrTelaAdmin = new Admin();
                        IrTelaAdmin.Show();
                        this.Close();

                    }


                }

            }
            catch { }
        }

        private void DeleteEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DeleteEmail_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
