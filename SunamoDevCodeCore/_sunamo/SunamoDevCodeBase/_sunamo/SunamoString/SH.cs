namespace SunamoDevCodeCore._sunamo.SunamoDevCodeBase._sunamo.SunamoString;

internal class SH
{

    internal static string GetTextBetweenSimple(string text, string afterDelimiter, string beforeDelimiter, bool isThrowExceptionIfNotContains = true)
    {
        int foundIndex = int.MinValue;
        var result = GetTextBetween(text, afterDelimiter, beforeDelimiter, out foundIndex, 0, isThrowExceptionIfNotContains);
        return result!;
    }

    internal static string? GetTextBetween(string text, string afterDelimiter, string beforeDelimiter, out int foundIndex, int startSearchingAt, bool isThrowExceptionIfNotContains = true)
    {
        string? result = null;
        foundIndex = text.IndexOf(afterDelimiter, startSearchingAt);
        int beforeIndex = text.IndexOf(beforeDelimiter, foundIndex + afterDelimiter.Length);
        bool isAfterFound = foundIndex != -1;
        bool isBeforeFound = beforeIndex != -1;
        if (isAfterFound && isBeforeFound)
        {
            foundIndex += afterDelimiter.Length;
            beforeIndex -= 1;
            // When I return between ( ), there must be +1
            var length = beforeIndex - foundIndex + 1;
            if (length < 1)
            {
                // EN: This was here before but logically it's nonsense
                // CZ: Takhle to tu bylo předtím ale logicky je to nesmysl
            }
            result = text.Substring(foundIndex, length).Trim();
        }
        else
        {
            if (isThrowExceptionIfNotContains)
            {
                ThrowEx.NotContains(text, afterDelimiter, beforeDelimiter);
            }
            else
            {
                // 24-1-21 return null instead of text
                return null;
                //result = text;
            }
        }

        return result;
    }

    internal static string WrapWith(string value, string wrapper)
    {
        return wrapper + value + wrapper;
    }

    internal static string WrapWithQm(string value)
    {
        var wrapper = "\"";
        return wrapper + value + wrapper;
    }

    internal static string WrapWithBs(string value)
    {
        var wrapper = "\\";
        return wrapper + value + wrapper;
    }

    #region SH.FirstCharUpper
    internal static string FirstCharUpper(ref string text)
    {
        text = FirstCharUpper(text);
        return text;
    }

internal static string FirstCharUpper(string text)
    {
        if (text.Length == 1)
        {
            return text.ToUpper();
        }

        string rest = text.Substring(1);
        return text[0].ToString().ToUpper() + rest;
    }

    #endregion

internal static string TextWithoutDiacritic(string projName)
    {
        return projName.RemoveDiacritics();
    }
}