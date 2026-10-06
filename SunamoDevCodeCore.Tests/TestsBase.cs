
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunamoDevCodeCore.Tests;

public class TestsBase
{
    public ILogger logger = NullLogger.Instance;
}
