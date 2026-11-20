namespace SunamoDevCodeCore;

/// <summary>
/// Represents the global usings instance type.
/// </summary>
public class GlobalUsingsInstance
{
    private string path = null!;
    private ParseGlobalUsingsResult r = null!;

    /// <summary>
    /// Init.
    /// </summary>
    /// <param name="path">The path.</param>
    public async Task Init(string path)
    {
        this.path = path;
        if (!File.Exists(path)) await FileAsync.WriteAllTextAsync(path, "");
        var list = await FileAsync.ReadAllLinesAsync(path);

        r = GlobalUsingsHelper.Parse(list.ToList());
    }

    /// <summary>
    /// Add new global using.
    /// </summary>
    /// <param name="_using">The using.</param>
    public void AddNewGlobalUsing(string _using)
    {
        if (!r.GlobalUsings.Contains(_using)) r.GlobalUsings.Add(_using);
    }

    // Remove all global usings that start with the specified prefix (case insensitive)
    /// <summary>
    /// Remove global usings starting with.
    /// </summary>
    /// <param name="prefix">The prefix.</param>
    public void RemoveGlobalUsingsStartingWith(string prefix)
    {
        r.GlobalUsings = r.GlobalUsings.Where(globalUsing => !globalUsing.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    /// <summary>
    /// Save.
    /// </summary>
    public async Task Save()
    {
        StringBuilder stringBuilder = new();

        foreach (var item in r.GlobalSymbols)
            stringBuilder.AppendLine(GlobalUsingsHelper.global + item.Key + " = " + item.Value + ";");

        foreach (var item in r.GlobalUsings) stringBuilder.AppendLine(GlobalUsingsHelper.globalUsing + item + ";");

        await FileAsync.WriteAllTextAsync(path, stringBuilder.ToString());
    }
}