using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Infrastructure.Persistance.DbContext;

public class HospitalSystemContext : IdentityDbContext
{


    public HospitalSystemContext(DbContextOptions<HospitalSystemContext> options) : base(options)
    {
        
    }
}
