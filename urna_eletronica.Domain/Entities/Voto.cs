using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urna_eletronica.Domain.Entities
{
    public class Voto
    {
        public Guid Id { get; private set; }
        public Guid EleitorId { get; private set; }
        public Guid CandidatoId { get; private set; }

        public Eleitor Eleitor { get; private set; }
        public Candidato Candidato { get; private set; }

        // Construtor sem parâmetros para o EF Core
        private Voto() { }

        // Construtor da aplicação
        public Voto(Guid eleitorId, Guid candidatoId)
        {
            if (eleitorId == Guid.Empty)
                throw new ArgumentException("EleitorId inválido");

            if (candidatoId == Guid.Empty)
                throw new ArgumentException("CandidatoId inválido");

            Id = Guid.NewGuid();
            EleitorId = eleitorId;
            CandidatoId = candidatoId;
        }
    }
}
