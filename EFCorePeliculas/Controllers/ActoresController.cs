using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCorePeliculas.DTOs;
using EFCorePeliculas.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/actores")]
    public class ActoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ActoresController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //[HttpGet]
        //public async Task<IEnumerable<ActorDTO>> Get()
        //{
        //    var actores = await context.Actores.Select(a => new ActorDTO { Id = a.Id, Nombre = a.Nombre }).ToListAsync();
        //    return actores;
        //}

        [HttpGet]
        public async Task<IEnumerable<ActorDTO>> Get()
        {
            return await context.Actores.ProjectTo<ActorDTO>(mapper.ConfigurationProvider).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(ActorCreacionDTO actorCreacionDTO)
        {
            var actor = mapper.Map<Actor>(actorCreacionDTO);
            context.Add(actor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(ActorCreacionDTO actorCreacionDTO, int id)
        {
            var actorDb = await context.Actores.AsTracking().FirstOrDefaultAsync(a => a.Id == id);

            if(actorDb is null)
            {
                return NotFound();
            }

            actorDb = mapper.Map(actorCreacionDTO, actorDb);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("desconectado/{id:int}")]
        public async Task<ActionResult> PutDesconectado(ActorCreacionDTO actorCreacionDTO, int id)
        {
            var existeAutor = context.Actores.Any(a => a.Id == id);

            if (!existeAutor)
            {
                return NotFound();
            }

            var actor = mapper.Map<Actor>(actorCreacionDTO);
            actor.Id = id;
            
            context.Update(actor);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
