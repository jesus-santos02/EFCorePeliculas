

# REST API Peliculas

Este proyecto es una Web API REST realizado con tecnologías .NET 6 y Entity Framework Core 6, que gestiona el almacenamiento de peliculas, modelando información sobre dicha pelicula, generos, actores y cines que disponen de ésta. Utilizamos NetTopologySuite para configurar datos espaciales, de esta manera podemos almacenar información geográfica y gestionar el cine más cercano en referencia a un punto establecido.

## Tecnologías
* .NET 6
* Entity Framework Core
* Sql Server
* AutoMapper
* NetTopologySuite
___
## Dependencias
___
* AutoMapper.Extensions.Microsoft.DependencyInjection (11.0.0)
* Microsoft.EntityFrameworkCore.SqlServer (6.0.9)
* Microsoft.EntityFrameworkCore.SqlServer.NetTopologySuite (6.0.9)
* Microsoft.EntityFrameworkCore.Tools (6.0.9)
* Swashbuckle.AspNetCore (6.2.3)

## Construyendo el proyecto
___
1. Instalar base de datos
2. Configurar cadena de conexión
3. Ejecutar migración *(Add-Migration)*
4. Compilar y desplegar el proyecto



