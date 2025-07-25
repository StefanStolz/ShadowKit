using System;

namespace ShadowKit.Legacy.NUnit.IsolatedAppDomain
{
    public class MyResult : MarshalByRefObject
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = "";
        public double DurationInMilliseconds { get; set; } = 0.0;
        public int AssertCount { get; set; } = 0;
        public Exception TestException { get; set; } = null;


        [Serializable]
        public class SerializableException
        {
            public string Message { get; set; }
            public string StackTrace { get; set; }
            public string ExceptionType { get; set; }
        }

        public SerializableException SerializedException { get; set; }
    }
}