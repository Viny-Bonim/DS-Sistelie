using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using DS_Sistelie.Database;
using DS_Sistelie.Models;

namespace DS_Sistelie
{
    /// <summary>
    /// Interação lógica para TelaLogin.xam
    /// </summary>
    public partial class TelaLogin : Window
    {

        public TelaLogin()
        {
            InitializeComponent();
            Loaded += TelaLogin_Loaded;
        }

        private void TelaLogin_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var conexao = new Conexao();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Password.ToString();

            if (Login.LoginUsuario(usuario, senha))
            {
                var main = new MenuInicial();
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario e/ou senha incorretos! Tente novamente", "Autorização negada", MessageBoxButton.OK, MessageBoxImage.Warning);
                _ = txtUsuario.Focus();
            }
        }
    }
}
