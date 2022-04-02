using HMS.Domain;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace HMS.Service
{
    public class EmailService : IEmailService
    {
        private readonly AppSettings _appSettings;
        MailTemplate _mailTemplate;

        public EmailService(AppSettings appSettings,  MailTemplate mailTemplate)
        {
            _appSettings = appSettings;
            _mailTemplate = mailTemplate;

        }

        public void SendForgotPassword(User user)
        {
            using WebClient client = new WebClient();
            string mailText = client.DownloadString($"{_mailTemplate.Url}ResetPassword.html");
            mailText = mailText.Replace("[PasswordLnk]", user.ResetPasswordLink);
            Send( user.Email, "Reset Your FY5 Password", mailText, _appSettings.EmailFrom);
        }

        public void SendNewUser(User user)
        {
            using WebClient client = new WebClient();
            string mailText = client.DownloadString($"{_mailTemplate.Url}newUser.html");
            mailText = mailText.Replace("[userName]", user.Name);

            Send(user.Email, "Your FY5 Account has been Created Succesfully", mailText, _appSettings.EmailFrom);
        }
        
        private void Send(string to, string subject, string html, string from = null)
        {
            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from ?? _appSettings.EmailFrom));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect(_appSettings.SmtpHost, _appSettings.SmtpPort, SecureSocketOptions.StartTls);
            smtp.Authenticate(_appSettings.SmtpUser, _appSettings.SmtpPass);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
