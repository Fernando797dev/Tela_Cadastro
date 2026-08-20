using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System;
using MySql.Data.MySqlClient;

namespace WpfApp1
{
    /// <summary>
    /// Lógica interna para LoginWindow1.xaml
    /// </summary>
    public partial class LoginWindow1 : Window
    {
        public string connectionString = "Server=localhost;Database=login;Uid=root;Pwd=;";

        public LoginWindow1()
        {
            InitializeComponent();

            cor_fundo.Background = System.Windows.Media.Brushes.CornflowerBlue;
        }

        private void btn_login_cadastro_Click(object sender, RoutedEventArgs e)
        {


            string senha = digita_senha.Password.Trim();
            string usuario = digita_usuario.Text.Trim();

            string Bcd = "SELECT COUNT(*) FROM usuarios WHERE usuario = @usuario AND senha = @senha";

            using(MySqlConnection connection =new MySqlConnection(connectionString))
            {

                connection.Open();

                using(MySqlCommand cmd= new MySqlCommand(Bcd, connection))
                {

                    cmd.Parameters.AddWithValue("@usuario", digita_usuario.Text);
                    cmd.Parameters.AddWithValue("@senha", digita_senha.Password);

                    int resultado = Convert.ToInt32(cmd.ExecuteScalar());

                    if (resultado > 0)
                    {

                        MessageBox.Show("Usuário logado com sucesso");
                        digita_usuario.Text = null;
                        digita_senha.Password = null;

                    }
                    else
                    {
                        MessageBox.Show("Usuário ou senha não encontrados, tente denovo mais tarde");
                        digita_usuario.Text = null;
                        digita_senha.Password = null;

                    }
                }

            }



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
