namespace SunamoDevCodeCore._sunamo.SunamoCSharp.SunamoCSharp.Helpers;

internal class CSharpHelperSunamo
{

    public static FromToList DetectFromToString(string text)
    {
        List<int> quoteIndices = null!;// SH.ReturnOccurencesOfString(text, "\"");
        for (int index = quoteIndices.Count - 1; index >= 0; index--)
        {
            if (text[quoteIndices[index] - 1] == '\\')
            {
                quoteIndices.RemoveAt(index);
            }
        }

        ThrowEx.HasOddNumberOfElements("quoteIndices", quoteIndices);

        var fromToList = new FromToList();
        for (int quoteIndex = 0; quoteIndex < quoteIndices.Count; quoteIndex++)
        {
            fromToList.Ranges.Add(new FromToDC(quoteIndices[quoteIndex], quoteIndices[++quoteIndex]));
        }
        return fromToList;
    }
}