
using Microsoft.AspNetCore.Mvc;
using PeliculaApi.Utilities;
using PeliculaModel.Dtos;
using PeliculaServices.Services;
using PeliculaServices.Utilities;

namespace PeliculaApi.Controllers
{
    [ApiController]
    [Route("api/v1/genero")]
    public class GeneroController(IGeneroService generoService, ResponseHttp response) : ControllerBase
    {
        private readonly IGeneroService _generoService = generoService;
        private readonly ResponseHttp _responseHttp = response;

        [HttpGet]
        public ActionResult<ResponseHttp> GetAll()
        {
            Task<List<GeneroDto>> generoDtos = _generoService.GetAll();

            _responseHttp.ResposeAll(generoDtos.Result, 200, "Success");

            return Ok(_responseHttp);
        }

        [HttpGet("{id:int}")]
        public ActionResult<ResponseHttp> GetById([FromRoute] int id)
        {
            Task<GeneroDto> generoDto = _generoService.GetById(id);

            if(generoDto.Result is null)
            {
                _responseHttp.Response(404, $"Genre id not found: {id}");
                return NotFound(_responseHttp);
            }

            _responseHttp.ResponseById(generoDto.Result, 200, "Success");

            return Ok(_responseHttp);
        }

        [HttpGet("softdelete")]
        public ActionResult<List<GeneroDto>> GetSoftDelete()
        {
            Task<List<GeneroDto>> generoDtos = _generoService.GetSoftDeleteAll();

            _responseHttp.ResposeAll(generoDtos.Result, 200, "Success");

            return Ok(_responseHttp);
        }

        [HttpPost]
        public ActionResult Post([FromBody] GeneroCreateDto generoCreateDto)
        {
            Task<ResponseService> completedTask = _generoService.Post(generoCreateDto);

            if (!completedTask.Result.Completed)
            {
                _responseHttp.Response(409, completedTask.Result.Message);
                return Conflict(_responseHttp);
            }

            _responseHttp.Response(201, "Create new Genre");

            return Ok(_responseHttp);
        }

        [HttpPost("range")]
        public ActionResult<ResponseHttp> PostRange([FromBody] List<GeneroCreateDto> generoCreateDtos)
        {
            Task<ResponseService> responseService = _generoService.PostRange(generoCreateDtos);

            if (!responseService.Result.Completed)
            {
                _responseHttp.Response(409, responseService.Result.Message);
                return Conflict(_responseHttp);
            }
            _responseHttp.Response(200, "Create New Genres");

            return Ok(_responseHttp);
        }

        [HttpPut("connect/{id:int}")]
        public ActionResult<ResponseHttp> Put([FromRoute]int id, [FromBody]GeneroCreateDto generoCreateDto)
        {
            Task<ResponseService> responseService = _generoService.UpdateConnect(id, generoCreateDto);

            if (!responseService.Result.Completed)
            {
                _responseHttp.Response(404, responseService.Result.Message);
                return NotFound(_responseHttp);
            }

            _responseHttp.Response(200, "Update Genre");
            return Ok(_responseHttp);
        }

        [HttpPut("disconnect/{id:int}")]
        public ActionResult<ResponseHttp> PutDisconnect(int id, GeneroCreateDto generoCreateDto)
        {
            Task<ResponseService> responseService = _generoService.UpdateDisconnect(id, generoCreateDto);

            if(!responseService.Result.Completed)
            {
                _responseHttp.Response(404, responseService.Result.Message);
                return NotFound(responseService);
            }

            _responseHttp.Response(200, "Delete soft Genre Completed");
            return Ok(_responseHttp);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<ResponseHttp> DeleteById([FromRoute]int id)
        {
            Task<ResponseService> responseService = _generoService.DeleteById(id);

            if (!responseService.Result.Completed)
            {
                _responseHttp.Response(404, responseService.Result.Message);
                return NotFound(_responseHttp);
            }

            _responseHttp.Response(200, "Delete Logic Completed");
            return Ok(_responseHttp);
        }
    }
}
