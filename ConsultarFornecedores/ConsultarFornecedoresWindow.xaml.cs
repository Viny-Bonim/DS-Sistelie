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
using DS_Sistelie.Models;

namespace DS_Sistelie.ConsultarFornecedores
{
    /// <summary>
    /// Lógica interna para ConsultarFornecedoresWindow.xaml
    /// </summary>
    public partial class ConsultarFornecedoresWindow : Window
    {
        private List<string> ordemConsultaForncedores;
        List<Models.Fornecedor> ListaFornecedor = new List<Models.Fornecedor>();

        public ConsultarFornecedoresWindow()
        {
            InitializeComponent();
            Loaded += ConsultarFornecedoresWindow_Loaded;
        }

        private void ConsultarFornecedoresWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadListForne();

            /*
            for (int i = 0; i < 3; i++)
            {
                ListaFornecedor.Add(new Models.Fornecedor()
                {
                    CodigoFornecedor = i + 1,
                    TipoFornecedor = "Pessoa Física",
                    DataCadastroFornecedor = DateTime.Now,
                    RgIe = "135090",
                    Cpf = "0346890225",
                    Cnpj = "135964856",
                    NomeFantasia = "Papelaria Universo - " + i,
                    RazaoSocial = "Papelaria Universo Lmtd.",
                    Telefone = "205515454",
                    Email = "vinyscaldelai@gmail.com",
                    Cep = "76908494",
                    Logradouro = "Rua João Batista Neto",
                    Numero = "1633",
                    Pais = "Brasil",
                    Uf = "RO",
                    Cidade = "Ji-Paraná"
                });
            }
            DataGridConsultarFornecedor.ItemsSource = ListaFornecedor;
            */
        } 

          

        private void btnInicioFornecedor_Click(object sender, RoutedEventArgs e)
        {
            MenuInicial menuInicial = new MenuInicial();
            menuInicial.Show();
            this.Close();
        }

        private void btnEditarFornecedor_Click(object sender, RoutedEventArgs e)
        {
            if (rdbtConsultarFornecedores1.IsChecked == false && rdbtConsultarFornecedores2.IsChecked == false
                && rdbtConsultarFornecedores3.IsChecked == false)
            {
                MessageBox.Show("Selecione um Fornecedor para Editar!");
            }
            else
            {
                if (rdbtConsultarFornecedores1.IsChecked == true)
                {
                    CadastrarFornecedor cadastrarFornecedor = new CadastrarFornecedor();
                    cadastrarFornecedor.Show();
                    this.Close();
                }

                if (rdbtConsultarFornecedores2.IsChecked == true)
                {
                    CadastrarFornecedor cadastrarFornecedor = new CadastrarFornecedor();
                    cadastrarFornecedor.Show();
                    this.Close();
                }

                if (rdbtConsultarFornecedores3.IsChecked == true)
                {
                    CadastrarFornecedor cadastrarFornecedor = new CadastrarFornecedor();
                    cadastrarFornecedor.Show();
                    this.Close();
                }
            }       
        }

        private void btnExcluirFornecedor_Click(object sender, RoutedEventArgs e)
        {
            if (rdbtConsultarFornecedores1.IsChecked == false && rdbtConsultarFornecedores2.IsChecked == false
                && rdbtConsultarFornecedores3.IsChecked == false)
            {
                MessageBox.Show("Selecione um Fornecedor para Excluir!");
            }
            else
            {
                MessageBox.Show("Fornecedor Excluído com Sucesso!");
            }
        }

        private void DataGridConsultarFornecedor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LoadListForne()
        {
            try
            {
                var dao = new FornecedorDAO();
                DataGridConsultarFornecedor.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
