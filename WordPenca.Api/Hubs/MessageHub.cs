using Microsoft.AspNetCore.SignalR;
using MongoDB.Bson;
using MongoDB.Driver;
using WordPenca.Business.Domain;
using WordPenca.Business.Repository.Interface;
using WordPenca.Business.Service;

namespace WordPenca.Api.Hubs
{
    public class MessageHub : Hub
    {
        public ChatService _chatService;
        public ChatHistorialService _chatHistorialService;
        public ChatMensajeService _chatMensajeService;
        public ChatUsuarioService _chatUsuarioService;


        public MessageHub(ChatUsuarioService chatUsuarioService, ChatService chatService, ChatHistorialService chatHistorialService, ChatMensajeService _chatMensajeService, IMongoClient mongoClient)
        {
            this._chatService = chatService;
            this._chatHistorialService = chatHistorialService;
            this._chatMensajeService = _chatMensajeService;
            this._chatUsuarioService = chatUsuarioService;

        }

        public async Task JoinGroup(string chatId, string usuarioId)
        {
            //Falta recargar el histoprial cuando entre al chat
          
            try
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, chatId);
                await Clients.Group(chatId).SendAsync("NewUser", $"{usuarioId} entró al canal");

                ///Agrego el chat a la lista que tiene el usuario
                ChatUsuario chatUsuario = await this._chatUsuarioService.GetUsuarioByChat(chatId);
                if (chatUsuario == null)
                {
                    bool agregarEstado = await this._chatUsuarioService.AgregarChatAUsuario(usuarioId, chatId);
                }
               
                ChatMensaje mensaje = new ChatMensaje
                {

                    Id = ObjectId.GenerateNewId().ToString(),
                    mensaje = $"{usuarioId} entró al canal",
                    CreationDate = DateTime.Now,
                    Usuario = usuarioId,
                    activo = false,
                    Description = "Entrada al canal"
                };



                ChatMensaje chatMensajeCreado =  await _chatMensajeService.CreateChatMensaje(mensaje);

                //Respaldos en el historial

                ChatHistorial chatHistorial = await _chatHistorialService.GetChatHistorialByChat(chatId);
                chatHistorial.Mensajes.Add(chatMensajeCreado);
                chatHistorial.UltimaActualizacion = DateTime.Now;
                bool estado = await _chatHistorialService.UpdateChatHistorial(chatHistorial.Id,chatHistorial);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public async Task LeaveGroup(string chatId, string usuarioId)
        {
            try
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatId);
                await Clients.Group(chatId).SendAsync("LeftUser", $"{usuarioId} Salio del canal");

                ChatMensaje mensaje = new ChatMensaje
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    mensaje = $"{usuarioId} salió del canal",
                    CreationDate = DateTime.Now,
                    Usuario = usuarioId,
                    activo = false,
                    Description = "Salida del canal"
                };

                ChatMensaje mensajeCreado = await _chatMensajeService.CreateChatMensaje(mensaje);

                //Respaldos en el historial
                ChatHistorial chatHistorial = await _chatHistorialService.GetChatHistorialByChat(chatId);
                chatHistorial.Mensajes.Add(mensajeCreado);
                chatHistorial.UltimaActualizacion = DateTime.Now;
                bool estado = await _chatHistorialService.UpdateChatHistorial(chatHistorial.Id, chatHistorial);
                if (estado)
                {
                    Console.WriteLine("Se Actualizo el historial");
                }
                else
                {
                    Console.WriteLine("Error al actualizar el historial");
                }
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
                EnviarMessage messageToSend = new EnviarMessage(message.UsuarioId, message.Message);
                await Clients.Group(message.ChatId).SendAsync("NewMessage", messageToSend);

                ChatMensaje mensaje = new ChatMensaje
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    mensaje = message.Message,
                    CreationDate = DateTime.Now,
                    Usuario = message.UsuarioId,
                    activo = false,
                    Description = "Mensaje enviado"
                };


                // Insertar mensaje en la colección de mensajes
                ChatMensaje mensajeCreado = await _chatMensajeService.CreateChatMensaje(mensaje);

                // Actualizar historial del chat
                //Respaldos en el historial

                ChatHistorial chatHistorial = await _chatHistorialService.GetChatHistorialByChat(message.ChatId);
                chatHistorial.Mensajes.Add(mensajeCreado);
                chatHistorial.UltimaActualizacion = DateTime.Now;
                bool estado = await _chatHistorialService.UpdateChatHistorial(chatHistorial.Id, chatHistorial);
                if (estado)
                {
                    Console.WriteLine("Se Actualizo el historial");
                }
                else
                {
                    Console.WriteLine("Error al actualizar el historial");
                }
            }
            catch (Exception ex)
            {
                // Manejo del error de formato de GUID
                Console.WriteLine($"Error En enviar el mensaje: {ex.Message}");
            }


        }
    }
}
public record NewMessage(string Message, string ChatId, string UsuarioId);
public record EnviarMessage(string? UserName, string Message);