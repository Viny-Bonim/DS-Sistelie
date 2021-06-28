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
        private List<string> ordemConsultaForncedores;

        public ConsultarFornecedoresWindow()
        {
            InitializeComponent();
            Loaded += ConsultarFornecedoresWindow_Loaded;
        }

        private void ConsultarFornecedoresWindow_Loaded(object sender, RoutedEventArgs e)
        {
            List<Fornecedor> ListaFornecedor = new List<Fornecedor>();         

            for (int i = 0; i < 41; i++)
            {
                ListaFornecedor.Add(new Fornecedor()
                {
                    CodigoFornecedor = i + 1,
                    TipoFornecedor = "Pessoa Física",
                    DataCadastroFornecedor = "01/05/2020",
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

            /*ComboBox ordem de consulta de fornecedores*/
            ordemConsultaForncedores = new List<string>();

            ordemConsultaForncedores.Add("ID");
            ordemConsultaForncedores.Add("Nome Fantasia");
            ordemConsultaForncedores.Add("Razão Social");
            ordemConsultaForncedores.Add("Data de Cadastro");
            ordemConsultaForncedores.Add("Categoria");
            ordemConsultaForncedores.Add("País");
            ordemConsultaForncedores.Add("Cidade");
            ordemConsultaForncedores.Add("UF");

            cmbxFiltroConsultaFornecedores.ItemsSource = ordemConsultaForncedores;
        }

        private void btnInicioFornecedor_Click(object sender, RoutedEventArgs e)
        {
            MenuInicial menuInicial = new MenuInicial();
            menuInicial.Show();
            this.Close();
        }
    }
}
