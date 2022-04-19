using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using WebMotors.Domain;

namespace WebMotors.Infrastructure.Context
{
    public class WebMotorsContext
    {
        public DbSet<Anuncio> tb_AnuncioWebmotors { get; set; }

        static string connectionString;

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
