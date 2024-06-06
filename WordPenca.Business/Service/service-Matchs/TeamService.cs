using Microsoft.Extensions.Options;
using MongoDB.Driver;

using WordPenca.Business.Domain;

namespace WordPenca.Business.Service
{

    public class TeamService
    {
        private IMongoCollection<Team> _collection;
        public TeamService(IMongoClient mongoClient, IOptions<MongoDbSettings> mongoDbSettings)
        {
            var database = mongoClient.GetDatabase(mongoDbSettings.Value.DataBase);
            _collection = database.GetCollection<Team>(mongoDbSettings.Value.TeamCollection);
        }
        async public Task<Team> GetTeam(int id)
        {
            return _collection.Find<Team>(x => x.id == id).FirstOrDefault();
        }
        async public Task<List<Team>> GetTeams()
        {
            return await _collection.Find<Team>(x => true).ToListAsync();
        }



        async public Task<Team> CreateTeam(Team t)
        {
            try
            {
                var team = _collection.Find<Team>(x => x.id == t.id).FirstOrDefault();
                if (team == null)
                {
                    await _collection.InsertOneAsync(t);
                    return t;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        async public Task<bool> CreateTeamsToMatchs(List<Match> c)
        {
            try
            {
                foreach (var match in c)
                {
                    var team = _collection.Find<Team>(x => x.id == match.homeTeam.id).FirstOrDefault();
                    if (team == null)
                    {
                        await _collection.InsertOneAsync(match.homeTeam);
                    }
                    team = _collection.Find<Team>(x => x.id == match.awayTeam.id).FirstOrDefault();
                    if (team == null)
                    {
                        await _collection.InsertOneAsync(match.awayTeam);
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


        async public Task<bool> UpdateTeamsToMatchs(List<Match> c)
        {
            try
            {
                foreach (var match in c)
                {
                    var team = _collection.Find<Team>(x => x.id == match.homeTeam.id).FirstOrDefault();
                    if (team != null)
                    {
                        _collection.ReplaceOne(x => x.id == team.id, team);
                    }
                    var team2 = _collection.Find<Team>(x => x.id == match.awayTeam.id).FirstOrDefault();
                    if (team2 != null)
                    {
                        _collection.ReplaceOne(x => x.id == team2.id, team2);
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


        async public Task<bool> UpdateTeams(List<Team> c)
        {
            try
            {
                foreach (var team in c)
                {
                    _collection.ReplaceOne(x => x.id == team.id, team);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        async public Task<bool> UpdateTeam(int id, Team t)
        {
            try
            {
                _collection.ReplaceOne(x => x.id == id, t);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }

        }
        public void RemoveTeam(int id)
        {
            _collection.DeleteOne(x => x.id == id);
        }
    }
}
