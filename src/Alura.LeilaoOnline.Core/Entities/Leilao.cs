using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Core.Entities
{
    public class Leilao
    {
        private List<Lance> _lances;
        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }

        public Leilao(string peca)
        {
            Peca = peca;
            _lances = new List<Lance>();
        }

        public void RecebeLance(Interessada cliente, double valor)
        {
            _lances.Add(new Lance(cliente, valor));
        }

        public void IniciaPregao()
        {

        }

        public void TerminaPregao() => Ganhador = _lances.OrderBy(x => x.Valor).Last();
    }
}