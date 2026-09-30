namespace SunamoDevCodeCore._sunamo.SunamoDevCodeBase;

internal class CSharpParser
{

    public static List<string> ParseConsts(List<string> lines, out int first)
    {
        var keys = new List<string>();
        first = -1;
        for (var i = 0; i < lines.Count; i++)
        {
            var text = lines[i].Trim();
            if (text.Contains(XmlLocalisationInterchangeFileFormatSunamo.Cs))
            {
                if (first == -1) first = i;

                var key = XmlLocalisationInterchangeFileFormatSunamo.GetConstsFromLine(text);
                keys.Add(key);
            }
        }

        return keys;
    }
}