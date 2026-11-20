namespace SunamoDevCodeCore.Data;

/// <summary>
/// Represents the parse global usings result type.
/// </summary>
public class ParseGlobalUsingsResult
{
    /// <summary>
    /// Gets or sets the global usings.
    /// </summary>
    public List<string> GlobalUsings { get; set; } = new List<string>();

    /// <summary>
    /// Gets or sets the global symbols.
    /// </summary>
    public Dictionary<string, string> GlobalSymbols { get; set; } = new();
}