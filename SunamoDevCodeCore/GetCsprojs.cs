namespace SunamoDevCodeCore;

using Microsoft.Extensions.Logging;

public partial class GetCsprojs
{
    // Vrátí plné cesty k složce řešení
    public static List<string> GetCsprojsAll(ILogger logger, bool __NotCore_Projects = false, bool __NotCoreWeb_Projects = false, bool __OnlyWindowsCore_Projects = false)
    {
        var slns = GetSlns.GetSolutions(logger);
        //FoldersWithSolutions.Fwss.Where(d => d.)

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

    public static CsprojsInSolution GetCsprojInSwdNotmineAndSunamo(ILogger logger)
    {
        var PlatformIndependentNuGetPackages = GetCsprojInSolutionClass(logger, @"E:\vs\Projects\PlatformIndependentNuGetPackages\");
        return PlatformIndependentNuGetPackages;

        //var sunamoNotmine = GetCsprojInSolutionClass(@"E:\vs\Projects\sunamo.notmine\");
        ////var sunamo = GetCsprojInSolutionClass(@"E:\vs\Projects\PlatformIndependentNuGetPackages\");

        //return PlatformIndependentNuGetPackages.Intersect(sunamoNotmine);
    }

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