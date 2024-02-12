namespace WebMailService.Models
{
    public class ResponseModel
    {
        /// <summary>
        /// тема письма
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// содержммое письма
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// почта получателя
        /// </summary>
        public string Recipient { get; set; }
        /// <summary>
        /// Дата отправки
        /// </summary>
        public DateTime Data { get; set; }


    }
}
