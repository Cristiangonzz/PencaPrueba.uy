using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WordPenca.Common.Dto;
using WordPenca.Business.Domain;
using Microsoft.AspNetCore.SignalR;
using WordPenca.Api.Hubs;
using WordPenca.Business.Repository.Interface;
using System;
using WordPenca.Business.Service;


namespace WordPenca.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ChatUsuarioService _chatUsuarioService;
        private readonly IMapper _mapper;



        public UsuarioController(ChatUsuarioService chatUsuarioService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._chatUsuarioService = chatUsuarioService;

        }

        [HttpPost]
        [Route("CrearUsuario")]
        public async Task<IActionResult> CreateUsuario([FromBody] UsuarioDTO request)
        {
            ResponseDTO<UsuarioDTO> _ResponseDTO = new ResponseDTO<UsuarioDTO>();
            try
            {

                Usuario usuario = _mapper.Map<Usuario>(request);
                
                usuario = await this._unitOfWork.Usuario.Add(usuario);
                this._unitOfWork.Save();

                //Creamos los mismos datos para mongo
                ChatUsuario chatUsuario = new ChatUsuario
                {
                    Id = usuario.Id.ToString(),
                    Name = usuario.Name,
                    Chats = new List<string>()
                };
                await this._chatUsuarioService.CreateChatUsuario(chatUsuario);
                _ResponseDTO = new ResponseDTO<UsuarioDTO>() { status = true, msg = "ok", value = _mapper.Map<UsuarioDTO>(usuario) };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<UsuarioDTO>() { status = false, msg = "No se pudo crear el producto" + ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListGetAll()
        {

            ResponseDTO<List<UsuarioDTO>> _ResponseDTO = new ResponseDTO<List<UsuarioDTO>>();

            try
            {
                List<UsuarioDTO> ListaUsuarioDto = new List<UsuarioDTO>();
                IEnumerable<Usuario> listUsuario = await this._unitOfWork.Usuario.GetAll();


                ListaUsuarioDto = _mapper.Map<List<UsuarioDTO>>(listUsuario.ToList());

                if (ListaUsuarioDto.Count > 0)
                    _ResponseDTO = new ResponseDTO<List<UsuarioDTO>>() { status = true, msg = "ok", value = ListaUsuarioDto };
                else
                    _ResponseDTO = new ResponseDTO<List<UsuarioDTO>>() { status = false, msg = "Lista Vacia", value = null };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<UsuarioDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
            //var ListEquipos = dbContext.Equipos.ToList();

            //return Ok(ListEquipos);

        }
    }
}
