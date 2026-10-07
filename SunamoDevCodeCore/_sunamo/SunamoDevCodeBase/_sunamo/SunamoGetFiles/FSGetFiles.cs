namespace SunamoDevCodeCore._sunamo.SunamoDevCodeBase._sunamo.SunamoGetFiles;

internal class FSGetFiles
{
    internal static List<string> GetFilesEveryFolder(ILogger logger, string folder, string mask, SearchOption searchOption)
    {
        try
        {
            return Directory.GetFiles(folder, mask, searchOption).ToList();
        }
        catch (Exception exception)
        {
            logger.LogError(exception.Message);
            return new List<string>();
        }
    }

#pragma warning disable
    internal static List<string> GetFiles(ILogger logger, string folder, string mask, SearchOption searchOption, GetFilesArgsDC? getFilesArgs = null)
#pragma warning restore
    {
        if (getFilesArgs != null)
        {
            ThrowEx.Custom("getFilesArgs is not null");
        }

        return Directory.GetFiles(folder, mask, searchOption).ToList();
    }
}