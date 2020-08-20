using System;
using KLabs.Entities.ComplexTypes.AboutUs;
using KLabs.WebUI.Models;
using Microsoft.Extensions.Configuration;

namespace KLabs.WebUI.Helpers.MailHelper
{
    public class SendMail
    {

        public readonly string ReCaptcha = "6Le5X8EZAAAAAHrRIk0DTdGToZcYnjKT3OySOWU7";

        private readonly IConfigurationRoot _configuration;
        private MailOptions _options;
        public SendMail()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json", true);

            _configuration = config.Build();
            _options = _configuration.GetSection("MailOptions").Get<MailOptions>();
        }
        public bool MailGonder(SendMailModel model)
        {
            try
            {
                System.Net.NetworkCredential cred = new System.Net.NetworkCredential(_options.From, _options.Password);


                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.From = new System.Net.Mail.MailAddress(_options.From, _options.DisplayName);
                mail.To.Add(_options.To);

                mail.Subject = model.Subject;

                mail.IsBodyHtml = true;
                mail.Body =
                    $"{model.Description} <br/><br/> Kimden : {model.Name} <br/><br/>  Telefon : {model.PhoneNumber} <br/><br/> Mail Adresi : {model.Email}";

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(_options.SmtpClient, 587);
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = false;
                smtp.Credentials = cred;
                smtp.SendAsync(mail, mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}