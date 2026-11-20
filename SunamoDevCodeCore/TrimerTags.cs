namespace SunamoDevCodeCore;

/// <summary>
/// Represents the trimer tags type.
/// </summary>
public static class TrimerTags
{
    private static List<string> tagsWrapping = null!;
    private static List<string> tagsWrappingUpper = null!;

    /// <summary>
    /// Trim wrapping tag.
    /// </summary>
    /// <param name="html">The html.</param>
    /// <param name="fromStart">The from start.</param>
    /// <param name="fromEnd">The from end.</param>
    /// <returns>The trim wrapping tag result.</returns>
    public static string TrimWrappingTag(string html, StringBuilder fromStart, StringBuilder fromEnd)
    {
        fromStart.Clear();
        fromEnd.Clear();

        html = html.Trim();
        if (!html.StartsWith("<")) return html;

        var changed = false;

        html = TrimmingWrappingTags(html, tagsWrapping, fromStart, fromEnd, ref changed);
        if (!changed) html = TrimmingWrappingTags(html, tagsWrappingUpper, fromStart, fromEnd, ref changed);

        return html;
    }

    private static string TrimmingWrappingTags(string html, List<string> tagsWrapping, StringBuilder fromStart,
        StringBuilder fromEnd, ref bool changed)
    {
        string? endingTag = null;

        for (var index = 0; index < tagsWrapping.Count; index++)
        {
            var item = tagsWrapping[index];
            if (html.StartsWith(item))
            {
                endingTag = item.Replace("<", "<" + "/");

                if (!html.EndsWith(endingTag)) continue;

                html = SHTrim.TrimStart(html, item);

                html = SHTrim.TrimEnd(html, endingTag);

                fromStart.Append(item);
                fromEnd.Append(endingTag);
                changed = true;
                break;
            }
        }

        return html;
    }

    /// <summary>
    /// Init tags wrapping.
    /// </summary>
    public static void InitTagsWrapping()
    {
        tagsWrapping = new List<string>(["i", "b", "u"]);
        tagsWrappingUpper = new List<string>(tagsWrapping.Count);
        foreach (var item in tagsWrapping) tagsWrappingUpper.Add(item.ToUpper());

        WrapWithBracket(tagsWrapping);
        WrapWithBracket(tagsWrappingUpper);
    }

    private static void WrapWithBracket(List<string> tagsWrapping)
    {
        for (var index = 0; index < tagsWrapping.Count; index++) tagsWrapping[index] = "<" + tagsWrapping[index] + ">";
    }
}