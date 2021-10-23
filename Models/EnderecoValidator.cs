using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentValidation;

namespace DS_Sistelie.Models
{
    class EnderecoValidator : AbstractValidator<Endereco>
    {

        public EnderecoValidator()
        {
            RuleFor(x => x.Cep).NotEqual("_____-___").WithMessage("O campo 'CEP' é de preenchimento obrigatório!\n");
            RuleFor(x => x.Cep).Must(ValidaCEP).WithMessage("CEP inválido\n");

            RuleFor(x => x.Bairro).NotEmpty().WithMessage("O campo BAIRRO é de preenchimento obrigatório!\n");

            RuleFor(x => x.Logradouro).NotEmpty().WithMessage("O campo LOGRADOURO é de preenchimento obrigatório!\n");

            RuleFor(x => x.Numero).NotEmpty().WithMessage("O campo NÚMERO é de preenchimento obrigatório!\n");

            RuleFor(x => x.Uf).NotEmpty().WithMessage("O campo UF é de preenchimento obrigatório!\n");
            
            RuleFor(x => x.Cidade).NotEmpty().WithMessage("O campo CIDADE é de preenchimento obrigatório!");
        }

        public bool ValidaCEP(string cep)
        {
            Regex Rgx = new Regex("^/d{5}-/d{3}$");

            if (!Rgx.IsMatch(cep))
                return false;
            else
                return true;
        }
    }
}
