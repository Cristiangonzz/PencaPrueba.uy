using Microsoft.AspNetCore.SignalR;
using MongoDB.Bson;
using MongoDB.Driver;
using WordPenca.Business.Domain;
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
                ///Agrego el chat a la lista que tiene el usuario
                ChatUsuario chatUsuario = await _chatUsuarioService.GetUsuarioByChat(chatId);
                if (chatUsuario == null)
                {
                    chatUsuario = await _chatUsuarioService.AgregarChatAUsuario(usuarioId, chatId);
                    ChatMensaje mensaje = new ChatMensaje
                    {
                        Id = ObjectId.GenerateNewId().ToString(),
                        mensaje = $"{chatUsuario.Name} se unio al chat",
                        CreationDate = DateTime.Now,
                        Usuario = usuarioId,
                        UsuarioName = chatUsuario.Name,
                        activo = false,
                        Description = "Entrada al canal"
                    };


                    await Clients.Group(chatId).SendAsync("NewUser", mensaje);
                    ChatMensaje chatMensajeCreado = await _chatMensajeService.CreateChatMensaje(mensaje);
                    //Respaldos en el historial
                    ChatHistorial chatHistorial = await _chatHistorialService.GetChatHistorialByChat(chatId);
                    chatHistorial.Mensajes.Add(chatMensajeCreado);
                    chatHistorial.UltimaActualizacion = DateTime.Now;
                    await _chatHistorialService.UpdateChatHistorial(chatHistorial.Id, chatHistorial);

                }




            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public async Task JoinGroupMatch(){
            await Groups.AddToGroupAsync(Context.ConnectionId, "Match");
        }
        public async Task LeaveGroup(string chatId, string usuarioId)
        {
            try
            {

                ChatUsuario chatUsuario = await _chatUsuarioService.GetUsuarioByChat(chatId);
                if (chatUsuario != null)
                {
                    ChatMensaje mensajeSistema = new ChatMensaje
                    {
                        Id = ObjectId.GenerateNewId().ToString(),
                        mensaje = $"{chatUsuario.Name} salió del chat",
                        CreationDate = DateTime.Now,
                        Usuario = usuarioId,
                        UsuarioName = chatUsuario.Name,
                        activo = false,
                        Description = "Salida del canal"
                    };

                    ///Elimino el chat a la lista que tiene el usuario
                    chatUsuario.Chats.Remove(chatId);
                    await _chatUsuarioService.UpdateChatUsuario(chatUsuario.Id, chatUsuario);
                    await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatId);
                    await Clients.Group(chatId).SendAsync("LeftUser", mensajeSistema);

                    ChatMensaje mensaje = new ChatMensaje
                    {
                        Id = ObjectId.GenerateNewId().ToString(),
                        mensaje = $"{chatUsuario.Name} salió del canal",
                        CreationDate = DateTime.Now,
                        Usuario = usuarioId,
                        UsuarioName = chatUsuario.Name,
                        activo = false,
                        Description = "Salida del canal"
                    };


                    ChatMensaje mensajeCreado = await _chatMensajeService.CreateChatMensaje(mensaje);

                    //Respaldos en el historial
                    ChatHistorial chatHistorial = await _chatHistorialService.GetChatHistorialByChat(chatId);
                    chatHistorial.Mensajes.Add(mensajeCreado);
                    chatHistorial.UltimaActualizacion = DateTime.Now;
                    await _chatHistorialService.UpdateChatHistorial(chatHistorial.Id, chatHistorial);


                }




            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public async Task SendMessage(NewMessage message)
        {
            try
            {

                ChatMensaje mensaje = new ChatMensaje
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    mensaje = message.Message,
                    CreationDate = DateTime.Now,
                    Usuario = message.UsuarioId,
                    UsuarioName = message.UsuarioName,
                    activo = false,
                    Description = "Mensaje enviado"
                };
                if (message.respuestaMensaje != null)
                {
                    mensaje.RespuestaMensaje = message.respuestaMensaje;
                }


                // Insertar mensaje en la colección de mensajes
                ChatMensaje mensajeCreado = await _chatMensajeService.CreateChatMensaje(mensaje);

                await Clients.Group(message.ChatId).SendAsync("NewMessage", mensaje);

                // Actualizar historial del chat
                //Respaldos en el historial

                ChatHistorial chatHistorial = await _chatHistorialService.GetChatHistorialByChat(message.ChatId);
                chatHistorial.Mensajes.Add(mensajeCreado);
                chatHistorial.UltimaActualizacion = DateTime.Now;
                await _chatHistorialService.UpdateChatHistorial(chatHistorial.Id, chatHistorial);

            }
            catch (Exception ex)
            {
                // Manejo del error de formato de GUID
                Console.WriteLine($"Error En enviar el mensaje: {ex.Message}");
            }


        }
    }
}
public record NewMessage(string Message, string ChatId, string UsuarioId, string UsuarioName, string? respuestaMensaje);