﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using P2_AP1_Frankelyn_20190276.DAL;

namespace P2_AP1_Frankelyn_20190276.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("P2_AP1_Frankelyn_20190276.Entidades.TipoDeTarea", b =>
                {
                    b.Property<int>("TipoDeTareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("TiempoAcumulado")
                        .HasColumnType("INTEGER");

                    b.HasKey("TipoDeTareaId");

                    b.ToTable("TipoDeTarea");

                    b.HasData(
                        new
                        {
                            TipoDeTareaId = 1,
                            Descripcion = "Analisis",
                            TiempoAcumulado = 0
                        },
                        new
                        {
                            TipoDeTareaId = 2,
                            Descripcion = "Diseño",
                            TiempoAcumulado = 0
                        },
                        new
                        {
                            TipoDeTareaId = 3,
                            Descripcion = "Programacion",
                            TiempoAcumulado = 0
                        },
                        new
                        {
                            TipoDeTareaId = 4,
                            Descripcion = "Prueba",
                            TiempoAcumulado = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}