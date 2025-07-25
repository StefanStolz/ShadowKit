using System;

using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal.Commands;

namespace ShadowKit.Legacy.NUnit.IsolatedAppDomain
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class IsolatedAppDomainAttribute : NUnitAttribute, IWrapTestMethod
    {
        public TestCommand Wrap(TestCommand command)
        {
            return new AppDomainIsolatedCommand(command);
        }
    }
}