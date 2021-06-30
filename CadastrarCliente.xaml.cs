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
            CbSexo.Items.Add("Não Binario");
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Deseja Cancelar o Cadastro desse Cliente?", "Cadastrar Cliente", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MenuInicial menuInicial = new MenuInicial();
                menuInicial.Show();
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
            string telefone = txtTelefone.Text;
            string email = txtEmail.Text;
            string bairro = txtBairro.Text;
            string rua = txtRua.Text;
            string numero = txtNumero.Text;
            string estado = txtEstado.Text;
            string cidade = txtCidade.Text;


            bool validacao = false;

            if (nome.Equals("") || cpf.Equals("") || rg.Equals("") || nascimento.Equals("") || sexo.Equals("") || telefone.Equals("") || bairro.Equals("") || rua.Equals("") || numero.Equals("") || estado.Equals("") || cidade.Equals("") )
            {
                MessageBox.Show($"Os campos marcados com \"*\" são obrigatorios, preencha-os");
                validacao = false;
            }
            else
            {
                validacao = true;
            }

            if (validacao.Equals(true) && email.Equals(""))
            {
                MessageBox.Show("Cliente cadastrado com sucesso, veja as informações abaixo:\n" +
                    $"Nome: {nome}\n" +
                    $"CPF: {cpf}\n" +
                    $"RG: {rg}\n" +
                    $"Nascimento: {nascimento}\n" +
                    $"Sexo: {sexo}\n" +
                    $"Telefone: {telefone}\n" +
                    $"Bairro: {bairro}\n" +
                    $"Rua: {rua}\n" +
                    $"Numero: {numero}\n" +
                    $"Estado: {estado}\n" +
                    $"Cidade: {cidade}\n"
                    );
                LimparTextBox();
            }
            else if(validacao.Equals(true))
            {
                MessageBox.Show("Cliente cadastrado com sucesso, veja as informações abaixo:\n" +
                    $"Nome: {nome}\n" +
                    $"CPF: {cpf}\n" +
                    $"RG: {rg}\n" +
                    $"Nascimento: {nascimento}\n" +
                    $"Sexo: {sexo}\n" +
                    $"Telefone: {telefone}\n" +
                    $"Email: {email}\n" +
                    $"Bairro: {bairro}\n" +
                    $"Rua: {rua}\n" +
                    $"Numero: {numero}\n" +
                    $"Estado: {estado}\n" +
                    $"Cidade: {cidade}\n"
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
            PickNascimento.Text = "";
            CbSexo.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
            txtBairro.Text = "";
            txtRua.Text = "";
            txtNumero.Text = "";
            txtCidade.Text = "";
            txtEstado.Text = "";

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

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CbSexo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
