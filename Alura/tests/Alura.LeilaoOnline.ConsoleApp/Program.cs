using System;
using static System.Console;
using Alura.LeilaoOnline.Core.Entities;
using Alura.LeilaoOnline.Core.Interfaces;

namespace Alura.LeilaoOnline.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LeilaoComVariosLances();
            LeilaiComUmLance();
        }

        static void LeilaoComVariosLances()
        {

            //Arranje
            IModalidadeLeilao modalidade= new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);

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
            VerificaRresultado(esperado, leilao.Ganhador.Valor);

        }
        static void LeilaiComUmLance()
        {
            IModalidadeLeilao modalidade= new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);

            var fulano = new Interessada("fulano", leilao);

            leilao.RecebeLance(fulano, 1000);

            leilao.TerminaPregao();

            double esperado = 900;
            VerificaRresultado(esperado, leilao.Ganhador.Valor);
        }
        static void VerificaRresultado(double espereado, double obtido)
        {
            var cor = Console.ForegroundColor;

            if (espereado == obtido)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                WriteLine("TESTE OK");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                WriteLine("TESTE FALHOU!");
            }

            Console.ForegroundColor = cor;
        }
    }
}
