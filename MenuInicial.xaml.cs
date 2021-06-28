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
    /// Lógica interna para MenuInicial.xaml
    /// </summary>
    public partial class MenuInicial : Window
    {
        public MenuInicial()
        {
            InitializeComponent();
        }

        private void btnFornecedor_Click(object sender, RoutedEventArgs e)
        {
            CadastrarFornecedor cad_fornecedor = new CadastrarFornecedor();
            cad_fornecedor.Show();
            this.Close();
        }
        private void btnCadCliente_Click(object sender, RoutedEventArgs e)
        {
            CadastrarCliente cad_cliente = new CadastrarCliente();
            cad_cliente.Show();
            this.Close();
        }

        private void btnCadProprietario_Click(object sender, RoutedEventArgs e)
        {
            CadastrarProprietario cad_proprietario = new CadastrarProprietario();
            cad_proprietario.Show();
            this.Close();
        }

        private void btnConsultarFornecedor_Click(object sender, RoutedEventArgs e)
        {
            ConsultarFornecedores.ConsultarFornecedoresWindow consultarFornecedores = new ConsultarFornecedores.ConsultarFornecedoresWindow();
            consultarFornecedores.Show();
            this.Close();
        }

        private void btnCadmateriaPrima_Click(object sender, RoutedEventArgs e)
        {
            CadastrarMateriaPrima cad_CastrarMateria = new CadastrarMateriaPrima();
            cad_CastrarMateria.Show();
            this.Close();
        }

        private void btnRegSaidaMateriaPrima_Click(object sender, RoutedEventArgs e)
        {
            SaidaMateriaPrima Reg_saidaMateriaPrima = new SaidaMateriaPrima();
            Reg_saidaMateriaPrima.Show();
            this.Close();
        }

        private void btnRegVendas_Click(object sender, RoutedEventArgs e)
        {
            RegistrarVendas Reg_Vendas = new RegistrarVendas();
            Reg_Vendas.Show();
            this.Close();
        }

        private void btnExibVendas_Click(object sender, RoutedEventArgs e)
        {
            ExibirVendas Exib_Vendas = new ExibirVendas();
            Exib_Vendas.Show();
            this.Close();
        }

        private void btnCadastrarDespesa_Click(object sender, RoutedEventArgs e)
        {
            Despesas.CadastrarDespesaWindow cadastrarDespesa = new Despesas.CadastrarDespesaWindow();
            cadastrarDespesa.Show();
            this.Close();
        }
    }
}
