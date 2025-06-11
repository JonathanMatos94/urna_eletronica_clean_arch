using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace urna_eletronica.Domain.ValueObjects
{
    public class CPF
    {
        public string Numero { get; }

        public CPF(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentException("CPF não pode ser vazio.");

            var cpfFormatado = Regex.Replace(numero, "[^0-9]", "");

            if (!ValidarCpf(cpfFormatado))
                throw new ArgumentException("CPF inválido.");

            Numero = cpfFormatado;
        }

        public override string ToString()
        {
            return Convert.ToUInt64(Numero).ToString(@"000\.000\.000\-00");
        }

        public override bool Equals(object obj)
        {
            return obj is CPF cpf && Numero == cpf.Numero;
        }

        public override int GetHashCode()
        {
            return Numero.GetHashCode();
        }

        private bool ValidarCpf(string cpf)
        {
            if (cpf.Length != 11 || new string(cpf[0], 11) == cpf)
                return false;

            int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            string digito = resto.ToString();

            tempCpf += digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            digito += resto.ToString();

            return cpf.EndsWith(digito);
        }
    }
}

