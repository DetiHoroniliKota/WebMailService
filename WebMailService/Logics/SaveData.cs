using WebMailService.Data;
using WebMailService.Models;

namespace WebMailService.Logics
{
    public class SaveData
    {
        private WebMailServiceContext _context;
        public SaveData(WebMailServiceContext context)
        {
            _context = context;
        }
        /// <summary>
        /// метод принимает обработанныые данные из запроса в виде полей модели запроса,
        /// сохраняет данные в БД
        /// </summary>
        /// <param name="subject">Тема письма</param>
        /// <param name="body">Тело письма</param>
        /// <param name="recipients">Список получателей </param>
        public void SaveDatainDB(string subject, string body, List<string> recipients)
        {
            MailData str = new MailData { Subject = subject, Body = body, CreatedDate = DateTime.Now };
            _context.MailData.Add(str);
            _context.SaveChanges();

            foreach (string recipient in recipients)
            {
                _context.Recipients.Add(new Recipient
                {
                    Email = recipient,
                    MailData = str

                });
                _context.SaveChanges();
            }
        }
    }
}
