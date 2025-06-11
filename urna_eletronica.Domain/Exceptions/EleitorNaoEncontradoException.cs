using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urna_eletronica.Domain.Exceptions
{
    public class EleitorNaoEncontradoException : Exception
    {
        public EleitorNaoEncontradoException()
            : base("Eleitor não encontrado.") { }

        public EleitorNaoEncontradoException(string message)
            : base(message) { }

        public EleitorNaoEncontradoException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
