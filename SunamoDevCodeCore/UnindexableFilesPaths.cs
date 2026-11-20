namespace SunamoDevCodeCore;

/// <summary>
/// Represents the unindexable files paths type.
/// </summary>
public class UnindexableFilesPaths
{
    /// <summary>
    /// Gets or sets the file unindexable file names.
    /// </summary>
    public string FileUnindexableFileNames { get; set; }
    /// <summary>
    /// Gets or sets the file unindexable file names exactly.
    /// </summary>
    public string FileUnindexableFileNamesExactly { get; set; }
    /// <summary>
    /// Gets or sets the file unindexable path ends.
    /// </summary>
    public string FileUnindexablePathEnds { get; set; }
    /// <summary>
    /// Gets or sets the file unindexable path parts.
    /// </summary>
    public string FileUnindexablePathParts { get; set; }
    /// <summary>
    /// Gets or sets the file unindexable path starts.
    /// </summary>
    public string FileUnindexablePathStarts { get; set; }

    /// <summary>
    /// Initializes a new instance of the unindexable files paths class.
    /// </summary>
    /// <param name="basePath">The base path.</param>
    public UnindexableFilesPaths(string basePath)
    {
        var fileNames = UnindexableFilesNames.Instance;
        FileUnindexablePathParts = basePath + fileNames.FileUnindexablePathParts;
        FileUnindexableFileNames = basePath + fileNames.FileUnindexableFileNames;
        FileUnindexableFileNamesExactly = basePath + fileNames.FileUnindexableFileNamesExactly;
        FileUnindexablePathEnds = basePath + fileNames.FileUnindexablePathEnds;
        FileUnindexablePathStarts = basePath + fileNames.FileUnindexablePathStarts;
    }
}