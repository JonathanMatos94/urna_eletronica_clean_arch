namespace urna_eletronica.Domain.Exceptions
{
    public class VotoInvalidoException : Exception
    {
        public VotoInvalidoException()
            : base("O voto é inválido.") { }

        public VotoInvalidoException(string message)
            : base(message) { }

        public VotoInvalidoException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
