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
        var l = await File.ReadAllLinesAsync(path);
        l[0] = "namespace SunamoGetFiles._sunamo;";
        await TFCsFormat.WriteAllLines(path, l);


    }

    [Fact]
    public async Task WriteAllLinesTest2()
    {
        const string path = @"E:\vs\Projects\sunamo.net\Lyrics\ProgramControllers.cs";
        var l = (await File.ReadAllLinesAsync(path)).ToList();
        l.Insert(3, "");
        await TFCsFormat.WriteAllLines(path, l);


    }
}