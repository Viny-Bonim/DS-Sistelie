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

namespace DS_Sistelie.Despesas
{
    /// <summary>
    /// Lógica interna para CadastrarDespesaWindow.xaml
    /// </summary>
    public partial class CadastrarDespesaWindow : Window
    {
        private List<string> grupoDespesa;

        public CadastrarDespesaWindow()
        {
            InitializeComponent();
            Loaded += CadastrarDespesaWindow_Loaded;
        }

        private void CadastrarDespesaWindow_Loaded(object sender, RoutedEventArgs e)
        {
            grupoDespesa = new List<string>();

            grupoDespesa.Add("Despesa Fixa");
            grupoDespesa.Add("Despesa Variável");

            cmbxGrupoDespesa.ItemsSource = grupoDespesa;
        }
    }
}
