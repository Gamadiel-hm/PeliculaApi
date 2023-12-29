using PeliculaModel.Dtos;
using PeliculaServices.Utilities;

namespace PeliculaServices.Services
{
    public interface IGeneroService
    {
        public Task<List<GeneroDto>> GetAll();
        public Task<GeneroDto> GetById(int id);
        public Task<List<GeneroDto>> GetSoftDeleteAll();
        public Task<ResponseService> Post(GeneroCreateDto generoCreateDto);
        public Task<ResponseService> PostRange(List<GeneroCreateDto> generoCreateDtos);
        public Task<ResponseService> UpdateConnect(int id, GeneroCreateDto generoCreateDto);
        public Task<ResponseService> UpdateDisconnect(int id, GeneroCreateDto generoCreateDto);
        public Task<ResponseService> DeleteById(int id);
    }
}
