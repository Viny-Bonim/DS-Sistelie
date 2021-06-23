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
    /// Lógica interna para CadastrarProprietario.xaml
    /// </summary>
    public partial class CadastrarProprietario : Window
    {
        public CadastrarProprietario()
        {
            InitializeComponent();
        }

        private void BtCancelar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Deseja Cancelar o Cadastro desse Fornecedor?", "Cadastrar Fornecedor", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
            string nome = txtNome.Text;
            string cpf = txtCpf.Text; 
            string rg = txtRg.Text;
            string email = txtEmail.Text;
            string senha = txtSenha.Text;
            string confsenha = txtConfsenha.Text;

            bool validacao = false;

            if(nome.Equals(""))
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

            if (email.Equals(""))
            {
                MessageBox.Show("O campo 'Email' é obrigatorio, preencha-o");
                validacao = false;
            }
            else
            {
                validacao = true;
            }

            if (senha.Equals(""))
            {
                MessageBox.Show("O campo 'Senha' é obrigatorio, preencha-o");
                validacao = false;
            }
            else
            {
                validacao = true;
            }

            if (confsenha.Equals(""))
            {
                MessageBox.Show("O campo 'Confirmar senha' é obrigatorio, preencha-o");
                validacao = false;

            }
            else
            {
                validacao = true;
            }

            if (senha.Length < 6)
            {
                MessageBox.Show("A senha precisa ter pelo menos de 6 caracteres");
                validacao = false;
            }
            else
            {
                validacao = true;
            }

            if (senha != confsenha)
            {
                MessageBox.Show("As senhas não coincidem");
                validacao = false;
            }
            else
            {
                validacao = true;
            }

            if (validacao == true)
            {
                MessageBox.Show("Proprietario cadastrado com sucesso, veja as informações abaixo:\n" +
                    $"Nome: {nome}\n" +
                    $"CPF: {cpf}\n" +
                    $"RG: {rg}\n" +
                    $"Email: {email}\n" +
                    $"Senha: {senha}"
                    );
    
            }
            else
            {
                MessageBox.Show("Revise as informações!");
            }
        }
    }
}
