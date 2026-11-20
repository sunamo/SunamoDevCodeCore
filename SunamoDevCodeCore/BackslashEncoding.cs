namespace SunamoDevCodeCore;

/// <summary>
/// Represents the backslash encoding type.
/// </summary>
public class BackslashEncoding
{
    /// <summary>
    /// Remove which is in string.
    /// </summary>
    /// <param name="inputString">The input string.</param>
    /// <param name="positionsList">The positions list.</param>
    public static void RemoveWhichIsInString(string inputString, List<int> positionsList)
    {
        var fromToDetector = CSharpHelperSunamo.DetectFromToString(inputString);
        for (var index = 0; index < positionsList.Count; index++)
            if (fromToDetector.IsInRange(positionsList[index]))
                positionsList.RemoveAt(index);
    }
}