namespace SunamoDevCodeCore;

using Microsoft.Extensions.Logging;

/// <summary>
/// Represents the get csprojs type.
/// </summary>
public partial class GetCsprojs
{
    // Returns the full paths to the solution folder
    /// <summary>
    /// Get csprojs all.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="__NotCore_Projects">The not core projects.</param>
    /// <param name="__NotCoreWeb_Projects">The not core web projects.</param>
    /// <param name="__OnlyWindowsCore_Projects">The only windows core projects.</param>
    /// <returns>The get csprojs all result.</returns>
    public static List<string> GetCsprojsAll(ILogger logger, bool __NotCore_Projects = false, bool __NotCoreWeb_Projects = false, bool __OnlyWindowsCore_Projects = false)
    {
        var slns = GetSlns.GetSolutions(logger);

        if (!__NotCore_Projects)
        {
            slns = slns.Where(sln => !sln.Contains("__NotCore_Projects")).ToList();
        }
        if (!__NotCoreWeb_Projects)
        {
            slns = slns.Where(webSln => !webSln.Contains("__NotCoreWeb_Projects")).ToList();
        }
        if (!__OnlyWindowsCore_Projects)
        {
            slns = slns.Where(windowsSln => !windowsSln.Contains("__OnlyWindowsCore_Projects")).ToList();
        }

        List<string> result = [];
        foreach (var item in slns)
        {
            result.AddRange(GetCsprojInSolution(logger, item).Item2);
        }

        return result;
    }

    /// <summary>
    /// Get folders with at least one csproj in solution.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="slnFolder">The sln folder.</param>
    /// <returns>The get folders with at least one csproj in solution result.</returns>
    public static List<string> GetFoldersWithAtLeastOneCsprojInSolution(ILogger logger, string slnFolder)
    {
        var folders = FSGetFolders.GetFoldersEveryFolderWhichContainsFiles(logger, slnFolder, "*.csproj", SearchOption.TopDirectoryOnly);
        for (int index = folders.Count - 1; index >= 0; index--)
        {
            var csprojs = FSGetFiles.GetFilesEveryFolder(logger, folders[index], "*.csproj", SearchOption.TopDirectoryOnly).ToList();

            if (csprojs.Count == 0)
            {
                Error("No csproj");
                folders.RemoveAt(index);
            }
            else if (csprojs.Count > 1)
            {
                Error("More than one csproj");
                folders.RemoveAt(index);
            }
        }

        return folders;
    }

    static void Error(string errorMessage)
    {
        throw new Exception(errorMessage);
    }

    /// <summary>
    /// Get csproj in swd notmine and sunamo.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <returns>The get csproj in swd notmine and sunamo result.</returns>
    public static CsprojsInSolution GetCsprojInSwdNotmineAndSunamo(ILogger logger)
    {
        var PlatformIndependentNuGetPackages = GetCsprojInSolutionClass(logger, @"E:\vs\Projects\PlatformIndependentNuGetPackages\");
        return PlatformIndependentNuGetPackages;

        ////var sunamo = GetCsprojInSolutionClass(@"E:\vs\Projects\PlatformIndependentNuGetPackages\");

    }

    /// <summary>
    /// Get csprojs all dict.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <returns>The get csprojs all dict result.</returns>
    public static Dictionary<string, string> GetCsprojsAllDict(ILogger logger)
    {
        Dictionary<string, string> result = [];

        var csprojs = GetCsprojsAll(logger);
        foreach (var item in csprojs)
        {
            var fileName = Path.GetFileName(item);

            if (fileName == "Runner.csproj")
            {
                continue;
            }

            result.Add(fileName, item);
        }

        return result;
    }
}