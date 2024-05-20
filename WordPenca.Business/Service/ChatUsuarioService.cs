using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

using WordPenca.Business.Domain;

namespace WordPenca.Business.Service
{

    public class ChatUsuarioService
    {
        
        private IMongoCollection<ChatUsuario> _collection;

       
        public ChatUsuarioService(IMongoClient mongoClient, IOptions<MongoDbSettings> mongoDbSettings)
        {
            var database = mongoClient.GetDatabase(mongoDbSettings.Value.DataBase);
            _collection = database.GetCollection<ChatUsuario>(mongoDbSettings.Value.ChatUsuarioCollection);
        }
        async public Task<ChatUsuario> GetUsuario(string id)
        {
            return _collection.Find<ChatUsuario>(x => x.Id == id).FirstOrDefault();
        }
        async public Task<List<ChatUsuario>> GetUsuarios()
        {
            return await _collection.Find<ChatUsuario>(x => true).ToListAsync();
        }
        async public Task<ChatUsuario> GetUsuarioByChat(string idChat) // Solo traer los chat que contengan este usuario
        {
            return await _collection.Find<ChatUsuario>(x => x.Chats.Contains(idChat)).FirstOrDefaultAsync();
        }
        async public Task<ChatUsuario> CreateChatUsuario(ChatUsuario chatUsuario)
        {
            await _collection.InsertOneAsync(chatUsuario);
            return chatUsuario;
        }
        async public Task<bool> UpdateChatUsuario(string id, ChatUsuario chatUsuario)
        {
            try
            {
                _collection.ReplaceOne(x => x.Id == id, chatUsuario);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            
                return false;
            }
            
        }
        async public Task<bool> AgregarChatAUsuario(string idUsuario, string idChat)
        {
            try
            {
                ChatUsuario chatUsuario = await _collection.FindAsync<ChatUsuario>(x => x.Id == idUsuario).Result.FirstOrDefaultAsync();
                chatUsuario.Chats.Add(idChat);
                _collection.ReplaceOne(x => x.Id == idUsuario, chatUsuario);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se pudo agregar el chat a la lista de chat del usuario" + ex.Message);

                return false;
            }

        }

        public void RemoveChatUsuario(string id)
        {
            _collection.DeleteOne(x => x.Id == id);
        }

        //Funciones para la conexiones de los usuarios
        


    }
}
