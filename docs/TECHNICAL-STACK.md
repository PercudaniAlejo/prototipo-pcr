# Stack Tecnológico - PCR System

## 🏗️ Framework y Runtime

### .NET Platform
- **Framework**: .NET 10.0
- **Runtime**: CoreCLR
- **Lenguaje**: C# 13.0

---

## FRONTEND

### Framework Principal
- **Blazor Interactive Auto** (.NET 10.0)
  - Modo híbrido: Server + WebAssembly
  - Server-Side Rendering (SSR) para carga inicial
  - SignalR para comunicación en tiempo real
  - WebAssembly para interactividad del lado del cliente

### Componentes UI
- **Flowbite** `0.0.12-alpha`
  - Biblioteca de componentes basados en Tailwind CSS
  - Botones, modales, formularios, tablas, etc.
  - `Flowbite.ExtendedIcons` `0.0.5-alpha` - Set extendido de iconos

### Visualización de Datos
- **Blazor-ApexCharts** `6.0.2`
  - Gráficos interactivos: barras, líneas, donas, áreas
  - Actualización dinámica de datos
  - Responsive y personalizable

### Estilos
- **Tailwind CSS** `4.1.16`
  - Utility-first CSS framework
  - Configuración personalizada en `tailwind.config.js`
  - CLI: `@tailwindcss/cli` `4.1.16`

### Herramientas CSS
- **PostCSS** `8.5.6` - Procesamiento de CSS moderno
- **Autoprefixer** `10.4.21` - Compatibilidad cross-browser

### Scripts NPM
- `css:build` - Build de producción de CSS
- `css:watch` - Watch mode para desarrollo
- `css:prod` - Build minificado para producción

---

## ⚙️ BACKEND

### Arquitectura
- **Clean Architecture** (Arquitectura Hexagonal/Ports & Adapters)
  - Separación por capas: Domain → Application → Infrastructure → Presentation
  - Independencia de frameworks en el núcleo
  - Inversión de dependencias

### Patrones de Diseño

#### CQRS (Command Query Responsibility Segregation)
- **MediatR** `13.1.0`
  - Patrón Mediator para desacoplamiento
  - Separación de comandos (escritura) y consultas (lectura)
  - Pipeline behaviors para validación, logging, etc.

#### Mapping
- **AutoMapper** `15.1.0`
  - Mapeo automático entre entidades y DTOs
  - Profiles para configuración declarativa

#### Validación
- **FluentValidation** `12.1.0`
  - Validación fluida y expresiva de comandos/consultas
  - `FluentValidation.DependencyInjectionExtensions` `12.1.0`
  - Integración con MediatR pipeline

### Persistencia de Datos
- **Entity Framework Core** `9.0.10`
  - ORM principal para acceso a datos
  - Code-First approach
  - Migrations automáticas
  - Change Tracking y Unit of Work

#### Provider de Base de Datos
- **Microsoft SQL Server**
  - `Microsoft.EntityFrameworkCore.SqlServer` `9.0.10`
  - Soporte completo para tipos de datos de SQL Server

#### Herramientas EF Core
- `Microsoft.EntityFrameworkCore.Design` `9.0.10` - Design-time tools
- `Microsoft.EntityFrameworkCore.Tools` `9.0.10` - CLI para migrations

### Seguridad
- **ASP.NET Core Identity** `9.0.10`
  - `Microsoft.AspNetCore.Identity.EntityFrameworkCore`
  - Gestión de usuarios, roles y claims
  - Password hashing (PBKDF2)
  - Tokens de autenticación

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
<PackageReference Include="Blazor-ApexCharts" Version="6.0.2" />
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
