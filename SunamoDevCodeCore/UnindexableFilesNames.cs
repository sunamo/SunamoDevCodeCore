namespace SunamoDevCodeCore;

/// <summary>
/// Represents the unindexable files names type.
/// </summary>
public class UnindexableFilesNames
{
    /// <summary>
    /// Gets the instance.
    /// </summary>
    public static UnindexableFilesNames Instance { get; } = new();
    /// <summary>
    /// Gets the file unindexable file names.
    /// </summary>
    public string FileUnindexableFileNames { get; } = "unindexableFileNames.txt";
    /// <summary>
    /// Gets the file unindexable file names exactly.
    /// </summary>
    public string FileUnindexableFileNamesExactly { get; } = "unindexableFileNamesExactly.txt";
    /// <summary>
    /// Gets the file unindexable path ends.
    /// </summary>
    public string FileUnindexablePathEnds { get; } = "unindexablePathEnds.txt";
    /// <summary>
    /// Gets the file unindexable path parts.
    /// </summary>
    public string FileUnindexablePathParts { get; } = "unindexablePathParts.txt";
    /// <summary>
    /// Gets the file unindexable path starts.
    /// </summary>
    public string FileUnindexablePathStarts { get; } = "unindexablePathStarts.txt";

    private UnindexableFilesNames()
    {
    }
}