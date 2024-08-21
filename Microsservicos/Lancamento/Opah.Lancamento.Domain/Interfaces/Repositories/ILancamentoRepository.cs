namespace Opah.Lancamento.Domain.Interfaces.Repositories
{
    public interface ILancamentoRepository
    {
        void AtualizarSaldo(decimal valor);
        decimal BuscarSaldo();
        void LancarValor(decimal valor);
    }
}