using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.Infrastructure.Persistance
{
    public partial class HospitalSystemDBContext : DbContext
    {
        public HospitalSystemDBContext(DbContextOptions<HospitalSystemDBContext> options):base(options)
        {
            
        }
        public DbSet<Person> People { get; set; }
    }
}
