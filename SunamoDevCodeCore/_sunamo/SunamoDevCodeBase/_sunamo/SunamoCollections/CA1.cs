namespace SunamoDevCodeCore._sunamo.SunamoCollections;

internal partial class CA
{
    internal static void RemoveWhichContainsList(List<string> files, List<string> list, bool isWildcard, Func<string, string, bool>? wildcardIsMatch = null)
    {
        foreach (var item in list)
        {
            RemoveWhichContains(files, item, isWildcard, wildcardIsMatch);
        }
    }

    internal static List<T> JoinIList<T>(params IList<T>[] lists)
    {
        var result = new List<T>();
        foreach (var list in lists)
        {
            foreach (var element in list)
            {
                result.Add((T)element);
            }
        }

        return result;
    }

    internal static List<string> RemoveStringsEmpty2(List<string> list)
    {
        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (list[i].Trim() == string.Empty)
            {
                list.RemoveAt(i);
            }
        }

        return list;
    }

    internal static List<string> WrapWith(List<string> list, string wrapText)
        => WrapWith(list, wrapText, wrapText);

    internal static List<string> WrapWith(List<string> list, string prefixText, string suffixText)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i] = prefixText + list[i] + suffixText;
        }

        return list;
    }

    internal static List<string> EnsureBackslash(List<string> paths)
    {
        for (int i = 0; i < paths.Count; i++)
        {
            string path = paths[i];
            if (path[path.Length - 1] != '\\')
            {
                paths[i] = path + "\\";
            }
        }

        return paths;
    }

    internal static bool ContainsElement<T>(IList<T> list, T element)
    {
        if (list.Count == 0)
        {
            return false;
        }

        foreach (T item in list)
        {
            if (Comparer<T>.Equals(item, element))
            {
                return true;
            }
        }

        return false;
    }
}
