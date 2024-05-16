using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WordPenca.Api.Hubs;

namespace WordPenca.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebSocketController : Controller
    {
        private readonly IHubContext<MessageHub> _hubContext;

        public WebSocketController(IHubContext<MessageHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task<IActionResult> Send(String message)
        {
          
            await _hubContext.Clients.All.SendAsync("SendMessage", message);
            return Ok();
        }
        
    }
}
