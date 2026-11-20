namespace SunamoDevCodeCore;

/// <summary>
/// Represents the unindexable helper type.
/// </summary>
public class UnindexableHelper
{
    /// <summary>
    /// The unindexable.
    /// </summary>
    public static Unindexable Unindexable = null!;

    /// <summary>
    /// Gets the unindexable path parts.
    /// </summary>
    public static PpkOnDriveDC UnindexablePathParts => Unindexable.UnindexablePathParts;

    /// <summary>
    /// Gets the unindexable file names.
    /// </summary>
    public static PpkOnDriveDC UnindexableFileNames => Unindexable.UnindexableFileNames;

    /// <summary>
    /// Gets the unindexable path ends.
    /// </summary>
    public static PpkOnDriveDC UnindexablePathEnds => Unindexable.UnindexablePathEnds;

    /// <summary>
    /// Gets the unindexable path starts.
    /// </summary>
    public static PpkOnDriveDC UnindexablePathStarts => Unindexable.UnindexablePathStarts;

    //    Into A1 insert SearchCodeElementsUC .ufp
    /// <summary>
    /// Load.
    /// </summary>
    /// <param name="filePaths">The file paths.</param>
    public static void Load(UnindexableFilesPaths filePaths)
    {
        Unindexable = new Unindexable();


        Unindexable.UnindexablePathParts = new PpkOnDriveDC(filePaths.FileUnindexablePathParts);

        Unindexable.UnindexableFileNames = new PpkOnDriveDC(filePaths.FileUnindexableFileNames);
        Unindexable.UnindexableFileNamesExactly = new PpkOnDriveDC(filePaths.FileUnindexableFileNamesExactly);
        Unindexable.UnindexablePathEnds = new PpkOnDriveDC(filePaths.FileUnindexablePathEnds);
        Unindexable.UnindexablePathStarts = new PpkOnDriveDC(filePaths.FileUnindexablePathStarts);
    }

    /// <summary>
    /// Is to indexed folder.
    /// </summary>
    /// <param name="filePaths">The file paths.</param>
    /// <returns>The is to indexed folder result.</returns>
    public static bool IsToIndexedFolder(string path)
    {
        if (UnindexablePathStarts != null && UnindexablePathParts != null)
        {
            if (UnindexablePathParts.TrueForAll(part => !path.Contains(part)))
                if (UnindexablePathStarts.TrueForAll(start => !path.StartsWith(start)))
                    return true;
        }
        else
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Is to indexed.
    /// </summary>
    /// <param name="!">The !.</param>
    /// <returns>The is to indexed result.</returns>
    public static bool IsToIndexed(string path, string fileName, Func<string, bool> sci_IsIndexed)
    {
        if (UnindexablePathEnds != null && UnindexableFileNames != null)
        {
            //Checking for sth for which is checking in SourceCodeIndexerRoslyn.ProcessFile
            if (UnindexablePathEnds.TrueForAll(ending => !path.EndsWith(ending)))
                if (UnindexableFileNames.TrueForAll(name => !fileName.Contains(name)))
                {
                    if (sci_IsIndexed == null)
                        return true;
                    return sci_IsIndexed(path);
                }
        }
        else
        {
            return true;
        }

        return false;
    }
}