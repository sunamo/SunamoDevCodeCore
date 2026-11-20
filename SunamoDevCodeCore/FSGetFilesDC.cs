namespace SunamoDevCodeCore;

/// <summary>
/// Represents the FS get files DC type.
/// </summary>
public class FSGetFilesDC
{
    /// <summary>
    /// Get files DC.
    /// </summary>
    /// <param name="slnFolder">The sln folder.</param>
    /// <param name="fileMask">The file mask.</param>
    /// <param name="searchOption">The search option.</param>
    /// <param name="arguments">The arguments.</param>
    /// <returns>The get files DC result.</returns>
    public static List<string> GetFilesDC(string slnFolder, string fileMask, SearchOption searchOption, GetFilesDCArgs arguments)
    {
        var resultFiles = new List<string>();
        var projectDirectories = Directory.GetDirectories(slnFolder);
        foreach (var projectDirectory in projectDirectories)
        {
            if (arguments.OnlyInSunamo)
            {
                var sunamoFolder = Path.Combine(projectDirectory, "_sunamo");
                if (Directory.Exists(sunamoFolder))
                {
                    resultFiles.AddRange(Directory.GetFiles(sunamoFolder, fileMask, searchOption));
                }
            }
            else
            {
                resultFiles.AddRange(Directory.GetFiles(projectDirectory, fileMask, searchOption));
            }
        }
        return resultFiles;
    }
}