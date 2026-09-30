namespace SunamoCSharp.Helpers;

internal class CSharpHelperSunamo
{

    public static FromToList DetectFromToString(string text)
    {
        List<int> quoteIndices = null!;// SH.ReturnOccurencesOfString(text, "\"");
        for (int i = quoteIndices.Count - 1; i >= 0; i--)
        {
            if (text[quoteIndices[i] - 1] == '\\')
            {
                quoteIndices.RemoveAt(i);
            }
        }

        ThrowEx.HasOddNumberOfElements("quoteIndices", quoteIndices);

        var fromToList = new FromToList();
        for (int i = 0; i < quoteIndices.Count; i++)
        {
            fromToList.Ranges.Add(new FromToDC(quoteIndices[i], quoteIndices[++i]));
        }
        return fromToList;
    }
}
