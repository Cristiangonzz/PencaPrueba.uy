using Firebase.Auth;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPenca.Business.Domain;

namespace WordPenca.Business.Service
{

    public class ChatService
    {
        
        private IMongoCollection<Chat> _collection;
        public ChatService(IMongoClient mongoClient, IOptions<MongoDbSettings> mongoDbSettings)
        {
            var database = mongoClient.GetDatabase(mongoDbSettings.Value.DataBase);
            _collection = database.GetCollection<Chat>(mongoDbSettings.Value.ChatCollection);
        }
        async public Task<Chat> GetChat(string id)
        {
            return _collection.Find<Chat>(x => x.Id == id).FirstOrDefault();
        }
        async public Task<List<Chat>> GetChats()
        {
            return await _collection.Find<Chat>(x => true).ToListAsync();
        }
        async public Task<List<Chat>> GetChatUser(string userId) // Solo traer los chat que contengan este usuario
        {
           
            var filter = Builders<Chat>.Filter.ElemMatch(chat => chat.Usuarios, usuario => usuario.Id == userId);
            return await _collection.Find(filter).ToListAsync();
        }
        async public Task<Chat> CreateChat(Chat chat)
        {
            await _collection.InsertOneAsync(chat);
            return chat;
        }
        async public Task<bool> UpdateChat(string id, Chat chat)
        {
            try
            {
                _collection.ReplaceOne(x => x.Id == id, chat);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            
                return false;
            }
            
        }
        public void RemoveChat(string id)
        {
            _collection.DeleteOne(x => x.Id == id);
        }



    }
}
