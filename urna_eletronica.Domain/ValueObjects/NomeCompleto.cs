using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urna_eletronica.Domain.ValueObjects
{
    public class NomeCompleto
    {
        public string Valor { get; }

        public NomeCompleto(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException("Nome não pode ser vazio.");

            Valor = valor.Trim();
        }

        public override string ToString()
        {
            return Valor;
        }

        public override bool Equals(object obj)
        {
            return obj is NomeCompleto nome && Valor == nome.Valor;
        }

        public override int GetHashCode()
        {
            return Valor.GetHashCode();
        }
    }
}
