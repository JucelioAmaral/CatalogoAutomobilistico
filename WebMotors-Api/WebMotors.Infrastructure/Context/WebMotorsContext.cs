using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using WebMotors.Domain;

namespace WebMotors.Infrastructure.Context
{
    public class WebMotorsContext : DbContext
    {
        public DbSet<Anuncio> tbl_AnuncioWebmotors { get; set; }

        static string connectionString;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public WebMotorsContext(IConfiguration configuration)
        {
            connectionString = configuration
                     .GetConnectionString("DefaultConnection").ToString();

        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
