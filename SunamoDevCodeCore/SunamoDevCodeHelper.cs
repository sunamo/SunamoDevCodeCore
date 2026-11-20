namespace SunamoDevCodeCore;

/// <summary>
/// Represents the sunamo dev code helper type.
/// </summary>
public class SunamoDevCodeHelper
{
    /// <summary>
    /// Try delete directory.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="directoryPath">The directory path.</param>
    /// <returns>The try delete directory result.</returns>
    public static bool TryDeleteDirectory(ILogger logger, string directoryPath)
    {
        if (!Directory.Exists(directoryPath)) return true;

        try
        {
            Directory.Delete(directoryPath, true);
            return true;
        }
        catch (Exception)
        {
            // It's try so don't know what this is doing here
        }

        var files = FSGetFiles.GetFiles(logger, directoryPath, "*", SearchOption.AllDirectories);
        foreach (var filePath in files) File.SetAttributes(filePath, FileAttributes.Normal);

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

    /// <summary>
    /// Copy solution.
    /// </summary>
    /// <param name="slnFolder">The sln folder.</param>
    /// <param name="folderTo">The folder to.</param>
    /// <param name="archive">The archive.</param>
    public static void CopySolution(string slnFolder, string folderTo, Action<string> archive)
    {
        var list = Directory.GetFiles(slnFolder, "*", SearchOption.AllDirectories).ToList();
        RemoveTemporaryFilesVS(list);
        RemoveGitFiles(list);

        var sourceBasePath = Path.GetDirectoryName(slnFolder)!;
        FS.WithEndSlash(ref sourceBasePath);
        FS.WithEndSlash(ref folderTo);

        var slnFolderTo = Path.Combine(folderTo, Path.GetFileName(slnFolder));
        FS.TryDeleteDirectory(slnFolderTo);

        foreach (var item in list)
        {
            var newPath = item.Replace(sourceBasePath, folderTo);
            FS.CreateUpfoldersPsysicallyUnlessThere(newPath);
        }

        archive(slnFolderTo);
    }

    /// <summary>
    /// Remove git files.
    /// </summary>
    /// <param name="files">The files.</param>
    /// <param name="isIncludingGitFiles">The is including git files.</param>
    /// <param name="isIncludingDownloadedFolders">The is including downloaded folders.</param>
    /// <param name="isIncludingFoldersToDelete">The is including folders to delete.</param>
    public static void RemoveGitFiles(List<string> files, bool isIncludingGitFiles = true, bool isIncludingDownloadedFolders = false,
        bool isIncludingFoldersToDelete = false)
    {
        string? wrapped = null;

        if (!isIncludingGitFiles)
        {
            wrapped = SH.WrapWith(VisualStudioTempFse.GitFolderName, "\"");
            files.RemoveAll(file => file.Contains(wrapped));
        }

        if (!isIncludingDownloadedFolders)
            foreach (var item in VisualStudioTempFse.FoldersInSolutionDownloaded)
            {
                wrapped = SH.WrapWithBs(item);
                files.RemoveAll(filePath => filePath.Contains(wrapped));
            }

        if (!isIncludingFoldersToDelete)
            foreach (var item in VisualStudioTempFse.FoldersInSolutionToDelete)
            {
                wrapped = SH.WrapWithBs(item);
                files.RemoveAll(fileToRemove => fileToRemove.Contains(wrapped));
            }
    }

    /// <summary>
    /// Remove temporary files VS.
    /// </summary>
    /// <param name="files">The files.</param>
    public static void RemoveTemporaryFilesVS(List<string> files)
    {
        var list = VisualStudioTempFseWrapped.FoldersInSolutionToDelete;

        // todo list here is List<string>, it wants only string, analyze later

        //As foldersInProjectToDelete dont have contains WildCard, set false
        CA.RemoveWhichContainsList(files, list, false);
        list = VisualStudioTempFseWrapped.FoldersInProjectToDelete;
        CA.RemoveWhichContainsList(files, list, false);
        list = VisualStudioTempFseWrapped.FoldersAnywhereToDelete;
        CA.RemoveWhichContainsList(files, list, false);

        list = VisualStudioTempFseWrapped.FoldersInSolutionDownloaded;
        CA.RemoveWhichContainsList(files, list, false);
        list = VisualStudioTempFseWrapped.FoldersInProjectDownloaded;
        CA.RemoveWhichContainsList(files, list, false);
        list = VisualStudioTempFseWrapped.FoldersAnywhereDownloaded;
        CA.RemoveWhichContainsList(files, list, false);
    }

    private static bool IsNameOfHtmlAttrValue(string between)
    {
        return AllHtmlAttrsValues.list.Contains(between.Trim());
    }

    private static bool IsNameOfHtmlAttr(string between)
    {
        return AllHtmlAttrs.list!.Contains(between.Trim());
    }

    /// <summary>
    /// Is name of html tag.
    /// </summary>
    /// <param name="between">The between.</param>
    /// <param name="add">The add.</param>
    /// <returns>The is name of html tag result.</returns>
    public static bool IsNameOfHtmlTag(string between, bool add)
    {
        string? element = null;
        var startWithTag = CA.StartWith(AllHtmlTags.list!, between, out element);
        startWithTag = element;
        if (startWithTag != null)
        {
            if (startWithTag == between)
            {
                add = true;
            }
            else
            {
                var remain = between.Substring(startWithTag.Length);
                add = int.TryParse(remain, out var _);
            }
        }

        return add;
    }

    // A1 normal, not lower
    /// <summary>
    /// Is name of control.
    /// </summary>
    /// <param name="between">The between.</param>
    /// <returns>The is name of control result.</returns>
    public static bool IsNameOfControl(string between)
    {
        var add = false;
        add = IsNameOfHtmlTag(between, add);
        if (!add) add = IsNameOfHtmlAttr(between);

        if (!add) add = IsNameOfHtmlAttrValue(between);

        if (!add)
        {
            var firstInt = -1;
            var index = 0;
            foreach (var item in between)
            {
                if (char.IsLower(item))
                {
                    if (firstInt != -1)
                    {
                        add = false;
                        break;
                    }
                }
                else if (char.IsNumber(item))
                {
                    if (firstInt == -1) firstInt = index;
                }
                else
                {
                    add = false;
                    break;
                }

                index++;
            }

            var prefix = between;
            if (firstInt != -1) prefix = between.Substring(0, firstInt);

            add = SystemWindowsControls.IsShortcutOfControl(prefix);
        }

        return add;
    }
}