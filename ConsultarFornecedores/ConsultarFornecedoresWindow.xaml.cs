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

namespace DS_Sistelie.ConsultarFornecedores
{
    /// <summary>
    /// Lógica interna para ConsultarFornecedoresWindow.xaml
    /// </summary>
    public partial class ConsultarFornecedoresWindow : Window
    {
        private List<Fornecedor> _fornecedorList = new List<Fornecedor>();

        public ConsultarFornecedoresWindow()
        {
            InitializeComponent();
            Loaded += ConsultarFornecedoresWindow_Loaded;
        }

        private void ConsultarFornecedoresWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadListForne();
        } 

          

        private void btnInicioFornecedor_Click(object sender, RoutedEventArgs e)
        {
            MenuInicial menuInicial = new MenuInicial();
            menuInicial.Show();
            this.Close();
        }

        private void LoadListForne()
        {
            try
            {
                _fornecedorList = new FornecedorDAO().List();
                DataGridConsultarFornecedor.ItemsSource = _fornecedorList;

                //var dao = new FornecedorDAO();
                //DataGridConsultarFornecedor.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            var fornecedorSelecionado = DataGridConsultarFornecedor.SelectedItem as Fornecedor;

            var windowforne = new CadastrarFornecedor(fornecedorSelecionado.CodigoFornecedor);
            windowforne.ShowDialog();
            LoadListForne();
            this.Close();
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            var fornecedorSelecionado = DataGridConsultarFornecedor.SelectedItem as Fornecedor;

            var result = MessageBox.Show($"Deseja realmente excluir o fornecedor: {fornecedorSelecionado.NomeFantasia}", "Excluir Fornecedor?", MessageBoxButton.YesNo, MessageBoxImage.Question);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new FornecedorDAO();
                    dao.Delete(fornecedorSelecionado);
                    LoadListForne();
                    MessageBox.Show("Fornecedor Excluído com sucesso"); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnPesquisarFornecedor_Click(object sender, RoutedEventArgs e)
        {
            var text = txtConsultarFornecedor.Text;

            var filteredList = _fornecedorList.Where(i => i.NomeFantasia.ToLower().Contains(text));
            DataGridConsultarFornecedor.ItemsSource = filteredList;
        }
    }
}
