using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Models
{
    public class MonitoringContext : DbContext
    {
        public MonitoringContext(DbContextOptions<MonitoringContext> options) : base(options)
        {

        }
        public DbSet<Measurement> Measurement { get; set; }
        public DbSet<Sensors> Sensors { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
