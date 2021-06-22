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
    /// Lógica interna para CadastrarFornecedor.xaml
    /// </summary>
    public partial class CadastrarFornecedor : Window
    {
        public CadastrarFornecedor()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Deseja Cancelar o Cadastro desse Fornecedor?", "Cadastrar Fornecedor", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            string codigo = txtCodigo.Text;
            string tipo = cmbxTipo.Text;
            string data_cad = dtCadastro.Text;
            string rg_ie = txtRGIE.Text;
            string cpf_cnpj = txtCPFCNPJ.Text;
            string nome_fantasia = txtNomeFantasia.Text;
            string razao_social = txtRazaoSocial.Text;
            string telefone = txtTelefone.Text;
            string email = txtEmail.Text;
            string cep = txtCEP.Text;
            string logradouro = txtLogradouro.Text;
            string numero = txtNumero.Text;
            string pais = txtPais.Text;
            string uf = txtUF.Text;
            string cidade = txtCidade.Text;

            bool validacao = false;

            if (tipo.Equals(""))
            {
                MessageBox.Show("Preencha o campo TIPO");
                validacao = false;
            }
            else
            {
                validacao = true;
            }

            if (data_cad.Equals(""))
            {
                MessageBox.Show("Preencha o campo DATA DO CADASTRO");
                validacao = false;
            }
            else
            {
                validacao = true;
            }

            if (rg_ie.Equals(""))
            {
                MessageBox.Show("Preencha o campo RG/IE");
                validacao = false;
            }
            else
            {
                validacao = true;
            }

            if (cpf_cnpj.Equals(""))
            {
                MessageBox.Show("Preencha o campo CPF/CNPJ");
                validacao = false;
            }
            else
            {
                validacao = true;
            }


            if (nome_fantasia.Equals(""))
            {
                MessageBox.Show("Preencha o campo NOME FANTASIA");
                validacao = false;
            }
            else
            {
                validacao = true;
            }

            if (razao_social.Equals(""))
            {
                MessageBox.Show("Preencha o campo RAZÃO SOCIAL");
                validacao = false;
            }
            else
            {
                validacao = true;
            }

            if (telefone.Equals(""))
            {
                MessageBox.Show("Preencha o campo TELEFONE");
                validacao = false;
            }
            else
            {
                validacao = true;
            }

            if (email.Equals(""))
            {
                MessageBox.Show("Preencha o campo EMAIL");
                validacao = false;
            }
            else
            {
                validacao = true;
            }

            if (cep.Equals(""))
            {
                MessageBox.Show("Preencha o campo CEP");
                validacao = false;
            }
            else
            {
                validacao = true;
            }

            if (logradouro.Equals(""))
            {
                MessageBox.Show("Preencha o campo LOGRADOURO");
                validacao = false;
            }
            else
            {
                validacao = true;
            }

            if (numero.Equals(""))
            {
                MessageBox.Show("Preencha o campo NUMERO");
                validacao = false;
            }
            else
            {
                validacao = true;
            }

            if (pais.Equals(""))
            {
                MessageBox.Show("Preencha o campo PAÍS");
                validacao = false;
            }
            else
            {
                validacao = true;
            }

            if (uf.Equals(""))
            {
                MessageBox.Show("Preencha o campo UF");
                validacao = false;
            }
            else
            {
                validacao = true;
            }

            if (cidade.Equals(""))
            {
                MessageBox.Show("Preencha o campo CIDADE");
                validacao = false;
            }
            else
            {
                validacao = true;
            }

            if (validacao == true)
            {
                MessageBox.Show("Fornecedor cadastrado com sucesso!\n" +
                $"Código: {codigo}\n" +
                $"Tipo: {tipo}\n" +
                $"Data do Cadastro: {data_cad}\n" +
                $"RG/IE: {rg_ie}\n" +
                $"CPF/CNPJ: {cpf_cnpj}\n" +
                $"Nome Fantasia: {nome_fantasia}\n" +
                $"Razão Social: {razao_social}\n" +
                $"Telefone: {telefone}\n" +
                $"E-mail: {email}\n" +
                $"CEP: {cep}\n" +
                $"Logradouro: {logradouro}\n" +
                $"Número: {numero}\n" +
                $"País: {pais}\n" +
                $"UF: {uf}\n" +
                $"Cidade: {cidade}");
            }
        }
    }
}
