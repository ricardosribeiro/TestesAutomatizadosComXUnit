using System.Collections.Generic;
using PocTeste.Parametrizado.Console;
using Xunit;

namespace PocTeste.Parametrizado.Tests
{
    public class CalculatorAddWithDataIntoTestClass
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void RetornaSomaDadoNumerosInteiros(int valor1, int valor2, int esperado)
        {
            //Arranje //Act
            var resultado = Calculator.Add(valor1, valor2);

            //Assert
            Assert.Equal(esperado, resultado);
        }

        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[] { 1, 5, 6 },
            new object[] { -1, -10, -11 },
            new object[] { -10, 8, -2 },
            new object[] { int.MinValue, -1, int.MaxValue }
        };
    }
}

//https://andrewlock.net/creating-parameterised-tests-in-xunit-with-inlinedata-classdata-and-memberdata/