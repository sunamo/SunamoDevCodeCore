namespace SunamoDevCodeCore.Data;

/// <summary>
/// Represents the unindexable files type.
/// </summary>
public class UnindexableFiles
{
    /// <summary>
    /// The instance.
    /// </summary>
    public static UnindexableFiles Instance = new UnindexableFiles();

    private UnindexableFiles()
    {
    }

    /// <summary>
    /// Gets or sets the unindexable path parts files.
    /// </summary>
    public CollectionWithoutDuplicatesDC<string> UnindexablePathPartsFiles { get; set; } = new CollectionWithoutDuplicatesDC<string>();

    /// <summary>
    /// Gets or sets the unindexable file names files.
    /// </summary>
    public CollectionWithoutDuplicatesDC<string> UnindexableFileNamesFiles { get; set; } = new CollectionWithoutDuplicatesDC<string>();

    /// <summary>
    /// Gets or sets the unindexable file names exactly files.
    /// </summary>
    public CollectionWithoutDuplicatesDC<string> UnindexableFileNamesExactlyFiles { get; set; } = new CollectionWithoutDuplicatesDC<string>();

    /// <summary>
    /// Gets or sets the unindexable path ends files.
    /// </summary>
    public CollectionWithoutDuplicatesDC<string> UnindexablePathEndsFiles { get; set; } = new CollectionWithoutDuplicatesDC<string>();

    /// <summary>
    /// Gets or sets the unindexable path starts files.
    /// </summary>
    public CollectionWithoutDuplicatesDC<string> UnindexablePathStartsFiles { get; set; } = new CollectionWithoutDuplicatesDC<string>();
}