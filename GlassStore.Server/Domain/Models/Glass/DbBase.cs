using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GlassStore.Server.Domain.Models.Glass
{
    public class DbBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
    }
}
