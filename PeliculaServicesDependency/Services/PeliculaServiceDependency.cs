using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PeliculaDb;
using PeliculaModel.Dtos;
using PeliculaModel.Entities;
using PeliculaServices.Services;
using PeliculaServices.Utilities;

namespace PeliculaServicesDependency.Services
{
    public class PeliculaServiceDependency(ApplicationDbContext context, IMapper mapper) : IPeliculaServices
    {

        private readonly ApplicationDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<List<PeliculaDto>> GetAll()
        {
            return await _context.Peliculas.ProjectTo<PeliculaDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<PeliculaByIdDto> GetById(int id)
        {
            PeliculaByIdDto peliculaByIdDto = await _context.Peliculas
                .Include(prop => prop.PeliculaGeneros)
                    .ThenInclude(prop => prop.Genero)
                .Include(prop => prop.PeliculaActors)
                .ProjectTo<PeliculaByIdDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(prop => prop.PeliculaId == id);
            return peliculaByIdDto;
        }

        public Task<List<PeliculaDto>> GetSoftDelete()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseService> Post(PeliculaCreateDto peliculaCreateDto)
        {
            Pelicula pelicula = _mapper.Map<Pelicula>(peliculaCreateDto);
            ResponseService responseService = new();
            _context.Peliculas.Add(pelicula);
            await _context.SaveChangesAsync();
            responseService.Response(true, "Pelicula created");
            return responseService;
        }

        public Task<ResponseService> SoftDelete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseService> UpdateConnect(int id, PeliculaUpdateDto peliculaUpdateDto)
        {
            ResponseService responseService = new();
            Pelicula pelicula = await _context.Peliculas.AsTracking()
                .Include(prop => prop.PeliculaActors)
                .Include(prop => prop.PeliculaGeneros)
                .FirstOrDefaultAsync(prop => prop.PeliculaId == id);

            if (pelicula is null)
            {
                responseService.Message = $"Pelicula Not found: {id}";
                return responseService;
            }

            try
            {
                pelicula = _mapper.Map(peliculaUpdateDto, pelicula);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            await _context.SaveChangesAsync();
            responseService.Response(true,$"PelculabyId {id}: Update");
            return responseService;
        }
    }
}
