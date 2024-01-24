# API CRUD .NET

Este proyecto es una API CRUD desarrollada en ASP.NET Core que utiliza Entity Framework Core para la gestión de una base de datos SQL Server. La API proporciona operaciones básicas de creación, lectura, actualización y eliminación para entidades de usuarios, productos y pedidos.

## Requisitos Previos

Asegúrate de tener instalado lo siguiente antes de ejecutar la aplicación:

- [SDK de .NET Core](https://dotnet.microsoft.com/download)

## Configuración del Proyecto

1. Clona el repositorio: `https://github.com/santiagoHV/dotnet-crud.git`
2. Navega al directorio del proyecto: `cd dotnet-crud`

## Configuración de la Base de Datos

La aplicación utiliza Entity Framework Core para interactuar con la base de datos SQL Server. Sigue estos pasos para configurar la base de datos:

1. Abre una terminal y navega al directorio del proyecto.
3. Crea el contenedor docker que almacenará la base de datos `docker compose up -d`
2. Ejecuta las migraciones: `dotnet ef database update`
3. La base de datos ahora debería estar lista para ser utilizada por la aplicación.

## Ejecución de la Aplicación

1. Ejecuta la aplicación: `dotnet run`
2. La API estará disponible en `https://localhost:7100` por defecto.

## Endpoints de la API

- `GET /api/users`: Obtiene todos los usuarios.
- `GET /api/users/{id}`: Obtiene un usuario por ID.
- `POST /api/users`: Crea un nuevo usuario.
- `PUT /api/users/{id}`: Actualiza un usuario existente.
- `DELETE /api/users/{id}`: Elimina un usuario por ID.

Repite los mismos pasos para las entidades de productos y pedidos.
