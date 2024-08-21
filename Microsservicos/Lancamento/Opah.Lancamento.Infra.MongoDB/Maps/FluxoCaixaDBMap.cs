using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Opah.Lancamento.Infra.MongoDB.Maps
{
    public class FluxoCaixaDBMap
    {
        #region Public Properties

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public required decimal Saldo { get; set; }

        #endregion Public Properties
    }
}
