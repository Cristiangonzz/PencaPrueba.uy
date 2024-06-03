
using Microsoft.AspNetCore.Mvc;
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

        public PartidoController(RootMatchsService rootMatchService)
        {
            _rootMatchService = rootMatchService;
        }


        [HttpGet]
        [Route("Matchs")]
        public async Task<IActionResult> ListGetAllMatchs()
        {

            ResponseDTO<List<RootMatch>> _ResponseDTO = new ResponseDTO<List<RootMatch>>();

            try
            {

                List<RootMatch> listMatchs = await this._rootMatchService.GetMatchs();



                if (listMatchs.Count > 0)
                    _ResponseDTO = new ResponseDTO<List<RootMatch>>() { status = true, msg = "ok", value = listMatchs };

                else
                    _ResponseDTO = new ResponseDTO<List<RootMatch>>() { status = false, msg = "Lista Vacia", value = null };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<RootMatch>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }



    }
}
