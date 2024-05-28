using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Quartz;
using WordPenca.Api.Hubs;
using WordPenca.Business.Domain;


namespace WordPenca.Api.quartz
{
    public class GetMatchesJob : IJob
    {
        private readonly ILogger<GetMatchesJob> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
         private readonly IHubContext<MessageHub> _hubContext;

        public GetMatchesJob(ILogger<GetMatchesJob> logger, IHttpClientFactory httpClientFactory,IHubContext<MessageHub> hubContext)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _hubContext = hubContext;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("GetMatches method called at {time}", DateTimeOffset.Now);

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

            //Armar el mensaje que voy a enviar
            
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    RootMatch matchesData = JsonConvert.DeserializeObject<RootMatch>(body);
                    Console.WriteLine("Corriendo");
                    _logger.LogInformation("Matches data: {data}", matchesData);


                    await _hubContext.Clients.Group("Match").SendAsync("NewMatch", body);
                }
                else
                {
                    _logger.LogError("Failed to fetch matches data: {status}", response.StatusCode);
                }
            }
        }
    }
}
