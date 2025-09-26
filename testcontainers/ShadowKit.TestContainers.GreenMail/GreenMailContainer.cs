using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;

using JetBrains.Annotations;

namespace ShadowKit.TestContainers.GreenMail
{
    [PublicAPI]
    public sealed class GreenMailContainer : DockerContainer
    {
        private readonly IContainerConfiguration configuration;

        public GreenMailContainer(IContainerConfiguration configuration)
            : base(configuration)
        {
            this.configuration = configuration;
        }

        public int SmtpPort => this.GetMappedPublicPort(GreenMailBuilder.SmtpPort);
        public int Pop3Port => this.GetMappedPublicPort(GreenMailBuilder.Pop3Port);
        public int ImapPort => this.GetMappedPublicPort(GreenMailBuilder.ImapPort);
        public int SmtpsPort => this.GetMappedPublicPort(GreenMailBuilder.SmtpsPort);
        public int ImapsPort => this.GetMappedPublicPort(GreenMailBuilder.ImapsPort);
        public int Pop3sPort => this.GetMappedPublicPort(GreenMailBuilder.Pop3sPort);
        public int WebApiPort => this.GetMappedPublicPort(GreenMailBuilder.WebUiPort);
    }
}
