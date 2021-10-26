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
using LiveCharts;
using LiveCharts.Wpf;
using DS_Sistelie.Models;

namespace DS_Sistelie.Despesas
{
    /// <summary>
    /// Lógica interna para ConsultarDespesasWindow.xaml
    /// </summary>
    public partial class ConsultarDespesasWindow : Window
    {
        private List<Despesas> _despesaList = new List<Despesas>();

        List<EntradaSaidaDespesa> ListaEntradaSaidaDespesas = new List<EntradaSaidaDespesa>();

        public ConsultarDespesasWindow()
        {
            InitializeComponent();
            Loaded += ConsultarDespesasWindow_Loaded;

            PointLabel = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            DataContext = this;
        }

        public Func<ChartPoint, string> PointLabel { get; set; }

        private void ConsultarDespesasWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //Inserindo os dados na tabela através do banco de dados
            LoadListDesp();
            LoadListEntradaSaida();

            /*
            //DataGrid de entrada e saída de despesa
            for (int i = 0; i < 3; i++)
            {
                ListaEntradaSaidaDespesas.Add(new EntradaSaidaDespesa()
                {
                    Ano = i + 2019,
                    Mes = "Outubro",
                    Entrada = 1500.00,
                    Saida = 8000,
                    Saldo = 1500 - 8000,
                    Final = "Déficit"
                });
            }
            DataGridEntradaSaidaDespesas.ItemsSource = ListaEntradaSaidaDespesas;*/
        }

        private void LoadListDesp()
        {
            try
            {
                _despesaList = new DespesasDAO().List();
                DataGridConsultarDespesas.ItemsSource = _despesaList;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void LoadListEntradaSaida()
        {
            try
            {
                _despesaList = new DespesasDAO().List();
                DataGridEntradaSaidaDespesas.ItemsSource = _despesaList;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnInicioConsultarDespesa_Click(object sender, RoutedEventArgs e)
        {
            MenuInicial menuInicial = new MenuInicial();
            menuInicial.Show();
            this.Close();
        }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //limpa a fatia selecionada.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }

        private void Button_UpdateDesp_Click(object sender, RoutedEventArgs e)
        {
            var despesaSelecionada = DataGridConsultarDespesas.SelectedItem as Despesas;

            var windowdesp = new CadastrarDespesaWindow(despesaSelecionada.IdDespesa);
            windowdesp.ShowDialog();
            LoadListDesp();
            this.Close();
        }

        private void Button_DeleteDesp_Click(object sender, RoutedEventArgs e)
        {
            var despesaSelecionada = DataGridConsultarDespesas.SelectedItem as Despesas;

            var result = MessageBox.Show($"Deseja realmente excluir a Despesa: {despesaSelecionada.DescricaoDespesa}, datada de: {despesaSelecionada.dataDespesa} e " +
                $"com o valor de R${despesaSelecionada.ValorDespesa}", "Excluir Despesa?", MessageBoxButton.YesNo, MessageBoxImage.Question);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new DespesasDAO();
                    dao.Delete(despesaSelecionada);
                    LoadListDesp();
                    MessageBox.Show("Despesa Excluída com sucesso");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnPesquisarDespesa_Click(object sender, RoutedEventArgs e)
        {
            var text = txtOrdenarConsultaDespesa.Text;

            var filteredList = _despesaList.Where(i => i.DescricaoDespesa.ToLower().Contains(text));
            DataGridConsultarDespesas.ItemsSource = filteredList;
        }
    }
}
