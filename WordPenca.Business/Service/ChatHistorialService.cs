using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPenca.Business.Domain;

namespace WordPenca.Business.Service
{

    public class ChatHistorialService
    {
        
        private IMongoCollection<ChatHistorial> _collection;

        public ChatHistorialService(IMongoClient mongoClient, IOptions<MongoDbSettings> mongoDbSettings)
        {
            var database = mongoClient.GetDatabase(mongoDbSettings.Value.DataBase);
            _collection = database.GetCollection<ChatHistorial>(mongoDbSettings.Value.ChatHistorialCollection);
        }
        async public Task<ChatHistorial> GetChatHistorial(string id)
        {
            return _collection.Find<ChatHistorial>(x => x.Id == id).FirstOrDefault();
        }

        async public Task<ChatHistorial> GetChatHistorialByChat(string idChat)//Me retorna solo el historial del chat que le pase
        {
            return _collection.Find<ChatHistorial>(x => x.chat.Id == idChat).FirstOrDefault();
        }

        public List<ChatHistorial> GetChatHistorials()
        {
            return _collection.Find<ChatHistorial>(x => true).ToList();
        }
        async public Task<ChatHistorial> CreateChatHistorial(ChatHistorial chatHistorial)
        {
            await _collection.InsertOneAsync(chatHistorial);
            return chatHistorial;
        }
     
        async public Task<bool> UpdateChatHistorial(string id, ChatHistorial chatHistorial)
        {
            try
            {
                _collection.ReplaceOne(x => x.Id == id, chatHistorial);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }

        }


        public void RemoveChatHistorial(string id)
        {
            _collection.DeleteOne(x => x.Id == id);
        }


    }
}
