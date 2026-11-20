namespace SunamoDevCodeCore.Helpers;

// Single place for removing comments from everywhere
// because I wanted paragraph # and could not remember where they are used
public class RemoveCommentsHelper
{
    public static string Powershell(string text)
    {
        var list = SHGetLines.GetLines(text);
        CA.Trim(list);
        CA.RemoveStartingWith("#", list);
        return string.Join(Environment.NewLine, list);
    }
}