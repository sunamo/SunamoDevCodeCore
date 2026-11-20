namespace SunamoDevCodeCore.Interfaces;

/// <summary>
/// Represents the i cs file filter type.
/// </summary>
public interface ICsFileFilter
{
    /// <summary>
    /// Get files filtered.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <param name="searchPattern">The search pattern.</param>
    /// <param name="searchOption">The search option.</param>
    /// <returns>The get files filtered result.</returns>
    List<string> GetFilesFiltered(string path, string searchPattern, SearchOption searchOption);
}