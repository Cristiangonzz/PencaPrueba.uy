
using Microsoft.AspNetCore.Mvc;
using WordPenca.Business.Persistence;

namespace WordPenca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampionatoController : ControllerBase
    {

        public readonly ApplicationDbContext dbContext;

        public CampionatoController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
