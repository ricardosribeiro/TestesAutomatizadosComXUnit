using Alura.LeilaoOnline.Core.Entities;
using Xunit;
using System.Linq;
using Alura.LeilaoOnline.Core.Interfaces;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeLance
    {
        [Fact]
        public void NaoRecebeLanceDadoPregaoFinalizado()
        {
            //Arranje
            IModalidadeLeilao modalidade= new MaiorValor();
            var leilao = new Leilao("Van Gogh",modalidade);
            var fulano = new Interessada("fulano", leilao);
            var beltrano = new Interessada("beltrano", leilao);

            leilao.IniciaPregao();
            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(beltrano, 1000);
            leilao.TerminaPregao();

            //Act
            leilao.RecebeLance(fulano, 1200);

            //Assert
            int esperado = 2;
            Assert.Equal(esperado, leilao.Lances.Count());
        }


        [Fact]
        public void NaoRecebeLanceDadoMesmoClienteRealizouUltimoLance()
        {
            //Arranje
            IModalidadeLeilao modalidade= new MaiorValor();
            var leilao = new Leilao("Van Gogh",modalidade);
            var fulano = new Interessada("fulano", leilao);
            leilao.IniciaPregao();
            leilao.RecebeLance(fulano, 350);

            //Act
            leilao.RecebeLance(fulano, 800);
            leilao.TerminaPregao();
            var esperado = 1;

            //Assert
            Assert.Equal(esperado, leilao.Lances.Count());        
        }
    }
}