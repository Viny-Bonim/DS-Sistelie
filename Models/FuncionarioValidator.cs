using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace DS_Sistelie.Models
{
    class FuncionarioValidator : AbstractValidator<Funcionario>
    {
        public FuncionarioValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("O campo NOME é de preenchimento obrigatório!\n");

            RuleFor(x => x.CPF).NotEqual("___.___.___-__").WithMessage("O campo CPF é de preenchimento obrigatório!\n");
            RuleFor(x => x.CPF).Must(ValidaCPF).WithMessage("CPF inválido\n");

            RuleFor(x => x.RG).NotEmpty().WithMessage("O campo RG é de preenchimento obrigatório!\n");

            RuleFor(x => x.data_nas).NotEmpty().WithMessage("O campo NASCIMENTO é de preenchimento obrigatório!\n");

            RuleFor(x => x.Sexo).NotEmpty().WithMessage("O campo SEXO é de preenchimento obrigatório!\n");

            RuleFor(x => x.Endereco.Bairro).NotEmpty().WithMessage("O campo BAIRRO é de preenchimento obrigatório!\n");

            RuleFor(x => x.Endereco.Logradouro).NotEmpty().WithMessage("O campo RUA é de preenchimento obrigatório!\n");

            RuleFor(x => x.Endereco.Numero).NotEmpty().WithMessage("O campo NÚMERO é de preenchimento obrigatório!\n");

            RuleFor(x => x.Endereco.Cidade).NotEmpty().WithMessage("O campo CIDADE é de preenchimento obrigatório!\n");

            RuleFor(x => x.Endereco.Cep).NotEqual("_____-___").WithMessage("O campo CEP é de preenchimento obrigatório!\n");

            RuleFor(x => x.Email).NotEmpty().WithMessage("O campo EMAIL é de preenchimento obrigatório!\n");
        }
        public static bool ValidaCPF(string vrCPF)
        {
            string valor = vrCPF.Replace(".", "");
            valor = valor.Replace("-", "");

            if (valor.Length != 11)
                return false;


            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                    igual = false;


            if (igual || valor == "12345678909")
                return false;


            int[] numeros = new int[11];


            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(
                  valor[i].ToString());


            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];


            int resultado = soma % 11;


            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;


            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];


            resultado = soma % 11;


            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
                if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }
    }
}
