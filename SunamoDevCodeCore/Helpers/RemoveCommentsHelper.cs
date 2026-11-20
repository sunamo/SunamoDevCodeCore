namespace SunamoDevCodeCore.Helpers;

// Single place for removing comments from everywhere
// because I wanted paragraph # and could not remember where they are used
/// <summary>
/// Represents the remove comments helper type.
/// </summary>
public class RemoveCommentsHelper
{
    /// <summary>
    /// Powershell.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The powershell result.</returns>
    public static string Powershell(string text)
    {
        var list = SHGetLines.GetLines(text);
        CA.Trim(list);
        CA.RemoveStartingWith("#", list);
        return string.Join(Environment.NewLine, list);
    }
}