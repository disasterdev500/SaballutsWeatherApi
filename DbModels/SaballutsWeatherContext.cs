
using Microsoft.EntityFrameworkCore;

namespace SaballutsWeather.DbModels
{
    public class SaballutsWeatherContext : DbContext
    {
        public SaballutsWeatherContext(DbContextOptions<SaballutsWeatherContext> options) : base(options) { }
    }
}