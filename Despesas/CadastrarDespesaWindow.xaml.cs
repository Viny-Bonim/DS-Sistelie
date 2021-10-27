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

namespace DS_Sistelie.Despesas
{
    /// <summary>
    /// Lógica interna para CadastrarDespesaWindow.xaml
    /// </summary>
    public partial class CadastrarDespesaWindow : Window
    {
        private int _id;
        private Despesas _despesa;

        //Despesas despesas = new Despesas();

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

            LoadCbxFuncCaixa();

            _despesa = new Despesas();
            if (_id > 0)
            {
                FillForm();
            }
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
            _despesa.DescricaoDespesa = txtDescricaoDespesa.Text;
            _despesa.GrupoDespesa = cmbxGrupoDespesa.Text;

            if (double.TryParse(txtValorDespesa.Text, out double valorDesp))
                _despesa.ValorDespesa = valorDesp;

            if (dtpkDataDespesa.SelectedDate != null)
                _despesa.dataDespesa = (DateTime)dtpkDataDespesa.SelectedDate;

            if (cbxCaixaDespesa.SelectedItem != null)
                _despesa.Caixa = cbxCaixaDespesa.SelectedItem as Caixa;

            if (cbxFuncionarioDespesa.SelectedItem != null)
                _despesa.Funcionario = cbxFuncionarioDespesa.SelectedItem as Funcionario;

            SaveData();     
        }

        private bool Validate()
        {
            var validator = new DespesaValidator();
            var result = validator.Validate(_despesa);

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
                    var dao = new DespesasDAO();
                    var text = "atualizada";

                    if (_despesa.IdDespesa == 0)
                    {
                        dao.Insert(_despesa);
                        text = "cadastrada";
                    }
                    else
                        dao.Update(_despesa);

                    MessageBox.Show($"A Despesa foi {text} com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
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
                var dao = new DespesasDAO();
                _despesa = dao.GetById(_id);

                txtIdDespesa.Text = _despesa.IdDespesa.ToString();
                txtValorDespesa.Text = _despesa.ValorDespesa.ToString();
                dtpkDataDespesa.SelectedDate = _despesa.dataDespesa;
                txtDescricaoDespesa.Text = _despesa.DescricaoDespesa;
                cmbxGrupoDespesa.Text = _despesa.GrupoDespesa;

                if(_despesa.Caixa != null)
                    cbxCaixaDespesa.SelectedValue = _despesa.Caixa.IdCaixa;

                if (_despesa.Funcionario != null)
                    cbxFuncionarioDespesa.SelectedValue = _despesa.Funcionario.IdFunc;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseFormVerify()
        {
            if (_despesa.IdDespesa == 0)
            {
                var result = MessageBox.Show("Deseja cadastrar outra Despesa?", "Cadastrar Novamente?", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    LimparTextBox();
                }
                else
                {
                    ConsultarDespesasWindow consulDesp = new ConsultarDespesasWindow();
                    consulDesp.Show();
                    this.Close();
                }
            }
            else
            {
                ConsultarDespesasWindow consulDesp = new ConsultarDespesasWindow();
                consulDesp.Show();
                this.Close();
            }
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

        private void LoadCbxFuncCaixa()
        {
            try
            {
                cbxCaixaDespesa.ItemsSource = new CaixaDAO().List();
                cbxFuncionarioDespesa.ItemsSource = new FuncionarioDAO().List();
            }
            catch (Exception ex)
            {

            }
        }

        private void LimparTextBox()
        {
            txtValorDespesa.Text = "";
            dtpkDataDespesa.Text = "";
            dtpkDataDespesa.Text = "";
            cmbxGrupoDespesa.Text = "";
            cbxCaixaDespesa.Text = "";
            cbxFuncionarioDespesa.Text = "";
            txtDescricaoDespesa.Text = "";
        }
    }
}
