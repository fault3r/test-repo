using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace fa_mongo.Entities
{
    public class Book
    {
        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("_title")]
        public required string Title { get; set; }

        [BsonElement("_author")]
        public required string Author { get; set; }

        [BsonElement("_year")]
        public int Year { get; set; }        
    }
}