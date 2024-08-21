using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Opah.Consolidado.Infra.MongoDB.Maps
{
    public class LancamentoDbMap
    {
        #region Public Properties

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public required decimal Valor { get; set; }

        public required DateTime Data { get; set; }

        #endregion Public Properties
    }
}
