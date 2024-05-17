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


namespace WordPenca.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        private readonly IMongoCollection<Chat> _chatCollection;
        private readonly IMongoCollection<ChatHistorial> _chatHistorialCollection;

        private readonly IMongoCollection<ChatMensaje> _chatMensajesCollection;



        public ChatController(IMongoClient mongoClient, IUnitOfWork unitOfWork, IMapper mapper)
        {
            var database = mongoClient.GetDatabase("TuPencaChat");
            _chatCollection = database.GetCollection<Chat>("Chat");
            _chatHistorialCollection = database.GetCollection<ChatHistorial>("ChatHistorial");
            _chatMensajesCollection = database.GetCollection<ChatMensaje>("ChatMensaje");

            this._unitOfWork = unitOfWork;
            this._mapper = mapper;

        }

        [HttpPost]
        [Route("CrearChat/{idUser}")]
        public async Task<IActionResult> CreateChat([FromBody] ChatDTO request, [FromRoute] string idUser)
        {
            ResponseDTO<ChatDTO> _ResponseDTO = new ResponseDTO<ChatDTO>();
            try
            {

                Chat chat = new Chat();
                chat.Id = ObjectId.GenerateNewId().ToString();
                chat.Name = request.Name;
                chat.Description = request.Description;
                chat.Usuarios.Add(idUser);

                await _chatCollection.InsertOneAsync(chat);

                ChatHistorial chatHistorial = new ChatHistorial();
                chatHistorial.Id = ObjectId.GenerateNewId().ToString();
                chatHistorial.chat = chat;
                chatHistorial.UltimaActualizacion = DateTime.Now;
                await _chatHistorialCollection.InsertOneAsync(chatHistorial);



                _ResponseDTO = new ResponseDTO<ChatDTO>() { status = true, msg = "ok", value = _mapper.Map<ChatDTO>(chat) };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<ChatDTO>() { status = false, msg = "No se pudo crear el producto" + ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }

        }


        [HttpGet]
        [Route("getChat/{idUser}")]
        public async Task<IActionResult> ListGetAll([FromRoute] string idUser)
        {

            ResponseDTO<List<ChatDTO>> _ResponseDTO = new ResponseDTO<List<ChatDTO>>();

            try
            {

                var filter = Builders<Chat>.Filter.AnyEq(chat => chat.Usuarios, idUser);
                var chats = await _chatCollection.Find(filter).ToListAsync();

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
    }
}
