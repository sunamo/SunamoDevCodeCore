namespace SunamoDevCodeCore;

using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Represents the get slns type.
/// </summary>
public class GetSlns
{
    /// <summary>
    /// Get solutions.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="onlyCs">The only cs.</param>
    /// <returns>The get solutions result.</returns>
    public static List<string> GetSolutions(ILogger logger, bool onlyCs = false)
    {
        var parameter = @"E:\vs\";
        FoldersWithSolutions.PairProjectFolderWithEnum(logger, parameter);
        FoldersWithSolutions foldersWithSolutions = new FoldersWithSolutions(logger, parameter, null!, false);
        foldersWithSolutions.Reload(logger, parameter, null!);

        List<SolutionFolder> solutionFolders = foldersWithSolutions.GetSolutions(RepositoryLocal.Vs17);
        if (onlyCs)
        {
            solutionFolders = solutionFolders.Where(solutionFolder => solutionFolder.TypeProjectFolder == ProjectsTypes.Cs).ToList();
        }

        return solutionFolders.Select(solution => solution.FullPathFolder).ToList();
    }
}