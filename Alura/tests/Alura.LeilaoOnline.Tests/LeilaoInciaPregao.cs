using System.Linq;
using Alura.LeilaoOnline.Core.Entities;
using Alura.LeilaoOnline.Core.Interfaces;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoIniciaPregao
    {
        [Theory]
        [InlineData(0, new double[] {100,200,300,4000})] //Lances ordenados
        [InlineData(0, new double[]{100,400,200,500})] //Lances não ordenados
        [InlineData(0, new double[]{800})] //Lance único
        public void IgnoraLancesDadoPregaoNaoIniciado(int valorEsperado, double[] lances)
        {
            //Arranje
            IModalidadeLeilao modalidade= new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("fulano", leilao);

            //Act
            foreach (var lance in lances)
                leilao.RecebeLance(fulano, lance);

            //Assert
            Assert.Equal(valorEsperado, leilao.Lances.Count());

        }
    }
}
