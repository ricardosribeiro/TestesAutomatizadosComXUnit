using Alura.LeilaoOnline.Core.Interfaces;
using System.Linq;

namespace Alura.LeilaoOnline.Core.Entities
{
    public class MaiorValor : IModalidadeLeilao
    {
        public Lance ValidaLances(Leilao leilao)
        {
            return leilao.
                Lances.DefaultIfEmpty(new Lance(null, 0))
                .OrderBy(x => x.Valor)
                .LastOrDefault();
        }
    }
}