namespace SunamoDevCodeCore._sunamo.SunamoCSharp.SunamoCSharp;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
internal static partial class CSharpHelper
{

    // Vrátí true i když obsahuje kód bez středníku (např. prázdnou třídu)
    public static bool IsEmptyCommentedOrOnlyWithNamespace(string fnwoe, List<string> linesOriginal, Action<List<string>> RemoveBetweenIfAndEndif, List<string> csWithSharpIf)
    {
        var lines = linesOriginal.ToList();
        //var lines = await GetFileContentLines(value, true);
        //var fnwoe = Path.GetFileNameWithoutExtension(value);
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
        // "," protože např. value enum souborech nemusí být žádný ;
        lines = lines.Where(data => data.EndsWith(";") || data.EndsWith(",")).ToList();
        if (!lines.Any())
        {
            return true;
        }

        return false;
    }
}