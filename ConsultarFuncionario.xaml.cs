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

namespace DS_Sistelie
{
    /// <summary>
    /// Lógica interna para ConsultarFuncionario.xaml
    /// </summary>
    public partial class ConsultarFuncionario : Window
    {
        List<Funcionario> ListaF = new List<Funcionario>();
        public ConsultarFuncionario()
        {
            InitializeComponent();
            Loaded += ConsultarFuncionario_Loaded;
        }

        private void ConsultarFuncionario_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                ListaF.Add(new Funcionario()
                {
                    IdFunc = i + 1,

                    Nome = "Hiago Benitez",

                    CPF = "01002003044",
                    
                    RG = "001122",

                    data_nas = DateTime.Now,

                    Sexo = "Masculino",
                    
                    Email = "xxxxxx@gmil.com"
                });
                
            }
            DgFun.ItemsSource = ListaF;
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Deseja Cancelar a consulta de Funcionario?", "Cadastrar Cliente", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MenuInicial menuInicial = new MenuInicial();
                menuInicial.Show();
                this.Close();
            }
        }



        private void EditarFuncio_Click(object sender, RoutedEventArgs e)
        {
            CadastroFuncionario CadFuncionario = new CadastroFuncionario();
            CadFuncionario.Show();
            this.Close();
        }
    }
}

