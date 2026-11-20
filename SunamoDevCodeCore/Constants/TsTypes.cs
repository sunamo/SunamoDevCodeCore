namespace SunamoDevCodeCore.Constants;

/// <summary>
/// Represents the ts types type.
/// </summary>
public class TsTypes
{
    /// <summary>
    /// The string constant.
    /// </summary>
    public const string String = "string";

    /// <summary>
    /// The number constant.
    /// </summary>
    public const string Number = "number";

    /// <summary>
    /// The bigint constant.
    /// </summary>
    public const string Bigint = "bigint";

    /// <summary>
    /// The boolean constant.
    /// </summary>
    public const string Boolean = "boolean";

    // See https://www.typescriptlang.org/docs/handbook/symbols.html
    /// <summary>
    /// The symbol constant.
    /// </summary>
    public const string Symbol = "symbol";

    /// <summary>
    /// The undefined constant.
    /// </summary>
    public const string Undefined = "undefined";

    // The TypeScript object type represents all values that are not in primitive types.
    // All other types here are primitive types.
    /// <summary>
    /// The object constant.
    /// </summary>
    public const string Object = "object";

    /// <summary>
    /// The function constant.
    /// </summary>
    public const string Function = "function";
}