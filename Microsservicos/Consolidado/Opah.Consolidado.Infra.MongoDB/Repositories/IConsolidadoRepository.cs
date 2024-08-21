
using Opah.Consolidado.Infra.MongoDB.Maps;

namespace Opah.Consolidado.Infra.MongoDB.Repositories
{
    public interface IConsolidadoRepository
    {
        decimal BuscarSaldo();
        IList<LancamentoDbMap> ListarLancamentos();
    }
}