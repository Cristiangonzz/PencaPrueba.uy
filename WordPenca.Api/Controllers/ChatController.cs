using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WordPenca.Common.Dto;
using WordPenca.Business.Domain;
using Microsoft.AspNetCore.SignalR;
using WordPenca.Api.Hubs;
using WordPenca.Business.Repository.Interface;
using System;


namespace WordPenca.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;



        public ChatController(IHttpClientFactory httpClientFactory, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;

        }

        [HttpPost]
        [Route("CrearChat")]
        public async Task<IActionResult> CreateChat([FromBody] ChatDTO request)
        {
            ResponseDTO<ChatDTO> _ResponseDTO = new ResponseDTO<ChatDTO>();
            try
            {

                Chat chat = _mapper.Map<Chat>(request);

                ChatHistorial chatHistorial = new ChatHistorial();
                chatHistorial.chat = chat;
                chatHistorial.UltimaActualizacion = DateTime.Now;

                chat = await this._unitOfWork.Chat.Add(chat);
                chatHistorial = await this._unitOfWork.ChatHistorial.Add(chatHistorial);
                this._unitOfWork.Save();
                

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
        public async Task<IActionResult> ListGetAll(Guid userId)
        {

            ResponseDTO<List<ChatDTO>> _ResponseDTO = new ResponseDTO<List<ChatDTO>>();

            try
            {
                List<ChatDTO> listaChat = new List<ChatDTO>();


                IEnumerable<Chat> chats = await this._unitOfWork.Chat.GetAll(chat => chat.Usuarios.Any(u => u.Id == userId), includeProperties: "Usuarios");


                listaChat = _mapper.Map<List<ChatDTO>>(chats.ToList());

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
