using PocTeste.Parametrizado.Console;
using Xunit;

namespace PocTeste.Parametrizado.Tests
{
    public class CalculatorAddNormalTests
    {
        [Theory]
        [InlineData(1, 5, 6)] //Somente positivos
        [InlineData(-1,-10, -11)] //Somente negativos
        [InlineData(-10, 8, -2)] //Positivos e negativos
        [InlineData(int.MinValue, -1, int.MaxValue)] 
        public void RetornaSomaDadoNumerosInteiros(int valor1, int valor2, int esperado)
        {
            //Arranje
            int resultado = 0;

            //Act
            resultado = Calculator.Add(valor1, valor2);

            //Assert
            Assert.Equal(esperado, resultado);
        }
    }
}