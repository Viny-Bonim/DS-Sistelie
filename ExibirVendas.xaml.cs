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
        bool validacao = false;
        RegistrarVenda registrarVenda = new RegistrarVenda();
        Venda venda = new Venda();
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

            List<Venda> listaVendas = new List<Venda>();
            for (int i = 0; i < 3; i++)
            {
                
                listaVendas.Add(new Venda()
                {
                    Codigo = i +1,
                    DescricaoVenda = "Convite de Casamento em papel colorset de Fulano e Fulano de tal" + i,
                    Data = "29/06/2021" + i,
                    Nomecliente = "Messi" + i,
                    Quantidade = "10" + i,
                    FormaPagamento = "À viste" + i,
                    ValorDesconto = "R$ 2,00" +i,
                    ValorTotal = "R$ 28,00" + i
                }); 
                
            }
            DataGridVendas.ItemsSource = listaVendas;

        }

        private void btnExcluirRegistror_Click(object sender, RoutedEventArgs e)
        {
            if (Radio1.IsChecked == false && Radio2.IsChecked == false && Radio3.IsChecked == false)
            {
                MessageBox.Show("Selecione uma venda para ser excluída!");
            }
            else
            {

                MessageBox.Show("Venda excluída com sucesso!");

            }
            
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
            if (Radio1.IsChecked == false && Radio2.IsChecked == false && Radio3.IsChecked == false)
            {
                MessageBox.Show("Selecione uma Venda para editar!");
            }
            else
            {
                if (Radio1.IsChecked == true)
                {
                    RegistrarVendas registrarVendas = new RegistrarVendas();
                    registrarVendas.Show();
                    this.Close();
                }

                if (Radio2.IsChecked == true)
                {
                    RegistrarVendas registrarVendas = new RegistrarVendas();
                    registrarVendas.Show();
                    this.Close();
                }

                if (Radio3.IsChecked == true)
                {
                    RegistrarVendas registrarVendas = new RegistrarVendas();
                    registrarVendas.Show();
                    this.Close();
                }
            }
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
