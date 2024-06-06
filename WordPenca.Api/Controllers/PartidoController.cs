
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WordPenca.Business.Domain;
using WordPenca.Business.Persistence;
using WordPenca.Business.Service;
using WordPenca.Common.Dto;

namespace WordPenca.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PartidoController : ControllerBase
    {
        private readonly RootMatchsService _rootMatchService;
        private readonly MatchService _matchService;

        private readonly TeamService _teamService;
        private readonly CompetitionService _competitionService;

        private readonly IHttpClientFactory _httpClientFactory;


        public PartidoController(CompetitionService competitionService, TeamService teamService, RootMatchsService rootMatchService, MatchService matchService, IHttpClientFactory httpClientFactory)
        {
            _rootMatchService = rootMatchService;
            _matchService = matchService;
            _httpClientFactory = httpClientFactory;
            _teamService = teamService;
            _competitionService = competitionService;

        }


        [HttpGet]
        [Route("Matchs/{dateTo}/{dateFrom}")]
        public async Task<IActionResult> GetRootMatchs([FromRoute] DateOnly dateTo, [FromRoute] DateOnly dateFrom)
        {

            ResponseDTO<RootMatch> _ResponseDTO = new ResponseDTO<RootMatch>();

            try
            {
                string dateFromString = $"{dateFrom:yyyy-MM-dd}";
                string dateToString = $"{dateTo:yyyy-MM-dd}";
                System.Console.WriteLine("Desde la Api" + dateFromString + "&dateTo=" + dateToString);

                RootMatch rootMatchs = await _rootMatchService.GetRootMatch(dateToString, dateFromString);

                // Registrar el JSON para depuración
                System.Console.WriteLine("Este es el Json deserializado: " + JsonConvert.SerializeObject(rootMatchs));

                if (rootMatchs != null)
                    _ResponseDTO = new ResponseDTO<RootMatch>() { status = true, msg = "ok", value = rootMatchs };

                else
                    _ResponseDTO = new ResponseDTO<RootMatch>() { status = false, msg = "Root Match Vacia", value = rootMatchs };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<RootMatch>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpGet]
        [Route("Match/{id}")]
        public async Task<IActionResult> GetMatch([FromRoute] int id)
        {
            ResponseDTO<Match> _ResponseDTO = new ResponseDTO<Match>();
            try
            {
                Match match = await _matchService.GetMatch(id);
                if (match != null)
                    _ResponseDTO = new ResponseDTO<Match>() { status = true, msg = "ok", value = match };
                else
                    _ResponseDTO = new ResponseDTO<Match>() { status = false, msg = "Root Match Vacia", value = match };
                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<Match>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }


        [HttpGet]
        [Route("CargarMatchs/{dateTo}/{dateFrom}")]
        public async Task<IActionResult> CargarMatchs([FromRoute] DateOnly dateTo, [FromRoute] DateOnly dateFrom)
        {

            ResponseDTO<RootMatch> _ResponseDTO = new ResponseDTO<RootMatch>();

            try
            {

                string dateFromString = $"{dateFrom:yyyy-MM-dd}";
                string dateToString = $"{dateTo:yyyy-MM-dd}";

                var client = _httpClientFactory.CreateClient();

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://api.football-data.org/v4/matches?dateFrom={dateFromString}&dateTo={dateToString}"),
                    Headers =
                    {
                        { "X-Auth-Token", "5e5f4b403ed749dcb7065634af5e8dc4" }
                    },
                };

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        var body = await response.Content.ReadAsStringAsync();

                        RootMatch matchsData = JsonConvert.DeserializeObject<RootMatch>(body);


                        RootMatch matchsDataMongo = await _rootMatchService.GetRootMatch(dateToString, dateFromString);

                        if (matchsDataMongo == null)
                        {
                            await _rootMatchService.CreateRootMatch(matchsData);
                            await _matchService.CreateOrUpdateMatchesAsync(matchsData.matches);
                            //await _teamService.CreateTeamsToMatchs(matchsData.matches);
                            //await _competitionService.CreateCompetitionsToMatchs(matchsData.matches);
                            _ResponseDTO = new ResponseDTO<RootMatch>() { status = true, msg = "ok", value = matchsData };

                        }
                        else
                        {
                            await _rootMatchService.UpdateRootMatch(matchsData);
                            await _matchService.CreateOrUpdateMatchesAsync(matchsData.matches);
                            // await _teamService.UpdateTeamsToMatchs(matchsData.matches);
                            //  await _competitionService.UpdateCompetitionsToMatchs(matchsData.matches);
                            _ResponseDTO = new ResponseDTO<RootMatch>() { status = true, msg = "ok", value = matchsData };

                        }

                        if (matchsData != null)
                        {
                            _ResponseDTO = new ResponseDTO<RootMatch>() { status = true, msg = "ok", value = matchsData };
                        }
                        else
                        {
                            _ResponseDTO = new ResponseDTO<RootMatch>() { status = false, msg = "Root Match Vacia", value = matchsData };
                        }


                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
                    }

                    return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
                }
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<RootMatch>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpGet]
        [Route("Matches/competition/{idCompetition}")]
        public async Task<IActionResult> GetMatchesByCompetition([FromRoute] int idCompetition)
        {
            try
            {
                var matches = await _matchService.GetMatchToCompetition(idCompetition);
                if (matches != null && matches.Count > 0)
                {
                    return Ok(new ResponseDTO<List<Match>> { status = true, msg = "ok", value = matches });
                }
                else
                {
                    return NotFound(new ResponseDTO<List<Match>> { status = false, msg = "No matches found for the given competition.", value = null });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDTO<List<Match>> { status = false, msg = ex.Message, value = null });
            }
        }



    }
}
