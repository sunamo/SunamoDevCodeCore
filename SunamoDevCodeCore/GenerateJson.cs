namespace SunamoDevCodeCore;

/// <summary>
/// Represents the generate json type.
/// </summary>
public class GenerateJson
{
    /// <summary>
    /// With snake convention dict.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <returns>The with snake convention dict result.</returns>
    public static Dictionary<string, string> WithSnakeConventionDict(List<string> list)
    {
        var dictionary = new Dictionary<string, string>();
        foreach (var item in list) dictionary.Add(ConvertSnakeConvention.ToConvention(item), item);
        return dictionary;
    }

    /// <summary>
    /// With snake convention.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <returns>The with snake convention result.</returns>
    public static string WithSnakeConvention(List<string> list)
    {
        var dictionary = WithSnakeConventionDict(list);
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("{");
        foreach (var item in dictionary) stringBuilder.AppendLine($"{SH.WrapWithQm(item.Key) + ": " + SH.WrapWithQm(item.Value)},");
        stringBuilder.AppendLine("}");

        return stringBuilder.ToString();
    }
}