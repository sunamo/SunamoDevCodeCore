namespace SunamoDevCodeCore;

/// <summary>
/// Represents the repo get file masc generator data type.
/// </summary>
public class RepoGetFileMascGeneratorData
{
    /// <summary>
    /// Gets or sets the cs.
    /// </summary>
    public bool Cs { get; set; }
    /// <summary>
    /// Gets or sets the css.
    /// </summary>
    public bool Css { get; set; }
    /// <summary>
    /// Gets or sets the js jsx.
    /// </summary>
    public bool JsJsx { get; set; }
    /// <summary>
    /// Gets or sets the json.
    /// </summary>
    public bool Json { get; set; }
    /// <summary>
    /// Gets or sets the scss.
    /// </summary>
    public bool Scss { get; set; }
    /// <summary>
    /// Gets or sets the ts tsx.
    /// </summary>
    public bool TsTsx { get; set; }
    /// <summary>
    /// Gets or sets the yaml.
    /// </summary>
    public bool Yaml { get; set; }

    /// <summary>
    /// Numbers of.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The numbers of result.</returns>
    public int NumbersOf(bool value)
    {
        var count = 0;
        if (TsTsx == value) count++;
        if (JsJsx == value) count++;
        if (Scss == value) count++;
        if (Json == value) count++;
        if (Yaml == value) count++;
        if (Css == value) count++;
        if (Cs == value) count++;
        return count;
    }

    /// <summary>
    /// All source codes.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The all source codes result.</returns>
    public static RepoGetFileMascGeneratorData AllSourceCodes()
    {
        var argument = new RepoGetFileMascGeneratorData();
        argument.AllTo(true);
        return argument;
    }

    /// <summary>
    /// All to.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The all to result.</returns>
    public void AllTo(bool value)
    {
        // do it with reflection
        TsTsx = value;
        JsJsx = value;
        Scss = value;
        Json = value;
        Yaml = value;
        Css = value;
        Cs = value;
    }

    /// <summary>
    /// Generate.
    /// </summary>
    /// <returns>The generate result.</returns>
    public string Generate()
    {
        var stringBuilder = new StringBuilder();
        if (TsTsx) stringBuilder.Append("*.ts;*.tsx;");
        if (JsJsx) stringBuilder.Append("*.js;*.jsx;");
        if (Scss) stringBuilder.Append("*.scss;");
        if (Json) stringBuilder.Append("*.json;");
        if (Yaml) stringBuilder.Append("*.yaml;");
        if (Css) stringBuilder.Append("*.css;");
        if (Cs) stringBuilder.Append("*.cs;");

        return stringBuilder.ToString();
    }
}