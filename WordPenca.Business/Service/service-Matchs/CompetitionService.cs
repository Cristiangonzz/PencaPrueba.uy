using Microsoft.Extensions.Options;
using MongoDB.Driver;

using WordPenca.Business.Domain;

namespace WordPenca.Business.Service
{

    public class CompetitionService
    {

        private IMongoCollection<Competition> _collection;
        public CompetitionService(IMongoClient mongoClient, IOptions<MongoDbSettings> mongoDbSettings)
        {
            var database = mongoClient.GetDatabase(mongoDbSettings.Value.DataBase);
            _collection = database.GetCollection<Competition>(mongoDbSettings.Value.CompetitionCollection);
        }
        async public Task<Competition> GetCompetition(int id)
        {
            return _collection.Find<Competition>(x => x.id == id).FirstOrDefault();
        }
        async public Task<List<Competition>> GetCompetitions()
        {
            return await _collection.Find<Competition>(x => true).ToListAsync();
        }

        async public Task<Competition> CreateCompetition(Competition c)
        {
            try
            {
                var competition = _collection.Find<Competition>(x => x.id == c.id).FirstOrDefault();
                if (competition == null)
                {
                    await _collection.InsertOneAsync(c);
                    return c;
                }
                return null;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        async public Task<bool> CreateCompetitions(List<Competition> c)
        {
            try
            {
                await _collection.InsertManyAsync(c);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        async public Task<bool> UpdateCompetitions(List<Competition> c)
        {
            try
            {
                foreach (var competition in c)
                {
                    _collection.ReplaceOne(x => x.id == competition.id, competition);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }


        async public Task<bool> CreateCompetitionsToMatchs(List<Match> c)
        {
            try
            {
                foreach (var match in c)
                {
                    var competition = _collection.Find<Competition>(x => x.id == match.competition.id).FirstOrDefault();
                    if (competition == null)
                    {
                        await _collection.InsertOneAsync(competition);
                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        async public Task<bool> UpdateCompetitionsToMatchs(List<Match> c)
        {
            try
            {
                foreach (var match in c)
                {
                    var competition = _collection.Find<Competition>(x => x.id == match.competition.id).FirstOrDefault();
                    if (competition != null)
                    {
                        _collection.ReplaceOne(x => x.id == competition.id, competition);
                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        async public Task<bool> UpdateCompetition(int id, Competition competition)
        {
            try
            {
                _collection.ReplaceOne(x => x.id == id, competition);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }

        }
        public void RemoveCompetition(int id)
        {
            _collection.DeleteOne(x => x.id == id);
        }
    }
}
