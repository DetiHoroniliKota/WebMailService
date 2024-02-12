namespace WebMailService.Models
{
    public class RequestModel
    {
        /// <summary>
        /// тема письма
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// тело письма
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// список почт получателей
        /// </summary>
        public List<string> Recipients { get; set; }
    }
}
