using Opah.Lancamento.Infra.MongoDB.Maps;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Opah.Lancamento.Domain.Interfaces.Repositories;
using MongoDB.Bson;
using Opah.Lib.MicrosservicoBase.Exception;
using Opah.Lib.Logger;
using System.Reflection.Metadata.Ecma335;

namespace Opah.Lancamento.Infra.MongoDB.Repositories
{
    public class LancamentoMongoRepository : ILancamentoRepository
    {
        private readonly IMongoCollection<FluxoCaixaDBMap> _fluxoCaixa;
        private readonly IMongoCollection<LancamentoDbMap> _lancamento;
        private readonly IOpahLogger _logger;

        public LancamentoMongoRepository(IConfiguration _config, IOpahLogger logger)
        {
            var mongoClient = new MongoClient(
                _config["mongo-connection"]);

            var mongoDatabase = mongoClient.GetDatabase(
                _config["mongo-database"]);

            _fluxoCaixa = mongoDatabase.GetCollection<FluxoCaixaDBMap>("fluxo-caixa");
            _lancamento = mongoDatabase.GetCollection<LancamentoDbMap>("lancamento");

            _logger = logger;
        }

        public void AtualizarSaldo(decimal valor)
        {
            FluxoCaixaDBMap fluxoCaixa;

            try
            {
                fluxoCaixa = _fluxoCaixa.Find(new BsonDocument()).FirstOrDefault();
            }
            catch (Exception exception)
            {
                _logger.Log(LogType.Error, exception);
                throw new OpahException("Não foi possivel acessar os dados. Tente novamente mais tarde");
            }

            if (fluxoCaixa == null)
            {
                var fluxo = new FluxoCaixaDBMap
                {
                    Saldo = valor,
                };

                _fluxoCaixa.InsertOne(fluxo);

                return;
            }

            var filter = Builders<FluxoCaixaDBMap>.Filter.Eq(r => r.Id, fluxoCaixa.Id);
            var update = Builders<FluxoCaixaDBMap>.Update.Set(r => r.Saldo, valor);

            _fluxoCaixa.UpdateOne(filter, update);
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

        public void LancarValor(decimal valor)
        {
            var lancamento = new LancamentoDbMap
            {
                Data = DateTime.Now,
                Valor = valor,
            };

            _lancamento.InsertOne(lancamento);
        }
    }
}
