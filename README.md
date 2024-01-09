# Pelicula Api

## Arquitectura monorepositorio

## Aplicando principios SOLID para delegar responsabilidades a cada tarea

### PeliculaApi: Solo es para recibir las peticiones
### PeliculaDb: Se modela entityFramework configurando entidades de tablas, ApplicationDbContex
### PeliculaServices: Capa de abtraccion para no conectarnos directamente con entityFramework: Aplicamos patron de diseno IRepository
### PeliculaServicesDependency: Hace herencia de IRepository, aqui nos conectamos a entityFramework y uso de AutoMapper
### PeliculaModel: Modelado de las entidades de tabla para entityFramework
