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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using DS_Sistelie.Models;

namespace DS_Sistelie.Despesas
{
    /// <summary>
    /// Lógica interna para ConsultarDespesasWindow.xaml
    /// </summary>
    public partial class ConsultarDespesasWindow : Window
    {
        private List<Despesas> _despesaList = new List<Despesas>();
        private List<Caixa> _entradaSaidaList = new List<Caixa>();

        public ConsultarDespesasWindow()
        {
            InitializeComponent();
            Loaded += ConsultarDespesasWindow_Loaded;

            //PointLabel = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            //DataContext = this;
        }

        //public Func<ChartPoint, string> PointLabel { get; set; }

        private void ConsultarDespesasWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //Inserindo os dados na tabela de consulta de despesas
            //através do banco de dados
            LoadListDesp();


            //Inserindo os dados no gráfico de pizza
            LoadChart();


            //Inserindo os dados na tabela de entrada e saída
            //através do banco de dados
            LoadListEntradaSaida();
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
                
            }
        }


        private void LoadListEntradaSaida()
        {
            try
            {
                _entradaSaidaList = new CaixaDAO().List();
                DataGridEntradaSaidaDespesas.ItemsSource = _entradaSaidaList;
            }
            catch (Exception ex)
            {
                
            }
        }

        private void LoadChart()
        {
            try
            {
                pieChart.Series = new DespesasDAO().DadosGrafico();
            }
            catch (Exception ex)
            {
               
            }
        }

        private void btnInicioConsultarDespesa_Click(object sender, RoutedEventArgs e)
        {
            MenuInicial menuInicial = new MenuInicial();
            menuInicial.Show();
            this.Close();
        }

        /*
        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
          
            //limpa a fatia selecionada.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }  var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;
        */

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
