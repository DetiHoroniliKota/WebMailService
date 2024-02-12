using Microsoft.AspNetCore.Mvc;
using WebMailService.Data;
using WebMailService.Logics;
using WebMailService.Models;

namespace WebMailService.Controllers
{
    
        public class ApiController : ControllerBase
        {
            private WebMailServiceContext _context;

            // private readonly ILogger<ApiController> logger;

            public ApiController(WebMailServiceContext context)
            {
                _context = context;
            }
            SendingEmail sendingEmail = new SendingEmail();

        /// <summary>
        /// Get 
        /// метод получает данные из БД, обрабатывает, возвращает результат в виде Json(по дефолту))
        /// </summary>
        /// <returns> возвращает список отправок </returns>
        [HttpGet]
        [Route("api/mails")]
        public List<ResponseModel> Mails()
        {
            GetData getData = new GetData(_context);
            return getData.GetResponseItem();
        }

        /// <summary>
        /// Метод сохраняет данные из request в БД, отправляет письма используя данные хронящиеся в request
        /// </summary>
        /// <param name="model"> Модель запроса , принимает JSON из Request </param>
        /// <returns> Если все ОК возвращает статус код и сообщение </returns>
            [HttpPost]
            [Route("api/mails")]
            public IActionResult Mails([FromBody] RequestModel model)
            {
                if (model == null)
                {
                    return BadRequest(ModelState);
                }

                string subject = model.Subject;
                string body = model.Body;
                List<string> recipients = model.Recipients;

                SaveData saveData = new SaveData(_context);
                saveData.SaveDatainDB(subject, body, recipients);

                sendingEmail.SendingEmailMailkit(subject, body, recipients);

                return Ok("Mail Sent");
            }
        }
}

