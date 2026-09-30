namespace SunamoDevCodeCore._sunamo.SunamoRegex;

// Represents a wildcard running on the System.Text.RegularExpressions engine.
internal class Wildcard : Regex
{

    internal Wildcard(string pattern)
    : base(WildcardToRegex(pattern))
    {
    }

    internal static string WildcardToRegex(string pattern) =>
        "^" + Regex.Escape(pattern).Replace("\\*", ".*").Replace("\\?", ".") + "$";
}