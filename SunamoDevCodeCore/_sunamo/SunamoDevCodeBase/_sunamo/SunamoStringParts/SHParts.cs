namespace SunamoDevCodeCore._sunamo.SunamoDevCodeBase._sunamo.SunamoStringParts;

internal class SHParts
{
    internal static string RemoveAfterFirst(string text, string searchString)
    {
        int index = text.IndexOf(searchString);
        if (index == -1 || index == text.Length - 1)
        {
            return text;
        }

        string result = text.Remove(index);
        return result;
    }

}