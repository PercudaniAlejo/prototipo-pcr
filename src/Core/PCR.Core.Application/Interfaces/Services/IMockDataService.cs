namespace PCR.Core.Application.Interfaces.Services;

/// <summary>
/// Interfaz para el servicio de datos mock.
/// La implementación está en PCR.Infrastructure.Shared
/// </summary>
public interface IMockDataService
{
    /// <summary>
    /// Obtiene datos mock desde un archivo JSON
    /// </summary>
    /// <typeparam name="T">Tipo de entidad a deserializar</typeparam>
    /// <param name="fileName">Nombre del archivo JSON (ej: "users.json")</param>
    /// <returns>Lista de entidades deserializadas</returns>
    Task<List<T>> GetMockDataAsync<T>(string fileName);

    /// <summary>
    /// Obtiene un registro específico por ID
    /// </summary>
    Task<T?> GetByIdAsync<T>(string fileName, int id) where T : class;

    /// <summary>
    /// Verifica si existe un archivo mock
    /// </summary>
    bool FileExists(string fileName);
}
