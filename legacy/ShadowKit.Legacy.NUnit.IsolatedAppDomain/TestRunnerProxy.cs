using System;
using System.IO;
using System.Reflection;

namespace ShadowKit.Legacy.NUnit.IsolatedAppDomain
{
    public class TestRunnerProxy : MarshalByRefObject
    {
        public TestRunnerProxy()
        {
            AppDomain.CurrentDomain.AssemblyResolve += OnAppDomainAssemblyResolve;
        }

        private static Assembly OnAppDomainAssemblyResolve(object sender, ResolveEventArgs args)
        {
            var assemblyName = new AssemblyName(args.Name);

            try
            {
                string assemblyPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, assemblyName.Name + ".dll");
                if (File.Exists(assemblyPath))
                {
                    return Assembly.LoadFrom(assemblyPath);
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Exception during assembly resolving of {assemblyName.Name}: {e.Message}");
            }
            
            return null;
        }

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