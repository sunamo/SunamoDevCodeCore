namespace SunamoDevCodeCore;

// Cant be derived from FiltersNotTranslateAble because easy of finding instances of CsFileFilter
public partial class CsFileFilter : ICsFileFilter
{
    /// <summary>
    /// Represents the end args type.
    /// </summary>
    public class EndArgs
    {
        /// <summary>
        /// The designer cs.
        /// </summary>
        public bool designerCs;
        /// <summary>
        /// The designer cs.
        /// </summary>
        public bool DesignerCs;
        /// <summary>
        /// The g cs.
        /// </summary>
        public bool gCs;
        /// <summary>
        /// The g i cs.
        /// </summary>
        public bool gICs;
        /// <summary>
        /// The i cs.
        /// </summary>
        public bool iCs;
        /// <summary>
        /// The not translate able.
        /// </summary>
        public bool notTranslateAble;
        /// <summary>
        /// The shared cs.
        /// </summary>
        public bool sharedCs;
        /// <summary>
        /// The tmp.
        /// </summary>
        public bool tmp;
        /// <summary>
        /// The TMP.
        /// </summary>
        public bool TMP;
        /// <summary>
        /// The xaml cs.
        /// </summary>
        public bool xamlCs;
        // false which not to index, true which to index
        /// <summary>
        /// Initializes a new instance of the end args class.
        /// </summary>
        /// <param name="designerCs">The designer cs.</param>
        /// <param name="xamlCs">The xaml cs.</param>
        /// <param name="sharedCs">The shared cs.</param>
        /// <param name="/*">The /*.</param>
        /// <param name="gICs*/">The g i cs.</param>
        /// <param name="gCs">The g cs.</param>
        /// <param name="tmp">The tmp.</param>
        /// <param name="TMP">The TMP.</param>
        /// <param name="DesignerCs">The designer cs.</param>
        public EndArgs(bool designerCs, bool xamlCs, bool sharedCs, bool iCs /*, bool gICs*/, bool gCs, bool tmp, bool TMP, bool DesignerCs)
        {
            this.designerCs = designerCs;
            this.xamlCs = xamlCs;
            this.sharedCs = sharedCs;
            this.iCs = iCs;
            this.gCs = gCs;
            this.tmp = tmp;
            this.TMP = TMP;
            this.DesignerCs = DesignerCs;
        }
    }

    /// <summary>
    /// Allow only.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <returns>The allow only result.</returns>
    public bool AllowOnly(string filePath)
    {
        return AllowOnly(filePath, true);
    }

    /// <summary>
    /// Allow only.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <param name="isAlsoCheckingEnds">The is also checking ends.</param>
    /// <returns>The allow only result.</returns>
    public bool AllowOnly(string filePath, bool isAlsoCheckingEnds)
    {
        var hasEndMatch = true;
        return !AllowOnly(filePath, endArgs!, containsArgs!, ref hasEndMatch, isAlsoCheckingEnds);
    }

    /// <summary>
    /// Allow only contains.
    /// </summary>
    /// <param name="designerCs">The designer cs.</param>
    /// <param name="xamlCs">The xaml cs.</param>
    /// <param name="sharedCs">The shared cs.</param>
    /// <param name="/*">The /*.</param>
    /// <param name="gICs*/">The g i cs.</param>
    /// <param name="gCs">The g cs.</param>
    /// <param name="tmp">The tmp.</param>
    /// <param name="TMP">The TMP.</param>
    /// <param name="DesignerCs">The designer cs.</param>
    /// <returns>The allow only contains result.</returns>
    public bool AllowOnlyContains(string itemPath)
    {
        return !AllowOnlyContains(itemPath, containsArgs!);
    }
}