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
    /// Lógica interna para SaidaMateriaPrima.xaml
    /// </summary>
    public partial class SaidaMateriaPrima : Window
    {
        bool validacao = false;
        MateriaPrima saidaMateria = new MateriaPrima();
        private List<string> Nomemateriaprima;

        public SaidaMateriaPrima()
        {
            InitializeComponent();
            Loaded += CadastrarMateriaPrima_Loaded;
        }

        private void CadastrarMateriaPrima_Loaded(object sender, RoutedEventArgs e)
        {
            Nomemateriaprima = new List<string>();

            Nomemateriaprima.Add("Papelão Paraná 20mm");
            Nomemateriaprima.Add("papel a4 500 folhas");
            Nomemateriaprima.Add("papel cartolina a4 180g");

            ComboNomeMateriaPrima.ItemsSource = Nomemateriaprima;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {


            MessageBoxResult result = MessageBox.Show("Deseja Cancelar o Registro da saída de matéria - prima?", "Registrar Saída de Matéria - Prima", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MenuInicial menuInicial = new MenuInicial();
                menuInicial.Show();
                this.Close();
            }


        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            saidaMateria.NomeMateriPrima = ComboNomeMateriaPrima.Text;
            saidaMateria.QuantidadeUnidadesMateriaPrima = txtQtdMateriaPrimaUtilizada.Text;
            

            if (saidaMateria.NomeMateriPrima.Equals("")            
                || saidaMateria.QuantidadeUnidadesMateriaPrima.Equals(""))

            {
                MessageBox.Show("Preencha todos os campos com *");
                validacao = false;
            }

            else
            {
                validacao = true;
            }

            if (validacao == true)
            {
                MessageBox.Show("Registro salvo com sucesso!\n" +
                $"Nome: {saidaMateria.NomeMateriPrima}\n" +
                $"Quantidade: {saidaMateria.QuantidadeUnidadesMateriaPrima}");
                LimparTextBox();
            }

            void LimparTextBox()
            {
                ComboNomeMateriaPrima.Text = "";
                txtQtdMateriaPrimaUtilizada.Text = "";
               
            }

        }

        private void TxtCodigo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
