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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool validacao = false;

            string usuario = txtusuario.Text;
            string senha = txtsenha.Text;

            if(usuario.Equals("") || senha.Equals(""))
            {
                MessageBox.Show("Verifique se os campos estão preenchidos!");
                validacao = true;
            }
            else
            {
                validacao = false;
            }

            if (validacao == false)
            {
                MenuInicial menu_inicial = new MenuInicial();
                menu_inicial.Show();
                this.Close();
            }
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
