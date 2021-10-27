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
using DS_Sistelie.Helpers;

namespace DS_Sistelie
{
    /// <summary>
    /// Lógica interna para CadastroFuncionario.xaml
    /// </summary>
    public partial class CadastroFuncionario : Window
    {
        private int _id;
        private Funcionario _funcionario;
        private List<string> sexoFunc;

        public CadastroFuncionario()
        {
            InitializeComponent();
            Loaded += CadastroFuncionario_Loaded;
        }

        public CadastroFuncionario(int id)
        {
            _id = id;
            InitializeComponent();
            Loaded += CadastroFuncionario_Loaded;
        }

        private void CadastroFuncionario_Loaded(object sender, RoutedEventArgs e)
        {
            _funcionario = new Funcionario();

            sexoFunc = new List<string>();
            sexoFunc.Add("Masculino");
            sexoFunc.Add("Feminino");
            sexoFunc.Add("Não Binario");
            CbSexo.ItemsSource = sexoFunc;

            if (_id > 0)
            {
                FillForm();
            }
        }

        private void Salvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //inserindo dados da tabela Funcionário
                _funcionario.Nome = txtNome.Text;
                _funcionario.CPF = txtCpf.Text;
                _funcionario.Email = txtEmail.Text;
                _funcionario.RG = txtRg.Text;
                _funcionario.Sexo = CbSexo.Text;
                if (PickNascimento.SelectedDate != null)
                    _funcionario.data_nas = (DateTime)PickNascimento.SelectedDate;


                //Inserindo dados da tabela endereço
                _funcionario.Endereco = new Endereco();
                _funcionario.Endereco.Bairro = txtBairro.Text;
                _funcionario.Endereco.Logradouro = txtRua.Text;
                _funcionario.Endereco.Cidade = txtCidade.Text;
                _funcionario.Endereco.Cep = txtCEP.Text;

                if (int.TryParse(txtNumero.Text, out int numero))
                    _funcionario.Endereco.Numero = numero;

                SaveData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Deseja Cancelar o Cadastro desse Funcionario?", "Cadastrar Funcionário", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MenuInicial menuInicial = new MenuInicial();
                menuInicial.Show();
                this.Close();
            }
        }

        private void txtEmail_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            string email = txtEmail.Text.Trim();

            if (!Validacao.IsEmail(email))
            {
                e.Handled = true;
                txtEmail_error.Visibility = Visibility.Visible;
                txtEmail.Focus();
            }
            else
                txtEmail_error.Visibility = Visibility.Collapsed;
        }

        private void CloseFormVerify()
        {
            if (_funcionario.IdFunc == 0)
            {
                var result = MessageBox.Show("Deseja cadastrar outro Funcionário?", "Cadastrar Novamente?", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    LimparTextBox();
                }
                else
                {
                    ConsultarFuncionario consulfunc = new ConsultarFuncionario();
                    consulfunc.Show();
                    this.Close();
                }
            }
            else
            {
                ConsultarFuncionario consulfunc = new ConsultarFuncionario();
                consulfunc.Show();
                this.Close();
            }
        }

        private void LimparTextBox()
        {
            txtCodigo.Text = "";
            CbSexo.Text = "";
            txtCpf.Text = "";
            txtRg.Text = "";
            PickNascimento.Text = "";
            txtBairro.Text = "";
            txtRua.Text = "";
            txtCidade.Text = "";
            txtNumero.Text = "";
            txtEmail.Text = "";
        }

        private void FillForm()
        {
            try
            {
                var dao = new FuncionarioDAO();
                _funcionario = dao.GetById(_id);

                // Pegando informações da tabela Funcionario
                txtCodigo.Text = _funcionario.IdFunc.ToString();
                txtNome.Text = _funcionario.Nome;
                txtCpf.Text = _funcionario.CPF;
                txtRg.Text = _funcionario.RG;
                txtEmail.Text = _funcionario.Email;
                PickNascimento.SelectedDate = _funcionario.data_nas;
                CbSexo.Text = _funcionario.Sexo;


                // Pegando informações da tabela Endereco
                if (_funcionario.Endereco != null)
                {
                    txtBairro.Text = _funcionario.Endereco.Bairro;
                    txtRua.Text = _funcionario.Endereco.Logradouro;
                    txtCidade.Text = _funcionario.Endereco.Cidade;
                    txtNumero.Text = _funcionario.Endereco.Numero.ToString();
                    txtCEP.Text = _funcionario.Endereco.Cep;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool Validate()
        {
            var validator = new FuncionarioValidator();
            var result = validator.Validate(_funcionario);

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
                    var dao = new FuncionarioDAO();
                    var text = "atualizado";

                    if (_funcionario.IdFunc == 0)
                    {
                        dao.Insert(_funcionario);
                        text = "cadastrado";
                    }
                    else
                        dao.Update(_funcionario);

                    MessageBox.Show($"O Funcionário foi {text} com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    CloseFormVerify();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

        private void txtRg_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            string numero = txtRg.Text.Trim();

            if (SemLetras(numero) == false)
            {
                e.Handled = true;
                MessageBox.Show("NÚMERO de RG inválido. Por favor verifique!", "Informação Inválida", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtRg.Focus();
            }
        }

        private void txtNumero_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            string numero = txtNumero.Text.Trim();

            if (SemLetras(numero) == false)
            {
                e.Handled = true;
                MessageBox.Show("NÚMERO de endereço inválido. Por favor verifique!", "Informação Inválida", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtNumero.Focus();
            }
        }
    }
}
