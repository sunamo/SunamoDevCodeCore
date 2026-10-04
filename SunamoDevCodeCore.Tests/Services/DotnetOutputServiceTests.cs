using SunamoDevCodeCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunamoDevCodeCore.Tests.Services;
public class DotnetOutputServiceTests
{
    public void GetPartsFromDotnetBuildLineTest()
    {
        DotnetOutputService d = new();
        var r = d.GetPartsFromDotnetBuildLine(@"E:\vs\Projects\PlatformIndependentNuGetPackages\SunamoStopwatch\_sunamo\SunamoExceptions\Exceptions.cs(11,2): error CS1038: #endregion directive expected [E:\vs\Projects\PlatformIndependentNuGetPackages\SunamoStopwatch\SunamoStopwatch.csproj]");
    }
}
