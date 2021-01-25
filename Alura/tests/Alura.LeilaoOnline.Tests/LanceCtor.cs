using Alura.LeilaoOnline.Core.Entities;
using Xunit;
using System;
using Alura.LeilaoOnline.Core.Interfaces;

namespace Alura.LeilaoOnline.Tests
{
    public class LanceCtor
    {
        [Theory]
        [InlineData(-100)]
        public void LancaInvalidArgumetExceptionDadoValorNegativo(double lance)
        {
            //Arranje
            IModalidadeLeilao modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("fulano", leilao);
            leilao.IniciaPregao();

            //Assert
            Assert.Throws<ArgumentException>(
            //Act                
                () => leilao.RecebeLance(fulano, lance));
        }

        [Theory]
        [InlineData(-100, "Não é possível receber um lance negativo.")]
        public void LanceExcecaoComMensagemEspetadaDadoValorNegativo(double lance, string mensagemEsperada)
        {
            //Arranje
            IModalidadeLeilao modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("fulano", leilao);
            leilao.IniciaPregao();

            //Assert
            var excecaoLancada = Assert.Throws<ArgumentException>(
            //Act                
                () => leilao.RecebeLance(fulano, lance));

            Assert.Equal(mensagemEsperada, excecaoLancada.Message);
        }
    }
}