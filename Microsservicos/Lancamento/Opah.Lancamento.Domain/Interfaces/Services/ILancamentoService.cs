using Opah.Lancamento.Domain.Entities;

namespace Opah.Lancamento.Domain.Interfaces.Services
{
    public interface ILancamentoService
    {
        decimal BuscarSaldo();
        void Creditar(decimal valor, FluxoCaixa fluxoCaixa);
        void Debitar(decimal valor, FluxoCaixa fluxoCaixa);
    }
}