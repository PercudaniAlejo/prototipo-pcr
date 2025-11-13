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
- **Entity Framework Core** `10.0.0`
  - ORM principal para acceso a datos
  - Code-First approach
  - Migrations automáticas
  - Change Tracking y Unit of Work

#### Provider de Base de Datos
- **Microsoft SQL Server**
  - `Microsoft.EntityFrameworkCore.SqlServer` `10.0.0`
  - Soporte completo para tipos de datos de SQL Server

#### Herramientas EF Core
- `Microsoft.EntityFrameworkCore.Design` `10.0.0` - Design-time tools
- `Microsoft.EntityFrameworkCore.Tools` `10.0.0` - CLI para migrations

### Seguridad
- **ASP.NET Core Identity** `10.0.0`
  - `Microsoft.AspNetCore.Identity.EntityFrameworkCore`
  - Gestión de usuarios, roles y claims
  - Password hashing (PBKDF2)
  - Tokens de autenticación

---

## 🧪 Testing

### Frameworks de Testing
- **xUnit** `2.9.3` - Framework de testing principal
- **Microsoft.NET.Test.Sdk** `18.0.1` - SDK de testing para .NET
- **bUnit** `2.0.66` - Testing de componentes Blazor
- **Moq** `4.20.72` - Librería de mocking
- **FluentAssertions** `8.8.0` - Assertions fluidas y expresivas
- **coverlet.collector** `6.0.4` - Code coverage

### Base de Datos para Testing
- **Microsoft.EntityFrameworkCore.InMemory** `10.0.0` - In-memory database para tests de integración

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
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="10.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="10.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="10.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="10.0.0" />
```

### PCR.Infrastructure.Identity

```xml
<PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="10.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="10.0.0" />
```

### PCR.Web.Server

```xml
<PackageReference Include="Blazor-ApexCharts" Version="6.0.2" />
<PackageReference Include="Flowbite" Version="0.0.12-alpha" />
<PackageReference Include="Flowbite.ExtendedIcons" Version="0.0.5-alpha" />
<PackageReference Include="MediatR" Version="13.1.0" />
<PackageReference Include="Microsoft.AspNetCore.Components.WebAssembly.Server" Version="10.0" />
<PackageReference Include="Microsoft.Extensions.Localization" Version="10.0.0" />
```

### PCR.Infrastructure.Shared

```xml
<PackageReference Include="Microsoft.Extensions.Hosting.Abstractions" Version="10.0.0" />
```

### PCR.Core.Application.UnitTests

```xml
<PackageReference Include="coverlet.collector" Version="6.0.4" />
<PackageReference Include="FluentAssertions" Version="8.8.0" />
<PackageReference Include="Microsoft.NET.Test.Sdk" Version="18.0.1" />
<PackageReference Include="Moq" Version="4.20.72" />
<PackageReference Include="xunit" Version="2.9.3" />
<PackageReference Include="xunit.runner.visualstudio" Version="3.1.5" />
```

### PCR.Core.Domain.UnitTests

```xml
<PackageReference Include="coverlet.collector" Version="6.0.4" />
<PackageReference Include="FluentAssertions" Version="8.8.0" />
<PackageReference Include="Microsoft.NET.Test.Sdk" Version="18.0.1" />
<PackageReference Include="xunit" Version="2.9.3" />
<PackageReference Include="xunit.runner.visualstudio" Version="3.1.5" />
```

### PCR.Infrastructure.IntegrationTests

```xml
<PackageReference Include="coverlet.collector" Version="6.0.4" />
<PackageReference Include="Microsoft.EntityFrameworkCore.InMemory" Version="10.0.0" />
<PackageReference Include="Microsoft.NET.Test.Sdk" Version="18.0.1" />
<PackageReference Include="xunit" Version="2.9.3" />
<PackageReference Include="xunit.runner.visualstudio" Version="3.1.5" />
```

### PCR.Web.Tests

```xml
<PackageReference Include="bunit" Version="2.0.66" />
<PackageReference Include="coverlet.collector" Version="6.0.4" />
<PackageReference Include="Microsoft.NET.Test.Sdk" Version="18.0.1" />
<PackageReference Include="xunit" Version="2.9.3" />
<PackageReference Include="xunit.runner.visualstudio" Version="3.1.5" />
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
