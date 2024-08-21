using Opah.Lib.MicrosservicoBase.Interfaces;

namespace Opah.Lancamento.Domain.Entities
{
    public class FluxoCaixa : IOpahEntity
    {
        public decimal Saldo { get; private set; }

        public FluxoCaixa(decimal saldo)
        {
            Saldo = saldo;
        }
    }
}
