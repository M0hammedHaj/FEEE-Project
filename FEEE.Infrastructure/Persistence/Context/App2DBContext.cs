using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEEE.Infrastructure.Persistence.Models;
using FEEE.Domain.Entities;
using FEEE.Infrastructure.Persistence.Entities;


namespace FEEE.Infrastructure.Persistence.Context
{
    public class WinDbContext : DbContext
    {
        public WinDbContext(DbContextOptions<WinDbContext> options)
            : base(options) { }

        public DbSet<OldStudent> OldStudents { get; set; }
    }

}
