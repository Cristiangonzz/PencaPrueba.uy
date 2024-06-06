using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Quartz;
using WordPenca.Api.Hubs;
using WordPenca.Business.Domain;
using WordPenca.Business.Service;


namespace WordPenca.Api.quartz
{
    public class GetMatchesJob : IJob
    {
        private readonly ILogger<GetMatchesJob> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHubContext<MessageHub> _hubContext;
        private readonly RootMatchsService _rootMatchService;
        private readonly MatchService _matchService;
        private readonly TeamService _teamService;
        private readonly CompetitionService _competitionService;


        public GetMatchesJob(CompetitionService competitionService, TeamService teamService, MatchService matchService, ILogger<GetMatchesJob> logger, RootMatchsService rootMatchService, IHttpClientFactory httpClientFactory, IHubContext<MessageHub> hubContext)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _hubContext = hubContext;
            _rootMatchService = rootMatchService;
            _matchService = matchService;
            _teamService = teamService;
            _competitionService = competitionService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("GetMatches method called at {time}", DateTimeOffset.Now);

            // Crear las fechas usando DateOnly
            DateOnly dateFrom = DateOnly.FromDateTime(DateTime.Now);
            DateOnly dateTo = dateFrom.AddDays(1);

            // Formatear las fechas como cadenas
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
            System.Console.WriteLine("https://api.football-data.org/v4/matches?dateFrom=" + dateFromString + "&dateTo=" + dateToString);

            //Armar el mensaje que voy a enviar

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();

                    RootMatch matchsData = JsonConvert.DeserializeObject<RootMatch>(body);

                    //await _hubContext.Clients.All.SendAsync("NewMatch", matchsData); // Lo podemos usar para los partidos de hoy

                    RootMatch matchsDataMongo = await _rootMatchService.GetRootMatch(dateToString, dateFromString);

                    if (matchsDataMongo == null && matchsData != null)
                    {
                        await _rootMatchService.CreateRootMatch(matchsData);
                        await _matchService.CreateOrUpdateMatchesAsync(matchsData.matches);
                        // await _teamService.CreateTeamsToMatchs(matchsData.matches);
                        // await _competitionService.CreateCompetitionsToMatchs(matchsData.matches);

                    }
                    else if (matchsDataMongo != null && matchsData != null)
                    {
                        await _rootMatchService.UpdateRootMatch(matchsData);
                        await _matchService.CreateOrUpdateMatchesAsync(matchsData.matches);
                        // await _teamService.UpdateTeamsToMatchs(matchsData.matches);
                        // await _competitionService.UpdateCompetitionsToMatchs(matchsData.matches);
                    }

                }
                else
                {
                    _logger.LogError("Failed to fetch matches data: {status}", response.StatusCode);
                }
            }
        }
    }
}
