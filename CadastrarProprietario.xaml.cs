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
        bool validacao = false;

        public CadastrarProprietario()
        {
            InitializeComponent();
        }

        private void BtCancelar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Deseja Cancelar o Cadastro desse Proprietario?", "Cadastrar Proprietario", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MenuInicial menuInicial = new MenuInicial();
                menuInicial.Show();
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
            bool validacaosenha = false;
            bool validacaoconfsenha = false;


            if (nome.Equals("") || cpf.Equals("") || rg.Equals("") || email.Equals("") || senha.Equals("") || confsenha.Equals(""))
            {
                MessageBox.Show($"Os campos marcados com \"*\" são obrigatorios, preencha-os");
                validacao = false;

            }
            else
            {
                validacao = true;
            }

            if (senha.Length < 8)
            {
                MessageBox.Show("A senha precisa ter pelo menos 8 caracteres");
                validacaosenha = false;

            }
            else
            {
                validacaosenha = true;
            }

            if(senha != confsenha)
            {
                MessageBox.Show("As senhas não coincidem");
                validacaoconfsenha = false;
            }
            else
            {
                validacaoconfsenha = true;
            }

            if (validacao == true && validacaosenha == true && validacaoconfsenha == true )
            {
                MessageBox.Show("Proprietario cadastrado com sucesso, veja as informações abaixo:\n" +
                    $"Nome: {nome}\n" +
                    $"CPF: {cpf}\n" +
                    $"RG: {rg}\n" +
                    $"Email: {email}\n" +
                    $"Senha: {senha}"
                    );
                LimparTextBox();

            }
            else
            {
                MessageBox.Show("Revise as informações!");
            }
        }

        private void LimparTextBox()
        {
            txtNome.Text = "";
            txtCpf.Text = "";
            txtRg.Text = "";
            txtEmail.Text = "";
            txtSenha.Text = "";
            txtConfsenha.Text = "";
        }

        private void txtSenha_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
