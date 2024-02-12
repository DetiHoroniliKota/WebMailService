using Microsoft.EntityFrameworkCore;

namespace WebMailService.Data
{
    public class WebMailServiceContext: DbContext
    {
        public WebMailServiceContext(DbContextOptions<WebMailServiceContext> options)
           : base(options)
        {

        }

        public DbSet<WebMailService.Models.MailData> MailData { get; set; } // = default!;
        public DbSet<WebMailService.Models.Recipient> Recipients { get; set; }
    }
}
