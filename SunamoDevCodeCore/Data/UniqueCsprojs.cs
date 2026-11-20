namespace SunamoDevCodeCore.Data;

// Loads all csproj in directory, can convert from path to name and vice versa
/// <summary>
/// Represents the unique csprojs type.
/// </summary>
public static class UniqueCsprojs
{
    private static TwoWayDictionary<string, string> dictionary = new TwoWayDictionary<string, string>();

    /// <summary>
    /// Add from sln folder.
    /// </summary>
    /// <param name="csprojsInSolution">The csprojs in solution.</param>
    public static void AddFromSlnFolder(CsprojsInSolution csprojsInSolution)
    {
        if (dictionary.FirstToSecond.Any())
        {
            return;
        }

        foreach (var csprojPath in csprojsInSolution.CsprojPaths)
        {
            dictionary.Add(Path.GetFileNameWithoutExtension(csprojPath), csprojPath);
        }
    }

    /// <summary>
    /// To name.
    /// </summary>
    /// <param name="csprojPath">The csproj path.</param>
    /// <returns>The to name result.</returns>
    public static string ToName(string csprojPath)
    {

        return dictionary.SecondToFirst[csprojPath];
    }

    // Converts to csproj path, not to folder path
    /// <summary>
    /// To path.
    /// </summary>
    /// <param name="projectName">The project name.</param>
    /// <returns>The to path result.</returns>
    public static string ToPath(string projectName)
    {

        return dictionary.FirstToSecond[projectName];
    }
}