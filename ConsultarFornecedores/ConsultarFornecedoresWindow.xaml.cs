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
        List<Models.Fornecedor> ListaFornecedor = new List<Models.Fornecedor>();

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
                var dao = new FornecedorDAO();
                DataGridConsultarFornecedor.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            var fornecedorSelecionado = DataGridConsultarFornecedor.SelectedItem as Fornecedor;

            try
            {
                var dao = new FornecedorDAO();
                var forne = dao.GetById(fornecedorSelecionado.CodigoFornecedor);
                MessageBox.Show(forne.RazaoSocial + forne.Telefone);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}
