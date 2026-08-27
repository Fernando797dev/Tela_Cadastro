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
using BCryptNet = BCrypt.Net.BCrypt;

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


        }

        private void btn_login_cadastro_Click(object sender, RoutedEventArgs e)
        {
            string usuario = digita_usuario.Text.Trim();
            string senha = digita_senha.Password.Trim();

            try
            {

                string query = "SELECT senha FROM usuarios WHERE usuario = @usuario";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string hashBanco = reader["senha"].ToString();
                                BCryptNet.GenerateSalt(); 

                                if (BCryptNet.Verify(senha, hashBanco))
                                {
                                    MessageBox.Show($"Olá, {usuario}", "Bem-vindo", MessageBoxButton.OK, MessageBoxImage.Information);

                                    digita_usuario.Clear();
                                    digita_senha.Clear();
                                }
                                else
                                {
                                    MessageBox.Show("Usuário ou senha incorretos.", "Erro de Autenticação", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Usuário ou senha incorretos.", "Erro de Autenticação", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao conectar ao banco de dados: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Sign_InWindow1 telaCadastro = new Sign_InWindow1();
            telaCadastro.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            TelaInicial VoltarTelaInicial = new TelaInicial();
            VoltarTelaInicial.Show();
            this.Close();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
