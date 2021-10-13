using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_Sistelie.Despesas
{
    public class Despesas
    {
        public int IdDespesa { get; set; }

        public double ValorDespesa { get; set; }

        public DateTime dataDespesa { get; set; }

        public string DescricaoDespesa { get; set; }

        public string GrupoDespesa { get; set; }

        public int Fkcaixa { get; set; }

        public int Fkfuncionario { get; set; }
    }
}
