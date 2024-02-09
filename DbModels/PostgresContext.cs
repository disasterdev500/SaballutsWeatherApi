
using Microsoft.EntityFrameworkCore;

namespace CeballutWheather.DbModels
{
    public class PostgresContext : DbContext
    {
        public PostgresContext(DbContextOptions<PostgresContext> options) : base(options) { }
    }
}