using Docker.DotNet.Models;

using DotNet.Testcontainers.Configurations;

namespace ShadowKit.TestContainers.GreenMail;

public sealed class GreenMailConfiguration : ContainerConfiguration
{
    public GreenMailConfiguration()
        : base()
    { }

    public GreenMailConfiguration(IContainerConfiguration resourceConfiguration)
        : base(resourceConfiguration)
    { }

    public GreenMailConfiguration(IResourceConfiguration<CreateContainerParameters> resourceConfiguration)
        : base(resourceConfiguration)
    { }

    public GreenMailConfiguration(IContainerConfiguration oldValue, IContainerConfiguration newValue)
        : base(oldValue, newValue)
    { }
}