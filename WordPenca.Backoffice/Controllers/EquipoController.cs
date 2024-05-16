
using Microsoft.AspNetCore.Mvc;

using WordPenca.Business.Domain;
using WordPenca.Business.Persistence;

namespace WordPenca.Backoffice.Controllers
{
    public class EquipoController : Controller
    {
        private readonly ApplicationDbContext _ctx;
        private readonly ILogger<EquipoController> _logger;

        public EquipoController(ApplicationDbContext ctx, ILogger<EquipoController> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var equipos = _ctx.Equipos.ToList();

            return View(equipos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Equipo equipo)
        {
            if (!ModelState.IsValid)
            {
                return View(equipo);
            }
            _ctx.Equipos.Add(equipo);
            _ctx.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(Guid id)
        {
            var equipo = _ctx.Equipos.Find(id);
            return View(equipo);
        }

        public IActionResult Edit(Guid id)
        {
            var product = _ctx.Equipos.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, Equipo equipo)
        {
            if (id != equipo.id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(equipo);
            }

            _ctx.Equipos.Update(equipo);
            _ctx.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(Guid id)
        {
            try

            {
                var p = _ctx.Equipos.Find(id);

                if (p == null)
                {
                    return NotFound();
                }

                _ctx.Equipos.Remove(p);
                _ctx.SaveChanges();
            }
            catch (Exception e)
            {
                return e.InnerException != null ? BadRequest(e.InnerException.Message) : BadRequest(e.Message);
            }
            return RedirectToAction(nameof(Index));
        }

        //[Route("Error/{statusCode:int}")]
        //public IActionResult Error(int statusCode)
        //{
        //    var feature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

        //    return View(new ErrorViewModel { StatusCode = statusCode, OriginalPath = feature?.OriginalPath });
        //}


    }
}
