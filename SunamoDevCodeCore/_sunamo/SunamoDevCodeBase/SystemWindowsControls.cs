namespace SunamoDevCode;

// Helper class for System.Windows controls shortcuts and names
internal static class SystemWindowsControls
{
    private static readonly Dictionary<string, List<string>> s_controls = new();

    public static bool IsShortcutOfControl(string text)
    {
        foreach (var item in s_controls)
        foreach (var shortcut in item.Value)
            if (shortcut == text)
                return true;

        return false;
    }
}
