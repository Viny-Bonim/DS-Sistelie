using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_Sistelie.Models
{
    class Fornecedor
    {
        public int CodigoFornecedor { get; set; }

        public string Email { get; set; }

        public string TipoFornecedor { get; set; }

        public DateTime? DataCadastroFornecedor { get; set; }

        public string RgIe { get; set; }

        public string Cpf { get; set; }

        public string Cnpj { get; set; }

        public string NomeFantasia { get; set; }

        public string RazaoSocial { get; set; }

        public string Telefone { get; set; }

        public Endereco Endereco { get; set; }
    }
}
