using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WordPenca.Common.Dto;
using WordPenca.Business.Domain;
using Microsoft.AspNetCore.SignalR;
using WordPenca.Api.Hubs;
using WordPenca.Business.Repository.Interface;
using System;
using MongoDB.Driver;
using MongoDB.Bson;
using WordPenca.Business.Service;
using Microsoft.AspNetCore.Identity.Data;


namespace WordPenca.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        private readonly ChatService _chatService;
        private readonly ChatHistorialService _chatHistorialService;
        private readonly ChatMensajeService _chatMensajeService;
        private readonly ChatUsuarioService _chatUsuarioService;

        public ChatController(ChatUsuarioService chatUsuarioService, ChatService chatService, ChatHistorialService chatHistorialService, ChatMensajeService _chatMensajeService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._chatService = chatService;
            this._chatHistorialService = chatHistorialService;
            this._chatMensajeService = _chatMensajeService;
            this._chatUsuarioService = chatUsuarioService;


            this._unitOfWork = unitOfWork;
            this._mapper = mapper;

        }

        [HttpPost]
        [Route("CrearChat")]
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
        [HttpPost]
        [Route("CrearMensaje")]
        public async Task<IActionResult> CreateChatMensaje([FromBody] ChatMensajeDTO request)
        {
            ResponseDTO<ChatMensaje> _ResponseDTO = new ResponseDTO<ChatMensaje>();
            try
            {
                ChatMensaje chatMensaje = new ChatMensaje
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    mensaje = request.mensaje!,
                    Usuario = request.usuario!,
                    UsuarioName = request.usuarioName!,
                    activo = false,
                    CreationDate = DateTime.UtcNow,

                };

                ChatMensaje chatMensajeCreado = await _chatMensajeService.CreateChatMensaje(chatMensaje);

                try
                {
                    ChatHistorial chatHistorial = await this._chatHistorialService.GetChatHistorialByChat(request.chatId);
                    Console.WriteLine("Historial encontrado id: " + chatHistorial.Id);
                    chatHistorial.Mensajes.Add(chatMensajeCreado);
                    bool updateado = await this._chatHistorialService.UpdateChatHistorial(chatHistorial.Id, chatHistorial);
                    if (!updateado)
                    {
                        _ResponseDTO = new ResponseDTO<ChatMensaje> { status = false, msg = "El mensaje no se puedo guradar en el historial " };
                        return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
                    }
                    _ResponseDTO = new ResponseDTO<ChatMensaje>() { status = true, msg = "ok", value = chatMensajeCreado };

                }
                catch (Exception ex)
                {

                    _ResponseDTO = new ResponseDTO<ChatMensaje> { status = false, msg = "Fallo el agregar el mensaje al Historial ---- " + ex.ToString() };
                    return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
                }



                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<ChatMensaje> { status = false, msg = "No se pudo crear el producto: " + ex.ToString() };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }

        }

        [HttpGet]
        [Route("obtenerChatHistorial/{idChatHistorial}")]
        public async Task<IActionResult> ObtenerChatHistorial([FromRoute] string idChatHistorial)
        {

            ResponseDTO<ChatHistorial> _ResponseDTO = new ResponseDTO<ChatHistorial>();

            try
            {
                ChatHistorial chatHistorials = await this._chatHistorialService.GetChatHistorial(idChatHistorial);

                if (chatHistorials.Id != null)
                    _ResponseDTO = new ResponseDTO<ChatHistorial>() { status = true, msg = "ok", value = chatHistorials };
                else
                    _ResponseDTO = new ResponseDTO<ChatHistorial>() { status = false, msg = "Lista Vacia", value = null };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<ChatHistorial>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpGet]
        [Route("obtenerChat/{idChat}")]
        public async Task<IActionResult> ObtenerChat([FromRoute] string idChat)
        {

            ResponseDTO<Chat> _ResponseDTO = new ResponseDTO<Chat>();

            try
            {
                Chat chats = await this._chatService.GetChat(idChat);

                if (chats.Id != null)
                    _ResponseDTO = new ResponseDTO<Chat>() { status = true, msg = "ok", value = chats };
                else
                    _ResponseDTO = new ResponseDTO<Chat>() { status = false, msg = "Lista Vacia", value = null };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<Chat>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpGet]
        [Route("obtenerHistorialChat/{idChat}")]
        public async Task<IActionResult> ObtenerHistorialChat([FromRoute] string idChat)
        {

            ResponseDTO<ChatHistorial> _ResponseDTO = new ResponseDTO<ChatHistorial>();

            try
            {
                ChatHistorial historial = await this._chatHistorialService.GetChatHistorialByChat(idChat);


                if (historial.Id != null)
                    _ResponseDTO = new ResponseDTO<ChatHistorial>() { status = true, msg = "ok", value = historial };
                else
                    _ResponseDTO = new ResponseDTO<ChatHistorial>() { status = false, msg = "Lista Vacia", value = null };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<ChatHistorial>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }


        [HttpGet]
        [Route("obtenerChatUsuario/{idUser}")]
        public async Task<IActionResult> ListGetAll([FromRoute] string idUser)
        {

            ResponseDTO<List<ChatDTO>> _ResponseDTO = new ResponseDTO<List<ChatDTO>>();

            try
            {

                var chats = await this._chatService.GetChatUser(idUser);

                List<ChatDTO> listaChat = chats.Select(chat => _mapper.Map<ChatDTO>(chat)).ToList();



                if (listaChat.Count > 0)
                    _ResponseDTO = new ResponseDTO<List<ChatDTO>>() { status = true, msg = "ok", value = listaChat };
                else
                    _ResponseDTO = new ResponseDTO<List<ChatDTO>>() { status = false, msg = "Lista Vacia", value = null };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<ChatDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpGet]
        [Route("getAllChats")]
        public async Task<IActionResult> ListGetAllChat()
        {

            ResponseDTO<List<Chat>> _ResponseDTO = new ResponseDTO<List<Chat>>();

            try
            {

                List<Chat> listChats = await this._chatService.GetChats();



                if (listChats.Count > 0)
                    _ResponseDTO = new ResponseDTO<List<Chat>>() { status = true, msg = "ok", value = listChats };

                else
                    _ResponseDTO = new ResponseDTO<List<Chat>>() { status = false, msg = "Lista Vacia", value = null };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<Chat>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }


        [HttpGet]
        [Route("getAllChatUsuarios")]
        public async Task<IActionResult> ListGetAllChatUsuarios()
        {

            ResponseDTO<List<ChatUsuario>> _ResponseDTO = new ResponseDTO<List<ChatUsuario>>();

            try
            {

                List<ChatUsuario> listChatUsuarios = await this._chatUsuarioService.GetUsuarios();



                if (listChatUsuarios.Count > 0)
                    _ResponseDTO = new ResponseDTO<List<ChatUsuario>>() { status = true, msg = "ok", value = listChatUsuarios };
                else
                    _ResponseDTO = new ResponseDTO<List<ChatUsuario>>() { status = false, msg = "Lista Vacia", value = null };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<ChatUsuario>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }


        [HttpGet]
        [Route("obtenerUsuario/{idUser}")]
        public async Task<IActionResult> GetUsuario([FromRoute] string idUser)
        {

            ResponseDTO<ChatUsuario> _ResponseDTO = new ResponseDTO<ChatUsuario>();

            try
            {

                ChatUsuario usuario = await this._chatUsuarioService.GetUsuario(idUser);



                if (usuario != null)
                    _ResponseDTO = new ResponseDTO<ChatUsuario>() { status = true, msg = "ok", value = usuario };
                else
                    _ResponseDTO = new ResponseDTO<ChatUsuario>() { status = false, msg = "Lista Vacia", value = null };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<ChatUsuario>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }
    }
}
