namespace SunamoDevCodeCore;

using System.Collections.Generic;
using System.Linq;

public class GetSlns
{
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