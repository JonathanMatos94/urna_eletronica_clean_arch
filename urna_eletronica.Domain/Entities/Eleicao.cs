using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urna_eletronica.Domain.Entities
{
    public class Eleicao
    {
        public Guid Id { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public bool Ativa { get; private set; }
        public Eleicao()
        {
            
        }
        public Eleicao(Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            Ativa = false;
        }

        public void Iniciar(DateTime inicio, DateTime fim)
        {
            if (inicio >= fim)
                throw new ArgumentException("A data de início deve ser anterior à data de término.");

            if (Ativa)
                throw new InvalidOperationException("A eleição já está ativa.");

            DataInicio = inicio;
            DataFim = fim;
            Ativa = true;
        }

        public void Encerrar()
        {
            if (!Ativa)
                throw new InvalidOperationException("A eleição não está ativa.");

            Ativa = false;
        }



    }
}
