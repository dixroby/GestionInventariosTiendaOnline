# SISTEMA DE GESTIÓN DE INVENTARIOS PARA UNA TIENDA EN LÍNEA

## Descripción del Proyecto
Este proyecto está hecho con el enfoque de **DDD (Domain-Driven Design)**, **Clean Architecture**, **Microservicios**, y **TDD (Test-Driven Development)**, orquestado con **.NET Aspire** y **Docker**. Para la base de datos se utiliza **SQLite**, y para el almacenamiento en caché se utiliza **Redis**.


## Tecnologías Utilizadas
- **.NET** 9 para las APIs
- **.NET Aspire** para las orquestación de microservicios
- **Redis** para el almacenamiento en caché
- **Angular** para la interfaz de usuario
- **SQLite** para la base de datos

## Instrucciones para Desplegar el Proyecto en un Entorno Local

### Prerrequisitos
Asegúrate de tener instalados los siguientes software:
- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [Node.js y npm](https://nodejs.org/es/blog/release/v20.17.0)
- [Angular CLI](https://angular.io/cli)

### Pasos para Desplegar

#### Descarga el proyecto
1. Clona el repositorio a tu máquina local:
   ```bash
   git clone https://github.com/dixroby/GestionInventariosTiendaOnline

#### Frontend

1. Abre una nueva terminal y navega al directorio del proyecto Angular:
   ```bash
   cd FrontEnd/GestionInventariosTiendaOnline.Cliente

2. Instala las dependencias del proyecto Angular:
   ```bash
   npm i

#### Backend

1. Navega al directorio del proyecto de la aplicación backend:
   ```bash
   cd Aspire/GestionInventariosTiendaOnline.AppHost

2. Restaura las dependencias y construye el proyecto:
   ```bash
   dotnet restore
   dotnet build

3. Ejecuta la aplicación backend:
   ```bash
   dotnet run


#### Acceder a la Aplicación
Una vez que ambos servicios estén en funcionamiento, abre tu navegador web y accede a la URL proporcionada por el proyecto **GestionInventariosTiendaOnline**. Dentro del dashboard, localiza el servicio **angularGestionTienda** y haz clic en su URL. Esto te redirigirá al sitio web donde podrás interactuar con el proyecto.
