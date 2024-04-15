
using Microsoft.AspNetCore.Mvc;
using WordPenca.Business.Persistence;

namespace WordPenca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasificacionController : ControllerBase
    {

        public readonly ApplicationDbContext dbContext;

        public ClasificacionController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
