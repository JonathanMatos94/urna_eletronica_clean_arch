using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace urna_eletronica.Domain.ValueObjects
{
    public class TituloEleitoral
    {
        public string Numero { get; }

        public TituloEleitoral(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentException("Título de eleitor não pode ser vazio.");

            var apenasNumeros = Regex.Replace(numero, "[^0-9]", "");

            if (apenasNumeros.Length != 12)
                throw new ArgumentException("Título de eleitor deve conter 12 dígitos.");

            Numero = apenasNumeros;
        }

        public override string ToString()
        {
            return Numero;
        }

        public override bool Equals(object obj)
        {
            return obj is TituloEleitoral titulo && Numero == titulo.Numero;
        }

        public override int GetHashCode()
        {
            return Numero.GetHashCode();
        }
    }
}
