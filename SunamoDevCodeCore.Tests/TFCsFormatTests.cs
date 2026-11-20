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
    public async Task WriteAllLinesTest2()
    {
        const string path = @"E:\vs\Projects\sunamo.net\Lyrics\ProgramControllers.cs";
        var lines = (await File.ReadAllLinesAsync(path)).ToList();
        lines.Insert(3, "");
        await TFCsFormat.WriteAllLines(path, lines);


    }
}