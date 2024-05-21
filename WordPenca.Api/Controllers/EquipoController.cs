using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WordPenca.Common.Dto;
using WordPenca.Business.Domain;
using Microsoft.AspNetCore.SignalR;
using WordPenca.Api.Hubs;
using WordPenca.Business.Repository.Interface;


namespace WordPenca.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EquipoController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        private readonly IHubContext<MessageHub> _hubContext;

        private readonly IHttpClientFactory _httpClientFactory;
        public EquipoController(IHttpClientFactory httpClientFactory, IUnitOfWork unitOfWork, IMapper mapper, IHubContext<MessageHub> hubContext)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            _httpClientFactory = httpClientFactory;
            _hubContext = hubContext;
        }


        [HttpGet]
        [Route("Matches")]
        public async Task<IActionResult> GetMatches()
        {
            var client = _httpClientFactory.CreateClient();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.football-data.org/v4/matches"),
                Headers =
                {
                    { "X-Auth-Token", "5e5f4b403ed749dcb7065634af5e8dc4" }
                },
            };
            string chatId = "";
            string usuarioId = "";

            //NewMessage message = new NewMessage("Api de Match", chatId, usuarioId);
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);

                    //await _hubContext.Clients.Group(message.ChatId).SendAsync("NewMessage", message);

                    return StatusCode(StatusCodes.Status200OK, body);
                }
                else
                {
                    // Si la solicitud no fue exitosa, devuelve el código de estado de la respuesta
                    return StatusCode((int)response.StatusCode);
                }

            }

        }



        [HttpPost]
        [Route("Crear")]
        public async Task<IActionResult> Create([FromBody] EquipoDTO request)
        {

            ResponseDTO<EquipoDTO> _ResponseDTO = new ResponseDTO<EquipoDTO>();
            try
            {
                Equipo _producto = _mapper.Map<Equipo>(request);


                _producto = await this._unitOfWork.Equipo.Add(_producto);

                if (_producto.id != null)
                    _ResponseDTO = new ResponseDTO<EquipoDTO>() { status = true, msg = "ok", value = _mapper.Map<EquipoDTO>(_producto) };
                else
                    _ResponseDTO = new ResponseDTO<EquipoDTO>() { status = false, msg = "No se pudo crear el producto" };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<EquipoDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListGetAll()
        {

            ResponseDTO<List<EquipoDTO>> _ResponseDTO = new ResponseDTO<List<EquipoDTO>>();

            try
            {
                List<EquipoDTO> ListaEquiposDto = new List<EquipoDTO>();
                IEnumerable<Equipo> listEquipos = await this._unitOfWork.Equipo.GetAll();


                ListaEquiposDto = _mapper.Map<List<EquipoDTO>>(listEquipos.ToList());

                if (ListaEquiposDto.Count > 0)
                    _ResponseDTO = new ResponseDTO<List<EquipoDTO>>() { status = true, msg = "ok", value = ListaEquiposDto };
                else
                    _ResponseDTO = new ResponseDTO<List<EquipoDTO>>() { status = false, msg = "Lista Vacia", value = null };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<EquipoDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
            //var ListEquipos = dbContext.Equipos.ToList();

            //return Ok(ListEquipos);

        }

        [HttpPut]
        [Route("Editar/{Id:Guid}")]
        public async Task<IActionResult> Editar([FromBody] EquipoDTO request, [FromRoute] Guid id)
        {
            ResponseDTO<bool> _ResponseDTO = new ResponseDTO<bool>();
            try
            {
                Equipo _equipo = _mapper.Map<Equipo>(request);
                Equipo _equipoParaEditar = await this._unitOfWork.Equipo.GetFirstOrDefault(u => u.id == id);

                if (_equipoParaEditar != null)
                {

                    _equipoParaEditar.name = _equipo.name;

                    try
                    {
                        this._unitOfWork.Equipo.Update(_equipoParaEditar);
                        _ResponseDTO = new ResponseDTO<bool>() { status = true, msg = "ok", value = true };

                    }
                    catch (Exception ex)
                    {
                        _ResponseDTO = new ResponseDTO<bool>() { status = false, msg = "No se pudo editar el producto : " + ex.Message };
                        return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
                    }
                }
                else
                {
                    _ResponseDTO = new ResponseDTO<bool>() { status = false, msg = "No se encontró el producto" };
                }

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<bool>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }
    }
}
