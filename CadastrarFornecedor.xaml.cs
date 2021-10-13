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


            _fornecedor = new Fornecedor();
            try
            {
                var dao = new FornecedorDAO();
                _fornecedor = dao.GetById(_id);

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
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
            _fornecedor.Email = txtEmail.Text;
            _fornecedor.TipoFornecedor = cmbxTipo.Text;
            _fornecedor.DataCadastroFornecedor = (DateTime)dtCadastro.SelectedDate;
            _fornecedor.RgIe = txtRGIE.Text;
            _fornecedor.Cpf = txtCpf.Text;
            _fornecedor.Cnpj = txtCnpj.Text;
            _fornecedor.NomeFantasia = txtNomeFantasia.Text;
            _fornecedor.RazaoSocial = txtRazaoSocial.Text;
            _fornecedor.Telefone = txtTelefone.Text;
            _fornecedor.FkEndereco = 1;

            SaveData();
        }

        private void SaveData()
        {
            try
            {
                var dao = new FornecedorDAO();
                var text = "atualizado";
                
                if (_fornecedor.CodigoFornecedor == 0)
                {
                    dao.Insert(_fornecedor);
                    text = "cadastrado";
                }
                else
                {
                    dao.Update(_fornecedor);
                }
                MessageBox.Show($"Fornecedor {text} com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                CloseFormVerify();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao executar", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseFormVerify()
        {
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
                validacao = true;
            }
            else
                txtEmail_error.Visibility = Visibility.Collapsed;
        }

    }
}
