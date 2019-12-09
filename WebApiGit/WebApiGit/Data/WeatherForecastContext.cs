using Microsoft.EntityFrameworkCore;
using WebApiGit.Models;

namespace WebApiGit.Data
{
    public class WeatherForecastContext : DbContext
    {
        public DbSet<WeatherForecastModel> WeatherForecasts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(
                @"Data Source=THOMASPC\TEW_SQLEXPRESS;Initial Catalog=WeatherData;Integrated Security=True;Pooling=False");
    }
}
