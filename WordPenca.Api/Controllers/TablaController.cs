
using Microsoft.AspNetCore.Mvc;
using WordPenca.Business.Persistence;

namespace WordPenca.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TablaController : ControllerBase
    {

        public readonly ApplicationDbContext dbContext;

        public TablaController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
