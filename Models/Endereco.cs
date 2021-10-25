using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_Sistelie.Models
{
    public class Endereco
    {
        public int IdEnd { get; set; }

        public string Cep { get; set; }

        public string Bairro { get; set; }

        public string Logradouro { get; set; }

        public int Numero { get; set; }

        public string Uf { get; set; }

        public string Cidade { get; set; }

    }
}
