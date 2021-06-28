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
        Despesas despesas = new Despesas();

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

        private void btnCancelarDespesa_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Deseja Cancelar o Cadastro dessa Despesa?", "Cadastrar Despesa", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MenuInicial menuInicial = new MenuInicial();
                menuInicial.Show();
                this.Close();
            }
        }

        private void btnSalvarDespesa_Click(object sender, RoutedEventArgs e)
        {
            despesas.ValorDespesa = double.Parse(txtValorDespesa.Text);
            despesas.dataDespesa = DateTime.Parse(dtpkDataDespesa.Text);
            despesas.CodigoFornecedorCadDespesa = int.Parse(txtCodigoFornecedorDespesa.Text);
            despesas.DescricaoDespesa = txtDescricaoDespesa.Text;
            despesas.IdDespesa = int.Parse(txtIdDespesa.Text);
            despesas.GrupoDespesa = cmbxGrupoDespesa.Text;

            if (despesas.ValorDespesa.Equals("") && despesas.dataDespesa.Equals("")
                && despesas.DescricaoDespesa.Equals("") && despesas.GrupoDespesa.Equals(""))
            {
                MessageBox.Show("Preencha todos os campos com *");
            }
            else
            {
                MessageBox.Show("Despesa cadastrada com sucesso!\n" +
                    $"Valor da Despesa: {despesas.ValorDespesa}\n" +
                    $"Data de Cadastro: {despesas.dataDespesa}\n" +
                    $"Código do Forncedor: {despesas.CodigoFornecedorCadDespesa}\n" +
                    $"Descrição da Despesa: {despesas.DescricaoDespesa}\n" +
                    $"ID da Despesa: {despesas.IdDespesa}\n" +
                    $"Grupo da Despesa: {despesas.GrupoDespesa}");
            }
        }
    }
}
