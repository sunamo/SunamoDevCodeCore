namespace SunamoDevCodeCore._sunamo.SunamoDevCodeBase._sunamo.SunamoFileSystem;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
internal partial class FS
{

    internal static bool TryDeleteDirectory(string directoryPath)
    {
        if (!Directory.Exists(directoryPath))
        {
            return true;
        }

        try
        {
            Directory.Delete(directoryPath, true);
            return true;
        }
        catch (Exception)
        {
        // EN: It's try so don't know what this is doing here
        // CZ: Je to try takže nevím co tu dělá tohle
        }

        var files = GetFiles(directoryPath, "*", SearchOption.AllDirectories);
        foreach (var filePath in files)
        {
            File.SetAttributes(filePath, FileAttributes.Normal);
        }

        try
        {
            Directory.Delete(directoryPath, true);
            return true;
        }
        catch (Exception)
        {
        }

        return false;
    }

    internal static string WithEndSlash(ref string path)
    {
        if (path != string.Empty)
        {
            path = path.TrimEnd('\\') + '\\';
        }

        SH.FirstCharUpper(ref path);
        return path;
    }

    internal static List<string> OnlyNamesNoDirectEdit(String[] filePaths)
    {
        var list = filePaths.ToList();
        return OnlyNamesNoDirectEdit(list);
    }

    // No direct edit
    // Returns with extension
    // POZOR: Na rozdíl od stejné metody v sunamo tato metoda vrací úplně nové pole a nemodifikuje A1
    internal static List<string> OnlyNamesNoDirectEdit(List<string> filePaths)
    {
        var fileNames = new List<string>(filePaths.Count);
        for (int index = 0; index < filePaths.Count; index++)
        {
            fileNames.Add(Path.GetFileName(filePaths[index]));
        }

        return fileNames;
    }

    internal static List<string> GetFiles(string folder, string mask, SearchOption searchOption /*, GetFilesArgsDC getFilesArgs = null*/)
    {
        //ThrowEx.NotImplementedMethod();
        return Directory.GetFiles(folder, mask, searchOption).ToList();
    }
}