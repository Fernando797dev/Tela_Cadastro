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

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Preencha todos os campos para entrar.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conexao = new MySqlConnection(connectionString))
                {
                    conexao.Open();

                    string query = "SELECT senha, IsAdmin FROM usuarios WHERE usuario = @usuario";

                    using (MySqlCommand comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@usuario", usuario);

                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string senhaHashBanco = reader.GetString("senha");
                                bool isAdmin = reader.GetBoolean("IsAdmin");

                                if (BCryptNet.Verify(senha, senhaHashBanco))
                                {
                                    MessageBox.Show("Login realizado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);

                                    if (isAdmin)
                                    {
                                        Admin telaAdmin = new Admin();
                                        telaAdmin.Show();
                                    }
                                    else
                                    {

                                        TelaInicial telaUser = new TelaInicial();
                                        telaUser.Show();
                                    }

                                    this.Close(); 
                                }
                                else
                                {
                                    MessageBox.Show("Usuário ou senha incorretos.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                                    digita_senha.Password = string.Empty;
                                    digita_confirmar_senha.Password = string.Empty;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Usuário ou senha incorretos.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                                digita_senha.Password = string.Empty;
                                digita_confirmar_senha.Password = string.Empty;
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
