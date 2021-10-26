using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_Sistelie.Models
{
    public class Tarefa
    {
        public int IdTarefa { get; set; }
        public string TipoTarefa { get; set; }
        public string ResponsavelTarefa { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public string DescricaoTarefa { get; set; }
    }
}
