using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WordPenca.Common.Dto;
using WordPenca.Business.Domain;
using Microsoft.AspNetCore.SignalR;
using WordPenca.Api.Hubs;
using WordPenca.Business.Repository.Interface;
using Newtonsoft.Json;
using WordPenca.Api.quartz;
using WordPenca.Business.Service;


namespace WordPenca.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EquipoController : ControllerBase
    {

        private readonly ILogger<GetMatchesJob> _logger;
        private readonly TeamService _teamService;
        private readonly IHttpClientFactory _httpClientFactory;
        public EquipoController(TeamService teamService, IHttpClientFactory httpClientFactory, IUnitOfWork unitOfWork, IMapper mapper, IHubContext<MessageHub> hubContext)
        {

            _httpClientFactory = httpClientFactory;
            _teamService = teamService;
        }

        [HttpGet]
        [Route("Team/{id}")]
        public async Task<IActionResult> GetMatch([FromRoute] int id)
        {
            ResponseDTO<Team> _ResponseDTO = new ResponseDTO<Team>();
            try
            {
                Team team = await _teamService.GetTeam(id);
                if (team != null)
                    _ResponseDTO = new ResponseDTO<Team>() { status = true, msg = "ok", value = team };
                else
                    _ResponseDTO = new ResponseDTO<Team>() { status = false, msg = "Root Team Vacia", value = team };
                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<Team>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListGetAll()
        {

            ResponseDTO<List<Team>> _ResponseDTO = new ResponseDTO<List<Team>>();

            try
            {
                List<Team> ListaEquipos = await this._teamService.GetTeams();

                if (ListaEquipos.Count > 0)
                    _ResponseDTO = new ResponseDTO<List<Team>>() { status = true, msg = "ok", value = ListaEquipos };
                else
                    _ResponseDTO = new ResponseDTO<List<Team>>() { status = false, msg = "Lista Vacia", value = null };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<Team>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
            //var ListEquipos = dbContext.Equipos.ToList();

            //return Ok(ListEquipos);

        }


    }
}
