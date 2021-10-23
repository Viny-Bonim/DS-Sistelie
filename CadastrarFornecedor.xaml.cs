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

namespace DS_Sistelie
{
    /// <summary>
    /// Lógica interna para CadastrarFornecedor.xaml
    /// </summary>
    public partial class CadastrarFornecedor : Window
    {
        private int _id;
        private Fornecedor _fornecedor;
        private Endereco _endereco;

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
            tipoFornecedor = new List<string>();
            tipoFornecedor.Add("Pessoa Física");
            tipoFornecedor.Add("Pessoa Jurídica");
            cmbxTipo.ItemsSource = tipoFornecedor;


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
                //Inserindo dados da tabela endereço
                if (txtCEP.Text != null)
                    _endereco.Cep = txtCEP.Text;

                if (txtBairro.Text != null)
                    _endereco.Bairro = txtBairro.Text;

                if (txtLogradouro.Text != null)
                    _endereco.Logradouro = txtLogradouro.Text;

                if (txtNumero.Text != null)
                    _endereco.Numero = txtNumero.Text;

                if (cbxUF.Text != null)
                    _endereco.Uf = cbxUF.Text;

                if (txtCidade.Text != null)
                    _endereco.Cidade = txtCidade.Text;

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
                txtCEP.Text = _endereco.Cep;
                txtBairro.Text = _endereco.Bairro;
                txtLogradouro.Text = _endereco.Logradouro;
                txtNumero.Text = _endereco.Numero;
                cbxUF.Text = _endereco.Uf;
                txtCidade.Text = _endereco.Cidade;
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
    }
}
