using Microsoft.Extensions.Options;
using MongoDB.Driver;

using WordPenca.Business.Domain;

namespace WordPenca.Business.Service
{

    public class RootMatchsService
    {

        private readonly IMongoCollection<RootMatch> _collection;
        public RootMatchsService(IMongoClient mongoClient, IOptions<MongoDbSettings> mongoDbSettings)
        {
            var database = mongoClient.GetDatabase(mongoDbSettings.Value.DataBase);
            _collection = database.GetCollection<RootMatch>(mongoDbSettings.Value.RootMatchsCollection);
        }
        async public Task<RootMatch> GetRootMatch(Filter filter)
        {
            return _collection.Find<RootMatch>(x => x.Filters.DateTo == filter.DateTo && x.Filters.DateFrom == filter.DateFrom).FirstOrDefault();
        }
        async public Task<List<RootMatch>> GetMatchs()
        {
            return await _collection.Find<RootMatch>(x => true).ToListAsync();
        }

        async public Task<RootMatch> CreateRootMatch(RootMatch rootMatch)
        {
            await _collection.InsertOneAsync(rootMatch);
            return rootMatch;
        }
        async public Task<bool> UpdateRootMatch(RootMatch rootMatchs)
        {
            try
            {
                var result = await _collection.ReplaceOneAsync(x => x.Id == rootMatchs.Id, rootMatchs);
                return result.IsAcknowledged && result.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }

        }
        public void RemoveRootMatch(Filter filter)
        {
            _collection.DeleteOne(x => x.Filters == filter);
        }
    }
}
