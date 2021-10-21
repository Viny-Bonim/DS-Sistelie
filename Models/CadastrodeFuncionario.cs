using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_Sistelie.Models
{
    class CadastrodeFuncionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime data_nas { get; set; }
        public string Sexo { get; set; }
        public string RendaFamiliar { get; set; }
        public float Endereço { get; set; }

        public Endereço End = new Endereço();
        public float Email { get; set; }
    }
}
