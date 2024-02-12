

using MimeKit;

namespace WebMailService.Logics
{
    public class SendingEmail
    {
        //private readonly  ILogger<SendingEmail> logger;



        /// <summary>
        /// метод принимает обработанныые данные из запроса в виде полей модели запроса,
        /// создает объект Сообщения,заполняет его поля требуемые для отправки , выполняет отправку.
        /// </summary>
        /// <param name="subject">Тема письма</param>
        /// <param name="body">Тело письма</param>
        /// <param name="recipients">Список получателей </param>
        public void SendingEmailMailkit(string subject, string body, List<string> recipients)
        {
            foreach (string recipient in recipients)
            {
                try
                {
                    MimeMessage message = new MimeMessage();
                    message.From.Add(new MailboxAddress("собственно я", "mkavunov991@gmail.com"));
                    message.To.Add(new MailboxAddress("", recipient));
                    message.Subject = subject;

                    message.Body = new TextPart(MimeKit.Text.TextFormat.Html)//можно попробовать так new TextPart("Plain") 
                    {
                        Text = body
                    };
                    using (MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient())
                    {
                        client.Connect("smtp.gmail.com", 465, true);//true- защищеное соединение
                        client.Authenticate("mkavunov991@gmail.com", "password");
                        client.Send(message);

                        client.Disconnect(true);
                        // logger.LogInformation("Отправка выполнена");
                    }
                }
                catch (Exception)
                {
                    // logger.LogError(e.GetBaseException().Message);
                }
            }
        }
    }
}
