using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace fa_mongodb.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }

        public required string Title { get; set; }

        public required string Author { get; set; }

        public int Year { get; set; }
        
    }
}