using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace DS_Sistelie.Models
{
    class CaixaValidator : AbstractValidator<Caixa>
    {
        public CaixaValidator()
        {
            RuleFor(x => x.MesCaixa).NotEmpty().WithMessage("O campo MÊS CORRESPONDENTE é de preenchimento obrigatório!\n");
            RuleFor(x => x.AnoCaixa).NotEqual("____").WithMessage("O campo ANO CORRESPONDENTE' é de preenchimento obrigatório!\n");
        }
    }
}
