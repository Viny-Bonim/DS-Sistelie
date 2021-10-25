using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_Sistelie.Models
{
    class Caixa
    {
        public int IdCaixa { get; set; }

        public double SaldoInicial { get; set; }

        public double EntradaCaixa { get; set; }

        public double SaidaCaixa { get; set; }

        public double SaldoFinal { get; set; }

        public string MesCaixa { get; set; }

        public string AnoCaixa { get; set; }

        public Funcionario Funcionario { get; set; }
    }
}
