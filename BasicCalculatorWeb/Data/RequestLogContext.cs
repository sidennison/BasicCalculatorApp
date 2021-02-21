using Microsoft.EntityFrameworkCore;
using BasicCalculatorWeb.Models;


namespace BasicCalculatorWeb.Data
{
    public class RequestLogContext : DbContext
    {
        public RequestLogContext(DbContextOptions<RequestLogContext> options)
            : base(options)
        {
        }

        public DbSet<RequestLog> RequestLog { get; set; }
    }
}
