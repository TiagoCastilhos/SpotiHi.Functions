using MongoDB.Driver;
using System;

namespace Design.Promob.ProjectsApi.Data.Connections
{
    public class MongoDBConnection
    {
        private const string DatabaseName = "SpotiHi";
        private readonly IMongoDatabase _database;

        public MongoDBConnection(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            _database = CreateDatabaseReference(connectionString);
        }

        internal IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            if (string.IsNullOrEmpty(collectionName))
                throw new ArgumentNullException(nameof(collectionName));

            return _database.GetCollection<T>(collectionName);
        }

        private IMongoDatabase CreateDatabaseReference(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            var client = new MongoClient(connectionString);

            var database = client.GetDatabase(DatabaseName);

            if (database == null)
                throw new ArgumentException($"Could not get '{DatabaseName}' database reference");

            return database;
        }
    }
}