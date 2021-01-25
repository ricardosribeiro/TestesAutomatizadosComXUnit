using System;
using System.Linq;
using Alura.LeilaoOnline.Core.Entities;
using Alura.LeilaoOnline.Core.Interfaces;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {
        [Theory]
        [InlineData(1400, new double[] { 800, 1000, 1200, 1400 })] //Lances ordenados
        [InlineData(1400, new double[] { 800, 1200, 1400, 1000 })] //Lances não ordenados
        [InlineData(800, new double[] { 800 })] //Lance único
        public void RetornaMaiorValorDadoLeilaoPeloMenosUmLance(double valorEsperado, double[] lances)
        {

            //Arranje
            IModalidadeLeilao modalidade= new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("fulano", leilao);
            var beltrano = new Interessada("beltrano", leilao);

            leilao.IniciaPregao();

            //Act
            for (int i = 0; i < lances.Length; i++)
            {
                if (i % 2 == 0)
                {
                    leilao.RecebeLance(fulano, lances[i]);
                }
                else
                {
                    leilao.RecebeLance(beltrano, lances[i]);
                }
            }

            leilao.TerminaPregao();

            //Assert
            Assert.Equal(valorEsperado, leilao.Ganhador.Valor);

        }

        [Fact]
        public void RetornaZeroDadoLeilaoSemLances()
        {
            //Arranje
            IModalidadeLeilao modalidade= new MaiorValor();
            var leilao = new Leilao("Van Gogh",modalidade);
            leilao.IniciaPregao();
            var valorEsperado = 0;

            //Act
            leilao.TerminaPregao();
            var valorObtido = leilao.Ganhador.Valor;

            //Assert
            Assert.Equal(valorEsperado, valorObtido);

        }

        [Theory]
        [InlineData(800)]
        public void LancaInvalidOperationExceptionDadopregaoNaoIniciado(double lance)
        {
            //Arranje
            IModalidadeLeilao modalidade= new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("fulano", leilao);
            leilao.RecebeLance(fulano, lance);
            var esperado = "Não é possível finalizar o pregão se ele não tiver sido iniciado. Utilize o método IniciaLeilao()";

            //Act - Isso já seria suficiente para validar o tipo de exceção
            var excessaoLancada = Assert.Throws<InvalidOperationException>(() => leilao.TerminaPregao());

            //Assert - Aqui verifico se o retorno da mensagem é o esperado
            Assert.Throws<InvalidOperationException>(() => leilao.TerminaPregao());
            Assert.Equal(esperado, excessaoLancada.Message);

            //Forma menos elegante de implementação
            // try
            // {
            //     //Act
            //     leilao.TerminaPregao();
            //     Assert.True(false);
            // }
            // catch (System.Exception e)
            // {
            //     //Assert
            //     Assert.IsType<InvalidOperationException>(e);
            // }
        }

        [Theory]
        [InlineData(1400, 1500, new double[] { 800, 1200, 1500, 1700 })]
        public void RetornaGanhadorDadoModalidadeLimiteSuperioMaisProximo(double meta, double esperado, double[] lances)
        {
            //Arranje
            IModalidadeLeilao modalidade= new LimiteSuperiorMaisProximo(meta);
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("fulano", leilao);
            var beltrano = new Interessada("beltrano", leilao);
            leilao.IniciaPregao();

            for (int i = 0; i < lances.Count(); i++)
            {
                if (i % 2 == 0)
                {
                    leilao.RecebeLance(fulano, lances[i]);
                }
                else
                {
                    leilao.RecebeLance(beltrano, lances[i]);
                }
            }           

            //Act
            leilao.TerminaPregao();

            //Assert
            Assert.Equal(esperado,leilao.Ganhador.Valor);
        }
    }
}
