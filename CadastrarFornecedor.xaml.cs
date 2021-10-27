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
    /// Lógica interna para CadastrarFornecedor.xaml
    /// </summary>
    public partial class CadastrarFornecedor : Window
    {
        private int _id;
        private Fornecedor _fornecedor;
        bool validacao = false;
        
        private List<string> tipoFornecedor;

        public CadastrarFornecedor()
        {
            InitializeComponent();
            Loaded += CadastrarFornecedor_Loaded;
        }

        public CadastrarFornecedor(int id)
        {
            _id = id;
            InitializeComponent();
            Loaded += CadastrarFornecedor_Loaded;
        }

        private void CadastrarFornecedor_Loaded(object sender, RoutedEventArgs e)
        {
            _fornecedor = new Fornecedor();
            
            tipoFornecedor = new List<string>();
            tipoFornecedor.Add("Pessoa Física");
            tipoFornecedor.Add("Pessoa Jurídica");
            cmbxTipo.ItemsSource = tipoFornecedor;

            LoadComboBoxEstados();

            if (_id > 0)
            {
                FillForm();
            }
        }


        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Deseja Cancelar e Voltar ao Menu Inicial?", "Cadastrar Fornecedor", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                MenuInicial menuInicial = new MenuInicial();
                menuInicial.Show();
                this.Close();
            }
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //inserindo dados da tabela Fornecedor
                _fornecedor.Email = txtEmail.Text;
                _fornecedor.TipoFornecedor = cmbxTipo.Text;
                _fornecedor.RgIe = txtRGIE.Text;
                _fornecedor.Cpf = txtCpf.Text;
                _fornecedor.Cnpj = txtCnpj.Text;
                _fornecedor.NomeFantasia = txtNomeFantasia.Text;
                _fornecedor.RazaoSocial = txtRazaoSocial.Text;
                _fornecedor.Telefone = txtTelefone.Text;
                if (dtCadastro.SelectedDate != null)
                    _fornecedor.DataCadastroFornecedor = (DateTime)dtCadastro.SelectedDate;


                //Inserindo dados da tabela endereço
                _fornecedor.Endereco = new Endereco();

                _fornecedor.Endereco.Cep = txtCEP.Text;
                _fornecedor.Endereco.Bairro = txtBairro.Text;
                _fornecedor.Endereco.Logradouro = txtLogradouro.Text;

                if (int.TryParse(txtNumero.Text, out int numero))
                    _fornecedor.Endereco.Numero = numero;

                if (cbxUF.SelectedItem != null)
                    _fornecedor.Endereco.Uf = cbxUF.SelectedItem as string;

                _fornecedor.Endereco.Cidade = txtCidade.Text;

                SaveData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool Validate()
        {
            var validator = new FornecedorValidator();
            var result = validator.Validate(_fornecedor);

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
                    var dao = new FornecedorDAO();
                    var text = "atualizado";

                    if (_fornecedor.CodigoFornecedor == 0)
                    {
                        dao.Insert(_fornecedor);
                        text = "cadastrado";
                    }
                    else
                        dao.Update(_fornecedor);

                    MessageBox.Show($"O Fornecedor foi {text} com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
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
                var dao = new FornecedorDAO();
                _fornecedor = dao.GetById(_id);

                // Pegando informações da tabela Fornecedor
                txtCodigo.Text = _fornecedor.CodigoFornecedor.ToString();
                cmbxTipo.Text = _fornecedor.TipoFornecedor;
                dtCadastro.SelectedDate = _fornecedor.DataCadastroFornecedor;
                txtRGIE.Text = _fornecedor.RgIe;
                txtCpf.Text = _fornecedor.Cpf;
                txtCnpj.Text = _fornecedor.Cnpj;
                txtNomeFantasia.Text = _fornecedor.NomeFantasia;
                txtRazaoSocial.Text = _fornecedor.RazaoSocial;
                txtTelefone.Text = _fornecedor.Telefone;
                txtEmail.Text = _fornecedor.Email;


                // Pegando informações da tabela Endereco
                if (_fornecedor.Endereco != null)
                {
                    txtCEP.Text = _fornecedor.Endereco.Cep;
                    txtBairro.Text = _fornecedor.Endereco.Bairro;
                    txtLogradouro.Text = _fornecedor.Endereco.Logradouro;
                    txtNumero.Text = _fornecedor.Endereco.Numero.ToString();
                    cbxUF.Text = _fornecedor.Endereco.Uf;
                    txtCidade.Text = _fornecedor.Endereco.Cidade;

                    cbxUF.SelectedValue = _fornecedor.Endereco.Uf;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseFormVerify()
        {
            if (_fornecedor.CodigoFornecedor == 0)
            {
                var result = MessageBox.Show("Deseja cadastrar outro Fornecedor?", "Cadastrar Novamente?", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    LimparTextBox();
                }
                else
                {
                    ConsultarFornecedores.ConsultarFornecedoresWindow consulForn = new ConsultarFornecedores.ConsultarFornecedoresWindow();
                    consulForn.Show();
                    this.Close();
                }
            }
            else
            {
                ConsultarFornecedores.ConsultarFornecedoresWindow consulForn = new ConsultarFornecedores.ConsultarFornecedoresWindow();
                consulForn.Show();
                this.Close();
            }
        }

        private void LoadComboBoxEstados()
        {
            try
            {
                cbxUF.ItemsSource = Estado.List();
            }
            catch (Exception ex)
            {
                
            }
        }

        private void LimparTextBox()
        {
            txtCodigo.Text = "";
            cmbxTipo.Text = "";
            dtCadastro.Text = "";
            txtRGIE.Text = "";
            txtCpf.Text = "";
            txtCnpj.Text = "";
            txtNomeFantasia.Text = "";
            txtRazaoSocial.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
            txtCEP.Text = "";
            txtLogradouro.Text = "";
            txtNumero.Text = "";
            cbxUF.Text = "";
            txtCidade.Text = "";
        }

        private void txtEmail_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            string email = txtEmail.Text.Trim();

            if (!Validacao.IsEmail(email))
            {
                e.Handled = true;
                txtEmail_error.Visibility = Visibility.Visible;
                txtEmail.Focus();
                validacao = true;
            }
            else
                txtEmail_error.Visibility = Visibility.Collapsed;
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

        private void txtRGIE_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            string rgie = txtRGIE.Text.Trim();

            if (SemLetras(rgie) == false)
            {
                e.Handled = true;
                MessageBox.Show("A informação fornecida no campo: 'RG/IE' é inválida. Por favor verifique!", "Informação Inválida", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtRGIE.Focus();
            }
        }
    }
}
