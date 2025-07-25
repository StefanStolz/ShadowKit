using System;
using System.Reflection;

namespace ShadowKit.Legacy.NUnit.IsolatedAppDomain
{
    public class TestRunnerProxy : MarshalByRefObject
    {
        public MyResult RunTest(string assemblyPath, string typeName, string methodName)
        {
            var startTime = DateTime.Now;
            var result = new MyResult();

            try
            {
                var assembly = Assembly.LoadFrom(assemblyPath);
                var type = assembly.GetType(typeName);
                var method = type.GetMethod(methodName);

                var instance = Activator.CreateInstance(type);
                try
                {
                    method.Invoke(instance, null);
                    result.Success = true;
                }
                catch (TargetInvocationException e)
                {
                    result.Success = false;
                    result.TestException = e.InnerException;
                    result.Message = e.InnerException?.Message ?? e.Message;
                }
            }
            catch (Exception e)
            {
                result.Success = false;
                result.TestException = e;
                result.Message = e.Message;
            }

            var duration = DateTime.Now - startTime;
            result.DurationInMilliseconds = duration.TotalMilliseconds;
            return result;
        }

        public override object InitializeLifetimeService()
        {
            //return base.InitializeLifetimeService();
            // TODO Checken was hier wirklich sinnvoll ist; unbegrenzt kann doch ziemlich lange sein
            return null;
        }
    }
}