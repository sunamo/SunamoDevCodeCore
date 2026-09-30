namespace SunamoDevCodeCore._sunamo._public;

// TODO: Should this inherit from GetFoldersEveryFolderArgs? In vs2 it does
internal class GetFilesArgsDC : GetFilesBaseArgsDC
{
    internal new bool TrimA1AndLeadingBs { get; set; } = false;
}
