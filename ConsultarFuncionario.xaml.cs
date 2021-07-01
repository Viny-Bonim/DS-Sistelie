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
    /// Lógica interna para ConsultarFuncionario.xaml
    /// </summary>
    public partial class ConsultarFuncionario : Window
    {
        List<Funcionário> ListaF = new List<Funcionário>();
        public ConsultarFuncionario()
        {
            InitializeComponent();
            Loaded += ConsultarFuncionario_Loaded;
        }

        private void ConsultarFuncionario_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                ListaF.Add(new Funcionário()
                {
                    IdFuncionario = i + 1,

                    NomeFuncionario = "Hiago Benitez",

                    CpfFuncionario = 01002003044,
                    
                    RgFuncionario = "001122",

                    NascimentoFuncionario = "23/10/20",

                    SexoFuncionario = "Masculino",

                    RendaFuncionario = 20.000,

                    BairroFuncionario = "Bela Vista",

                    RuaFuncionario = "Rua sem Fim",

                    NumeroFuncionario = 1411,

                    CidadeFuncionario = "Ji-Paraná",
                    
                    EmailFuncionario = "xxxxxx@gmil.com"
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

