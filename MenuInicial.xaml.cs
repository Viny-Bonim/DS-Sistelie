﻿using System;
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
using DS_Sistelie.Views;

namespace DS_Sistelie
{
    /// <summary>
    /// Lógica interna para MenuInicial.xaml
    /// </summary>
    public partial class MenuInicial : Window
    {
        public MenuInicial()
        {
            InitializeComponent();
        }             

        private void CadastrarProprietario_Click(object sender, RoutedEventArgs e)
        {
            CadastrarProprietario cad_proprietario = new CadastrarProprietario();
            cad_proprietario.Show();
            this.Close();
        }

        private void CadastrarMateriaPrima_Click(object sender, RoutedEventArgs e)
        {
            CadastrarMateriaPrima cad_CastrarMateria = new CadastrarMateriaPrima();
            cad_CastrarMateria.Show();
            this.Close();
        }

        private void SaidaDeMateriaPrima_Click(object sender, RoutedEventArgs e)
        {
            SaidaMateriaPrima Reg_saidaMateriaPrima = new SaidaMateriaPrima();
            Reg_saidaMateriaPrima.Show();
            this.Close();
        }

        private void RegistarVendas_Click(object sender, RoutedEventArgs e)
        {
            RegistrarVendas Reg_Vendas = new RegistrarVendas();
            Reg_Vendas.Show();
            this.Close();
        }

        private void ExibirVendas_Click(object sender, RoutedEventArgs e)
        {
            ExibirVendas Exib_Vendas = new ExibirVendas();
            Exib_Vendas.Show();
            this.Close();
        }

        private void CadastrarDespesas_Click(object sender, RoutedEventArgs e)
        {
            Despesas.CadastrarDespesaWindow cadastrarDespesa = new Despesas.CadastrarDespesaWindow();
            cadastrarDespesa.Show();
            this.Close();
        }

        private void CadastrarFuncionario_Click(object sender, RoutedEventArgs e)
        {
            CadastroFuncionario CadFuncionario = new CadastroFuncionario();
            CadFuncionario.Show();
            this.Close();
        }

        private void ConsultarDespesas_Click(object sender, RoutedEventArgs e)
        {
            Despesas.ConsultarDespesasWindow ConsulDesp = new Despesas.ConsultarDespesasWindow();
            ConsulDesp.Show();
            this.Close();
        }


        private void ConsultarCliente_Click(object sender, RoutedEventArgs e)
        {
            Consultar_Cliente consultarCliente = new Consultar_Cliente();
            consultarCliente.Show();
        }

        private void CadastrarFornecedor_Click(object sender, RoutedEventArgs e)
        {
            CadastrarFornecedor cadastrarFornecedor = new CadastrarFornecedor();
            cadastrarFornecedor.Show();
            this.Close();
        }

        private void ConsultarFornecedor_Click(object sender, RoutedEventArgs e)
        {
            ConsultarFornecedores.ConsultarFornecedoresWindow consultarFornecedores = new ConsultarFornecedores.ConsultarFornecedoresWindow();
            consultarFornecedores.Show();
            this.Close();
        }

        private void CadastrarCliente_Click(object sender, RoutedEventArgs e)
        {
            CadastrarCliente cadastrarCliente = new CadastrarCliente();
            cadastrarCliente.Show();
            this.Close();
        }

        private void ConsultarFuncionario_Click(object sender, RoutedEventArgs e)
        {
            ConsultarFuncionario cad_proprietario = new ConsultarFuncionario();
            cad_proprietario.Show();
            this.Close();
        }

        private void ExibirTarefas_Click(object sender, RoutedEventArgs e)
        {
            Exibir_Tarefas exibirtar = new Exibir_Tarefas();
            exibirtar.Show();
            this.Close();
        }

        private void RegistrarCaixa_Click(object sender, RoutedEventArgs e)
        {
            InserirCaixaWindow inserirCaixa = new InserirCaixaWindow();
            inserirCaixa.Show();
            this.Close();
        }
    }
}
