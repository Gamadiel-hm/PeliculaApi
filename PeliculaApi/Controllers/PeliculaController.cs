using Microsoft.AspNetCore.Mvc;
using PeliculaApi.Utilities;
using PeliculaModel.Dtos;
using PeliculaServices.Services;
using PeliculaServices.Utilities;

namespace PeliculaApi.Controllers
{
    [ApiController]
    [Route("api/v1/pelicula")]
    public class PeliculaController(IPeliculaServices services, ResponseHttp responseHttp) : ControllerBase
    {
        private readonly IPeliculaServices _services = services;
        private readonly ResponseHttp _responseHttp = responseHttp;

        [HttpGet]
        public ActionResult<ResponseHttp> GetAll()
        {
            Task<List<PeliculaDto>> peliculaDtos = _services.GetAll();

            _responseHttp.ResposeAll(peliculaDtos.Result, 200, "Success");
            return Ok(_responseHttp);
        }

        [HttpGet("{id:int}")]
        public ActionResult<ResponseHttp> GetById(int id)
        {
            Task<PeliculaByIdDto> peliculaByIdDto = _services.GetById(id);

            if(peliculaByIdDto.Result is null)
            {
                _responseHttp.Response(400, $"PeliculaById not found: {id}");
                return BadRequest(_responseHttp);
            }

            _responseHttp.ResponseById(peliculaByIdDto.Result, 200, "Success");
            return Ok(_responseHttp);
        }

        [HttpPost]
        public ActionResult<ResponseHttp> Post(PeliculaCreateDto peliculaCreateDto)
        {
            Task<ResponseService> responseService = _services.Post(peliculaCreateDto);

            if (!responseService.Result.Completed)
                return BadRequest(_responseHttp);

            return Created();
        }

        [HttpPut("{id:int}")]
        public ActionResult<ResponseHttp> PutConnect(int id, PeliculaUpdateDto peliculaUpdateDto)
        {
            Task<ResponseService> responseService = _services.UpdateConnect(id, peliculaUpdateDto);

            if(!responseService.Result.Completed)
            {
                _responseHttp.Response(400, responseService.Result.Message);
                return BadRequest(_responseHttp);
            }

            _responseHttp.Response(200, responseService.Result.Message);
            return Ok(_responseHttp);
        }
    }
}
