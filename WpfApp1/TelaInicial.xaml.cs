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
    /// Lógica interna para TelaInicial.xaml
    /// </summary>
    public partial class TelaInicial : Window
    {
        public TelaInicial()
        {
            InitializeComponent();
        }

        private void BotãoTelaCadastro_Click(object sender, RoutedEventArgs e)
        {
            Sign_InWindow1 ParaCadastro = new Sign_InWindow1();
            ParaCadastro.Show();
            this.Close();
        }

        private void BotãoTelaLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow1 ParaLogin = new LoginWindow1();
            ParaLogin.Show();
            this.Close();
        }
    }
}
