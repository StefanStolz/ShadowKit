using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace LibOne;
public class One
{
    public static void DoIt()
    {
       ILogger logger = NullLogger.Instance;

        logger.LogInformation("abc");
    }
}
