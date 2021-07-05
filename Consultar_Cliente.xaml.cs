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
        List<ConsulCliente> listaConsulta = new List<ConsulCliente>();
        public Consultar_Cliente()
        {
            InitializeComponent();
            Loaded += Consultar_Cliente_Loaded;
        }

        private void Consultar_Cliente_Loaded(object sender, RoutedEventArgs e)
        {
            List<ConsulCliente> listaConsulta = new List<ConsulCliente>();
            for (int i = 0; i < 3; i++)
            {
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
            }
            DataGridConsulClien.ItemsSource = listaConsulta;
        }

        private void ButtonSalvar_Click(object sender, RoutedEventArgs e)
        {
            MenuInicial menuInicial = new MenuInicial();
            menuInicial.Show();
            this.Close();
        }
    }
}
