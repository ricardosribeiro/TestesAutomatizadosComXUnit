using System;
using System.Collections.Generic;
using System.Linq;
using Alura.LeilaoOnline.Core.Interfaces;

namespace Alura.LeilaoOnline.Core.Entities
{
    public enum EstadoLeilao
    {
        LeilaiNaoInciado,
        LeilaoAberto,
        LeilaoEncerrado
    }
    public class Leilao
    {
        private Interessada _ultimoCliente = null;
        private List<Lance> _lances;

        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }
        public EstadoLeilao EstadoLeilao { get; private set; }
        public IModalidadeLeilao Modalidade { get; }

        public Leilao(string peca, IModalidadeLeilao modalidade)
        {
            Peca = peca;
            _lances = new List<Lance>();
            EstadoLeilao = EstadoLeilao.LeilaiNaoInciado;
            Modalidade = modalidade;
        }

        private bool NovoLanceAceito(Interessada cliente, double valor)
        {
            return (EstadoLeilao.Equals(EstadoLeilao.LeilaoAberto)) && (cliente != _ultimoCliente);
        }
        public void RecebeLance(Interessada cliente, double valor)
        {
            if (NovoLanceAceito(cliente, valor))
            {
                _lances.Add(new Lance(cliente, valor));
                _ultimoCliente = cliente;
            }
        }

        public void IniciaPregao()
        {
            EstadoLeilao = EstadoLeilao.LeilaoAberto;
        }

        public void TerminaPregao()
        {
            if (EstadoLeilao != EstadoLeilao.LeilaoAberto)
                throw new InvalidOperationException("Não é possível finalizar o pregão se ele não tiver sido iniciado. Utilize o método IniciaLeilao()");

            Ganhador =  Modalidade.ValidaLances(this);
            EstadoLeilao = EstadoLeilao.LeilaoEncerrado;
        }
    }
}