namespace SunamoDevCodeCore.Data;

// Loads all csproj in directory, can convert from path to name and vice versa
public static class UniqueCsprojs
{
    private static TwoWayDictionary<string, string> dictionary = new TwoWayDictionary<string, string>();

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

    public static string ToName(string csprojPath)
    {

        return dictionary.SecondToFirst[csprojPath];
    }

    // Converts to csproj path, not to folder path
    public static string ToPath(string projectName)
    {

        return dictionary.FirstToSecond[projectName];
    }
}