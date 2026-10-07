namespace SunamoDevCodeCore._sunamo.SunamoDevCodeBase;

internal class CSharpParser
{

    public static List<string> ParseConsts(List<string> lines, out int first)
    {
        var keys = new List<string>();
        first = -1;
        for (var index = 0; index < lines.Count; index++)
        {
            var text = lines[index].Trim();
            if (text.Contains(XmlLocalisationInterchangeFileFormatSunamo.Cs))
            {
                if (first == -1) first = index;

                var key = XmlLocalisationInterchangeFileFormatSunamo.GetConstsFromLine(text);
                keys.Add(key);
            }
        }

        return keys;
    }
}