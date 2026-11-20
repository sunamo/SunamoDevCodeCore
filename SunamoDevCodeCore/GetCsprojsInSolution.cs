namespace SunamoDevCodeCore;

partial class GetCsprojs
{
    // The difference from GetCsprojInSolution is that it returns in the object what GetCsprojInSolution returns in a Tuple
    /// <summary>
    /// Get csproj in solution class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="slnFolder">The sln folder.</param>
    /// <param name="automaticallyAddToUniqueCsprojs">The automatically add to unique csprojs.</param>
    /// <returns>The get csproj in solution class result.</returns>
    public static CsprojsInSolution GetCsprojInSolutionClass(ILogger logger, string slnFolder, bool automaticallyAddToUniqueCsprojs = true)
    {
        var (csprojNames, csprojPaths) = GetCsprojInSolution(logger, slnFolder);
        var result = new CsprojsInSolution { CsprojFolderPaths = csprojNames, CsprojPaths = csprojPaths };
        if (automaticallyAddToUniqueCsprojs)
        {
            UniqueCsprojs.AddFromSlnFolder(result);
        }

        return result;
    }

    // The difference from GetCsprojInSolution is that it returns in the object what GetCsprojInSolution returns in a Tuple
    // 1 - csprojFolderPaths
    // 2 - csprojPaths
    /// <summary>
    /// Initializes a new instance of the get csproj in solution class.
    /// </summary>
    /// <param name="List<string>">The list string.</param>
    public static (List<string>, List<string>) GetCsprojInSolution(ILogger logger, string slnFolder)
    {
        List<string> csprojPaths = [];

        var csprojFolderPaths = FSGetFolders.GetFoldersEveryFolderWhichContainsFiles(logger, slnFolder, "*.csproj", SearchOption.TopDirectoryOnly);
        for (int index = csprojFolderPaths.Count - 1; index >= 0; index--)
        {
            var csprojFolderPath = csprojFolderPaths[index];
            var csprojs = FSGetFiles.GetFilesEveryFolder(logger, csprojFolderPath, "*.csproj", SearchOption.TopDirectoryOnly).ToList();

            if (csprojs.Count == 0)
            {
                Error("No csproj in " + csprojFolderPath);
                csprojFolderPaths.RemoveAt(index);
            }
            else if (csprojs.Count > 1)
            {
                foreach (var item in csprojs.Where(csproj => csproj.Contains(" - Backup")))
                {
                    File.Delete(item);
                }
                csprojs = csprojs.Where(csprojPath => !csprojPath.Contains(" - Backup")).ToList();
                if (csprojs.Count > 1)
                {
                    Error("More than one csproj in " + csprojFolderPath);
                    csprojFolderPaths.RemoveAt(index);
                }
            }
            else
            {
                csprojPaths.Add(csprojs[0]);
            }
            //E:\vs\Projects\PlatformIndependentNuGetPackages\SunamoCl\SunamoCl.csproj
        }

        csprojPaths.Reverse();

        return (csprojFolderPaths, csprojPaths);
    }

    /// <summary>
    /// Get csprojs in solution.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="slnFolder">The sln folder.</param>
    /// <returns>The get csprojs in solution result.</returns>
    [Obsolete("Tato metoda se zdá být zbytečná. Její práci dělá jiná v tomto souboru.")]
    public static List<string> GetCsprojsInSolution(ILogger logger, string slnFolder)
    {
        var foldersWithCsproj = GetFoldersWithAtLeastOneCsprojInSolution(logger, slnFolder);
        var result = new List<string>(foldersWithCsproj.Count);
        foreach (var item in foldersWithCsproj)
        {
            result.Add(FSGetFiles.GetFilesEveryFolder(logger, item, "*.csproj", SearchOption.TopDirectoryOnly)[0]);
        }
        return result;
    }
}