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
        bool validacao = false;
        Models.Fornecedor fornecedor = new Models.Fornecedor();
        private List<string> tipoFornecedor;

        public CadastrarFornecedor()
        {
            InitializeComponent();
            Loaded += CadastrarFornecedor_Loaded;
        }

        private void CadastrarFornecedor_Loaded(object sender, RoutedEventArgs e)
        {
            tipoFornecedor = new List<string>();

            tipoFornecedor.Add("Pessoa Física");
            tipoFornecedor.Add("Pessoa Jurídica");

            cmbxTipo.ItemsSource = tipoFornecedor;
        }


        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Deseja Cancelar o Cadastro desse Fornecedor?", "Cadastrar Fornecedor", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                MenuInicial menuInicial = new MenuInicial();
                menuInicial.Show();
                this.Close();
            }
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            InsertTeste();

            /*
            string recebeData;

            fornecedor.CodigoFornecedor = int.Parse(txtCodigo.Text);
            fornecedor.TipoFornecedor = cmbxTipo.Text;
            recebeData = dtCadastro.Text;
            fornecedor.DataCadastroFornecedor = DateTime.Parse(recebeData);
            fornecedor.RgIe = txtRGIE.Text;
            fornecedor.Cpf = txtCpf.Text;
            fornecedor.Cnpj = txtCnpj.Text;
            fornecedor.NomeFantasia = txtNomeFantasia.Text;
            fornecedor.RazaoSocial = txtRazaoSocial.Text;
            fornecedor.Telefone = txtTelefone.Text;
            fornecedor.Email = txtEmail.Text;
            fornecedor.Cep = txtCEP.Text;
            fornecedor.Logradouro = txtLogradouro.Text;
            fornecedor.Numero = txtNumero.Text;
            fornecedor.Pais = txtPais.Text;
            fornecedor.Uf = txtUF.Text;
            fornecedor.Cidade = txtCidade.Text;

            if (fornecedor.CodigoFornecedor.Equals("") || fornecedor.TipoFornecedor.Equals("")
                || fornecedor.DataCadastroFornecedor.Equals("")
                || fornecedor.RgIe.Equals("") || fornecedor.Cpf.Equals("") || fornecedor.Cnpj.Equals("")
                || fornecedor.NomeFantasia.Equals("")
                || fornecedor.RazaoSocial.Equals("") || fornecedor.Telefone.Equals("")
                || fornecedor.Email.Equals("") || fornecedor.Cep.Equals("")
                || fornecedor.Logradouro.Equals("") || fornecedor.Numero.Equals("")
                || fornecedor.Pais.Equals("") || fornecedor.Uf.Equals("")
                || fornecedor.Cidade.Equals(""))
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
                MessageBox.Show("Fornecedor cadastrado com sucesso!\n" +
                $"Código: {fornecedor.CodigoFornecedor}\n" +
                $"Tipo: {fornecedor.TipoFornecedor}\n" +
                $"Data do Cadastro: {fornecedor.DataCadastroFornecedor}\n" +
                $"RG/IE: {fornecedor.RgIe}\n" +
                $"CPF: {fornecedor.Cpf}\n" +
                $"CNPJ: {fornecedor.Cnpj}\n" +
                $"Nome Fantasia: {fornecedor.NomeFantasia}\n" +
                $"Razão Social: {fornecedor.RazaoSocial}\n" +
                $"Telefone: {fornecedor.Telefone}\n" +
                $"E-mail: {fornecedor.Email}\n" +
                $"CEP: {fornecedor.Cep}\n" +
                $"Logradouro: {fornecedor.Logradouro}\n" +
                $"Número: {fornecedor.Numero}\n" +
                $"País: {fornecedor.Pais}\n" +
                $"UF: {fornecedor.Uf}\n" +
                $"Cidade: {fornecedor.Cidade}");
                LimparTextBox();
            }  
            */
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
            txtPais.Text = "";
            txtUF.Text = "";
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
            }
            else
                txtEmail_error.Visibility = Visibility.Collapsed;
        }

        private void InsertTeste()
        {
            try
            {
                Fornecedor fornecedor = new Fornecedor();

                fornecedor.Email = txtEmail.Text;
                fornecedor.TipoFornecedor = cmbxTipo.Text;
                fornecedor.DataCadastroFornecedor = (DateTime)dtCadastro.SelectedDate;
                fornecedor.RgIe = txtRGIE.Text;
                fornecedor.Cpf = txtCpf.Text;
                fornecedor.Cnpj = txtCnpj.Text;
                fornecedor.NomeFantasia = txtNomeFantasia.Text;
                fornecedor.RazaoSocial = txtRazaoSocial.Text;
                fornecedor.Telefone = txtTelefone.Text;
                fornecedor.FkEndereco = 1;

                FornecedorDAO fornecedorDAO = new FornecedorDAO();
                fornecedorDAO.Insert(fornecedor);

                MessageBox.Show("Fornecedor cadastrado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                var result = MessageBox.Show("Deseja cadastrar outro Fornecedor?", "Cadastrar Novamente?", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    LimparTextBox();
                }
                else
                {
                    MenuInicial menuInicial = new MenuInicial();
                    menuInicial.Show();
                    this.Close();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao executar", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
