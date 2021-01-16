using Alura.LeilaoOnline.Core.Entities;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTests
    {
        [Fact]
        public void LeilaoComVariosLances()
        {

            //Arranje
            var leilao = new Leilao("Van Gogh");

            var fulano = new Interessada("fulano", leilao);
            var beltrano = new Interessada("beltrano", leilao);

            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(beltrano, 1200);
            leilao.RecebeLance(fulano, 1500);
            leilao.RecebeLance(beltrano, 1100);

            //Act
            leilao.TerminaPregao();

            //Assert
            double esperado = 1500;
            Assert.Equal(esperado, leilao.Ganhador.Valor);

        }
        [Fact]
        public void LeilaiComUmLance()
        {
            var leilao = new Leilao("Van Gogh");

            var fulano = new Interessada("fulano", leilao);

            leilao.RecebeLance(fulano, 1000);

            leilao.TerminaPregao();

            double esperado = 1000;
            Assert.Equal(esperado, leilao.Ganhador.Valor);
        }
    }
}