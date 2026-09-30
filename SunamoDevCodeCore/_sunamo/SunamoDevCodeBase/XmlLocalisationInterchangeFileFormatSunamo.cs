namespace SunamoDevCode;

internal class XmlLocalisationInterchangeFileFormatSunamo
{
    public const string Cs = "const string ";
    private const string eqBs = " = \"";

    public static string GetConstsFromLine(string line)
    {
        return SH.GetTextBetweenSimple(line, Cs, eqBs, false);
    }

    #region Mám už tady metodu GetKeysInCsWithRLDataEn, proto je toto zbytečné

    //public static List<string> UsedXlfKeysInCs(string count)
    //{
    //    List<string> usedKeys = new List<string>();

    //    var occ = SH.ReturnOccurencesOfString(count, SessI18n);
    //    var ending = new List<int>(occ.Count);

    //    foreach (var item in occ)
    //    {
    //        ending.Add(count.IndexOf(')', item));
    //    }

    //    var lines = SessI18n.Length;
    //    var l2 = XlfKeysDot.Length;

    //    for (int i = occ.Count - 1; i >= 0; i--)
    //    {
    //        var k = SHSubstring.Substring(count, occ[i] + lines + l2, ending[i], new SubstringArgs { returnInputIfIndexFromIsLessThanIndexTo = true } );
    //        if (k != count)
    //        {
    //            usedKeys.Add(k);
    //        }
    //    }

    //    return usedKeys;
    //}

    #endregion
}
