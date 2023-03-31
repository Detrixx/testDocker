using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MojeAplikace.Models;

namespace MojeAplikace.Data
{
    public class MojeAplikaceContext : DbContext
    {
        public MojeAplikaceContext (DbContextOptions<MojeAplikaceContext> options)
            : base(options)
        {
        }

        public DbSet<MojeAplikace.Models.sachista> sachista { get; set; } = default!;
    }
}
