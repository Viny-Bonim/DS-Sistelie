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

namespace DS_Sistelie.Despesas
{
    /// <summary>
    /// Lógica interna para ConsultarDespesasWindow.xaml
    /// </summary>
    public partial class ConsultarDespesasWindow : Window
    {
        private List<string> ordenarDespesa;

        List<Despesas> ListaDespesas = new List<Despesas>();

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
            /*ComboBox de ordenar conulta de despesas*/
            ordenarDespesa = new List<string>();

            ordenarDespesa.Add("ID");
            ordenarDespesa.Add("Código do Fornecedor");
            ordenarDespesa.Add("Valor da Despesa");
            ordenarDespesa.Add("Data da Despesa");

            cmbxOrdenarConsultaDespesa.ItemsSource = ordenarDespesa;


            /*DataGrid de depesas*/
            for (int i = 0; i < 3; i++)
            {
                ListaDespesas.Add(new Despesas()
                {
                    IdDespesa = i + 1,
                    CodigoFornecedorCadDespesa = i + 2,
                    DescricaoDespesa = "Compra de Papel Colorset para convite preto e amarelo",
                    ValorDespesa = 15.25 + i,
                    dataDespesa = "01/05/2021",
                    GrupoDespesa = "Despesa Variável"
                });
            }
            DataGridConsultarDespesas.ItemsSource = ListaDespesas;


            /*DataGrid de entrada e saída de despesa*/
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
            DataGridEntradaSaidaDespesas.ItemsSource = ListaEntradaSaidaDespesas;

        }

        private void btnEditarDespesa_Click(object sender, RoutedEventArgs e)
        {
            if (rdbtConsultarDespesas1.IsChecked == false && rdbtConsultarDespesas2.IsChecked == false
                && rdbtConsultarDespesas3.IsChecked == false)
            {
                MessageBox.Show("Selecione uma Despesa para Editar!");
            }
            else
            {
                if (rdbtConsultarDespesas1.IsChecked == true)
                {
                    CadastrarDespesaWindow cadastrarDespesa = new CadastrarDespesaWindow();
                    cadastrarDespesa.Show();
                    this.Close();
                }

                if (rdbtConsultarDespesas2.IsChecked == true)
                {
                    CadastrarDespesaWindow cadastrarDespesa = new CadastrarDespesaWindow();
                    cadastrarDespesa.Show();
                    this.Close();
                }

                if (rdbtConsultarDespesas3.IsChecked == true)
                {
                    CadastrarDespesaWindow cadastrarDespesa = new CadastrarDespesaWindow();
                    cadastrarDespesa.Show();
                    this.Close();
                }
            }
        }

        private void btnExcluirDespesa_Click(object sender, RoutedEventArgs e)
        {
            if (rdbtConsultarDespesas1.IsChecked == false && rdbtConsultarDespesas2.IsChecked == false
                && rdbtConsultarDespesas3.IsChecked == false)
            {
                MessageBox.Show("Selecione uma Despesa para Excluir!");
            }
            else
            {
                MessageBox.Show("Despesa Excluída com Sucesso!");
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
    }
}
