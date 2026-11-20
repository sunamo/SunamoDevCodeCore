namespace SunamoDevCodeCore.Data;

/// <summary>
/// Represents the exists non exists list t type.
/// </summary>
public class ExistsNonExistsList<T>
{
    /// <summary>
    /// Gets or sets the exists.
    /// </summary>
    public List<T> Exists { get; set; } = new List<T>();

    /// <summary>
    /// Gets or sets the non exists.
    /// </summary>
    public List<T> NonExists { get; set; } = new List<T>();
}