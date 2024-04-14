
//using AutoMapper;

//using Microsoft.AspNetCore.Mvc;
//using System.Text.Json;
//using Newtonsoft.Json;

//namespace AngularApp1.Server.Infraestructure.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class EquipoController : ControllerBase
//    {

//        private readonly IEquipoRepository _equipoRepositorio;

//        private readonly IMapper _mapper;

//        private readonly IHttpClientFactory _httpClientFactory;

//        public EquipoController(IHttpClientFactory httpClientFactory, IEquipoRepository equipoRepositorio, IMapper mapper)
//        {
//            this._equipoRepositorio = equipoRepositorio;
//            this._mapper = mapper;
//            _httpClientFactory = httpClientFactory;
//        }



//        [HttpGet]
//        [Route("Matches")]
//        public async Task<IActionResult> GetMatches()
//        {
//            var client = _httpClientFactory.CreateClient();

//            var request = new HttpRequestMessage
//            {
//                Method = HttpMethod.Get,
//                RequestUri = new Uri("https://api.football-data.org/v4/matches"),
//                Headers =
//                {
//                    { "X-Auth-Token", "5e5f4b403ed749dcb7065634af5e8dc4" }
//                },
//            };

//            using (var response = await client.SendAsync(request))
//            {
//                response.EnsureSuccessStatusCode();
                


//                if (response.IsSuccessStatusCode)
//                {
//                    var body = await response.Content.ReadAsStringAsync();
//                    Console.WriteLine(body);
//                    return StatusCode(StatusCodes.Status200OK, body);
//                }
//                else
//                {
//                    // Si la solicitud no fue exitosa, devuelve el código de estado de la respuesta
//                    return StatusCode((int)response.StatusCode);
//                }

//            }



//            //ResponseDTO<MatchDTO> _ResponseDTO = new ResponseDTO<MatchDTO>();
            

//            //// Configura la URL de la API externa
//            //var url = "https://api.football-data.org/v4/matches";

//            //// Configura el token de autenticación si es necesario
//            //client.DefaultRequestHeaders.Add("X-Auth-Token", "5e5f4b403ed749dcb7065634af5e8dc4");

//            //try
//            //{
//            //    // Realiza la solicitud HTTP GET a la API externa
//            //    var response = await client.GetAsync(url);

//            //    // Verifica si la solicitud fue exitosa (código de estado 200)
//            //    if (response.IsSuccessStatusCode)
//            //    {
//            //        var responseStream = await response.Content.ReadAsStreamAsync();
                   
//            //        return StatusCode(StatusCodes.Status200OK, responseStream);
//            //    }
//            //    else
//            //    {
//            //        // Si la solicitud no fue exitosa, devuelve el código de estado de la respuesta
//            //        return StatusCode((int)response.StatusCode);
//            //    }
//            //}
//            //catch (HttpRequestException)
//            //{
//            //    // Si ocurre un error al realizar la solicitud, devuelve un código de estado 500 (Error interno del servidor)
//            //    return StatusCode(500);
//            //}
//        }



//        [HttpPost]
//        [Route("Crear")]
//        public async Task<IActionResult> Create([FromBody] EquipoDTO request)
//        {

//            ResponseDTO<EquipoDTO> _ResponseDTO = new ResponseDTO<EquipoDTO>();
//            try
//            {
//                Equipo _producto = _mapper.Map<Equipo>(request);

//                Equipo _productoCreado = await _equipoRepositorio.Create(_producto);

//                if (_productoCreado.name != null)
//                    _ResponseDTO = new ResponseDTO<EquipoDTO>() { status = true, msg = "ok", value = _mapper.Map<EquipoDTO>(_productoCreado) };
//                else
//                    _ResponseDTO = new ResponseDTO<EquipoDTO>() { status = false, msg = "No se pudo crear el producto" };

//                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
//            }
//            catch (Exception ex)
//            {
//                _ResponseDTO = new ResponseDTO<EquipoDTO>() { status = false, msg = ex.Message };
//                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
//            }
//        }

//        [HttpGet]
//        public async Task<IActionResult> ListGetAll()
//        {

//            ResponseDTO<List<EquipoDTO>> _ResponseDTO = new ResponseDTO<List<EquipoDTO>>();

//            try
//            {
//                List<EquipoDTO> ListaEquipos = new List<EquipoDTO>();
//                IQueryable<Equipo> query = await _equipoRepositorio.Consultar();
//               // query = query.Include(r => r.IdCategoriaNavigation);

//                ListaEquipos = _mapper.Map<List<EquipoDTO>>(query.ToList());

//                if (ListaEquipos.Count > 0)
//                    _ResponseDTO = new ResponseDTO<List<EquipoDTO>>() { status = true, msg = "ok", value = ListaEquipos };
//                else
//                    _ResponseDTO = new ResponseDTO<List<EquipoDTO>>() { status = false, msg = "Lista Vacia", value = null };

//                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
//            }
//            catch (Exception ex)
//            {
//                _ResponseDTO = new ResponseDTO<List<EquipoDTO>>() { status = false, msg = ex.Message, value = null };
//                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
//            }
//            //var ListEquipos = dbContext.Equipos.ToList();

//            //return Ok(ListEquipos);

//        }

//        [HttpPut]
//        [Route("Editar/{Id:Guid}")]
//        public async Task<IActionResult> Editar([FromBody] EquipoDTO request, [FromRoute] Guid id)
//        {
//            ResponseDTO<bool> _ResponseDTO = new ResponseDTO<bool>();
//            try
//            {
//                Equipo _equipo = _mapper.Map<Equipo>(request);
//                Equipo _equipoParaEditar = await _equipoRepositorio.Obtener(u => u.id == id);

//                if (_equipoParaEditar != null)
//                {

//                    _equipoParaEditar.name = _equipo.name;
                    

//                    bool respuesta = await _equipoRepositorio.Update(_equipoParaEditar);

//                    if (respuesta)
//                        _ResponseDTO = new ResponseDTO<bool>() { status = true, msg = "ok", value = true };
//                    else
//                        _ResponseDTO = new ResponseDTO<bool>() { status = false, msg = "No se pudo editar el producto" };
//                }
//                else
//                {
//                    _ResponseDTO = new ResponseDTO<bool>() { status = false, msg = "No se encontró el producto" };
//                }

//                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
//            }
//            catch (Exception ex)
//            {
//                _ResponseDTO = new ResponseDTO<bool>() { status = false, msg = ex.Message };
//                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
//            }
//        }

      

     
//    }



    
//}
