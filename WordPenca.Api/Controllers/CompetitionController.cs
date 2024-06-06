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
    public class CompetitionController : ControllerBase
    {

        private readonly ILogger<GetMatchesJob> _logger;
        private readonly CompetitionService _competitionService;
        private readonly IHttpClientFactory _httpClientFactory;
        public CompetitionController(CompetitionService competitionService, IHttpClientFactory httpClientFactory, IUnitOfWork unitOfWork, IMapper mapper, IHubContext<MessageHub> hubContext)
        {

            _httpClientFactory = httpClientFactory;
            _competitionService = competitionService;
        }

        [HttpGet]
        [Route("Competition/{id}")]
        public async Task<IActionResult> GetCompetition([FromRoute] int id)
        {
            ResponseDTO<Competition> _ResponseDTO = new ResponseDTO<Competition>();
            try
            {
                Competition competition = await _competitionService.GetCompetition(id);
                if (competition != null)
                    _ResponseDTO = new ResponseDTO<Competition>() { status = true, msg = "ok", value = competition };
                else
                    _ResponseDTO = new ResponseDTO<Competition>() { status = false, msg = "Root Competition Vacia", value = competition };
                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<Competition>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListGetAll()
        {

            ResponseDTO<List<Competition>> _ResponseDTO = new ResponseDTO<List<Competition>>();

            try
            {
                List<Competition> ListaCompetition = await this._competitionService.GetCompetitions();

                if (ListaCompetition.Count > 0)
                    _ResponseDTO = new ResponseDTO<List<Competition>>() { status = true, msg = "ok", value = ListaCompetition };
                else
                    _ResponseDTO = new ResponseDTO<List<Competition>>() { status = false, msg = "Lista Vacia", value = null };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<Competition>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        


    }
}
