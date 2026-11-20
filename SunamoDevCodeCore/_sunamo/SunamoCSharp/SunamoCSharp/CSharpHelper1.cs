namespace SunamoDevCodeCore._sunamo.SunamoCSharp.SunamoCSharp;

internal static partial class CSharpHelper
{

    // Returns true even if it contains code without a semicolon (e.g. an empty class)
    public static bool IsEmptyCommentedOrOnlyWithNamespace(string fnwoe, List<string> linesOriginal, Action<List<string>> RemoveBetweenIfAndEndif, List<string> csWithSharpIf)
    {
        var lines = linesOriginal.ToList();
        if (csWithSharpIf.Contains(fnwoe))
        {
            return false;
        }

        if (RemoveBetweenIfAndEndif != null)
        {
            RemoveBetweenIfAndEndif(lines);
        }

        CA.Trim(lines);
        CA.RemoveNullEmptyWs(lines);
        lines = RemoveComments(lines);
        lines = lines.Where(data => !data.StartsWith("namespace")).ToList();
        lines = lines.Where(data => !data.StartsWith("using")).ToList();
        lines = lines.Where(data => data.EndsWith(";") || data.EndsWith(",")).ToList();
        if (!lines.Any())
        {
            return true;
        }

        return false;
    }
}