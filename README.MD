# Forrajería API

Backend desarrollado con **ASP.NET Core 8** aplicando **Clean Architecture**, **Domain-Driven Design (DDD)** y **CQRS**, con autenticación JWT y autorización basada en políticas y roles.

## Objetivos

- Aplicar Clean Architecture con separación estricta de responsabilidades por capa
- Modelar un dominio rico (Rich Domain Model) con invariantes autoprotegidos
- Implementar CQRS con MediatR
- Persistir con Entity Framework Core sobre PostgreSQL
- Proteger la API con autenticación JWT y autorización basada en roles/políticas
- Centralizar el manejo de errores con un middleware global
- Cubrir las reglas de negocio del dominio con pruebas unitarias
- Aplicar principios SOLID y buenas prácticas de diseño

## Tecnologías

- .NET 8 / ASP.NET Core Web API
- Entity Framework Core + Npgsql (PostgreSQL)
- MediatR (CQRS)
- JWT Bearer Authentication (`Microsoft.AspNetCore.Authentication.JwtBearer`)
- BCrypt.Net-Next (hasheo de contraseñas)
- Swagger / OpenAPI
- xUnit

## Arquitectura

El proyecto sigue Clean Architecture: las dependencias siempre apuntan hacia adentro, hacia el dominio.

```
Forrajeria.API
        │
        ▼
Forrajeria.Application
        │
        ▼
Forrajeria.Domain
        ▲
        │
Forrajeria.Infrastructure
```

### Capas

- **Domain:** entidades con lógica de negocio propia (rich domain model), enums y jerarquía de excepciones de dominio. No depende de ninguna otra capa ni de librerías externas.
- **Application:** casos de uso organizados por *vertical slices* (Commands, Queries y sus Handlers vía MediatR), interfaces de repositorio y de servicios (puertos), sin conocer detalles de infraestructura.
- **Infrastructure:** implementación de EF Core, repositorios concretos, Unit of Work, hasheo de contraseñas y generación de tokens JWT.
- **API:** controladores REST delgados (solo orquestan MediatR), middlewares transversales, configuración de autenticación/autorización y Swagger.

## Conceptos y patrones aplicados

### Arquitectura y diseño

- **Clean Architecture** — 4 capas independientes con regla de dependencia hacia el dominio.
- **Domain-Driven Design (DDD)** — el dominio modela reglas de negocio reales, no solo estructuras de datos.
- **Rich Domain Model** — entidades con setters privados y comportamiento propio (`Activar()`, `ModificarNombre()`, `AplicarDescuento()`, etc.); ningún estado se modifica desde afuera sin pasar por un método que valide sus invariantes.
- **Aggregate Root** — `Venta` es la raíz de agregado que encapsula su colección de `DetalleVenta`; los detalles solo se crean, modifican o eliminan a través de métodos de `Venta` (`AgregarDetalle`, `EliminarDetalle`), nunca de forma independiente.
- **CQRS** — separación explícita entre Commands (escritura) y Queries (lectura) en cada módulo del dominio.
- **Vertical Slice Architecture** — cada caso de uso vive en su propia carpeta con su Command/Query, Handler y Response, en vez de organizarse por tipo técnico.
- **Principios SOLID** aplicados de forma consistente en toda la solución.

### Patrones de diseño

- **Repository Pattern** — `ICategoriaRepository`, `IProductoRepository`, `IPresentacionProductoRepository`, `IVentaRepository`, `IUsuarioRepository`, definidos en Application e implementados en Infrastructure.
- **Unit of Work** — `IUnitOfWork` centraliza el `SaveChanges` de una transacción de negocio, independiente del repositorio que la originó.
- **Mediator Pattern** — MediatR desacopla los controladores de la lógica de aplicación.
- **Dependency Injection / Inversion of Control** — cada capa expone su propio método de extensión (`AddApplication`, `AddInfrastructure`, `AddJwtAuthentication`, `AddApiAuthorization`) para registrar sus servicios sin acoplar `Program.cs` a los detalles internos.

### Dominio

- **Encapsulación real** — constructores protegidos para EF Core, setters privados, validaciones centralizadas por entidad.
- **Jerarquía de excepciones de dominio**, con clases base semánticas que se mapean 1:1 a códigos HTTP:

  | Excepción base | HTTP | Uso |
  |---|---|---|
  | `BusinessRuleException` | 400 | Violación de una regla/valor inválido (ej. nombre vacío, precio negativo) |
  | `UnauthorizedException` | 401 | Falla de autenticación (credenciales inválidas) |
  | `NotFoundException` | 404 | El recurso solicitado no existe |
  | `ConflictException` | 409 | La operación choca con el estado actual del recurso (ej. venta ya confirmada, email duplicado) |

  Las excepciones concretas (`CantidadInvalidaException`, `StockInsuficienteException`... ) heredan de estas bases y se organizan en `Domain/Exceptions/{BusinessRules,Conflict,NotFound,Common}`.

### Seguridad

- **Autenticación JWT (Bearer)** — `IJwtProvider`/`JwtProvider` generan el token firmado con los claims del usuario (id, nombre, email, rol); `AddJwtAuthentication` configura la validación (issuer, audience, firma, expiración).
- **Hasheo de contraseñas** — `IPasswordHasher`/`PasswordHasher` (BCrypt), la contraseña en texto plano nunca se persiste ni se loguea.
- **Autorización basada en políticas y roles (Policy-based Authorization)** — `RoleNames` (constantes de rol) y `Policies` (nombres de política) definen reglas declarativas por caso de uso (`PuedeVerCategorias`, `PuedeGestionarCategorias`, `PuedeGestionarVentas`, `PuedeGestionarUsuarios`, etc.), aplicadas con `[Authorize(Policy = ...)]` en cada endpoint según si es de consulta o de gestión.

### Middlewares transversales (API)

- **Middleware de autenticación/autorización** — `UseAuthentication()` + `UseAuthorization()` validan el JWT y aplican las políticas antes de llegar al controlador.
- **Middleware de manejo global de excepciones** — `ExceptionMiddleware` intercepta cualquier excepción no controlada y la traduce a una respuesta HTTP consistente (`ErrorResponse`) según el tipo base de la jerarquía de excepciones de dominio, evitando manejo de errores repetido en cada controlador.

### Persistencia

- **Entity Framework Core + PostgreSQL** (Npgsql).
- **Fluent API Configurations** (`IEntityTypeConfiguration<T>`) — una clase de configuración por entidad, en vez de Data Annotations.
- **Migrations** versionadas por EF Core.

### Testing

- **xUnit** — pruebas unitarias del dominio (validaciones de entidades, invariantes del agregado `Venta`), independientes de la base de datos y de la API.

## Autorización por controlador

| Controlador | Consulta | Gestión (crear/editar/activar/desactivar) |
|---|---|---|
| Categorías | `PuedeVerCategorias` (Admin o Vendedor) | `PuedeGestionarCategorias` (solo Admin) |
| Productos | `PuedeVerProductos` (Admin o Vendedor) | `PuedeGestionarProductos` (solo Admin) |
| Presentaciones de Producto | `PuedeVerPresentaciones` (Admin o Vendedor) | `PuedeGestionarPresentaciones` (solo Admin) |
| Ventas | `PuedeGestionarVentas` (Admin o Vendedor) para todos los endpoints | — |
| Usuarios | — | `PuedeGestionarUsuarios` (solo Admin). `Login` es público (`AllowAnonymous`) |

## Estado del proyecto

En desarrollo activo.

Implementado hasta el momento: **Categorías**, **Productos**, **Presentaciones de Producto**, **Ventas** (con **Detalle de Venta** como parte del agregado) y **Usuarios**, incluyendo autenticación JWT, autorización por roles/políticas y manejo global de excepciones.

Pendiente: **Docker** para el entorno de desarrollo/despliegue, y ampliar la cobertura de pruebas automatizadas más allá del dominio.
