using PeliculaModel.Dtos;
using PeliculaServices.Utilities;

namespace PeliculaServices.Services
{
    public interface IActorService
    {
        public Task<List<ActorDto>> GetAll();
        public Task<ActorByIdDto> GetById(int id);
        public Task<List<ActorDto>> GetAllSoftDelete();
        public Task<ResponseService> Post(ActorCreateDto actorCreateDto);
        public Task<ResponseService> PutConnect(int id, ActorCreateDto actorCreateDto);
        public Task<ResponseService> PutDisconnect(int id, ActorCreateDto actorCreateDto);
        public Task<ResponseService> DeleteConnect(int id);
    }
}
