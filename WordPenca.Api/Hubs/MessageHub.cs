using Microsoft.AspNetCore.SignalR;
using MongoDB.Bson;
using MongoDB.Driver;
using WordPenca.Business.Domain;
using WordPenca.Business.Repository.Interface;

namespace WordPenca.Api.Hubs
{
    public class MessageHub : Hub
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMongoCollection<Chat> _chatCollection;
        private readonly IMongoCollection<ChatHistorial> _chatHistorialCollection;

        private readonly IMongoCollection<ChatMensaje> _chatMensajesCollection;
        public MessageHub(IUnitOfWork unitOfWork, IMongoClient mongoClient)
        {
            this._unitOfWork = unitOfWork;
            var database = mongoClient.GetDatabase("TuPencaChat");
            _chatCollection = database.GetCollection<Chat>("Chat");
            _chatHistorialCollection = database.GetCollection<ChatHistorial>("ChatHistorial");
            _chatMensajesCollection = database.GetCollection<ChatMensaje>("ChatMensaje");
        }

        public async Task JoinGroup(string userName, string chatId, string usuarioId)
        {

            try
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, chatId);
                await Clients.Group(chatId).SendAsync("NewUser", $"{userName} entró al canal");
            }
            catch (Exception ex)
            {
                // Manejo del error de formato de GUID
                Console.WriteLine($"Error En enviar el mensaje: {ex.Message}");
            }




            try
            {

                ChatMensaje mensaje = new ChatMensaje
                {

                    Id = ObjectId.GenerateNewId().ToString(),
                    mensaje = $"{userName} entró al canal",
                    CreationDate = DateTime.Now,
                    Usuario = usuarioId,
                    activo = false,
                    Description = "Entrada al canal"
                };



                await _chatMensajesCollection.InsertOneAsync(mensaje);

                //Respaldos en el historial
                var filterHistorial = Builders<ChatHistorial>.Filter.Eq(historial => historial.chat.Id, chatId);
                var updateHistorial = Builders<ChatHistorial>.Update
                .Push(historial => historial.Mensajes, mensaje)
                .Set(historial => historial.UltimaActualizacion, DateTime.Now);

                await _chatHistorialCollection.UpdateOneAsync(filterHistorial, updateHistorial);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public async Task LeaveGroup(string userName, string chatId, string usuarioId)
        {

            try
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatId);
                await Clients.Group(chatId).SendAsync("NewUser", $"{userName} Salio del canal");
            }
            catch (Exception ex)
            {
                // Manejo del error de formato de GUID
                Console.WriteLine($"Error En enviar el mensaje: {ex.Message}");
            }


            try
            {
                ChatMensaje mensaje = new ChatMensaje
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    mensaje = $"{userName} salió del canal",
                    CreationDate = DateTime.Now,
                    Usuario = usuarioId,
                    activo = false,
                    Description = "Salida del canal"
                };

                await _chatMensajesCollection.InsertOneAsync(mensaje);

                //Respaldos en el historial
                var filterHistorial = Builders<ChatHistorial>.Filter.Eq(historial => historial.chat.Id, chatId);
                var updateHistorial = Builders<ChatHistorial>.Update
                    .Push(historial => historial.Mensajes, mensaje)
                    .Set(historial => historial.UltimaActualizacion, DateTime.Now);

                await _chatHistorialCollection.UpdateOneAsync(filterHistorial, updateHistorial);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }

        public async Task SendMessage(NewMessage message)
        {
            try
            {
                EnviarMessage messageToSend = new EnviarMessage(message.UserName, message.Message);
                await Clients.Group(message.ChatId).SendAsync("NewMessage", messageToSend);
            }
            catch (Exception ex)
            {
                // Manejo del error de formato de GUID
                Console.WriteLine($"Error En enviar el mensaje: {ex.Message}");
            }

            try
            {

                ChatMensaje mensaje = new ChatMensaje
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    mensaje = $"{message.UserName} entró al canal",
                    CreationDate = DateTime.Now,
                    Usuario = message.UsuarioId,
                    activo = false,
                    Description = "Mensaje enviado"
                };


                // Insertar mensaje en la colección de mensajes
                await _chatMensajesCollection.InsertOneAsync(mensaje);

                // Actualizar historial del chat
                var filterHistorial = Builders<ChatHistorial>.Filter.Eq(historial => historial.chat.Id, message.ChatId);
                var updateHistorial = Builders<ChatHistorial>.Update
                    .Push(historial => historial.Mensajes, mensaje)
                    .Set(historial => historial.UltimaActualizacion, DateTime.Now);

                await _chatHistorialCollection.UpdateOneAsync(filterHistorial, updateHistorial);

            }
            catch (Exception ex)
            {
                // Manejo del error de formato de GUID
                Console.WriteLine($"Error En enviar el mensaje: {ex.Message}");
            }


        }
    }
}
public record NewMessage(string? UserName, string Message, string ChatId, string UsuarioId);
public record EnviarMessage(string? UserName, string Message);