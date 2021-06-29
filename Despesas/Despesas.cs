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

        public int CodigoFornecedorCadDespesa { get; set; }

        public string DescricaoDespesa { get; set; }

        public double ValorDespesa { get; set; }

        public string dataDespesa { get; set; }

        public string GrupoDespesa { get; set; }
    }
}
