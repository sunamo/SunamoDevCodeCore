namespace SunamoDevCodeCore.Tests;

public class GlobalUsingsInstanceTests
{
    [Fact]
    public async Task GlobalUsingsInstance_Test()
    {
        GlobalUsingsInstance globalUsings = new GlobalUsingsInstance();
        await globalUsings.Init(@"E:\vs\Projects\PlatformIndependentNuGetPackages\SunamoArgs\GlobalUsings.cs");

        globalUsings.AddNewGlobalUsing("a");
        await globalUsings.Save();
    }
}