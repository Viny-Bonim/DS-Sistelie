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
    /// Lógica interna para CadastrarCliente.xaml
    /// </summary>
    public partial class CadastrarCliente : Window
    {
        public CadastrarCliente()
        {
            InitializeComponent();

            CbSexo.Items.Add("Masculino");
            CbSexo.Items.Add("Feminino");
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Deseja Cancelar o Cadastro desse Cliente", "Cadastrar Cliente", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
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
                MessageBox.Show("O campo 'Sexo' é obrigatorio, selecione-o");
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
    }
}
