using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using OrderQueueSystem.Domain;

namespace OrderQueueSystem.Services;

public class EmailService

{
    private readonly IConfiguration _configuration;


    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }


    public async Task SendEmail(Pedido pedido)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_configuration["EmailSettings:Username"]));
        email.To.Add(MailboxAddress.Parse(pedido.Email));
        email.Subject = "ProcessarPedido";
        email.Body = new TextPart("plain") { Text = "Pedido processado!" };

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(
            _configuration["EmailSettings:SmtpServer"],
            int.Parse(_configuration["EmailSettings:Port"]),
            SecureSocketOptions.StartTls);

        await smtp.AuthenticateAsync(
            _configuration["EmailSettings:Username"],
            _configuration["EmailSettings:Password"]);

        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }
}
