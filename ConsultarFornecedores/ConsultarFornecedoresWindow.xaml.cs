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
using System.Windows.Shapes;

namespace DS_Sistelie.ConsultarFornecedores
{
    /// <summary>
    /// Lógica interna para ConsultarFornecedoresWindow.xaml
    /// </summary>
    public partial class ConsultarFornecedoresWindow : Window
    {
        public ConsultarFornecedoresWindow()
        {
            InitializeComponent();
        }

        private void btnInicioFornecedor_Click(object sender, RoutedEventArgs e)
        {
            MenuInicial menuInicial = new MenuInicial();
            menuInicial.Show();
            this.Close();
        }

        private void btnExcluirFornecedor_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
