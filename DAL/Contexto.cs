using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P2_AP1_Frankelyn_20190276.Entidades;

namespace P2_AP1_Frankelyn_20190276.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<TipoDeTarea> TipoDeTarea { get; set; }

        public DbSet<Proyectos> Proyectos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoDeTarea>().HasData(new TipoDeTarea
            {
                TipoDeTareaId = 1,
                Descripcion = "Analisis",
                TiempoAcumulado = 0

            });

            modelBuilder.Entity<TipoDeTarea>().HasData(new TipoDeTarea
            {
                TipoDeTareaId = 2,
                Descripcion = "Diseño",
                TiempoAcumulado = 0

            });

            modelBuilder.Entity<TipoDeTarea>().HasData(new TipoDeTarea
            {
                TipoDeTareaId = 3,
                Descripcion = "Programacion",
                TiempoAcumulado = 0

            });

            modelBuilder.Entity<TipoDeTarea>().HasData(new TipoDeTarea
            {
                TipoDeTareaId = 4,
                Descripcion = "Prueba",
                TiempoAcumulado = 0

            });

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA\Proyectos.db");
        }
    }
}
