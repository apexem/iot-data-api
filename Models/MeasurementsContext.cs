using Microsoft.EntityFrameworkCore;

namespace sql_berry_api.Models
{
    public class MeasurementsContext : DbContext
    {
        private static readonly string connectionString = "Host=iot-system-db.cpzbghw4bziv.eu-central-1.rds.amazonaws.com;Port=5400;Database=iot_system_db;User Id=postgres;Password=inzynierka";
        public DbSet<TemperatureMea> Temperatures { get; set; }
        public DbSet<AnalogInput> AnalogInputs {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(connectionString);
    }
} 

//docker run --rm --name db -d -e POSTGRES_DB = db - e POSTGRES_USER=postgres -e POSTGRES_PASSWORD = admin - p 5432:5432 -v /Users/karolus/Containers/docker/volumes/postgres:/var/lib/postgresql/data postgres