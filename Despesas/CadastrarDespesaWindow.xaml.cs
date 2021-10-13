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
        private int _id;
        private Despesas _despesa;

        Despesas despesas = new Despesas();

        private List<string> grupoDespesa;

        bool verifica_txtbox = false;

        public CadastrarDespesaWindow()
        {
            InitializeComponent();
            Loaded += CadastrarDespesaWindow_Loaded;
        }

        public CadastrarDespesaWindow(int id)
        {
            _id = id;
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
            _despesa.ValorDespesa = double.Parse(txtValorDespesa.Text);
            _despesa.DescricaoDespesa = txtDescricaoDespesa.Text;
            _despesa.GrupoDespesa = cmbxGrupoDespesa.Text;
            _despesa.Fkcaixa = 1;
            _despesa.Fkfuncionario = 1;

            if (dtpkDataDespesa.SelectedDate != null)
                _despesa.dataDespesa = (DateTime)dtpkDataDespesa.SelectedDate;


            /*
            if (txtValorDespesa.Text == "" || dtpkDataDespesa.Text == ""
                || dtpkDataDespesa.Text == "" || cmbxGrupoDespesa.Text == ""
                || txtCodigoFornecedorDespesa.Text == "" || txtDescricaoDespesa.Text == "")
            {
                MessageBox.Show("Preencha todos os campos com *");
            }
            else
            {
                despesas.ValorDespesa = double.Parse(txtValorDespesa.Text);
                despesas.dataDespesa = dtpkDataDespesa.Text;
                despesas.CodigoFornecedorCadDespesa = int.Parse(txtCodigoFornecedorDespesa.Text);
                despesas.DescricaoDespesa = txtDescricaoDespesa.Text;
                despesas.IdDespesa = int.Parse(txtIdDespesa.Text);
                despesas.GrupoDespesa = cmbxGrupoDespesa.Text;

                MessageBox.Show("Despesa cadastrada com sucesso!\n" +
                    $"Valor da Despesa: {despesas.ValorDespesa}\n" +
                    $"Data de Cadastro: {despesas.dataDespesa}\n" +
                    $"Código do Forncedor: {despesas.CodigoFornecedorCadDespesa}\n" +
                    $"Descrição da Despesa: {despesas.DescricaoDespesa}\n" +
                    $"ID da Despesa: {despesas.IdDespesa}\n" +
                    $"Grupo da Despesa: {despesas.GrupoDespesa}");
                
                LimparTextBox();
            }
            */
        }


        
        public static bool LetrasEVirgulas(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsDigit(c) && c != ',')
                    return false;
            }
            return true;
        }

        public static bool SemLetras(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        private void txtValorDespesa_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            
            string valor = txtValorDespesa.Text.Trim();

            if (LetrasEVirgulas(valor) == false)
            {
                e.Handled = true;
                MessageBox.Show("Preencha sem letras e separando o número por vígula!");
                txtValorDespesa.Focus();
                verifica_txtbox = false;
            }
            else
            {
                verifica_txtbox = true;
            }
        }

        private void txtCodigoFornecedorDespesa_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            
            string codigo_fornecedor = txtCodigoFornecedorDespesa.Text.Trim();

            if (SemLetras(codigo_fornecedor) == false)
            {
                e.Handled = true;
                MessageBox.Show("Preencha apenas com números!");
                txtCodigoFornecedorDespesa.Focus();
                verifica_txtbox = false;
            }
            else
            {
                verifica_txtbox = true;
            }
        }

        private void LimparTextBox()
        {
            txtValorDespesa.Text = "";
            dtpkDataDespesa.Text = "";
            dtpkDataDespesa.Text = "";
            cmbxGrupoDespesa.Text = "";
            txtCodigoFornecedorDespesa.Text = "";
            txtDescricaoDespesa.Text = "";
        }
    }
}
