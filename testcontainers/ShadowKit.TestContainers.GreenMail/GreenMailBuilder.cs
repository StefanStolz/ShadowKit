using System.Net;

using Docker.DotNet.Models;

using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;

using JetBrains.Annotations;

namespace ShadowKit.TestContainers.GreenMail;

[PublicAPI]
public sealed class GreenMailBuilder : ContainerBuilder<GreenMailBuilder, GreenMailContainer, GreenMailConfiguration>
{
    public const string GreenMailImage = "greenmail/standalone:latest";

    public const int SmtpPort = 3025;
    public const int Pop3Port = 3110;
    public const int ImapPort = 3143;
    public const int SmtpsPort = 3465;
    public const int ImapsPort = 3993;
    public const int Pop3sPort = 3995;
    public const int WebUiPort = 8080;

    public GreenMailBuilder()
        : this(new GreenMailConfiguration())
    {
        this.DockerResourceConfiguration = this.Init().DockerResourceConfiguration;
    }

    public GreenMailBuilder(GreenMailConfiguration dockerResourceConfiguration)
        : base(dockerResourceConfiguration)
    {
        this.DockerResourceConfiguration = dockerResourceConfiguration;
    }

    protected override GreenMailBuilder Init()
    {
        return base.Init()
                   .WithImage(GreenMailImage)
                   .WithPortBinding(SmtpPort, true)
                   .WithPortBinding(Pop3Port, true)
                   .WithPortBinding(ImapPort, true)
                   .WithPortBinding(SmtpsPort, true)
                   .WithPortBinding(ImapsPort, true)
                   .WithPortBinding(Pop3sPort, true)
                   .WithPortBinding(WebUiPort, true)
                   // .WithEnvironment("GREENMAIL_OPTS", "-Dgreenmail.setup.test.all -Dgreenmail.auth.disabled")
                   .WithWaitStrategy(Wait.ForUnixContainer().UntilExternalTcpPortIsAvailable(WebUiPort))
                   .WithWaitStrategy(Wait.ForUnixContainer().UntilExternalTcpPortIsAvailable(SmtpPort))
                   .WithWaitStrategy(Wait.ForUnixContainer()
                                         .UntilHttpRequestIsSucceeded(r => r.ForPort(WebUiPort)
                                                                            .ForPath("/api/service/readiness")
                                                                            .ForStatusCode(HttpStatusCode.OK)));
    }

    public override GreenMailContainer Build()
    {
        this.Validate();

        return new GreenMailContainer(this.DockerResourceConfiguration);
    }

    protected override GreenMailBuilder Clone(IResourceConfiguration<CreateContainerParameters> resourceConfiguration)
    {
        return this.Merge(this.DockerResourceConfiguration, new GreenMailConfiguration(resourceConfiguration));
    }

    protected override GreenMailBuilder Clone(IContainerConfiguration resourceConfiguration)
    {
        return this.Merge(this.DockerResourceConfiguration, new GreenMailConfiguration(resourceConfiguration));
    }

    protected override GreenMailBuilder Merge(GreenMailConfiguration oldValue, GreenMailConfiguration newValue)
    {
        return new GreenMailBuilder(new GreenMailConfiguration(oldValue, newValue));
    }

    protected override GreenMailConfiguration DockerResourceConfiguration { get; }
}
