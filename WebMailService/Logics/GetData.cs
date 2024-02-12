using Microsoft.EntityFrameworkCore;
using WebMailService.Data;
using WebMailService.Models;

namespace WebMailService.Logics
{
    public class GetData
    {
        private WebMailServiceContext _context;

        public GetData(WebMailServiceContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Metod вытаскивает данные из БД, на их основе создает новый обьект модели даныых для ответа, добавляет их в лист. 
        /// </summary>
        /// <returns>возвращает модель запрашиваемых данных собранную из таблиц</returns>
        public List<ResponseModel> GetResponseItem()
        {
            List<ResponseModel> responseList = new List<ResponseModel>();

            var mailData = _context.MailData.Include(m => m.Recipients).ToList();

            foreach (MailData mailDataitem in mailData)
            {
                foreach (Recipient recipient in mailDataitem.Recipients)
                {
                    responseList.Add(new ResponseModel
                    {
                        Subject = mailDataitem.Subject,
                        Body = mailDataitem.Body,
                        Recipient = recipient.Email,
                        Data = mailDataitem.CreatedDate

                    });
                }
            }
            return responseList;
        }
    }
}
