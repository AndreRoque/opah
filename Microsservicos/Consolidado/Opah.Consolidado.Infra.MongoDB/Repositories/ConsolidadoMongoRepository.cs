using Opah.Consolidado.Infra.MongoDB.Maps;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Bson;
using Opah.Lib.MicrosservicoBase.Exception;
using Opah.Lib.Logger;
using System.Reflection.Metadata.Ecma335;

namespace Opah.Consolidado.Infra.MongoDB.Repositories
{
    public class ConsolidadoMongoRepository : IConsolidadoRepository
    {
        private readonly IMongoCollection<FluxoCaixaDBMap> _fluxoCaixa;
        private readonly IMongoCollection<LancamentoDbMap> _lancamento;
        private readonly IOpahLogger _logger;

        public ConsolidadoMongoRepository(IConfiguration _config, IOpahLogger logger)
        {
            var mongoClient = new MongoClient(
                _config["mongo-connection"]);

            var mongoDatabase = mongoClient.GetDatabase(
                _config["mongo-database"]);

            _fluxoCaixa = mongoDatabase.GetCollection<FluxoCaixaDBMap>("fluxo-caixa");
            _lancamento = mongoDatabase.GetCollection<LancamentoDbMap>("lancamento");

            _logger = logger;
        }

        public decimal BuscarSaldo()
        {
            FluxoCaixaDBMap fluxoCaixa;

            try
            {
                fluxoCaixa = _fluxoCaixa.Find(new BsonDocument()).FirstOrDefault();
            }
            catch (Exception exception)
            {
                _logger.Log(LogType.Error, exception);
                throw new OpahException("Não foi possivel acessar os dados. Tente novamewnte mais tarde");
            }            

            if (fluxoCaixa == null)
            {
                return 0;
            }

            return fluxoCaixa.Saldo;
        }

        public IList<LancamentoDbMap> ListarLancamentos()
        {
            List<LancamentoDbMap> lista;

            try
            {
                lista = _lancamento.Find(new BsonDocument()).ToList();
            }
            catch (Exception exception)
            {
                _logger.Log(LogType.Error, exception);
                throw new OpahException("Não foi possivel acessar os dados. Tente novamewnte mais tarde");
            }

            if (!lista.Any())
            {
                throw new Opah404Exception("Nao foram encontrados lancamentos");
            }

            return lista;
        }
    }
}
