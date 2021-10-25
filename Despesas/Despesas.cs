using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS_Sistelie.Models;

namespace DS_Sistelie.Despesas
{
    public class Despesas
    {
        public int IdDespesa { get; set; }

        public double ValorDespesa { get; set; }

        public DateTime? dataDespesa { get; set; }

        public string DescricaoDespesa { get; set; }

        public string GrupoDespesa { get; set; }

        public Caixa Caixa { get; set; }

        public Funcionario Funcionario { get; set; }
    }
}
