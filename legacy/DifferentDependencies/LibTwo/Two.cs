using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace LibTwo;

public class Two

{
    public static void DoIt()
    {
        ILogger logger = NullLogger.Instance;

        logger.LogInformation("abc");
    }
}