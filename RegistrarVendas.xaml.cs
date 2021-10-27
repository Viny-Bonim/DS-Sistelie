using DS_Sistelie.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DS_Sistelie
{
    /// <summary>
    /// Lógica interna para RegistrarVendas.xaml
    /// </summary>
    public partial class RegistrarVendas : Window
    {
        bool validacao = false;
        private int _Codigovenda;
        private Venda _venda;
        private List<string> Nomecliente;
        private List<string> Formapagamento;
        private List<string> Nomevendedor;
        public RegistrarVendas()
        {
            InitializeComponent();
            Loaded += RegistrarVendas_Loaded;
        }

        public RegistrarVendas(int Codigovenda)
        {
            _Codigovenda = Codigovenda;
            InitializeComponent();
            Loaded += RegistrarVendas_Loaded;
        }

        private void RegistrarVendas_Loaded(object sender, RoutedEventArgs e)
        {
            _venda = new Venda();

            Nomecliente = new List<string>();
            Nomecliente.Add("Carolaine Aparecida de Souza Barros");
            Nomecliente.Add("Gabriel André Estevam Gross");
            Nomecliente.Add("Gustavo dos Anjos Néri");
            Nomecliente.Add("Hiago Santana Benitez");
            Nomecliente.Add("Viny Bonim Scaldelai");
            ComboNomeCliente.ItemsSource = Nomecliente;

            Formapagamento = new List<string>();
            Formapagamento.Add("À vista");
            Formapagamento.Add("Cartão de crédito");
            ComboFormaPagamento.ItemsSource = Formapagamento;

            Nomevendedor = new List<string>();
            Nomevendedor.Add("Mariluci Bonim Scaldelai");
            ComboNomeVendedor.ItemsSource = Nomevendedor;

            List<Venda> listaVendas = new List<Venda>();
            listaVendas.Add(new Venda()
            {
                Codigovenda = 1,
                DescricaoVenda = TxtDescricaoVenda.Text,
                UnidadeVenda = TxtUnidadedeVenda.Text,
                Quantidade = TxtQuantidade.Text,
                ValorUnidade = TxtValorUnidade.Text,
                ValorTotal = "Null"
            });

            DataGridVendas.ItemsSource = listaVendas;

        }



        private void btnNovaVenda_Click(object sender, RoutedEventArgs e)
        {
            LimparTextBox();

            void LimparTextBox()
            {
                DataVenda.Text = "";
                ComboFormaPagamento.Text = "";
                ComboNomeCliente.Text = "";
                ComboNomeVendedor.Text = "";
                TxtDescricaoVenda.Text = "";
                TxtQuantidade.Text = "";
                TxtValorUnidade.Text = "";
                TxtUnidadedeVenda.Text = "";
                TxtValorDesconto.Text = "";
            }


        }


        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (DataVenda.SelectedDate != null)
                _venda.DataVenda = (DateTime)DataVenda.SelectedDate;
            _venda.Formapagamento = ComboFormaPagamento.Text;
            _venda.Nomecliente = ComboNomeCliente.Text;
            _venda.Nomevendedor = ComboNomeVendedor.Text;
            _venda.DescricaoVenda = TxtDescricaoVenda.Text;
            _venda.UnidadeVenda = TxtUnidadedeVenda.Text;

            if (_venda.DataVenda.Equals("")
                || _venda.Formapagamento.Equals("")
                || _venda.Nomecliente.Equals("")
                || _venda.Nomevendedor.Equals("")
                || _venda.DescricaoVenda.Equals("")
                || _venda.Quantidade.Equals("")
                || _venda.UnidadeVenda.Equals(""))

            {
                MessageBox.Show("Preencha todos os campos com *");
                validacao = false;
            }

            else
            {
                validacao = true;
            }

            if (validacao == true)
            {
                MessageBox.Show("Registro salvo com sucesso!\n" +
                $"Data: {_venda.DataVenda}\n" +
                $"Forma de pagamento: {_venda.Formapagamento}\n" +
                $"Nome do(a) Cliente: {_venda.Nomecliente}\n" +
                $"Nome do(a) vendedor(a): {_venda.Nomevendedor}\n" +
                $"Descrição: {_venda.DescricaoVenda}\n" +
                $"Quantidade: {_venda.Quantidade}\n" +
                $"Unidade de venda: {_venda.UnidadeVenda}");
            }



        }
        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }     
          private void btnExcluirRegistror_Click(object sender, RoutedEventArgs e)
         {
                List<Venda> listaVendas = new List<Venda>();
                listaVendas.Add(new Venda()
                {
                  Codigovenda = 1,
                  DescricaoVenda = "",
                  UnidadeVenda = "",
                  Quantidade = "",
                  ValorUnidade = "",
                  ValorTotal = "Null"
                });
            
            DataGridVendas.ItemsSource = listaVendas;
          }
      

        private void btnInserirRegistro_Click(object sender, RoutedEventArgs e)
        {
           
            List<Venda> listaVendas = new List<Venda>();
            listaVendas.Add(new Venda()
            {
                Codigovenda = 1,
                DescricaoVenda = TxtDescricaoVenda.Text,
                UnidadeVenda = TxtUnidadedeVenda.Text,
                Quantidade = TxtQuantidade.Text,
                ValorUnidade = TxtValorUnidade.Text,
                ValorTotal = "Não configurado :("
            });

            DataGridVendas.ItemsSource = listaVendas;

        }

        private void TxtCodigo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TxtDescricaoVenda_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DataGridVendas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TxtQuantidade_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtValorUnidade_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtUnidadedeVenda_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnExcluirFornecedor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnInicioRegistrarVenda_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Deseja voltar ao inicio?", "Registrar Vendas", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MenuInicial menuInicial = new MenuInicial();
                menuInicial.Show();
                this.Close();
            }

        }
    }
}
