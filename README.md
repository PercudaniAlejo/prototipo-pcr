# PCR System - Clean Architecture

## 📁 Estructura del Proyecto

```
prototipo-pcr-blazor/
├── src/
│   ├── Core/                           # Capa de Dominio (sin dependencias)
│   │   ├── PCR.Core.Domain/
│   │   └── PCR.Core.Application/
│   ├── Infrastructure/                 # Implementaciones técnicas
│   │   ├── PCR.Infrastructure.Persistence/
│   │   ├── PCR.Infrastructure.Identity/
│   │   └── PCR.Infrastructure.Shared/
│   └── Presentation/                   # Capa de Presentación
│       └── PCR.Web.Server/             # Blazor Interactive Auto + Flowbite
│           ├── Components/             # Componentes Blazor
│           ├── wwwroot/                # Archivos estáticos públicos
│           │   ├── images/             # Imágenes (logos, banners, etc.)
│           │   ├── js/                 # Scripts JavaScript personalizados
│           │   ├── css/                # Archivos CSS compilados
│           │   └── lib/                # Librerías JavaScript de terceros
│           ├── Services/
│           ├── Utilities/
│           └── ...
├── tests/                              # Proyectos de Testing
└── docs/                               # Documentación
```

## 🚀 Tecnologías

- **.NET 10.0**
- **Blazor Interactive Auto** (Server + WebAssembly) con Flowbite
- **Blazor-ApexCharts** para visualización de datos (gráficos)
- **Tailwind CSS**
- **Entity Framework Core** con SQL Server
- **MediatR** (CQRS Pattern)
- **AutoMapper**
- **FluentValidation**
- **xUnit** + **bUnit** para testing

## 🏗️ Arquitectura

Este proyecto sigue los principios de **Clean Architecture** con:

- **Separación de responsabilidades** por capas
- **Organización por features** (Vertical Slices)
- **Independencia de frameworks** en la capa de dominio
- **Inversión de dependencias**
- **Testeable por diseño**

## 📦 Comandos Útiles

```bash
# Restaurar paquetes
dotnet restore

# Compilar solución
dotnet build

# Ejecutar tests
dotnet test
```

## 🐛 Debug en VS Code

**Opción más fácil - Todo automático:**
1. Presiona `F5` en VS Code
2. Selecciona "🚀 Full Stack Debug (Blazor + Tailwind)"
3. ¡Listo! Ambos procesos (Blazor + Tailwind) inician automáticamente

**Opción manual (dos terminales):**

Terminal 1 - Tailwind CSS:
```bash
cd src/Presentation/PCR.Web.Server
npm run css:watch
```

Terminal 2 - Blazor:
```bash
dotnet watch --project src/Presentation/PCR.Web.Server
```

## 🔧 Configuración Inicial

1. **Base de Datos**: Actualizar connection string en `appsettings.json`
2. **Migraciones**: 
   ```bash
   cd src/Infrastructure/PCR.Infrastructure.Persistence
   dotnet ef migrations add InitialCreate --startup-project ../../Presentation/PCR.Web.Server
   dotnet ef database update --startup-project ../../Presentation/PCR.Web.Server
   ```
3. **Tailwind CSS**: El CSS se compila automáticamente en desarrollo

## 📚 Documentación Completa

### 📖 Guías Principales

- **[Stack Tecnológico](docs/TECHNICAL-STACK.md)** - Tecnologías, librerías y versiones utilizadas
- **[Guía de Desarrollo](docs/DEVELOPMENT-GUIDE.md)** - Setup, convenciones y workflow de desarrollo
