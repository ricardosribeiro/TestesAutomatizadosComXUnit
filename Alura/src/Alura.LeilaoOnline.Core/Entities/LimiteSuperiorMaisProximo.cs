using System.Collections.Generic;
using System.Linq;
using Alura.LeilaoOnline.Core.Interfaces;

namespace Alura.LeilaoOnline.Core.Entities
{
    public class LimiteSuperiorMaisProximo : IModalidadeLeilao
    {
        public double Meta { get;}
        public LimiteSuperiorMaisProximo(double meta)
        {
            Meta = meta;
        }

        public Lance ValidaLances(Leilao leilao)
        {
            return leilao.Lances
                .DefaultIfEmpty(new Lance(null, 0))
                .Where(x=>x.Valor>Meta)
                .OrderBy(x=>x.Valor)
                .FirstOrDefault();
        }
    }
}