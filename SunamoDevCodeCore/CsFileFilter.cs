namespace SunamoDevCodeCore;

// Filter for C# files with configurable filtering rules
// Cannot be derived from FiltersNotTranslateAble to make finding instances of CsFileFilter easier
/// <summary>
/// Represents the cs file filter type.
/// </summary>
public partial class CsFileFilter : ICsFileFilter
{
    private static readonly FiltersNotTranslateAble filtersNotTranslateable = FiltersNotTranslateAble.Instance;
    private static bool? _returnValue;
    private ContainsArgs? containsArgs;
    private EndArgs? endArgs;
    // In default is everything in false
    // Call some Set* method
    /// <summary>
    /// Initializes a new instance of the cs file filter class.
    /// </summary>
    public CsFileFilter()
    {
    }

    private static bool? returnValue
    {
        get => _returnValue;
        set
        {
            if (value.HasValue)
                if (!value.Value)
                {
                }

            _returnValue = value;
        }
    }

    /// <summary>
    /// Get files filtered.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <param name="searchPattern">The search pattern.</param>
    /// <param name="searchOption">The search option.</param>
    /// <returns>The get files filtered result.</returns>
    public List<string> GetFilesFiltered(string path, string searchPattern, SearchOption searchOption)
    {
        var files = Directory.GetFiles(path, searchPattern, searchOption).ToList();
        files.RemoveAll(AllowOnly);
        files.RemoveAll(AllowOnlyContains);
        return files;
    }

    /// <summary>
    /// Allow only.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <param name="end">The end.</param>
    /// <param name="containsArgs">The contains args.</param>
    /// <returns>The allow only result.</returns>
    public static bool AllowOnly(string filePath, EndArgs end, ContainsArgs containsArgs)
    {
        var hasEndMatch = false;
        return AllowOnly(filePath, end, containsArgs, ref hasEndMatch, true);
    }

    // A2 is also for master.designer.cs and aspx.designer.cs
    // A2,3 can be null
    /// <summary>
    /// Allow only.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <param name="end">The end.</param>
    /// <param name="containsArgs">The contains args.</param>
    /// <param name="hasEndMatch">The has end match.</param>
    /// <param name="isAlsoCheckingEnds">The is also checking ends.</param>
    /// <returns>The allow only result.</returns>
    public static bool AllowOnly(string filePath, EndArgs end, ContainsArgs containsArgs, ref bool hasEndMatch, bool isAlsoCheckingEnds)
    {
        returnValue = null;
        if (isAlsoCheckingEnds && end != null)
        {
            hasEndMatch = true;
            if (!end.designerCs && filePath.EndsWith(End.designerCsPp))
                returnValue = false;
            if (!end.xamlCs && filePath.EndsWith(End.xamlCsPp))
                returnValue = false;
            if (!end.sharedCs && filePath.EndsWith(End.sharedCsPp))
                returnValue = false;
            if (!end.iCs && filePath.EndsWith(End.iCsPp))
                returnValue = false;
            if (!end.gICs && filePath.EndsWith(End.gICsPp))
                returnValue = false;
            if (!end.gCs && filePath.EndsWith(End.gCsPp))
                returnValue = false;
            if (!end.tmp && filePath.EndsWith(End.tmpPp))
                returnValue = false;
            if (!end.TMP && filePath.EndsWith(End.TMPPp))
                returnValue = false;
            if (!end.DesignerCs && filePath.EndsWith(End.DesignerCsPp))
                returnValue = false;
            if (!end.notTranslateAble && filePath.EndsWith(End.NotTranslateAblePp))
                returnValue = false;
        }

        if (returnValue.HasValue)
            // Always false
            return returnValue.Value;
        hasEndMatch = false;
        if (containsArgs != null)
        {
            if (!containsArgs.binFp && filePath.Contains(Contains.binFp))
                returnValue = false;
            if (!containsArgs.objFp && filePath.Contains(Contains.objFp))
                returnValue = false;
            if (!containsArgs.tildaRF && filePath.Contains(Contains.tildaRFFp))
                returnValue = false;
        }

        if (returnValue.HasValue)
            // Always false
            return returnValue.Value;
        return true;
    }

    /// <summary>
    /// Set.
    /// </summary>
    /// <param name="endArguments">The end arguments.</param>
    /// <param name="containsArguments">The contains arguments.</param>
    public void Set(EndArgs endArguments, ContainsArgs containsArguments)
    {
        endArgs = endArguments;
        this.containsArgs = containsArguments;
    }

    /// <summary>
    /// Set default.
    /// </summary>
    public void SetDefault()
    {
        //false which not to index, true which to index
        endArgs = new EndArgs(false, true, true, false /*, false*/, false, false, false, false);
        containsArgs = new ContainsArgs(false, false, false /*, false*/);
    }

    // Gets list of "contains" patterns based on flags
    /// <summary>
    /// Get contains by flags.
    /// </summary>
    /// <param name="negate">The negate.</param>
    /// <returns>The get contains by flags result.</returns>
    public List<string> GetContainsByFlags(bool negate)
    {
        var containsList = new List<string>();
        if (BTS.Is(containsArgs!.binFp, negate))
            containsList.Add(Contains.binFp);
        if (BTS.Is(containsArgs.objFp, negate))
            containsList.Add(Contains.objFp);
        if (BTS.Is(containsArgs.tildaRF, negate))
            containsList.Add(Contains.tildaRFFp);
        return containsList;
    }

    /// <summary>
    /// Get ending by flags.
    /// </summary>
    /// <param name="negate">The negate.</param>
    /// <returns>The get ending by flags result.</returns>
    public List<string> GetEndingByFlags(bool negate)
    {
        var endingsList = new List<string>();
        if (Is(endArgs!.designerCs, negate))
            endingsList.Add(End.designerCsPp);
        if (Is(endArgs.xamlCs, negate))
            endingsList.Add(End.xamlCsPp);
        if (Is(endArgs.xamlCs, negate))
            endingsList.Add(End.xamlCsPp);
        if (Is(endArgs.sharedCs, negate))
            endingsList.Add(End.sharedCsPp);
        if (Is(endArgs.iCs, negate))
            endingsList.Add(End.iCsPp);
        if (Is(endArgs.gICs, negate))
            endingsList.Add(End.gICsPp);
        if (Is(endArgs.gCs, negate))
            endingsList.Add(End.gCsPp);
        if (Is(endArgs.tmp, negate))
            endingsList.Add(End.tmpPp);
        if (Is(endArgs.TMP, negate))
            endingsList.Add(End.TMPPp);
        if (Is(endArgs.DesignerCs, negate))
            endingsList.Add(End.DesignerCsPp);
        if (Is(endArgs.notTranslateAble, negate))
            endingsList.Add(filtersNotTranslateable.NotTranslateAblePp);
        return endingsList;
    }

    private bool Is(bool flagValue, bool negate)
    {
        return BTS.Is(flagValue, negate);
    }

    /// <summary>
    /// Allow only contains.
    /// </summary>
    /// <param name="itemPath">The item path.</param>
    /// <param name="containsArgs">The contains args.</param>
    /// <returns>The allow only contains result.</returns>
    public static bool AllowOnlyContains(string itemPath, ContainsArgs containsArgs)
    {
        if (!containsArgs.objFp && itemPath.Contains(@"\obj\"))
            return false;
        if (!containsArgs.binFp && itemPath.Contains(@"\bin\"))
            return false;
        if (!containsArgs.tildaRF && itemPath.Contains(@"RF~"))
            return false;
        return true;
    }

    /// <summary>
    /// Represents the contains type.
    /// </summary>
    public class Contains
    {
        /// <summary>
        /// The not translate able fp constant.
        /// </summary>
        public const string notTranslateAbleFp = "NotTranslateAble";
        /// <summary>
        /// The obj fp.
        /// </summary>
        public static string objFp = @"\obj\";
        /// <summary>
        /// The bin fp.
        /// </summary>
        public static string binFp = @"\bin\";
        /// <summary>
        /// The tilda RF fp.
        /// </summary>
        public static string tildaRFFp = "~RF";
        private static List<string> unindexablePaths = null!;
        // Into A1 is inserting copy to leave only unindexed
        /// <summary>
        /// Fill end from file list.
        /// </summary>
        /// <param name="unindexablePathEnds">The unindexable path ends.</param>
        /// <returns>The fill end from file list result.</returns>
        public static ContainsArgs FillEndFromFileList(List<string> unindexablePathEnds)
        {
            unindexablePaths = unindexablePathEnds;
            var containsArgs = new ContainsArgs(ContainsPattern(objFp), ContainsPattern(binFp), ContainsPattern(tildaRFFp) /*, ContainsPattern(notTranslateAbleFp)*/);
            return containsArgs;
        }

        private static bool ContainsPattern(string pattern)
        {
            return unindexablePaths.Contains(pattern);
        }
    }

    /// <summary>
    /// Represents the contains args type.
    /// </summary>
    public class ContainsArgs
    {
        /// <summary>
        /// The bin fp.
        /// </summary>
        public bool binFp;
        /// <summary>
        /// The obj fp.
        /// </summary>
        public bool objFp;
        /// <summary>
        /// The tilda RF.
        /// </summary>
        public bool tildaRF;
        // false which not to index, true which to index
        /// <summary>
        /// Contains args.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <returns>The contains args result.</returns>
        public ContainsArgs(bool objFp, bool binFp, bool tildaRF)
        {
            this.objFp = objFp;
            this.binFp = binFp;
            this.tildaRF = tildaRF;
        }
    }

    /// <summary>
    /// Represents the end type.
    /// </summary>
    public class End
    {
        /// <summary>
        /// The not translate able pp constant.
        /// </summary>
        public const string NotTranslateAblePp = "NotTranslateAble";
        /// <summary>
        /// The designer cs pp constant.
        /// </summary>
        public const string designerCsPp = ".designer.cs";
        /// <summary>
        /// The designer cs pp constant.
        /// </summary>
        public const string DesignerCsPp = ".Designer.cs";
        /// <summary>
        /// The xaml cs pp constant.
        /// </summary>
        public const string xamlCsPp = ".xaml.cs";
        /// <summary>
        /// The shared cs pp constant.
        /// </summary>
        public const string sharedCsPp = "Shared.cs";
        /// <summary>
        /// The i cs pp constant.
        /// </summary>
        public const string iCsPp = ".i.cs";
        /// <summary>
        /// The g i cs pp constant.
        /// </summary>
        public const string gICsPp = ".g.i.cs";
        /// <summary>
        /// The g cs pp constant.
        /// </summary>
        public const string gCsPp = ".g.cs";
        /// <summary>
        /// The tmp pp constant.
        /// </summary>
        public const string tmpPp = ".tmp";
        /// <summary>
        /// The TMP pp constant.
        /// </summary>
        public const string TMPPp = ".TMP";
        private static List<string> unindexablePaths = null!;
        // Into A1 is inserting copy to leave only unindexed
        /// <summary>
        /// Fill end from file list.
        /// </summary>
        /// <param name="unindexablePathEnds">The unindexable path ends.</param>
        /// <returns>The fill end from file list result.</returns>
        public static EndArgs FillEndFromFileList(List<string> unindexablePathEnds)
        {
            unindexablePaths = unindexablePathEnds;
            var endArgs = new EndArgs(ContainsPattern(designerCsPp), ContainsPattern(xamlCsPp), ContainsPattern(sharedCsPp), ContainsPattern(iCsPp) /*, ContainsPattern(gICsPp)*/, ContainsPattern(gCsPp), ContainsPattern(tmpPp), ContainsPattern(TMPPp), ContainsPattern(DesignerCsPp));
            return endArgs;
        }

        private static bool ContainsPattern(string pattern)
        {
            if (unindexablePaths.Contains(pattern))
            {
                // Really I want to delete it
                unindexablePaths.Remove(pattern);
                return false;
            }

            return true;
        }
    }
}