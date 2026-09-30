namespace SunamoDevCodeCore._sunamo.SunamoFileSystem;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
internal partial class FS
{

    internal static void CreateUpfoldersPsysicallyUnlessThere(string path)
    {
        CreateFoldersPsysicallyUnlessThere(Path.GetDirectoryName(path)!);
    }

    internal static void CreateFoldersPsysicallyUnlessThere(string path)
    {
        ThrowEx.IsNullOrEmpty(nameof(path), path);
        //ThrowEx.IsNotWindowsPathFormat(nameof(path), path);
        if (Directory.Exists(path))
        {
            return;
        }

        var foldersToCreate = new List<string>
        {
            path
        };
        while (true)
        {
            path = Path.GetDirectoryName(path)!;
            if (Directory.Exists(path))
            {
                break;
            }

            foldersToCreate.Add(path);
        }

        foldersToCreate.Reverse();
        foreach (var folder in foldersToCreate)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }
    }
}