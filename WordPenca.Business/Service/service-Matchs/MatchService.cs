using Microsoft.Extensions.Options;
using MongoDB.Driver;

using WordPenca.Business.Domain;

namespace WordPenca.Business.Service
{

    public class MatchService
    {

        private IMongoCollection<Match> _collection;
        public MatchService(IMongoClient mongoClient, IOptions<MongoDbSettings> mongoDbSettings)
        {
            var database = mongoClient.GetDatabase(mongoDbSettings.Value.DataBase);
            _collection = database.GetCollection<Match>(mongoDbSettings.Value.MatchCollection);
        }
        async public Task<Match> GetMatch(int id)
        {
            return _collection.Find<Match>(x => x.id == id).FirstOrDefault();
        }
        async public Task<List<Match>> GetMatchs()
        {
            return await _collection.Find<Match>(x => true).ToListAsync();
        }

        async public Task<Match> CreateMatch(Match Match)
        {
            await _collection.InsertOneAsync(Match);
            return Match;
        }


        async public Task<bool> CreateMatchs(List<Match> Matchs)
        {
            try
            {
                await _collection.InsertManyAsync(Matchs);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        async public Task<bool> UpdateMatchs(List<Match> Matchs)
        {
            try
            {
                foreach (var Match in Matchs)
                {
                    _collection.ReplaceOne(x => x.id == Match.id, Match);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        async public Task<bool> UpdateMatch(int id, Match Match)
        {
            try
            {
                _collection.ReplaceOne(x => x.id == id, Match);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }

        }
        public void RemoveMatch(int id)
        {
            _collection.DeleteOne(x => x.id == id);
        }
    }
}
