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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
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


        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            string usuarioDigitado;
            string email;
            string senha;


            if(digita_usuario.Text.Length <3)
            {
                MessageBox.Show("Usuário cadastrado errado, usuario deve conter 3 ou mais caracteres");
                digita_usuario.Text = null;
            }


            if (!new EmailAddressAttribute().IsValid(digita_email.Text))
            {
                MessageBox.Show("Email digitado errado, digite um email valido");
                digita_email.Text = null;
            }


           if(digita_confirmar_senha.Password.Length < 8)
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
    }
    }
