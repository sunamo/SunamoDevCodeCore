namespace SunamoDevCodeCore._sunamo.SunamoDevCodeBase;

internal class XmlLocalisationInterchangeFileFormatSunamo
{
    public const string Cs = "const string ";
    private const string eqBs = " = \"";

    public static string GetConstsFromLine(string line)
    {
        return SH.GetTextBetweenSimple(line, Cs, eqBs, false);
    }

    #region Mám už tady metodu GetKeysInCsWithRLDataEn, proto je toto zbytečné







    #endregion
}