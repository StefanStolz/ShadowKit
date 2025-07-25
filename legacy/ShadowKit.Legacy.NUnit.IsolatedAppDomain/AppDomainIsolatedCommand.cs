using System;
using System.Security.Policy;

using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Commands;

namespace ShadowKit.Legacy.NUnit.IsolatedAppDomain
{
    public class AppDomainIsolatedCommand : DelegatingTestCommand
    {
        public AppDomainIsolatedCommand(TestCommand innerCommand)
            : base(innerCommand)
        { }

        public override TestResult Execute(TestExecutionContext context)
        {
            var testType = context.TestObject.GetType();

            AppDomainSetup setupInfo = new AppDomainSetup();
            setupInfo.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;
            var appDomain = AppDomain.CreateDomain($"TestDomain{context.CurrentTest.Name}", new Evidence(), setupInfo);

            try {
                var proxyType = typeof(TestRunnerProxy);
                var runner = (TestRunnerProxy)appDomain.CreateInstanceAndUnwrap(
                    proxyType.Assembly.FullName,
                    proxyType.FullName);

                var myResult = runner.RunTest(
                    testType.Assembly.Location,
                    testType.FullName,
                    context.CurrentTest.MethodName);

                var testCaseResult = context.CurrentTest.MakeTestResult();
                if (myResult.Success) {
                    testCaseResult.SetResult(ResultState.Success, myResult.Message);
                } else {
                    testCaseResult.SetResult(ResultState.Failure, myResult.Message);
                    ;
                }

                return testCaseResult;
            }
            finally {
                AppDomain.Unload(appDomain);
            }
        }
    }
}
