namespace WebMailService.Models
{
    public class Recipient
    {
        public int Id { get; set; }
        /// <summary>
        /// Почта
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Внешний ключ
        /// </summary>
        public int MailDataId { get; set; }
        /// <summary>
        /// Навигационное свойство
        /// </summary>
        public MailData? MailData { get; set; }
    }
}
