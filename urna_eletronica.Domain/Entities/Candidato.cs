using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urna_eletronica.Domain.Entities
{
    public class Candidato
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Partido { get; private set; }
        public int Numero { get; private set; }
        public Candidato()
        {
            
        }
        public Candidato(string Nome, string Partido, int Numero)
        {
            Id = Guid.NewGuid();
            if (string.IsNullOrWhiteSpace(Nome))
                throw new ArgumentException("Nome do candidato não pode ser vazio.", nameof(Nome));
            if (string.IsNullOrWhiteSpace(Partido))
                throw new ArgumentException("Partido do candidato não pode ser vazio.", nameof(Partido));
            if (Numero <= 0)
                throw new ArgumentException("Número do candidato deve ser maior que zero.", nameof(Numero));
        }
    }
}
