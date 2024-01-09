using PeliculaModel.Dtos;
using PeliculaServices.Utilities;

namespace PeliculaServices.Services
{
    public interface IPeliculaServices
    {
        public Task<List<PeliculaDto>> GetAll();
        public Task<PeliculaByIdDto> GetById(int id);
        public Task<List<PeliculaDto>> GetSoftDelete();
        public Task<ResponseService> Post(PeliculaCreateDto peliculaCreateDto);
        public Task<ResponseService> UpdateConnect(int id, PeliculaUpdateDto peliculaCreateDto);
        public Task<ResponseService> SoftDelete(int id);
    }
}
