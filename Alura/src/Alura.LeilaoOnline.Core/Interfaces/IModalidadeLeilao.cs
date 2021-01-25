using Alura.LeilaoOnline.Core.Entities;

namespace Alura.LeilaoOnline.Core.Interfaces
{
    public interface IModalidadeLeilao
    {
        Lance ValidaLances(Leilao leilao);
    }
}