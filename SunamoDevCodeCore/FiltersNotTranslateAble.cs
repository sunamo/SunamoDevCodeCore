namespace SunamoDevCodeCore;

/// <summary>
/// Represents the filters not translate able type.
/// </summary>
public class FiltersNotTranslateAble
{
    /// <summary>
    /// The instance.
    /// </summary>
    public static FiltersNotTranslateAble Instance = new();

    // List of substrings - if a path contains any of these, it should not be translated.
    /// <summary>
    /// The contains.
    /// </summary>
    public readonly List<string> Contains;

    // Is good include the most files as is possible due to performamce
    /// <summary>
    /// The ending.
    /// </summary>
    public readonly List<string> Ending;

    /// <summary>
    /// The assembly info.
    /// </summary>
    public string AssemblyInfo = "AssemblyInfo.cs";
    /// <summary>
    /// The attributes.
    /// </summary>
    public string Attributes = "Attributes";
    /// <summary>
    /// The consts.
    /// </summary>
    public string Consts = "Consts";
    /// <summary>
    /// The credentials.
    /// </summary>
    public string Credentials = "Credentials";
    /// <summary>
    /// The enigma data.
    /// </summary>
    public string EnigmaData = "EnigmaData.cs";
    /// <summary>
    /// The enums.
    /// </summary>
    public string Enums = "Enums";
    /// <summary>
    /// The interfaces.
    /// </summary>
    public string Interfaces = "Interfaces";
    /// <summary>
    /// The layer.
    /// </summary>
    public string Layer = "Layer.cs";
    /// <summary>
    /// The not translate able cs.
    /// </summary>
    public string NotTranslateAbleCs = "NotTranslateAble.cs";
    /// <summary>
    /// The not translate able pp.
    /// </summary>
    public string NotTranslateAblePp = "NotTranslateAble";
    /// <summary>
    /// The standard.
    /// </summary>
    public string Standard = @"\standard\";

    // in XLF is not available sess coz is in sunamo
    /// <summary>
    /// The sunamo xlf.
    /// </summary>
    public string SunamoXlf = "sunamo\\Xlf";

    // All which is WithoutDep cant have Xlf
    // If yes, I couldn't have Xlf.web and Xlf
    /// <summary>
    /// The without dep.
    /// </summary>
    public string WithoutDep = "WithoutDep";

    private FiltersNotTranslateAble()
    {
        Ending = new List<string>([AssemblyInfo, Layer, NotTranslateAbleCs]);
        Contains = new List<string>([SunamoXlf, WithoutDep, Credentials, Interfaces, Enums, NotTranslateAblePp, Consts,
            Standard]);
    }
}