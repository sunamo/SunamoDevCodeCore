namespace SunamoDevCodeCore.Interfaces;

public interface ICsFileFilter
{
    List<string> GetFilesFiltered(string path, string searchPattern, SearchOption searchOption);
}