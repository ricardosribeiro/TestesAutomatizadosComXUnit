using System;

namespace Alura.LeilaoOnline.Core.Entities
{
    public class Lance
    {
        public Interessada Cliente { get; }
        public double Valor { get; }

        public Lance(Interessada cliente, double valor)
        {
            Cliente = cliente;

            if (valor < 0)
                throw new ArgumentException("Não é possível receber um lance negativo.");
            
            Valor = valor;
        }
    }
}