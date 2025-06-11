using urna_eletronica.Domain.Exceptions;
using urna_eletronica.Domain.ValueObjects;

namespace urna_eletronica.Domain.Entities;

public class Eleitor
{
    public Guid Id { get; private set; }
    public NomeCompleto Nome { get; private set; }
    public CPF CPF { get; private set; }
    public TituloEleitoral TituloEleitoral { get; private set; }
    public bool JaVotou { get; private set; }

    // Construtor
    public Eleitor()
    {
        
    }
    public Eleitor(Guid id, NomeCompleto nome, CPF cpf, TituloEleitoral tituloEleitoral)
    {
        if (nome == null) throw new ArgumentNullException(nameof(nome));
        if (cpf == null) throw new ArgumentNullException(nameof(cpf));
        if (tituloEleitoral == null) throw new ArgumentNullException(nameof(tituloEleitoral));

        Id = id == Guid.Empty ? Guid.NewGuid() : id;
        Nome = nome;
        CPF = cpf;
        TituloEleitoral = tituloEleitoral;
        JaVotou = false;
    }

    // Método de domínio: registrar que o eleitor votou
    public void RegistrarVoto()
    {
        if (JaVotou)
            throw new VotoInvalidoException("Eleitor já votou.");

        JaVotou = true;
    }

    // Método de domínio: valida se o título pertence ao eleitor
    public bool ValidarTitulo(string numeroTitulo)
    {
        return TituloEleitoral != null && TituloEleitoral.Numero == numeroTitulo;
    }
}





