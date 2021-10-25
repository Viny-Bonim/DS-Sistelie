using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace DS_Sistelie.Despesas
{
    class DespesaValidator : AbstractValidator<Despesas>
    { 
        public DespesaValidator()
        {
            RuleFor(x => x.ValorDespesa).NotEmpty().WithMessage("O campo VALOR DA DESPESA é de preenchimento obrigatório!\n");
            RuleFor(x => x.dataDespesa).NotEmpty().WithMessage("O campo DATA DA DESPESA é de preenchimento obrigatório!\n");
            RuleFor(x => x.Caixa.MesCaixa).NotEmpty().WithMessage("O campo CAIXA é de preenchimento obrigatório!\n");
            RuleFor(x => x.Funcionario.Nome).NotEmpty().WithMessage("O campo FUNCIONÁRIO é de preenchimento obrigatório!\n");
            RuleFor(x => x.DescricaoDespesa).NotEmpty().WithMessage("O campo DESCRIÇÃO DA DESPESA é de preenchimento obrigatório!\n");
            RuleFor(x => x.GrupoDespesa).NotEmpty().WithMessage("O campo GRUPO DA DESPESA é de preenchimento obrigatório!\n");
        }
    }
}
