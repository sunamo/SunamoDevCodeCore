namespace SunamoDevCodeCore._sunamo.SunamoDevCodeBase;

internal class XmlLocalisationInterchangeFileFormatSunamo
{
    public const string Cs = "const string ";
    private const string eqBs = " = \"";

    public static string GetConstsFromLine(string line)
    {
        return SH.GetTextBetweenSimple(line, Cs, eqBs, false);
    }

    #region I already have the method GetKeysInCsWithRLDataEn here, so this is unnecessary







    #endregion
}