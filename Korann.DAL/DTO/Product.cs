using Korann.DAL.Contracts;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Korann.DAL.DTO
{
    [BsonIgnoreExtraElements]
    public class Product : IEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        [BsonElement("_id")]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("cat")]
        public string Category { get; set; }

        [BsonElement("price")]
        public int Price { get; set; }

        [BsonElement("img")]
        public string Image { get; set; }

        [BsonElement("desc")]
        public string Description { get; set; }
    }
}