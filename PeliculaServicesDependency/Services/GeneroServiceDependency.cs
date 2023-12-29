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
    public class GeneroServiceDependency(ApplicationDbContext context, IMapper mapper) : IGeneroService
    {
        private readonly ApplicationDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<ResponseService> DeleteById(int id)
        {
            Genero genero = await _context.Generos.AsTracking().FirstOrDefaultAsync(prop => prop.GeneroId == id);

            ResponseService responseService = new();
            if (genero is null)
            {
                responseService.Message = $"Genre id not found: {id}";
                return responseService;
            }

            genero.Delete = true;
            genero.DateDelete = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            responseService.Response(true, $"Genre Soft Delete");

            return responseService;
        }

        public async Task<List<GeneroDto>> GetAll()
        {
            return await _context.Generos
                .Select(p => new GeneroDto() { GeneroId = p.GeneroId, Name = p.Name })
                .ToListAsync();
        }

        public async Task<GeneroDto> GetById(int id)
        {
            GeneroDto generoDto = await _context.Generos
                .ProjectTo<GeneroDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(prop => prop.GeneroId == id);
            return generoDto;
        }

        public async Task<List<GeneroDto>> GetSoftDeleteAll()
        {
            List<GeneroDto> generoDto = await _context.Generos
                .IgnoreQueryFilters().Where(prop => prop.Delete)
                .ProjectTo<GeneroDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return generoDto;
        }

        public async Task<ResponseService> Post(GeneroCreateDto generoCreateDto)
        {
            bool exist = await _context.Generos.AnyAsync();
            ResponseService responseService = new();

            if (exist)
            {
                responseService.Message = $"Conflic Genre exist: {generoCreateDto.Name}";
            }

            _context.Generos.Add(_mapper.Map<Genero>(generoCreateDto));
            await _context.SaveChangesAsync();
            responseService.Response(true, "Create Genre Completed");

            return  responseService;
        }

        public async Task<ResponseService> PostRange(List<GeneroCreateDto> generoCreateDtos)
        {
            List<string> nameGeneros = generoCreateDtos.Select(p => p.Name).ToList();

            List<Genero> generos = await _context.Generos
                .Where(prop => nameGeneros.Contains(prop.Name)).ToListAsync();

            ResponseService responseService = new();
            if(generos.Count != 0)
            {
                responseService.Message = $"Conflic Genre exist:";
                List<string> generosExist = generos.Where(prop => nameGeneros.Contains(prop.Name)).Select(prop => prop.Name).ToList();
                generosExist.ForEach(genero => responseService.Message = $"{responseService.Message} $s{genero} ");

                return responseService;
            }

            List<Genero> generoNews = _mapper.Map<List<Genero>>(generoCreateDtos);
            _context.Generos.AddRange(generoNews);
            await _context.SaveChangesAsync();
            responseService.Response(true, "Compled range Generos");

            return responseService;
        }

        public async Task<ResponseService> UpdateConnect(int id, GeneroCreateDto generoCreateDto)
        {
            Genero genero = await _context.Generos.AsTracking().FirstOrDefaultAsync(prop => prop.GeneroId == id);

            ResponseService responseService = new();
            if(genero is null)
            {
                responseService.Message = $"Genre Update not found: {generoCreateDto.Name}";
                return responseService;
            }

            genero = _mapper.Map(generoCreateDto, genero);
            await _context.SaveChangesAsync();
            responseService.Response(true, "Update Completed");
            return responseService;
        }

        public async Task<ResponseService> UpdateDisconnect(int id,GeneroCreateDto generoCreateDto)
        {
            bool exist = await _context.Generos.AnyAsync(prop => prop.GeneroId == id);
            ResponseService responseService = new();

            if (!exist)
            {
                responseService.Message = $"Genre Delete by id not found: {id}";
                return responseService;
            }

            Genero genero = _mapper.Map<Genero>(generoCreateDto);
            genero.GeneroId = id;
            _context.Generos.Update(genero);
            await _context.SaveChangesAsync();

            responseService.Response(true, "Genre soft Delete Completed");
            return responseService;
        }
    }
}
