using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace WMS.DataStore
{
    public interface IRepository
    {
        IEnumerable<TObject> GetAll<TObject>();
        void Save<TObject>(TObject entity);
        void SaveAll<TObject>(IList<TObject> entities);
    }

    public class Repository : IRepository
    {
        private readonly MongoDatabase _database;

        public Repository(MongoDatabase database)
        {
            _database = database;
        }

        public IEnumerable<TObject> GetAll<TObject>()
        {
            var collection = _database.GetCollection<TObject>(typeof(TObject).Name);
            return collection.FindAllAs<TObject>();
        }

        public void Save<TObject>(TObject entity)
        {
            var collection = _database.GetCollection<TObject>(entity.GetType().Name);
            collection.Insert(entity);
        }

        public void SaveAll<TObject>(IList<TObject> entities)
        {
            var collection = _database.GetCollection<TObject>(typeof(TObject).Name);
            foreach (var entity in entities)
                collection.Insert(entity);
            
        }
    }

    public class Bootstrapper
    {
        const string CONNECTION_STRING = "mongodb://localhost";

        public static MongoDatabase Initialise(string databaseName)
        {
            var _client = new MongoClient(CONNECTION_STRING);
            var server = _client.GetServer();
            return server.GetDatabase(databaseName);
        }
    }

}
