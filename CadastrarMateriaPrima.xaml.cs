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
    /// Lógica interna para CadastrarMateriaPrima.xaml
    /// </summary>
    public partial class CadastrarMateriaPrima : Window
    {
        bool validacao = false;
        MateriaPrima materiPrima = new MateriaPrima();
        private List<string> Nomemateriaprima;

        public CadastrarMateriaPrima()
        {
            InitializeComponent();
            Loaded += CadastrarMateriaPrima_Loaded;
        }

        private void CadastrarMateriaPrima_Loaded(object sender, RoutedEventArgs e)
        {
            Nomemateriaprima = new List<string>();

            Nomemateriaprima.Add("Papelão Paraná 20mm");
            Nomemateriaprima.Add("papel a4 500 folhas");
            Nomemateriaprima.Add("papel cartolina a4 180g");

            ComboNomeMateriaPrima.ItemsSource = Nomemateriaprima;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {


            MessageBoxResult result = MessageBox.Show("Deseja Cancelar o Cadastro de matéria - prima?", "Cadastrar matéria - prima", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MenuInicial menuInicial = new MenuInicial();
                menuInicial.Show();
                this.Close();
            }

            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            materiPrima.DataCadastroMateriaprima = DataCad.Text;
            materiPrima.ValorUnitarioMateriaPrima = TxtValorUnitario.Text;
            materiPrima.QuantidadeUnidadesMateriaPrima = TxtQtd.Text;
            materiPrima.NomeMateriPrima = ComboNomeMateriaPrima.Text;
            materiPrima.FornecedorMateriaPrima = TxtFornecedor.Text;
            materiPrima.ValorTotalMateriaPrima = TxtValorTotal.Text;

            if (materiPrima.DataCadastroMateriaprima.Equals("")
                || materiPrima.ValorUnitarioMateriaPrima.Equals("")
                || materiPrima.NomeMateriPrima.Equals(""))

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
                MessageBox.Show("Matéria - prima cadastrada com sucesso!\n" +
                $"Data: {materiPrima.DataCadastroMateriaprima}\n" +
                $"Valor Unitário: {materiPrima.ValorUnitarioMateriaPrima}\n" +
                $"Quantidade: {materiPrima.QuantidadeUnidadesMateriaPrima}\n" +
                $"Nome: {materiPrima.NomeMateriPrima}\n" +
                $"Fornecedor: {materiPrima.FornecedorMateriaPrima}\n" +
                $"Valor total: {materiPrima.ValorTotalMateriaPrima}");
                LimparTextBox();
            }

            void LimparTextBox()
            {
                DataCad.Text = "";
                TxtValorUnitario.Text = "";
                TxtQtd.Text = "";
                ComboNomeMateriaPrima.Text = "";
                TxtFornecedor.Text = "";
                TxtValorTotal.Text = "";
            }

        }

        private void TxtCodigo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}

        
    

