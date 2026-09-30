namespace SunamoDevCodeCore._sunamo.SunamoDevCodeBase._sunamo.SunamoStringTrim;

internal class SHTrim
{

    // EN: Method TrimLeadingNumbersAtStart was removed - inlined in ConstsManager.cs:110

    internal static string TrimEnd(string text, string suffix)
    {
        while (text.EndsWith(suffix)) return text.Substring(0, text.Length - suffix.Length);

        return text;
    }

    // EN: Method TrimStartAndEnd was removed - inlined in XmlLocalisationInterchangeFileFormat2.cs:691

    internal static string TrimStart(string text, string prefix)
    {
        while (text.StartsWith(prefix))
        {
            text = text.Substring(prefix.Length);
        }

        return text;
    }

}