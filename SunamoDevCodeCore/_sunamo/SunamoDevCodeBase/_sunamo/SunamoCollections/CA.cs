namespace SunamoDevCodeCore._sunamo.SunamoDevCodeBase._sunamo.SunamoCollections;

internal partial class CA
{

    internal static void RemoveNullEmptyWs(List<string> list)
    {
        for (int index = list.Count - 1; index >= 0; index--)
        {
            if (string.IsNullOrWhiteSpace(list[index]))
            {
                list.RemoveAt(index);
            }
        }
    }

    internal static List<string> Trim(List<string> list)
    {
        for (var index = 0; index < list.Count; index++)
            list[index] = list[index].Trim();
        return list;
    }

    internal static (bool, string) IsNegationTuple(string text)
    {
        if (text[0] == '!')
        {
            text = text.Substring(1);
            return (true, text);
        }

        return (false, text);
    }

    internal static void RemoveStartingWith(string prefix, List<string> list, RemoveStartingWithArgs? args = null)
    {
        args ??= new RemoveStartingWithArgs();

        var(isNegated, actualPrefix) = IsNegationTuple(prefix);
        prefix = actualPrefix;
        for (int index = list.Count - 1; index >= 0; index--)
        {
            var value = list[index];
            if (args.TrimBeforeFinding)
            {
                value = value.Trim();
            }

            if (isNegated)
            {
                if (!StartingWith(value, prefix, args.CaseSensitive))
                {
                    list.RemoveAt(index);
                }
            }
            else
            {
                if (StartingWith(value, prefix, args.CaseSensitive))
                {
                    list.RemoveAt(index);
                }
            }
        }
    }

    internal static bool StartingWith(string text, string prefix, bool isCaseSensitive)
    {
        if (isCaseSensitive)
        {
            return text.StartsWith(prefix);
        }
        else
        {
            return text.ToLower().StartsWith(prefix.ToLower());
        }
    }

    internal static string? StartWith(List<string> prefixes, string text, out string? matchedPrefix)
    {
        matchedPrefix = null;
        if (prefixes != null)
        {
            foreach (var prefix in prefixes)
            {
                if (text.StartsWith(prefix))
                {
                    matchedPrefix = prefix;
                    return text;
                }
            }
        }

        return null;
    }

    internal static void RemoveWhichContains(List<string> list, string pattern, bool isWildcard, Func<string, string, bool>? wildcardIsMatch)
    {
        if (isWildcard)
        {
            if (wildcardIsMatch is null)
            {
                throw new ArgumentNullException(nameof(wildcardIsMatch), "Wildcard match function is required when isWildcard is true");
            }

            for (int index = list.Count - 1; index >= 0; index--)
            {
                if (wildcardIsMatch(list[index], pattern))
                {
                    list.RemoveAt(index);
                }
            }
        }
        else
        {
            for (int itemIndex = list.Count - 1; itemIndex >= 0; itemIndex--)
            {
                if (list[itemIndex].Contains(pattern))
                {
                    list.RemoveAt(itemIndex);
                }
            }
        }
    }
}