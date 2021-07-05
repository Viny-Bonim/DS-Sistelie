using DS_Sistelie.Dominio.ExibTarefas;
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
    /// Lógica interna para Exibir_Tarefas.xaml
    /// </summary>
    public partial class Exibir_Tarefas : Window
    {
        List<ExibTaref> listaConsulta = new List<ExibTaref>();
        public Exibir_Tarefas()
        {
            InitializeComponent();
            Loaded += Exibir_Tarefas_Loaded;
        }

        private void Exibir_Tarefas_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                listaConsulta.Add(new ExibTaref()
                {
                    DataInicio = "12/09/2020",
                    Nome = "Murilo Raskhi",
                    Status = "Em andamento",
                    DataTermino = "20/09/2020"
                });
            }
            DataGridExibTarefas.ItemsSource = listaConsulta;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MenuInicial menuInicial = new MenuInicial();
            menuInicial.Show();
            this.Close();
        }

    }
}
