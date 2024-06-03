
using Microsoft.AspNetCore.Mvc;
using WordPenca.Business.Persistence;

namespace WordPenca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidoController : ControllerBase
    {
        public readonly ApplicationDbContext dbContext;

        public PartidoController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        [Route("CrearPartido")]
        public async Task<IActionResult> CreateChat([FromBody] ChatDTO request)
        {
            ResponseDTO<Chat> _ResponseDTO = new ResponseDTO<Chat>();
            try
            {
                ChatUsuario chatUsuario = await this._chatUsuarioService.GetUsuario(request.usuarioCreadorId);
                Chat chat = new Chat
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    privado = request.Privado,
                    Usuarios = new List<ChatUsuario> { chatUsuario }
                };

                if (request.Privado && request.usuarioInvitadoId != null)
                {
                    ChatUsuario chatUsuarioInvitado = await this._chatUsuarioService.GetUsuario(request.usuarioInvitadoId);
                    await this._chatUsuarioService.AgregarChatAUsuario(request.usuarioInvitadoId, chat.Id);
                    chat.Usuarios.Add(chatUsuarioInvitado);

                }
                else
                {
                    chat.Description = request.Description;
                    chat.Name = request.Name;
                }

                await this._chatUsuarioService.AgregarChatAUsuario(request.usuarioCreadorId, chat.Id);//Este chat nuevo se lo agrego al usuario

                Chat chatCreado = await _chatService.CreateChat(chat);

                ChatHistorial chatHistorial = new ChatHistorial
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    chat = chatCreado,
                    Mensajes = new List<ChatMensaje>(),
                    UltimaActualizacion = DateTime.UtcNow
                };
                ChatHistorial historialCreado = await this._chatHistorialService.CreateChatHistorial(chatHistorial);
                chatCreado.Historial = historialCreado;

                await _chatService.UpdateChat(chatCreado.Id, chatCreado);


                _ResponseDTO = new ResponseDTO<Chat>() { status = true, msg = "ok", value = chatCreado };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<Chat> { status = false, msg = "No se pudo crear el producto: " + ex.ToString() };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }

        }

    }
}
