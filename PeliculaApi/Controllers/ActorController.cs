using Microsoft.AspNetCore.Mvc;
using PeliculaApi.Utilities;
using PeliculaModel.Dtos;
using PeliculaServices.Services;
using PeliculaServices.Utilities;

namespace PeliculaApi.Controllers
{
    [ApiController]
    [Route("api/v1/actor")]
    public class ActorController(IActorService actorService, ResponseHttp responseHttp) : ControllerBase
    {
        private readonly IActorService _actorService = actorService;
        private readonly ResponseHttp _responseHttp = responseHttp;

        [HttpGet]
        public ActionResult<ResponseHttp> GetAll()
        {
            Task<List<ActorDto>> actorDtos = _actorService.GetAll();

            _responseHttp.ResposeAll<ActorDto>(actorDtos.Result, 200, "Success");
            return Ok(_responseHttp);
        }

        [HttpGet("{id:int}")]
        public ActionResult<ResponseHttp> GetById(int id)
        {
            Task<ActorByIdDto> actorByIdDto = _actorService.GetById(id);

            if(actorByIdDto.Result is null)
            {
                _responseHttp.ResponseById<ActorByIdDto>(actorByIdDto.Result, 400, $"Actor by id Not Found: {id}");
                return BadRequest(_responseHttp);
            }

            _responseHttp.ResponseById(actorByIdDto.Result, 200, $"Success");
            return Ok(_responseHttp);
        }

        [HttpGet("softdelete")]
        public ActionResult<ResponseHttp> GetAllSoftDelete()
        {
            Task<List<ActorDto>> actorDtos = _actorService.GetAllSoftDelete();

            _responseHttp.ResposeAll(actorDtos.Result, 200, "Success");
            return Ok( _responseHttp);
        }

        [HttpPost]
        public ActionResult Post([FromBody]ActorCreateDto actorCreateDto)
        {
            Task<ResponseService> responseService = _actorService.Post(actorCreateDto);

            if (!responseService.Result.Completed)
            {
                _responseHttp.Response(407, responseService.Result.Message);
                return Conflict(_responseHttp);
            }

            return Created();
        }

        [HttpPut("connect/{id:int}")]
        public ActionResult<ResponseHttp> PutConnect([FromRoute] int id, [FromBody]ActorCreateDto actorCreateDto)
        {
            Task<ResponseService> responseService = _actorService.PutConnect(id, actorCreateDto);

            if (!responseService.Result.Completed)
            {
                _responseHttp.Response(400, responseService.Result.Message);
                return BadRequest(_responseHttp);
            }

            _responseHttp.Response(200, responseService.Result.Message);
            return Ok( _responseHttp);
        }

        [HttpPut("disconnect/{id:int}")]
        public ActionResult<ResponseHttp> PutDisconnect([FromRoute] int id, [FromBody] ActorCreateDto actorCreateDto)
        {
            Task<ResponseService> responseService = _actorService.PutDisconnect(id, actorCreateDto);

            if (!responseService.Result.Completed)
            {
                _responseHttp.Response(400, responseService.Result.Message);
                return BadRequest(_responseHttp);
            }

            _responseHttp.Response(200, responseService.Result.Message);
            return Ok(_responseHttp);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<ResponseHttp> DeleteSoft([FromRoute]int id)
        {
            Task<ResponseService> responseService = _actorService.DeleteConnect(id);

            if (!responseService.Result.Completed)
            {
                _responseHttp.Response(400, responseService.Result.Message);
                return BadRequest(_responseHttp);
            }

            _responseHttp.Response(200, responseService.Result.Message);
            return Ok(_responseHttp);
        }
    }
}
