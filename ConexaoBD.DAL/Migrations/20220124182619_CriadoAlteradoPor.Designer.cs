﻿// <auto-generated />
using System;
using ConexaoBD.DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConexaoBD.DAL.Migrations
{
    [DbContext(typeof(ConexaoBDContexto))]
    [Migration("20220124182619_CriadoAlteradoPor")]
    partial class CriadoAlteradoPor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConexaoBD.DAL.Model.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AlteradoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("CriadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MoradaClienteId")
                        .HasColumnType("int");

                    b.Property<string>("NIF")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("Nome")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("MoradaClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ConexaoBD.DAL.Model.GrupoDeUtilizadores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlteradoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("CriadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoDeGrupoDeUtilizadores")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GrupoDeUtilizadores");
                });

            modelBuilder.Entity("ConexaoBD.DAL.Model.Morada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodigoPostal")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("Distrito")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("TipoDeMorada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZonaPostal")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("Id");

                    b.ToTable("Moradas");
                });

            modelBuilder.Entity("ConexaoBD.DAL.Model.Utilizador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AlteradoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("CriadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailLogin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GrupoDeUtilizadoresId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PasswordLogin")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GrupoDeUtilizadoresId");

                    b.ToTable("Utilizadores");
                });

            modelBuilder.Entity("ConexaoBD.DAL.Model.Cliente", b =>
                {
                    b.HasOne("ConexaoBD.DAL.Model.Morada", "MoradaCliente")
                        .WithMany()
                        .HasForeignKey("MoradaClienteId");

                    b.Navigation("MoradaCliente");
                });

            modelBuilder.Entity("ConexaoBD.DAL.Model.Utilizador", b =>
                {
                    b.HasOne("ConexaoBD.DAL.Model.GrupoDeUtilizadores", "GrupoDeUtilizadores")
                        .WithMany()
                        .HasForeignKey("GrupoDeUtilizadoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrupoDeUtilizadores");
                });
#pragma warning restore 612, 618
        }
    }
}
