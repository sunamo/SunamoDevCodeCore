namespace SunamoDevCodeCore;

partial class GetCsprojs
{
    // Rozdíl oproti GetCsprojInSolution je že vrací v objektu co je z GetCsprojInSolution v Tuple
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

    // Rozdíl oproti GetCsprojInSolution je že vrací v objektu co je z GetCsprojInSolution v Tuple
    // 1 - csprojFolderPaths
    // 2 - csprojPaths
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