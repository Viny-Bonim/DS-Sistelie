using DS_Sistelie.Helpers;
using DS_Sistelie.Models;
using DS_Sistelie.Despesas;
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

namespace DS_Sistelie.Views
{
    /// <summary>
    /// Lógica interna para InserirCaixaWindow.xaml
    /// </summary>
    public partial class InserirCaixaWindow : Window
    {
        private Caixa _caixa;
        private int _id;
        private List<Caixa> _listCaixa = new List<Caixa>();
        bool verifica_txtbox = false;
        public InserirCaixaWindow()
        {
            InitializeComponent();
            Loaded += InserirCaixaWindow_Loaded;
        }

        public InserirCaixaWindow(int id)
        {
            _id = id;
            InitializeComponent();
            Loaded += InserirCaixaWindow_Loaded;
        }

        private void InserirCaixaWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadComboBoxMeses();

            _caixa = new Caixa();
            if (_id > 0)
            {
                FillForm();
            }
        }

        private void btnCancelarCaixa_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Deseja Cancelar e Voltar ao Menu Inicial?", "Cadastrar Caixa", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MenuInicial menuInicial = new MenuInicial();
                menuInicial.Show();
                this.Close();
            }
        }

        private void LoadComboBoxMeses()
        {
            try
            {
                cbxMesCaixa.ItemsSource = Mes.List();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSalvarCaixa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _caixa.AnoCaixa = txtAnoCaixa.Text;

                if (double.TryParse(txtSaldoInicialCaixa.Text, out double saldoInicial))
                    _caixa.SaldoInicial = saldoInicial;

                if (double.TryParse(txtEntradaCaixa.Text, out double entrada))
                    _caixa.EntradaCaixa = entrada;

                if (double.TryParse(txtSaidaCaixa.Text, out double saida))
                    _caixa.SaidaCaixa = saida;

                if (double.TryParse(txtSaldoFinalCaixa.Text, out double saldoFinal))
                    _caixa.SaldoFinal = saldoFinal;

                if (cbxMesCaixa.SelectedItem != null)
                    _caixa.MesCaixa = cbxMesCaixa.SelectedItem as string;

                SaveData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool Validate()
        {
            var validator = new CaixaValidator();
            var result = validator.Validate(_caixa);

            if (!result.IsValid)
            {
                string errors = null;
                var count = 1;

                foreach (var failure in result.Errors)
                {
                    errors += $"{count++} - {failure.ErrorMessage}\n";
                }

                MessageBox.Show(errors, "Validação de Dados", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            return result.IsValid;
        }

        private void SaveData()
        {
            try
            {
                if (Validate())
                {
                    var dao = new CaixaDAO();
                    var text = "atualizado";

                    if (_caixa.IdCaixa == 0)
                    {
                        dao.Insert(_caixa);
                        text = "registrado";
                    }
                    else
                        dao.Update(_caixa);

                    MessageBox.Show($"O Caixa foi {text} com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    CloseFormVerify();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FillForm()
        {
            try
            {
                var dao = new CaixaDAO();
                _caixa = dao.GetById(_id);

                cbxMesCaixa.Text = _caixa.MesCaixa;
                txtAnoCaixa.Text = _caixa.AnoCaixa;
                txtSaldoInicialCaixa.Text = _caixa.SaldoInicial.ToString();
                txtEntradaCaixa.Text = _caixa.EntradaCaixa.ToString();
                txtSaidaCaixa.Text = _caixa.SaidaCaixa.ToString();
                txtSaldoFinalCaixa.Text = _caixa.SaldoFinal.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseFormVerify()
        {
            if (_caixa.IdCaixa == 0)
            {
                var result = MessageBox.Show("Deseja registrar outro Caixa?", "Registrar Novamente?", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    LimparTextBox();
                }
                else
                {
                    ConsultarDespesasWindow  consultarDespesas = new ConsultarDespesasWindow();
                    consultarDespesas.Show();
                    this.Close();
                }
            }
            else
            {
                ConsultarDespesasWindow consultarDespesas = new ConsultarDespesasWindow();
                consultarDespesas.Show();
                this.Close();
            }
        }

        private void LimparTextBox()
        {
            cbxMesCaixa.Text = "";
            txtAnoCaixa.Text = "";
            txtSaldoInicialCaixa.Text = "";
            txtEntradaCaixa.Text = "";
            txtSaidaCaixa.Text = "";
            txtSaldoFinalCaixa.Text = "";
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

        private void txtSaldoInicialCaixa_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            string valor = txtSaldoInicialCaixa.Text.Trim();

            if (LetrasEVirgulas(valor) == false)
            {
                e.Handled = true;
                MessageBox.Show("Preencha sem letras e separando o número por vígula!");
                txtSaldoInicialCaixa.Focus();
                verifica_txtbox = false;
            }
            else
            {
                UpdateSaldoFinal();
                verifica_txtbox = true;
            }
        }

        private void txtEntradaCaixa_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            string valor = txtEntradaCaixa.Text.Trim();

            if (LetrasEVirgulas(valor) == false)
            {
                e.Handled = true;
                MessageBox.Show("Preencha sem letras e separando o número por vígula!");
                txtEntradaCaixa.Focus();
                verifica_txtbox = false;
            }
            else
            {
                UpdateSaldoFinal();
                verifica_txtbox = true;
            }
        }

        private void txtSaidaCaixa_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            string valor = txtSaidaCaixa.Text.Trim();

            if (LetrasEVirgulas(valor) == false)
            {
                e.Handled = true;
                MessageBox.Show("Preencha sem letras e separando o número por vígula!");
                txtSaidaCaixa.Focus();
                verifica_txtbox = false;
            }
            else
            {
                UpdateSaldoFinal();
                verifica_txtbox = true;
            }
        }

        private double UpdateSaldoFinal()
        {
            var saldoFinal = 0.0;
            double saldoInicial = 0.0;
            double entrada = 0.0;
            double saida = 0.0;

            try
            {
                if (double.TryParse(txtSaldoInicialCaixa.Text, out double saldoIni))
                    saldoInicial = saldoIni;

                if (double.TryParse(txtEntradaCaixa.Text, out double entradaCai))
                    entrada = entradaCai;

                if (double.TryParse(txtSaidaCaixa.Text, out double saidaCai))
                    saida = saidaCai;

                saldoFinal = (saldoInicial + entrada) - saida;

                txtSaldoFinalCaixa.Text = saldoFinal.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return saldoFinal;
        }
    }
}
