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
            listaConsulta.Add(new ExibTaref()
            {
                DataInicio = "12/09/2020",
                Novo = "Murilo Raskhi - Organizar Estoque",
                EmAndamento = "Jockson Henrique - Comprar Produto",
                Fechado = "Sabrina Satto - Gerenciar o caixa",
                DataTermino = "Silvio Santos - Supervisionar o caixa"
            });
            DataGridExibTarefas.ItemsSource = listaConsulta;
        }
    }
}
