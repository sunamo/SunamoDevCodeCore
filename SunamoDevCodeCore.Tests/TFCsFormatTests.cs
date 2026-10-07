namespace SunamoDevCodeCore.Tests;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TFCsFormatTests
{
    [Fact]
    public async Task WriteAllLinesTest()
    {
        const string path = @"E:\vs\Projects\PlatformIndependentNuGetPackages\SunamoGetFiles\_sunamo\XlfKeys.cs";
        var lines = await File.ReadAllLinesAsync(path);
        lines[0] = "namespace SunamoGetFiles._sunamo;";
        await TFCsFormat.WriteAllLines(path, lines);


    }

    [Fact]
    public async Task WriteAllLinesTest2()
    {
        const string path = @"E:\vs\Projects\sunamo.net\Lyrics\ProgramControllers.cs";
        var lines = (await File.ReadAllLinesAsync(path)).ToList();
        lines.Insert(3, "");
        await TFCsFormat.WriteAllLines(path, lines);


    }
}