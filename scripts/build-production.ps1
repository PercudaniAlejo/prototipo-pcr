# Build Tailwind CSS para producción
npm run css:prod --prefix src/Presentation/PCR.Web.Server

# Build .NET
dotnet publish src/Presentation/PCR.Web.Server/PCR.Web.Server.csproj -c Release -o ./publish
