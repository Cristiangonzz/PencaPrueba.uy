using Microsoft.AspNetCore.SignalR;
using WordPenca.Business.Domain;
using WordPenca.Business.Repository.Interface;

namespace WordPenca.Api.Hubs
{
    public class MessageHub : Hub
    {
        private readonly IUnitOfWork _unitOfWork;
        public MessageHub(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
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
                    mensaje = $"{userName} entró al canal",
                    CreationDate = DateTime.Now,
                    Usuario = await _unitOfWork.Usuario.GetFirstOrDefault(x => x.Id == Guid.Parse(usuarioId)),
                    activo = false,
                    Description = "Entrada al canal"
                };

                mensaje.Usuario.Mensajes.Add(mensaje);//Le agregamos el mensaje al usuario
                _unitOfWork.Usuario.Update(mensaje.Usuario);

                
                //Respaldos en el historial
                ChatHistorial historial = await this._unitOfWork.ChatHistorial.GetFirstOrDefault(x => x.chat.Id == Guid.Parse(chatId));
                historial.UltimaActualizacion = DateTime.Now;
                historial.Mensajes.Add(mensaje);
                await this._unitOfWork.ChatHistorial.Update(historial);

                this._unitOfWork.Save();


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
                    mensaje = $"{userName} salió del canal",
                    CreationDate = DateTime.Now,
                    Usuario = await this._unitOfWork.Usuario.GetFirstOrDefault(x => x.Id == Guid.Parse(usuarioId)),
                    activo = false,
                    Description = "Salida del canal"
                };

                mensaje.Usuario.Mensajes.Add(mensaje);//Le agregamos el mensaje al usuario
                _unitOfWork.Usuario.Update(mensaje.Usuario);

                //Respaldos en el historial
                ChatHistorial historial = await this._unitOfWork.ChatHistorial.GetFirstOrDefault(x => x.chat.Id == Guid.Parse(chatId));
                historial.UltimaActualizacion = DateTime.Now;
                historial.Mensajes.Add(mensaje);
                await this._unitOfWork.ChatHistorial.Update(historial);
                this._unitOfWork.Save();

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
                    mensaje = $"{message.UserName} entró al canal",
                    CreationDate = DateTime.Now,
                    Usuario = await _unitOfWork.Usuario.GetFirstOrDefault(x => x.Id == Guid.Parse(message.UsuarioId)),
                    activo = false,
                    Description = "Mensaje enviado"
                };

                mensaje.Usuario.Mensajes.Add(mensaje);//Le agregamos el mensaje al usuario
                _unitOfWork.Usuario.Update(mensaje.Usuario);



                //Respaldos en el historial
                ChatHistorial historial = await _unitOfWork.ChatHistorial.GetFirstOrDefault(x => x.chat.Id == Guid.Parse(message.ChatId));
                historial.UltimaActualizacion = DateTime.Now;
                historial.Mensajes.Add(mensaje);
                await this._unitOfWork.ChatHistorial.Update(historial);
                this._unitOfWork.Save();

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