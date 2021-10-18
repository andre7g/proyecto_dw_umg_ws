using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using umg_clinica_backend.Models;

namespace umg_clinica_backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {}

        public DbSet<Estados> Estados { get; set; }
        public DbSet<personal_administrativo> personal_administrativo { get; set; }
        public DbSet<profecion> profecion { get; set; }
        public DbSet<tipo_personal> tipo_personal { get; set; }
        public DbSet<clinica> clinica { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

    }
}
