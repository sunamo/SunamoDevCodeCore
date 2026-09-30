namespace SunamoDevCodeCore._sunamo.SunamoBts;

internal class BTS
{

    internal static bool Is(bool first, bool isNegated)
    {
        if (isNegated)
        {
            return !first;
        }
        return first;
    }
}
