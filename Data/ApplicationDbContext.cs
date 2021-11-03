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
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Usuarios_Roles> Usuarios_Roles { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Via_Administracion_Producto> Via_Administracion_Producto { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Dosis> Dosis { get; set; }
        public DbSet<Presentacion> Presentacion { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Enfermedades> Enfermedades { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<Habitacion> Habitacion { get; set; }
        public DbSet<Habitacion_Paciente> Habitacion_Paciente { get; set; }
        public DbSet<Funcion_medicamento> Funcion_medicamento { get; set; }

    }
}
