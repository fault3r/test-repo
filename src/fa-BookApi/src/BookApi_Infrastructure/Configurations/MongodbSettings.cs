using System;

namespace BookApi_Infrastructure.Configurations
{
    public class MongodbSettings
    {
        public required string ConnectionString { get; set; }

        public required string DatabaseName { get; set; }
    }
}