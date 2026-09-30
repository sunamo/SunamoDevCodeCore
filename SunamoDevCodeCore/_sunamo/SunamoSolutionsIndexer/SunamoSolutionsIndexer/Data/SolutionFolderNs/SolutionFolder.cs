namespace SunamoDevCodeCore._sunamo.SunamoSolutionsIndexer.SunamoSolutionsIndexer.Data.SolutionFolderNs;

internal partial class SolutionFolder : SolutionFolderSerialize, ISolutionFolder
{
    public new static Type Type { get; } = typeof(SolutionFolder);

    public SolutionFolder(SolutionFolderSerialize source)
    {
        DisplayedText = source.DisplayedText;
        _FullPathFolder = source._FullPathFolder;
        _NameSolution = source._NameSolution;
        projectFolder = source.projectFolder;
        slnFullPath = source.slnFullPath;
        if (source.GetType() == Type)
        {
            var sourceSolutionFolder = (SolutionFolder)source;
            SlnNameWithoutExtension = sourceSolutionFolder.SlnNameWithoutExtension;
        }
    }

    // Gets or sets the type of project folder (C# Projects, PHP PHP_Projects, etc.).
    public ProjectsTypes TypeProjectFolder { get; set; } = ProjectsTypes.None;

    public void UpdateModules(ILogger logger, PpkOnDriveDC toSelling)
    {
        if (toSelling != null)
        {
            ModulesSelling = SolutionsIndexerHelper.ModulesInSolution(logger, ProjectsInSolution, FullPathFolder, true, toSelling);
            ModulesNotSelling = SolutionsIndexerHelper.ModulesInSolution(logger, ProjectsInSolution, FullPathFolder, false, toSelling);
        }
    }

    public SolutionFolder()
    {
    }

    private List<string> _projects = new List<string>();

    // Gets or sets projects in solution.
    // Only name without path.
    // Is filled in constructor with CreateSolutionFolder().
    // Only subfolders. Csproj files must be found out manually.
    // Csproj are available to get with GetCsprojs().
    public List<string> ProjectsInSolution { get => _projects; set => _projects = value; }

    private List<string>? _projectsGetCsprojs = null;

    // Gets or sets projects from SolutionFolder.GetCsprojs method.
    public List<string> ProjectsGetCsprojs
    {
        get => _projectsGetCsprojs!;
        set => _projectsGetCsprojs = value;
    }

    // Gets or sets modules for selling in format solution name\project name\module name.
    public List<string> ModulesSelling { get; set; } = new List<string>();

    // Gets or sets modules not for selling in format solution name\project name\module name.
    public List<string> ModulesNotSelling { get; set; } = new List<string>();

    public string NameSolutionWithoutDiacritic { get; set; } = "";

    public int CountOfImages { get; set; } = 0;

    public bool InVsFolder { get; set; } = false;

    public RepositoryLocal Repository { get; set; }

    public string? SlnNameWithoutExtension { get; set; } = null;

    public override string ToString()
    {
        if (CountOfImages != 0)
        {
            return $"{DisplayedText} ({CountOfImages} images)";
        }

        return DisplayedText;
    }

    public static bool operator>(SolutionFolder left, SolutionFolder right)
    {
        return left.CountOfImages > right.CountOfImages;
    }

    public static bool operator <(SolutionFolder left, SolutionFolder right)
    {
        return left.CountOfImages < right.CountOfImages;
    }
}