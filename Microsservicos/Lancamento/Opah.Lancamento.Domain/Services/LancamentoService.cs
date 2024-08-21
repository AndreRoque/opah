using Opah.Lancamento.Domain.Entities;
using Opah.Lancamento.Domain.Interfaces.Repositories;
using Opah.Lancamento.Domain.Interfaces.Services;

namespace Opah.Lancamento.Domain.Services
{
    public class LancamentoService : ILancamentoService
    {
        private ILancamentoRepository _repository;

        public LancamentoService(ILancamentoRepository repository)
        {
            _repository = repository;
        }

        public decimal BuscarSaldo()
        {
            return _repository.BuscarSaldo();
        }

        public void Creditar(decimal valor, FluxoCaixa fluxoCaixa)
        {
            _repository.LancarValor(valor);
            _repository.AtualizarSaldo(fluxoCaixa.Saldo + valor);
        }

        public void Debitar(decimal valor, FluxoCaixa fluxoCaixa)
        {
            _repository.LancarValor(-valor);
            _repository.AtualizarSaldo(fluxoCaixa.Saldo - valor);
        }
    }
}