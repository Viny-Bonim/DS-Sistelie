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
            RuleFor(x => x.Fkcaixa).NotEmpty().WithMessage("O campo CÓDIGO DO CAIXA é de preenchimento obrigatório!\n");
            RuleFor(x => x.Fkfuncionario).NotEmpty().WithMessage("O campo CÓDIGO DO FUNCIONÁRIO é de preenchimento obrigatório!\n");
            RuleFor(x => x.DescricaoDespesa).NotEmpty().WithMessage("O campo DESCR~IÇÃO DA DESPESA é de preenchimento obrigatório!\n");
            RuleFor(x => x.GrupoDespesa).NotEmpty().WithMessage("O campo GRUPO DA DESPESA é de preenchimento obrigatório!\n");
        }
    }
}
