using DS_Sistelie.Dominio.ConsulCliente;
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
    /// Lógica interna para Consultar_Cliente.xaml
    /// </summary>
    public partial class Consultar_Cliente : Window
    {
        public Consultar_Cliente()
        {
            InitializeComponent();
        }

        private void DataGridConsulClien_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            List<ConsulCliente> listaConsulta = new List<ConsulCliente>();

            listaConsulta.Add(new ConsulCliente()
            {
                ID = 1,
                Cliente = "Jackson Oliveira",
                RG = "1290280",
                Sexo = "Masculino",
                CPF = "123-432-234-12",
                Endereco = "Rua Oliveira",
                Contato = "69999870097",
                Progresso = "Em andamento"

            });
            DataGridConsulClien.ItemsSource = listaConsulta;
        }

        private void DataGridConsulClien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
