namespace WebMailService.Models
{
    public class MailData
    {
        public int Id { get; set; }
        /// <summary>
        /// тема письма
        /// </summary>
        public string? Subject { get; set; }
        /// <summary>
        /// тело пислма
        /// </summary>
        public string? Body { get; set; }
        /// <summary>
        /// дата отправки письма
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// адреса получателей
        /// </summary>
        public List<Recipient>? Recipients { get; set; }
    }
}
