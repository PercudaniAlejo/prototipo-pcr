# Guía de Desarrollo - PCR System

## 🚀 Configuración del Entorno de Desarrollo

### Requisitos Previos

#### Software Necesario

1. **.NET 10 SDK**
   ```powershell
   # Verificar instalación
   dotnet --version
   # Debe mostrar: 10.0.x
   ```

2. **Node.js (LTS 18.x o superior)**
   ```powershell
   # Verificar instalación
   node --version
   npm --version
   ```

3. **SQL Server**
   - SQL Server 2019+ o SQL Server Express
   - SQL Server LocalDB (para desarrollo)

4. **IDE Recomendado**
   - Visual Studio 2022 (v17.8+) con soporte para .NET 10
   - Visual Studio Code con extensiones:
     - C# Dev Kit
     - C#
     - .NET Install Tool
     - Tailwind CSS IntelliSense

### Configuración Inicial del Proyecto

#### 1. Clonar el Repositorio

```powershell
git clone https://github.com/tu-org/prototipo-pcr-blazor.git
cd prototipo-pcr-blazor
```

#### 2. Restaurar Dependencias .NET

```powershell
# Restaurar paquetes NuGet
dotnet restore

# Verificar que compila
dotnet build
```

#### 3. Instalar Dependencias Node.js

```powershell
cd src/Presentation/PCR.Web.Server
npm install
```

#### 4. Configurar Base de Datos

**Opción A: SQL Server LocalDB (Recomendado para desarrollo)**

```powershell
# La connection string por defecto usa LocalDB
# No requiere configuración adicional
```

**Opción B: SQL Server Estándar**

Actualizar connection string en `appsettings.Development.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=PCRSystem;Trusted_Connection=True;TrustServerCertificate=True"
     }
   }
   ```

#### 5. Aplicar Migraciones

```powershell
# Desde la raíz del proyecto
cd src/Infrastructure/PCR.Infrastructure.Persistence

# Crear migración inicial (si no existe)
dotnet ef migrations add InitialCreate --startup-project ../../Presentation/PCR.Web.Server

# Aplicar migraciones
dotnet ef database update --startup-project ../../Presentation/PCR.Web.Server
```

#### 6. Configurar User Secrets (Opcional)

Para datos sensibles en desarrollo:

```powershell
cd src/Presentation/PCR.Web.Server

# Inicializar secrets
dotnet user-secrets init

# Agregar secrets
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "tu-connection-string"
dotnet user-secrets set "EmailSettings:ApiKey" "tu-api-key"
```

---

## 🏃 Ejecutar el Proyecto

### Opción 1: Visual Studio 2022

1. Abrir `PCR.sln`
2. Establecer `PCR.Web.Server` como proyecto de inicio
3. Presionar `F5` o click en "Start Debugging"

### Opción 2: Visual Studio Code

**Método Manual (Dos terminales):**

Terminal 1 - Tailwind CSS Watch:
```powershell
cd src/Presentation/PCR.Web.Server
npm run css:watch
```

Terminal 2 - Blazor con Hot Reload:
```powershell
dotnet watch --project src/Presentation/PCR.Web.Server
```

### Opción 3: Línea de Comandos

```powershell
# Desarrollo con hot reload
dotnet watch --project src/Presentation/PCR.Web.Server
```

### Opción 4: Usando Tasks de VS Code

```powershell
# Desde VS Code, ejecutar task:
Ctrl+Shift+P → Tasks: Run Task → start-all
```
---

## 📂 Estructura del Proyecto

```
prototipo-pcr-blazor/
├── src/
│   ├── Core/
│   │   ├── PCR.Core.Domain/           # Entidades y lógica de dominio
│   │   └── PCR.Core.Application/      # Casos de uso (CQRS)
│   ├── Infrastructure/
│   │   ├── PCR.Infrastructure.Persistence/   # EF Core, Repositorios
│   │   ├── PCR.Infrastructure.Identity/      # Autenticación
│   │   └── PCR.Infrastructure.Shared/        # Servicios compartidos
│   └── Presentation/
│       └── PCR.Web.Server/            # Blazor Server UI
├── tests/                              # Tests unitarios e integración
├── docs/                               # Documentación
└── scripts/                            # Scripts de utilidad
```

---

### Comandos EF Core

```powershell
# Agregar migración
dotnet ef migrations add NombreMigracion `
    --project src/Infrastructure/PCR.Infrastructure.Persistence `
    --startup-project src/Presentation/PCR.Web.Server

# Aplicar migraciones
dotnet ef database update `
    --project src/Infrastructure/PCR.Infrastructure.Persistence `
    --startup-project src/Presentation/PCR.Web.Server

# Remover última migración
dotnet ef migrations remove `
    --project src/Infrastructure/PCR.Infrastructure.Persistence `
    --startup-project src/Presentation/PCR.Web.Server

# Generar script SQL
dotnet ef migrations script `
    --project src/Infrastructure/PCR.Infrastructure.Persistence `
    --startup-project src/Presentation/PCR.Web.Server `
    --output migration.sql
```
---