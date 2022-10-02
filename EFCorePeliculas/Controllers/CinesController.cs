using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCorePeliculas.DTOs;
using EFCorePeliculas.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/cines")]
    public class CinesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CinesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CineDTO>> Get()
        {
            return await context.Cines.ProjectTo<CineDTO>(mapper.ConfigurationProvider).ToListAsync();

            ////Sin AutoMapper
            //return await context.Cines.Select(c => new CineDTO { Id = c.Id, Nombre = c.Nombre, Latitud = c.Ubicacion.Y, Longitud = c.Ubicacion.X }).ToListAsync();
        }

        [HttpGet("cercanos")]
        public async Task<ActionResult> Get(double longitud, double latitud)
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            var miUbicacion = geometryFactory.CreatePoint(new Coordinate(longitud, latitud));//Tener cuidado especial con el orden longitud/latitud
            var distanciaMaximaEnMetros = 2000;

            var cines = await context.Cines
                .OrderBy(c => c.Ubicacion.Distance(miUbicacion))
                .Where(c => c.Ubicacion.IsWithinDistance(miUbicacion, distanciaMaximaEnMetros))
                .Select(c => new
                { 
                    Nombre = c.Nombre, 
                    Distancia = Math.Round(c.Ubicacion.Distance(miUbicacion)) 
                }).ToListAsync();

            return Ok(cines);
        }

        [HttpPost]
        public async Task<ActionResult> Post()
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            var ubicacionCine = geometryFactory.CreatePoint(new Coordinate(-69.90493530019926, 18.460140726471465));

            var cine = new Cine()
            {
                Nombre = "Caribbean Cinemas Centro",
                Ubicacion = ubicacionCine,
                CineOferta = new CineOferta()
                {
                    FechaInicio = DateTime.Today,
                    FechaFin = DateTime.Today.AddDays(7),
                    PorcentajeDescuento = 5
                },
                SalasDeCine = new HashSet<SalaDeCine>()
                {
                    new SalaDeCine()
                    {
                        Precio = 200,
                        TipoSalaDeCine = TipoSalaDeCine.DosDimensiones
                    },
                    new SalaDeCine()
                    {
                        Precio = 350,
                        TipoSalaDeCine = TipoSalaDeCine.TresDimensiones
                    }
                }
            };
            context.Add(cine);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("conDTO")]
        public async Task<ActionResult> Post(CineCreacionDTO cineCreacionDTO)
        {
            var cine = mapper.Map<Cine>(cineCreacionDTO);
            context.Add(cine);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
