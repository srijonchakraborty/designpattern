using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;
using RepositoryPattern.Contract;

namespace RepositoryPattern.Repository
{
    public class MongoDBRepository : IRepository
    {
        public readonly static string IdConstantName = "Id";
        public readonly static string Id = "Id";
        private readonly IMongoDatabase _database;
        public MongoDBRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<T?> GetByIdAsync<T>(string id) where T : class
        {
            var collection = _database.GetCollection<T>(typeof(T).Name);
            var filter = Builders<T>.Filter.Eq("Id", ObjectId.Parse(id));
            return await collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetByForeignIdAsync<T>(int foreignKeyId, string foreignKeyColumnName) where T : class
        {
            var collection = _database.GetCollection<T>(typeof(T).Name);
            var filter = Builders<T>.Filter.Eq(foreignKeyColumnName, foreignKeyId);
            return await collection.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetByForeignIdAsync<T>(string foreignKeyId, string foreignKeyColumnName) where T : class
        {
            var collection = _database.GetCollection<T>(typeof(T).Name);
            var filter = Builders<T>.Filter.Eq(foreignKeyColumnName, foreignKeyId);
            return await collection.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        {
            var collection = _database.GetCollection<T>(typeof(T).Name);
            return await collection.Find(_ => true).ToListAsync();
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            var collection = _database.GetCollection<T>(typeof(T).Name);
            await collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            var collection = _database.GetCollection<T>(typeof(T).Name);
            var filter = Builders<T>.Filter.Eq("Id", (entity as dynamic).Id);
            await collection.ReplaceOneAsync(filter, entity);
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            var collection = _database.GetCollection<T>(typeof(T).Name);
            var filter = Builders<T>.Filter.Eq("Id", (entity as dynamic).Id);
            await collection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var collection = _database.GetCollection<T>(typeof(T).Name);
            return await collection.Find(predicate).ToListAsync();
        }

        public async Task RemoveAsync<T>(T entity) where T : class
        {
            var collection = _database.GetCollection<T>(typeof(T).Name);
            var filter = Builders<T>.Filter.Eq("Id", (entity as dynamic).Id);
            await collection.DeleteOneAsync(filter);
        }

        public async Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            var collection = _database.GetCollection<T>(typeof(T).Name);
            await collection.InsertManyAsync(entities);
        }

        public async Task RemoveRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            var collection = _database.GetCollection<T>(typeof(T).Name);
            IEnumerable<object?> ids = entities.Select(entity => (entity as dynamic).Id);
            var filter = Builders<T>.Filter.In("Id", ids);
            await collection.DeleteManyAsync(filter);
        }
    }
}
