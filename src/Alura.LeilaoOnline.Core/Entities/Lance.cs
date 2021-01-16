namespace Alura.LeilaoOnline.Core.Entities
{
    public class Lance
    {
        public Interessada Cliente { get; }
        public double Valor{get;}

        public Lance(Interessada cliente, double valor)
        {
            Cliente = cliente;
            Valor = valor;
        }
    }
}