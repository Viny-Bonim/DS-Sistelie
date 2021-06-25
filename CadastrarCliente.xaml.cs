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
            string renda = txtRenda.Text;
            string bairro = txtBairro.Text;
            string rua = txtRua.Text;
            string numero = txtNumero.Text;
            string cidade = txtCidade.Text;
            string email = txtEmail.Text;

            bool validacao = false;

            if (nome.Equals("") || cpf.Equals("") || rg.Equals("") || nascimento.Equals("") || sexo.Equals("") || renda.Equals("") || bairro.Equals("") || rua.Equals("") || numero.Equals("") || cidade.Equals("") || email.Equals(""))
            {
                MessageBox.Show($"Os campos marcados com \"*\" são obrigatorios, preencha-os");
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
            txtRenda.Text = "";
            txtBairro.Text = "";
            txtRua.Text = "";
            txtNumero.Text = "";
            txtCidade.Text = "";
            txtEmail.Text = "";
        }
    }
}
