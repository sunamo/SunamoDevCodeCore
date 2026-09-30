namespace SunamoDevCodeCore._sunamo.SunamoDevCodeBase._sunamo.SunamoCollections;

internal partial class CA
{

    internal static void RemoveNullEmptyWs(List<string> list)
    {
        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (string.IsNullOrWhiteSpace(list[i]))
            {
                list.RemoveAt(i);
            }
        }
    }

    internal static List<string> Trim(List<string> list)
    {
        for (var i = 0; i < list.Count; i++)
            list[i] = list[i].Trim();
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
        for (int i = list.Count - 1; i >= 0; i--)
        {
            var value = list[i];
            if (args.TrimBeforeFinding)
            {
                value = value.Trim();
            }

            if (isNegated)
            {
                if (!StartingWith(value, prefix, args.CaseSensitive))
                {
                    list.RemoveAt(i);
                }
            }
            else
            {
                if (StartingWith(value, prefix, args.CaseSensitive))
                {
                    list.RemoveAt(i);
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

            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (wildcardIsMatch(list[i], pattern))
                {
                    list.RemoveAt(i);
                }
            }
        }
        else
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i].Contains(pattern))
                {
                    list.RemoveAt(i);
                }
            }
        }
    }
}