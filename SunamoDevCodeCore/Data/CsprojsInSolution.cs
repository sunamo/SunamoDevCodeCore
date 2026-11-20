namespace SunamoDevCodeCore.Data;

/// <summary>
/// Represents the csprojs in solution type.
/// </summary>
public class CsprojsInSolution
{
    /// <summary>
    /// Gets or sets the csproj folder paths.
    /// </summary>
    public List<string> CsprojFolderPaths { get; set; } = null!;
    /// <summary>
    /// Gets or sets the csproj paths.
    /// </summary>
    public List<string> CsprojPaths { get; set; } = null!;

    /// <summary>
    /// To dictionary.
    /// </summary>
    /// <returns>The to dictionary result.</returns>
    public Dictionary<string, string> ToDictionary()
    {
        Dictionary<string, string> dictionary = [];

        TestBothHaveSameLength();

        for (int index = 0; index < CsprojFolderPaths.Count; index++)
        {
            dictionary.Add(CsprojFolderPaths[index], CsprojPaths[index]);
        }

        return dictionary;
    }

    private void TestBothHaveSameLength()
    {
        if (CsprojPaths.Count != CsprojFolderPaths.Count)
        {
            ThrowEx.Custom("Different count in collection");
        }
    }

    /// <summary>
    /// Initializes a new instance of the intersect class.
    /// </summary>
    /// <param name="!">The !.</param>
    public CsprojsInSolution Intersect(CsprojsInSolution other)
    {
        CsprojFolderPaths.AddRange(other.CsprojFolderPaths);
        CsprojPaths.AddRange(other.CsprojPaths);

        var distinctFolderPaths = CsprojFolderPaths.Distinct();
        if (distinctFolderPaths.Count() != CsprojFolderPaths.Count)
        {
            ThrowEx.Custom("Not all CsprojNames is unique");
        }

        return this;
    }
}