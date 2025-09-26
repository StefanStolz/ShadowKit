using System.Text;

using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit.Search;

using MimeKit;

namespace ShadowKit.TestContainers.GreenMail.Tests;

public class IntegrationTests
{
    [Test]
    public async Task StartupAndShutdown()
    {
        var builder = new GreenMailBuilder();

        var container = builder.Build();

        await container.StartAsync();
        try {
            var port = container.WebApiPort;

            Console.WriteLine(port);
        }
        finally {
            await container.StopAsync();
        }
    }

    [Test]
    public async Task SendMail()
    {
        var builder = new GreenMailBuilder();

        var container = builder.Build();

        await container.StartAsync();
        try {
            using var smtpClient = new SmtpClient();
            await smtpClient.ConnectAsync("localhost", container.SmtpPort, false);

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("xx", "xx@abc.de"));
            message.To.Add(new MailboxAddress("xx", "xx@abc.de"));
            message.Subject = "Hello World";
            message.Body = new TextPart("plain") {
                Text = "Hello World"
            };

            await smtpClient.SendAsync(FormatOptions.Default, message);
            await smtpClient.DisconnectAsync(true);

            using var imapClient = new ImapClient();
            await imapClient.ConnectAsync("localhost", container.ImapPort, false);
            await imapClient.AuthenticateAsync("xx@abc.de", "xx@abc.de");

            await imapClient.Inbox.OpenAsync(FolderAccess.ReadOnly);
            var searchResult = await imapClient.Inbox.SearchAsync(SearchQuery.All);

            Assert.That(searchResult.Count, Is.EqualTo(1));

            await imapClient.DisconnectAsync(true);
        }
        finally {
            await container.StopAsync();
        }
    }
}
