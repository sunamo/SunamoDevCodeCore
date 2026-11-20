namespace SunamoDevCodeCore;

/// <summary>
/// Represents the vue consts type.
/// </summary>
public class VueConsts
{
    /// <summary>
    /// The cl constant.
    /// </summary>
    public const string Cl = "class ";
    /// <summary>
    /// The constructor constant.
    /// </summary>
    public const string Constructor = "constructor";
    /// <summary>
    /// The import constant.
    /// </summary>
    public const string Import = "import";
    /// <summary>
    /// The export constant.
    /// </summary>
    public const string Export = "export";
    /// <summary>
    /// The methods rcub constant.
    /// </summary>
    public const string MethodsRcub = "methods:{";
    /// <summary>
    /// The props rcub constant.
    /// </summary>
    public const string PropsRcub = "props:{";

    // name, inject, mixins, extends, watch
    // https://github.com/pablohpsilva/vuejs-component-style-guide
    /// <summary>
    /// The s start with.
    /// </summary>
    public static List<string> SStartWith = new List<string>(["name:", "inject:", "mixins:", "extends:", "watch:"]);

    /// <summary>
    /// The dont add rcub.
    /// </summary>
    public static List<string> DontAddRcub = new List<string>([MethodsRcub, PropsRcub]);

    /// <summary>
    /// The contains list.
    /// </summary>
    public static List<string> ContainsList = new List<string>([Cl]);

    /// <summary>
    /// The start with list.
    /// </summary>
    public static List<string> StartWithList = new List<string>([Constructor, Import, "//", Export]);
    /// <summary>
    /// The equal.
    /// </summary>
    public static List<char> Equal = new List<char>(['=']);
}