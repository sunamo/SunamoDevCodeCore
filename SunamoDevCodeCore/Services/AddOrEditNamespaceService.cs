namespace SunamoDevCodeCore.Services;

public class AddOrEditNamespaceService
{
    public async Task<string?> AddOrEditNamespaceForSingleFileAndSave(string pathToCsprojFolder, string projectName
        , string csPath, List<string>? linesFile = null, string? pathToSave = null)
    {
        linesFile ??= (await FileAsync.ReadAllLinesAsync(csPath)).ToList();
        if (CSharpHelper.IsEmptyCommentedOrOnlyWithNamespace(Path.GetFileNameWithoutExtension(csPath), linesFile, null!, [null!]))
        {
            return null;
        }

        var filenameWithoutExtension = Path.GetFileNameWithoutExtension(csPath);
        if (csPath.EndsWith(".xaml.cs")) return null;
        if (csPath.Contains(@"\obj\")) return null;
        var filename = Path.GetFileNameWithoutExtension(csPath);
        if (filename == "GlobalSuppressions") return null;
        if (filename == "GlobalUsings") return null;
        if (filename == "Net48Polyfills") return null;
        if (pathToSave != null)
        {
            csPath = pathToSave;
        }
        var relPath = csPath.Replace(pathToCsprojFolder, string.Empty);
        var parts = relPath.Split('\\', StringSplitOptions.RemoveEmptyEntries).ToList();
        parts.RemoveAt(parts.Count - 1);
        // Strip leading path segment that equals the project name (handles projects with an inner subfolder
        // named the same as the project, which would otherwise produce duplicate namespace segments
        // like SunamoFileSystem.SunamoFileSystem.FS instead of SunamoFileSystem.FS)
        if (parts.Count > 0 && string.Equals(parts[0], projectName, StringComparison.OrdinalIgnoreCase))
        {
            parts.RemoveAt(0);
        }
        var linesFileOri = linesFile.ToList();
        linesFile = await RemoveFileScopedNamespaceWhenIsInSharpIf(linesFile);
        var fullNamespace = projectName + (parts.Count == 0 ? "" : ".") + string.Join(".", parts);
        linesFile = AddNamespaceIfIsMissingInCs(linesFile, fullNamespace);
        linesFile = RemoveIfContainsMoreNamespace(linesFile);
        if (!linesFileOri.SequenceEqual(linesFile))
        {
            await TFCsFormat
                .WriteAllLines(pathToSave == null ? csPath : pathToSave, linesFile);
        }
        return fullNamespace;
    }
    private List<string> RemoveIfContainsMoreNamespace(List<string> list)
    {
        // Find all namespace lines and remove duplicates (keep only the first one)
        var nsLines = new List<int>();
        for (int index = 0; index < list.Count; index++)
        {
            if (list[index].StartsWith("namespace ") && list[index].EndsWith(";"))
            {
                nsLines.Add(index);
            }
        }

        // Remove from the end to avoid index shifting
        for (int lineIndex = nsLines.Count - 1; lineIndex > 0; lineIndex--)
        {
            list.RemoveAt(nsLines[lineIndex]);
        }
        return list;
    }
    // Worker method that is already called on a specific file
    // Called from AddNamespaceByInputFolderName
    private List<string> AddNamespaceIfIsMissingInCs(List<string> lines, string newNs)
    {
        // I put this here when I was being dumb and was working in the console on a nonexistent path. I wondered how it worked in the program. So it was not debug vs release as I originally thought! Again I was looking for the problem elsewhere than where it was!
        // todo napsat testy na toto
        var isNsOuter = false;
        var namespaceLineIndex = -1;
        RemoveEmptyLinesService removeEmptyLinesService = new RemoveEmptyLinesService();
        for (var index = 0; index < lines.Count; index++)
        {
            // .Trim() cannot be here because it would trim the whole file and I would have to reformat it again
            lines[index] = lines[index];
            var list = lines[index];
            isNsOuter = list.StartsWith("namespace");
            if (isNsOuter)
            {
                namespaceLineIndex = index;
                break;
            }
            if (classCodeElements.Any(codeElement => list.Contains(codeElement)))
            {
                break;
            }
            // I have no idea why I put this construct here
        }
        // todo there is a problem here. it adds NS even though it is already in #elif. then it is enough to comment out RemoveFileScopedNamespaceWhenIsInSharpIf
        if (namespaceLineIndex != -1 && lines[namespaceLineIndex].Trim() == "namespace")
        {
            // check whether the correct NS is under #else
            var elseIndex = lines.IndexOf("#else");
            if (lines[elseIndex + 1] != newNs)
            {
                lines[elseIndex + 1] = newNs;
            }
        }
        else
        {
            // if any line starts with namespace
            if (!isNsOuter)
            {
                AddNamespaceOnBegin(newNs, lines);
            }
            else
            {
                // Check if namespace is already correct at line 0 - skip processing to avoid corruption
                var expectedNs = "namespace " + newNs + ";";
                if (namespaceLineIndex == 0 && lines[0].Trim() == expectedNs.Trim())
                {
                    // Namespace is already correct, do nothing
                    return lines;
                }

                if (namespaceLineIndex != 0)
                {
                    if (!lines[namespaceLineIndex].Contains(";"))
                    {
                        removeEmptyLinesService.RemoveEmptyLinesFromStartAndEnd(lines);
                        lines[0] = lines[0].TrimStart('{');
                        lines[lines.Count - 1] = lines[lines.Count - 1].TrimEnd('}');
                    }
                    #region Tohle jsem nemusel dělat, od toho tu mám už TFCsFormat
                    lines.RemoveAt(namespaceLineIndex);
                    lines.Insert(0, "");
                    lines.Insert(0, "namespace " + newNs + ";");
                    #endregion
                }
                else
                {
                    lines[0] = "namespace " + newNs + ";";
                }
            }
        }
        //// for others it adds an empty line because it deleted }
        //// I put this here when I was being dumb and was working in the console on a nonexistent path. I wondered how it worked in the program. So it was not debug vs release as I originally thought! Again I was looking for the problem elsewhere than where it was!
        ////if (item.EndsWith("XmlGenerator.cs"))
        ////{
        ////    if (temp != text)
        ////    {
        ////        Console.WriteLine("Content changed, writing...");
        ////    }
        ////    else
        ////    {
        ////        Console.WriteLine("Content NOT changed");
        ////    }
        ////}
        return lines;
    }
    public readonly List<string> classCodeElements = new List<string>() { "class ", "interface ", "delegate", "enum ", "struct " };
    // It works OK, I went through all the files before the commit
    private async Task<List<string>> RemoveFileScopedNamespaceWhenIsInSharpIf(List<string> list)
    {
        List<int> dxNs = new List<int>();
        int dxElse = -1;
        for (int index = 0; index < list.Count; index++)
        {
            var line = list[index];
            // the error was here: the namespace had a space. then it did not return me the one in #if
            if (line.StartsWith("namespace"))
            {
                dxNs.Add(index);
            }
            if (line == "#else")
            {
                dxElse = index + 1;
            }
            if (dxElse != -1 && dxNs.Any())
            {
                break;
            }
            if (classCodeElements.Any(codeElement => line.Contains(codeElement)))
            {
                break;
            }
        }
        if (dxElse != -1 && dxNs.Count == 1)
        {
            // here I do not know if it is correct. I have only one line starting with namespace but I want to remove it
            // proto to zakomentuji
        }
        else if (dxNs.Count > 1)
        {
            List<string> lines = new List<string>(dxNs.Count);
            foreach (var item2 in dxNs)
            {
                lines.Add(list[item2]);
            }
            // I sort from smallest to largest
            var ordered = lines.OrderBy(orderedLine => orderedLine.Length).Skip(1);
            foreach (var item3 in ordered)
            {
                list.Remove(item3);
            }
            // It only removes lines, no formatting is needed
            // Only the changes are written here - it is in the else if
        }
        return list;
    }
    // Adds a new file scoped namespace at the start of the file
    private void AddNamespaceOnBegin(string newNs, List<string> lines)
    {
        if (lines.Count > 0)
        {
            lines.Insert(0, "namespace " + newNs + ";");
            if (lines[1].Trim() != string.Empty) lines.Insert(0, "");
        }
    }
}