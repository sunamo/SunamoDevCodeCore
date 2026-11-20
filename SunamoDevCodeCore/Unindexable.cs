namespace SunamoDevCodeCore;

/// <summary>
/// Represents the unindexable type.
/// </summary>
public class Unindexable
{
    /// <summary>
    /// Gets or sets the unindexable file names.
    /// </summary>
    public PpkOnDriveDC UnindexableFileNames { get; set; } = null!;
    /// <summary>
    /// Gets or sets the unindexable file names exactly.
    /// </summary>
    public PpkOnDriveDC UnindexableFileNamesExactly { get; set; } = null!;
    /// <summary>
    /// Gets or sets the unindexable path ends.
    /// </summary>
    public PpkOnDriveDC UnindexablePathEnds { get; set; } = null!;
    /// <summary>
    /// Gets or sets the unindexable path parts.
    /// </summary>
    public PpkOnDriveDC UnindexablePathParts { get; set; } = null!;
    /// <summary>
    /// Gets or sets the unindexable path starts.
    /// </summary>
    public PpkOnDriveDC UnindexablePathStarts { get; set; } = null!;
}