namespace SunamoDevCodeCore._sunamo.SunamoCSharp.SunamoCSharp;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
internal static partial class CSharpHelper
{

    private static string RemoveCommentsKeepLines(string input)
    {
        string output = "";
        using (StringReader reader = new(input))
        {
            bool inSingleLineComment = false;
            bool inMultiLineComment = false;
            int currentChar;
            while ((currentChar = reader.Read()) != -1)
            {
                char current = (char)currentChar;
                char next = (char)reader.Peek();
                if (inSingleLineComment)
                {
                    if (current == '\n')
                    {
                        inSingleLineComment = false;
                        output += current;
                    }
                }
                else if (inMultiLineComment)
                {
                    if (current == '*' && next == '/')
                    {
                        inMultiLineComment = false;
                        reader.Read(); // Přečteme '/'
                    }
                    else if (current == '\n')
                    {
                        output += current; // Přidáme nový řádek do výstupu
                    }
                }
                else
                {
                    if (current == '/' && next == '/')
                    {
                        inSingleLineComment = true;
                        reader.Read(); // Přečteme '/'
                    }
                    else if (current == '/' && next == '*')
                    {
                        inMultiLineComment = true;
                        reader.Read(); // Přečteme '*'
                    }
                    else
                    {
                        output += current;
                    }
                }
            }
        }

        return output;
    }

    public static List<string> RemoveComments(List<string> listOrString, bool line = true, bool block = true, bool keepLinesNumbers = false)
    {
        if (keepLinesNumbers)
        {
            return SHGetLines.GetLines(RemoveCommentsKeepLines(SHJoin.JoinNL(listOrString)));
        }

        if (line)
        {
            listOrString = RemoveLineComments(listOrString);
        }

        if (block)
        {
            listOrString = SHGetLines.GetLines(RemoveBlockComments(string.Join(Environment.NewLine, listOrString)));
        }

        //var list = CastHelper.ToListString(listOrString);
        //jak jsem mohl být takový debil argument dát to tady - na co tady trimovat?
        //CA.Trim(listOrString);
        return listOrString;
    }

    // Direct edit
    public static List<string> RemoveLineComments(List<string> list)
    {
        //List<string> list = CastHelper.ToListString(listOrString);
        for (int index = list.Count - 1; index >= 0; index--)
        {
            list[index] = SHParts.RemoveAfterFirst(list[index], "//");
        }

        CA.RemoveStringsEmpty2(list);
        return list;
    }

    const string blockComments = @"/\*(.*?)\*/";
    const string lineComments = @"//(.*?)\r?\n";
    const string strings = @"""((\\[^\n]|[^""\n])*)""";
    const string verbatimStrings = @"@(""[^""]*"")+";

    public static string RemoveBlockComments(string str)
    {
        str = Regex.Replace(str, blockComments + "|" + lineComments + "|" + strings + "|" + verbatimStrings, match =>
        {
            if (match.Value.StartsWith("/*") || match.Value.StartsWith("//"))
                return match.Value.StartsWith("//") ? Environment.NewLine : "";
            // Keep the literal strings
            return match.Value;
        }, RegexOptions.Singleline);
        return str;
    }
}