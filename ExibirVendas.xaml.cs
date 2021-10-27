using DS_Sistelie.Models;
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

namespace DS_Sistelie
{
    /// <summary>
    /// Lógica interna para ExibirVendas.xaml
    /// </summary>
    public partial class ExibirVendas : Window
    {
        
        private List<string> Nomecliente;
        
        public ExibirVendas()
        {
            InitializeComponent();
            Loaded += ExibirVendas_Loaded;
        }

        private void ExibirVendas_Loaded(object sender, RoutedEventArgs e)
        {
            Nomecliente = new List<string>();
            Nomecliente.Add("Carolaine Aparecida de Souza Barros");
            Nomecliente.Add("Gabriel André Estevam Gross");
            Nomecliente.Add("Gustavo dos Anjos Néri");
            Nomecliente.Add("Hiago Santana Benitez");
            Nomecliente.Add("Viny Bonim Scaldelai");
            ComboNomeCliente.ItemsSource = Nomecliente;

        }

        private void btnExcluirRegistror_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void btnInicioExibirVendas_Click(object sender, RoutedEventArgs e)
        {
           MessageBoxResult result = MessageBox.Show("Deseja voltar ao inicio?", "Exibir Vendas", MessageBoxButton.YesNo, MessageBoxImage.Question);
           if (result == MessageBoxResult.Yes)
           {
               MenuInicial menuInicial = new MenuInicial();
               menuInicial.Show();
               this.Close();
           }

        }
 
        
        private void btnEditarVenda_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TxtCodigo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtDescricaoVenda_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnPesquisarFornecedor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Radio1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Radio2_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Radio3_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void DataGridVendas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnPesquisarVenda_Click(object sender, RoutedEventArgs e)
        {

        }

       
    }
}
