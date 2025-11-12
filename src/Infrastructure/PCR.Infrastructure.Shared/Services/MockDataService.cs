using System.Text.Json;
using PCR.Core.Application.Interfaces.Services;
using Microsoft.Extensions.Hosting;

namespace PCR.Infrastructure.Shared.Services;

/// <summary>
/// Servicio para cargar datos mock desde archivos JSON en wwwroot/data
/// Permite actualización en tiempo real sin recompilar
/// </summary>
public class MockDataService : IMockDataService
{
    private readonly JsonSerializerOptions _jsonOptions;
    private readonly string _dataPath;

    public MockDataService(IHostEnvironment env)
    {
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            ReadCommentHandling = JsonCommentHandling.Skip,
            AllowTrailingCommas = true
        };

        // Ruta a wwwroot/data
        var contentRoot = env.ContentRootPath;
        _dataPath = Path.Combine(contentRoot, "wwwroot", "data");
    }

    /// <summary>
    /// Obtiene todos los registros de un archivo JSON
    /// </summary>
    public async Task<List<T>> GetMockDataAsync<T>(string fileName)
    {
        try
        {
            var filePath = GetFilePath(fileName);

            if (!File.Exists(filePath))
            {
                return new List<T>();
            }

            var json = await File.ReadAllTextAsync(filePath);
            
            var data = JsonSerializer.Deserialize<List<T>>(json, _jsonOptions);
            
            return data ?? new List<T>();
        }
        catch (Exception ex)
        {
            return new List<T>();
        }
    }

    /// <summary>
    /// Obtiene un registro específico por su propiedad Id
    /// </summary>
    public async Task<T?> GetByIdAsync<T>(string fileName, int id) where T : class
    {
        var allData = await GetMockDataAsync<T>(fileName);
        
        return allData.FirstOrDefault(item =>
        {
            var idProperty = typeof(T).GetProperty("Id");
            if (idProperty == null) return false;
            
            var itemId = idProperty.GetValue(item);
            return itemId != null && itemId.Equals(id);
        });
    }

    /// <summary>
    /// Verifica si existe un archivo mock
    /// </summary>
    public bool FileExists(string fileName)
    {
        var filePath = GetFilePath(fileName);
        var exists = File.Exists(filePath);
        
        if (!exists)
        {
            Console.WriteLine($"Archivo no existe: {filePath}");
        }
        
        return exists;
    }

    /// <summary>
    /// Construye la ruta completa del archivo en wwwroot/data
    /// </summary>
    private string GetFilePath(string fileName)
    {
        if (!fileName.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
        {
            fileName += ".json";
        }

        return Path.Combine(_dataPath, fileName);
    }
}
