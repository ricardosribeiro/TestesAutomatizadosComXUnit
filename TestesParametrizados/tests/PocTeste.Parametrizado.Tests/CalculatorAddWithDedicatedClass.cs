using System.Collections;
using System.Collections.Generic;
using PocTeste.Parametrizado.Console;
using Xunit;

namespace PocTeste.Parametrizado.Tests
{
    public class CalculatorAddWithDedicatedClass
    {
        [Theory]
        [ClassData(typeof(CalculatorTestData))]
        public void RetornaSomaDadoNumerosInteiros(int valor1, int valor2, int esperado)
        {
            //Arranje //Act
            var resultado = Calculator.Add(valor1, valor2);

            //Assert
            Assert.Equal(resultado, esperado);
        }
    }

    public class CalculatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 5, 6 };
            yield return new object[] { -1, -10, -11 };
            yield return new object[] { -10, 8, -2 };
            yield return new object[] { int.MinValue, -1, int.MaxValue };

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}