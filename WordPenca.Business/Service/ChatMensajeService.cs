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

    public class ChatMensajeService
    {
        
        private IMongoCollection<ChatMensaje> _collection;

     
        public ChatMensajeService(IMongoClient mongoClient, IOptions<MongoDbSettings> mongoDbSettings)
        {
            var database = mongoClient.GetDatabase(mongoDbSettings.Value.DataBase);
            _collection = database.GetCollection<ChatMensaje>(mongoDbSettings.Value.ChatMensajeCollection);
        }
        async public Task<ChatMensaje> GetChatMensaje(string id)
        {
            return _collection.Find<ChatMensaje>(x => x.Id == id).FirstOrDefault();
        }

        public List<ChatMensaje> GetChatMensajes()
        {
            return _collection.Find<ChatMensaje>(x => true).ToList();
        }
        async public Task<ChatMensaje> CreateChatMensaje(ChatMensaje chatMensaje)
        {
            await _collection.InsertOneAsync(chatMensaje);
            return chatMensaje;
        }
        public void UpdateChatMensaje(string id, ChatMensaje chatMensaje)
        {
            _collection.ReplaceOne(x => x.Id == id, chatMensaje);
        }
        public void RemoveChatMensaje(string id)
        {
            _collection.DeleteOne(x => x.Id == id);
        }


    }
}
