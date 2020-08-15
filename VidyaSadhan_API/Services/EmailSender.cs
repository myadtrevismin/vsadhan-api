using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using VidyaSadhan_API.Models;

namespace VidyaSadhan_API.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;
        private readonly IWebHostEnvironment _environment;
        private readonly SMSoptions _smsOptions;

        public EmailSender(IOptions<EmailSettings> emailSettings, 
            IWebHostEnvironment environment, 
            IOptions<SMSoptions> smsOptions)
        {
            _environment = environment;
            _emailSettings = emailSettings.Value;
            _smsOptions = smsOptions.Value;
        }

        public async Task SendEmailAsync(EmailMessage message)
        {
            try
            {
                var mimeMessage = new MimeMessage();

                mimeMessage.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.Sender));
                mimeMessage.To.AddRange(message.Email.Select(x => MailboxAddress.Parse(x)));

                mimeMessage.Subject = message.Subject;

                mimeMessage.Body = new TextPart("html")
                {
                    Text = message.Message
                };

                using (var client = new SmtpClient())
                {
                    client.MessageSent += (sender, args) => { };

                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    

                    if (_environment.IsDevelopment())
                    {
                        await client.ConnectAsync(_emailSettings.Server, _emailSettings.Port,true);
                    }
                    else
                    {
                        await client.ConnectAsync(_emailSettings.Server);
                    }

                    await client.AuthenticateAsync(_emailSettings.Sender, "dxexodscuusnnaic");

                    await client.SendAsync(mimeMessage);

                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task SendSmsAsync(string number, string message)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_smsOptions.SMSAccountUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("nl-NL"));

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.
                    GetAsync(string.Format("/api.php?username={0}&password={1}to={2}&from={2}&message={3}",
                    _smsOptions.SMSAccountIdentification,_smsOptions.SMSAccountPassword, number, _smsOptions.Sender, message));
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                }
            }
        }
    }
}
