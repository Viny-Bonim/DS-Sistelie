using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_Sistelie.Models
{
    public class RegistrarVenda
    {
        public int Codigovenda { get; set; }

        public DateTime DataVenda { get; set; }
        public string Datavenda { get; internal set; }
        public string Formapagamento { get; set; }

        public string Nomecliente { get; set; }

        public string Nomevendedor { get; set; }

        public string DescricaoVenda { get; set; }

        public string Quantidade { get; set; }

        public string ValorUnidade { get; set; }

        public string UnidadeVenda { get; set; }

        public string Valordesconto { get; set; }

        public string ValorTotal { get; set; }

        public int Codpedidofk { get; set; }

        public int Codclientefk { get; set; }

        public int Codfuncionariofk { get; set; }

        public int Codcaixafk { get; set; }

        public int Codprodutofk { get; set; }

    }
}