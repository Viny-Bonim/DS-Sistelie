using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_Sistelie.Models
{
    public class Funcionario
    {
        public int IdFunc { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public string RG { get; set; }

        public DateTime? data_nas { get; set; }

        public string Sexo { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public Endereco Endereco = new Endereco();
    }
}
