# Clean Architecture Solution (Domain Driven Design)
## Technologies

* [ASP.NET Core 7](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core)
* [Entity Framework Core 7](https://docs.microsoft.com/en-us/ef/core/)
* [MediatR](https://github.com/jbogard/MediatR)
* [CQRS](https://learn.microsoft.com/es-es/azure/architecture/patterns/cqrs)
* [AutoMapper](https://automapper.org/)
* [FluentValidation](https://fluentvalidation.net/)

## Overview

### Domain

This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

### Application

This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.

### Infrastructure

This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on. These classes should be based on interfaces defined within the application layer.

### WebUI

This layer is a application ASP.NET Core 7. This layer depends on both the Application and Infrastructure layers, however, the dependency on Infrastructure is only to support dependency injection.
