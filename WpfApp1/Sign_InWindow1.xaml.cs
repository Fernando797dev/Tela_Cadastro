using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging.Effects;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BCryptNet = BCrypt.Net.BCrypt;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Sign_InWindow1 : Window
    {
        public string connectionString = "Server=localhost;Database=login;Uid=root;Pwd=;";
        public Sign_InWindow1()
        {



            InitializeComponent();

            cor_fundo.Background = System.Windows.Media.Brushes.DarkCyan;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Cadastro_Click(object sender, RoutedEventArgs e)
        {



        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }


        private void btn_cadastro_Click(object sender, RoutedEventArgs e)
        {
            string usuarioDigitado;
            string email;
            string senha;


            if (digita_usuario.Text.Length < 3)
            {
                MessageBox.Show("Usuário cadastrado errado, usuario deve conter 3 ou mais caracteres");
                digita_usuario.Text = null;
            }


            if (!new EmailAddressAttribute().IsValid(digita_email.Text))
            {
                MessageBox.Show("Email digitado errado, digite um email valido");
                digita_email.Text = null;
            }


            if (digita_confirmar_senha.Password.Length < 8)
            {
                MessageBox.Show("Senha digitada errado, senha deve conter 8 ou mais caracteres");
                digita_senha.Password = null;
            }

            if (digita_confirmar_senha.Password != digita_senha.Password)
            {
                MessageBox.Show("As senhas não coincidem");
                digita_confirmar_senha.Password = null;
            }

            else
            {

                usuarioDigitado = digita_usuario.Text;
                senha = digita_senha.Password;
                email = digita_email.Text;
                MessageBox.Show($"Cadastro realizado com sucesso! \n\nUsuário: {usuarioDigitado} \nEmail: {email} \nSenha: {senha}");

            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow1 telaLogin = new LoginWindow1();

            telaLogin.Show();

            this.Close();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_login_cadastro_Click(object sender, RoutedEventArgs e)
        {


            if (digita_usuario.Text.Length < 3)
            {
                MessageBox.Show("Usuário cadastrado errado, usuario deve conter 3 ou mais caracteres");
                digita_usuario.Text = null;
            }


            if (!new EmailAddressAttribute().IsValid(digita_email.Text))
            {
                MessageBox.Show("Email digitado errado, digite um email valido");
                digita_email.Text = null;
            }


            if (digita_confirmar_senha.Password.Length < 8)
            {
                MessageBox.Show("Senha digitada errado, senha deve conter 8 ou mais caracteres");
                digita_senha.Password = null;
            }

            if (digita_confirmar_senha.Password != digita_senha.Password)
            {
                MessageBox.Show("As senhas não coincidem");
                digita_confirmar_senha.Password = null;
            }

            else
            {
                string email = digita_email.Text.Trim();
                string usuario = digita_usuario.Text.Trim();
                string senha = digita_senha.Password.Trim();

                try
                {
                    using (MySqlConnection conexao = new MySqlConnection(connectionString))
                    {
                       
                        conexao.Open();
                        string senhaCriptografada = BCryptNet.HashPassword(senha);
                        string query = "INSERT INTO usuarios (email, usuario, senha, IsAdmin) VALUES (@email, @usuario, @senha, @IsAdmin)";

                        using (MySqlCommand comando = new MySqlCommand(query, conexao))
                        {
                            bool validado = false;
                            if (admin.IsChecked == true)
                            {
                                validado = true;
                                
                            }
                            comando.Parameters.AddWithValue("@email", email);
                            comando.Parameters.AddWithValue("@usuario", usuario);
                            comando.Parameters.AddWithValue("@senha", senhaCriptografada);
                            comando.Parameters.AddWithValue("@IsAdmin", validado);

                            comando.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Usuário cadastrado com sucesso!", "Sucesso", MessageBoxButton.OK);
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TelaInicial VoltarTelaCadastro = new TelaInicial();
            VoltarTelaCadastro.Show();
            this.Close();
        }
    }
}
