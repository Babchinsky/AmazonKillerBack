using System.Net;
using System.Net.Mail;
using AmazonKiller.Application.Interfaces.Auth;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace AmazonKiller.Infrastructure.Services.Auth
{
    public class GmailEmailSender(IConfiguration cfg, IWebHostEnvironment env) : IEmailSender
    {
        private readonly string _from = cfg["Gmail:From"] ?? throw new ArgumentNullException(nameof(cfg));
        private readonly string _appPassword = cfg["Gmail:AppPassword"] ?? throw new ArgumentNullException(nameof(cfg));
        private readonly IWebHostEnvironment _env = env ?? throw new ArgumentNullException(nameof(env));

        // Внедрение зависимостей через конструктор

        // Реализуем отправку email
        public async Task SendEmailAsync(string to, string subject, string htmlBody)
        {
            // Закомментировано: больше не отправляем email в тестовом окружении
            if (_env.IsEnvironment("Testing"))
            {
                // Замените на простой вывод сообщения в консоль
                Console.WriteLine("Email sending skipped in Testing environment.");
                return; // Прекращаем выполнение метода, не отправляя email
            }

            // Если хотите полностью отключить отправку через почту (временно), закомментируйте или удалите следующую часть:
            /*
            var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(_from, _appPassword)
            };

            var message = new MailMessage(_from, to, subject, htmlBody)
            {
                IsBodyHtml = true
            };

            await smtp.SendMailAsync(message);
            */
            
            // Для временной заглушки просто ничего не делаем
            // Можно вывести лог для отладки:
            Console.WriteLine("Email sending is disabled.");
        }
    }
}
