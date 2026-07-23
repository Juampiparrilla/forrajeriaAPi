\# Forrajeria API



Backend desarrollado con ASP.NET Core utilizando Clean Architecture, CQRS y principios de Domain-Driven Design (DDD).



\## Objetivos



\- Aplicar Clean Architecture

\- Aplicar principios SOLID

\- Implementar CQRS con MediatR

\- Modelar un dominio rico (Rich Domain Model)

\- Implementar Entity Framework Core con PostgreSQL

\- Escribir pruebas unitarias

\- Implementar autenticación JWT

\- Utilizar Docker

\- Aplicar buenas prácticas y patrones de diseño



\## Tecnologías



\- .NET 8

\- ASP.NET Core Web API

\- Entity Framework Core

\- PostgreSQL (Npgsql)

\- MediatR

\- Swagger / OpenAPI

\- xUnit



\## Arquitectura



El proyecto sigue una arquitectura basada en Clean Architecture.



```

Forrajeria.API

&#x20;       │

&#x20;       ▼

Forrajeria.Application

&#x20;       │

&#x20;       ▼

Forrajeria.Domain



Forrajeria.Infrastructure

&#x20;       ▲

&#x20;       │

&#x20;       └──────────── API

```



\### Capas



\- \*\*Domain:\*\* entidades, reglas de negocio, excepciones y enums.

\- \*\*Application:\*\* casos de uso (Commands, Queries, Handlers), interfaces y CQRS.

\- \*\*Infrastructure:\*\* Entity Framework Core, repositorios, Unit of Work y persistencia.

\- \*\*API:\*\* controladores, configuración de servicios y exposición de endpoints REST.



\## Características implementadas



\-  Clean Architecture

\-  CQRS con MediatR

\-  Repository Pattern

\-  Unit of Work

\-  Rich Domain Model

\-  Entity Framework Core

\-  PostgreSQL

\-  Swagger

\-  Pruebas unitarias del dominio



\## Estado del proyecto



En desarrollo.



Actualmente se encuentran implementados los casos de uso de \*\*Categorías\*\* y \*\*Productos\*\*. El siguiente objetivo es continuar con las entidades \*\*PresentaciónProducto\*\*, \*\*Venta\*\* y \*\*DetalleVenta\*\*, además de incorporar autenticación JWT, manejo global de excepciones y Docker.

