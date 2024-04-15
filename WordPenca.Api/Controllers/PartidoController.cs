
using Microsoft.AspNetCore.Mvc;
using WordPenca.Business.Persistence;

namespace WordPenca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidoController : ControllerBase
    {
        public readonly ApplicationDbContext dbContext;

        public PartidoController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

    }
}
