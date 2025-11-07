# Stack Tecnológico - PCR System

## 🏗️ Framework y Runtime

### .NET Platform
- **Framework**: .NET 10.0
- **Runtime**: CoreCLR
- **Lenguaje**: C# 13.0

---

## 🌐 Frontend

### Framework Principal
- **Blazor Server** (.NET 10.0)
  - Server-Side Rendering (SSR)
  - SignalR para comunicación en tiempo real
  - Soporte para Interactive Server Components
  - Soporte para Interactive WebAssembly Components

### UI Libraries y Frameworks

#### Component Libraries
- **Flowbite** `0.0.12-alpha`
  - Componentes UI basados en Tailwind CSS
  - Iconos extendidos: `Flowbite.ExtendedIcons` `0.0.5-alpha`

#### CSS Framework
- **Tailwind CSS** `4.1.16`
  - Utility-first CSS framework
  - Configuración personalizada en `tailwind.config.js`
  - CLI: `@tailwindcss/cli` `4.1.16`

#### CSS Processing
- **PostCSS** `8.5.6`
  - Procesamiento de CSS moderno
- **Autoprefixer** `10.4.21`
  - Prefijos CSS automáticos para compatibilidad cross-browser

---

## 🎨 Arquitectura de Aplicación

### Patrón Arquitectónico
**Clean Architecture** (Arquitectura Hexagonal/Ports & Adapters)

### Patrones de Diseño Implementados

#### CQRS (Command Query Responsibility Segregation)
- **MediatR** `13.1.0`
  - Implementación del patrón Mediator
  - Separación de comandos y consultas
  - Pipeline behaviors para cross-cutting concerns

#### Mapping
- **AutoMapper** `15.1.0`
  - Mapeo automático entre entidades y DTOs
  - Profiles para configuración de mapeos

#### Validación
- **FluentValidation** `12.1.0`
  - Validación fluida y expresiva
  - `FluentValidation.DependencyInjectionExtensions` `12.1.0`
  - Validación en pipeline de MediatR

---

## 💾 Persistencia de Datos

### ORM y Base de Datos
- **Entity Framework Core** `9.0.10`
  - ORM principal para acceso a datos
  - Code-First approach
  - Migrations automáticas

### Provider de Base de Datos
- **Microsoft SQL Server**
  - `Microsoft.EntityFrameworkCore.SqlServer` `9.0.10`
  - Soporte para operaciones avanzadas de SQL Server

### Herramientas de EF Core
- **EF Core Design** `9.0.10`
  - Herramientas de design-time para migrations
- **EF Core Tools** `9.0.10`
  - CLI tools para scaffolding y migrations

---

## 🔐 Autenticación y Autorización

### Identity Framework
- **ASP.NET Core Identity** `9.0.10`
  - `Microsoft.AspNetCore.Identity.EntityFrameworkCore`
  - Gestión de usuarios y roles
  - Autenticación integrada
  - Password hashing y gestión de tokens

#### Scripts NPM
- `css:build` - Build de producción de CSS
- `css:watch` - Watch mode para desarrollo
- `css:prod` - Build minificado para producción

---

## 📦 Dependencias por Proyecto

### PCR.Core.Domain
**Sin dependencias externas** (Domain-Driven Design)
- Entidades de dominio puras
- Value Objects
- Domain Events
- Interfaces de repositorio

### PCR.Core.Application
```xml
<PackageReference Include="AutoMapper" Version="15.1.0" />
<PackageReference Include="FluentValidation" Version="12.1.0" />
<PackageReference Include="FluentValidation.DependencyInjectionExtensions" Version="12.1.0" />
<PackageReference Include="MediatR" Version="13.1.0" />
```

### PCR.Infrastructure.Persistence
```xml
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="9.0.10" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="9.0.10" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="9.0.10" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="9.0.10" />
```

### PCR.Infrastructure.Identity
```xml
<PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="9.0.10" />
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="9.0.10" />
```

### PCR.Web.Server
```xml
<PackageReference Include="Flowbite" Version="0.0.12-alpha" />
<PackageReference Include="Flowbite.ExtendedIcons" Version="0.0.5-alpha" />
<PackageReference Include="MediatR" Version="13.1.0" />
<PackageReference Include="Microsoft.AspNetCore.Components.WebAssembly.Server" Version="10.0.0-rc.2.25502.107" />
```

---

## 📊 Características de la Solución

### Proyectos en la Solución
1. **Core**
   - PCR.Core.Domain
   - PCR.Core.Application

2. **Infrastructure**
   - PCR.Infrastructure.Persistence
   - PCR.Infrastructure.Identity
   - PCR.Infrastructure.Shared

3. **Presentation**
   - PCR.Web.Server

4. **Tests**
   - PCR.Core.Domain.UnitTests
   - PCR.Core.Application.UnitTests
   - PCR.Infrastructure.IntegrationTests
   - PCR.Web.Tests
