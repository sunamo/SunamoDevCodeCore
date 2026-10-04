namespace SunamoDevCodeCore.Tests.Services;

using SunamoDevCodeCore.Services;
using System.Threading.Tasks;

public class AddOrEditNamespaceServiceTests
{
    [Fact]
    public async Task AddOrEditNamespaceForSingleFileAndSaveTest()
    {
        var addOrEditNamespaceService = new AddOrEditNamespaceService();
        var ns = await addOrEditNamespaceService.AddOrEditNamespaceForSingleFileAndSave(@"E:\vs\Projects\PlatformIndependentNuGetPackages\SunamoDevCode\", "SunamoDevCode", "E:\\vs\\Projects\\PlatformIndependentNuGetPackages\\SunamoDevCode\\Enums\\WhatIsExcepted.cs");

    }
}