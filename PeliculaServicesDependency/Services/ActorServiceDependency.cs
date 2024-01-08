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
    public class ActorServiceDependency(ApplicationDbContext context, IMapper mapper) : IActorService
    {
        private readonly ApplicationDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<ResponseService> DeleteConnect(int id)
        {
            ResponseService responseService = new();
            
            Actor actor = await _context.Actors.AsTracking().FirstOrDefaultAsync(prop => prop.ActorId == id);

            if (actor == null)
            {
                responseService.Message = $"Actor Delete by id Not Found: {id}";
                return responseService;
            }

            actor.Delete = true;
            actor.DateDelete = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            responseService.Response(true, "Actor Delete by id Completed");
            return responseService;
        }

        public async Task<List<ActorDto>> GetAll()
        {
            List<ActorDto> actorDtos = await _context.Actors
                .Select(s => new ActorDto { ActorId = s.ActorId, Name = s.Name})
                .ToListAsync();

            return actorDtos;
        }

        public async Task<List<ActorDto>> GetAllSoftDelete()
        {
            List<ActorDto> actorDtos = await _context.Actors.IgnoreQueryFilters()
                .Where(prop => prop.Delete)
                .ProjectTo<ActorDto>(_mapper.ConfigurationProvider).ToListAsync();

            return actorDtos;
        }

        public async Task<ActorByIdDto> GetById(int id)
        {
            ActorByIdDto actorByIdDto = await _context.Actors
                .ProjectTo<ActorByIdDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(prop => prop.ActorId == id);

            return actorByIdDto;
        }

        public async Task<ResponseService> Post(ActorCreateDto actorCreateDto)
        {
            ResponseService responseService = new ResponseService();
            bool exist = await _context.Actors.AnyAsync(prop => prop.Name == actorCreateDto.Name);

            if (exist)
            {
                responseService.Message = $"Conflict Actor with: {actorCreateDto.Name}";
                return responseService;
            }

            Actor actor = _mapper.Map<Actor>(actorCreateDto);
            _context.Actors.Add(actor);
            await _context.SaveChangesAsync();
            responseService.Response(true, "Actor created completed");
            return responseService;
        }

        public async Task<ResponseService> PutConnect(int id, ActorCreateDto actorCreateDto)
        {
            ResponseService responseService = new ResponseService();
            Actor actor = await _context.Actors.AsTracking().FirstOrDefaultAsync(prop => prop.ActorId == id);

            if(actor is null)
            {
                responseService.Message = $"Actor update Not Found: {id}";
                return responseService;
            }

            actor = _mapper.Map(actorCreateDto, actor);
            await _context.SaveChangesAsync();
            responseService.Response(true, "Actor update completed");
            return responseService;
        }

        public async Task<ResponseService> PutDisconnect(int id, ActorCreateDto actorCreateDto)
        {
            ResponseService responseService = new ResponseService();
            bool exist = await _context.Actors.AnyAsync(a => a.ActorId == id);

            if (!exist)
            {
                responseService.Message = $"Actor update Not Found: {id}";
                return responseService;
            }

            Actor actor = _mapper.Map<Actor>(actorCreateDto);
            actor.ActorId = id;
            _context.Actors.Update(actor);
            await _context.SaveChangesAsync();
            responseService.Response(true, "Actor update Completed");
            return responseService;
        }
    }
}
