namespace SunamoDevCodeCore.Tests;

public class GlobalUsingsInstanceTests
{
    [Fact]
    public async Task GlobalUsingsInstance_Test()
    {
        GlobalUsingsInstance g = new GlobalUsingsInstance();
        await g.Init(@"E:\vs\Projects\PlatformIndependentNuGetPackages\SunamoArgs\GlobalUsings.cs");

        g.AddNewGlobalUsing("a");
        await g.Save();
    }
}