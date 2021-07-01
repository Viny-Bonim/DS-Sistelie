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
    /// Lógica interna para CadastroFuncionario.xaml
    /// </summary>
    public partial class CadastroFuncionario : Window
    {
        public CadastroFuncionario()
        {
            InitializeComponent();
            CbSexo.Items.Add("Masculino");
            CbSexo.Items.Add("Feminino");
            CbSexo.Items.Add("Não Binario");
        }
       
        private void Salvar_Click(object sender, RoutedEventArgs e)
        {
            string nome = txtNome.Text;
            string cpf = txtCpf.Text;
            string rg = txtRg.Text;
            string nascimento = PickNascimento.Text;
            string sexo = CbSexo.Text;
            string renda = txtRenda.Text;
            string bairro = txtBairro.Text;
            string rua = txtRua.Text;
            string numero = txtNumero.Text;
            string cidade = txtCidade.Text;
            string email = txtEmail.Text;

            bool validacao = false;

            if (nome.Equals(""))
            {
                MessageBox.Show("O campo 'Nome' é obrigatorio, preencha-o");
                validacao = false;
            }
            else
            {
                validacao = true;
            }

            if (cpf.Equals(""))
            {
                MessageBox.Show("O campo 'CPF' é obrigatorio, preencha-o");
                validacao = false;
            }
            else
            {
                validacao = true;
            }

            if (rg.Equals(""))
            {
                MessageBox.Show("O campo 'RG' é obrigatorio, preencha-o");
                validacao = false;
            }
            else
            {
                validacao = true;
            }

            if (nascimento.Equals(""))
            {
                MessageBox.Show("O campo 'Nascimento' é obrigatorio, selecione-o");
                validacao = false;
            }
            else
            {
                validacao = true;
            }

            if (sexo.Equals(""))
            {
                MessageBox.Show("O campo 'Sexo' é obrigatorio, preencha-o");
                validacao = false;
            }
            else
            {
                validacao = true;
            }

            if (renda.Equals(""))
            {
                MessageBox.Show("O campo 'Renda familiar' é obrigatorio, preencha-o");
                validacao = false;

            }
            else
            {
                validacao = true;
            }

            if (bairro.Equals(""))
            {
                MessageBox.Show("O campo 'Bairro' é obrigatorio, preencha-o");
                validacao = false;
            }
            else
            {
                validacao = true;
            }

            if (rua.Equals(""))
            {
                MessageBox.Show("O campo 'Rua' é obrigatorio, preencha-o");
                validacao = false;
            }
            else
            {
                validacao = true;
            }

            if (numero.Equals(""))
            {
                MessageBox.Show("O campo 'Numero' é obrigatorio, preencha-o");
                validacao = false;
            }
            else
            {
                validacao = true;
            }

            if (cidade.Equals(""))
            {
                MessageBox.Show("O campo 'Cidade' é obrigatorio, preencha-o");
                validacao = false;
            }
            else
            {
                validacao = true;

            }

            if (email.Equals(""))
            {
                MessageBox.Show("O campo 'Email' é obrigatorio, preencha-o");
                validacao = false;
            }
            else
            {
                validacao = true;
            }

            if (validacao.Equals(true))
            {
                MessageBox.Show("Cliente cadastrado com sucesso, veja as informações abaixo:\n" +
                    $"Nome: {nome}\n" +
                    $"CPF: {cpf}\n" +
                    $"RG: {rg}\n" +
                    $"Nascimento: {nascimento}\n" +
                    $"Sexo: {sexo}\n" +
                    $"Renda: {renda}\n" +
                    $"Bairro: {bairro}\n" +
                    $"Rua: {rua}\n" +
                    $"Numero: {numero}\n" +
                    $"Cidade: {cidade}\n" +
                    $"Email: {email}\n"
                    );
            }
            else
            {
                MessageBox.Show("Revise as informações!");
            }
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Deseja Cancelar o Cadastro desse Funcionario?", "Cadastrar Cliente", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MenuInicial menuInicial = new MenuInicial();
                menuInicial.Show();
                this.Close();
            }
        }

        private void CbSexo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void rbSEXO_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (sender as RadioButton);
            MessageBox.Show("Sexo Selecionado: " + rb.Content.ToString());
        }

        private void txtEmail_TextChanged_1(object sender, TextChangedEventArgs e)
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

        private void txtBairro_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
