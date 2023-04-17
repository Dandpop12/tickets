﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tickets.api.Data;

#nullable disable

namespace tickets.api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230414235115_CorrigiendoCapoClasificacionClientes")]
    partial class CorrigiendoCapoClasificacionClientes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("tickets.shared.Models.Clientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClasificacionId")
                        .HasColumnType("int");

                    b.Property<string>("Correo")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Notas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RNC")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("URL_Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClasificacionId");

                    b.HasIndex("RNC")
                        .IsUnique()
                        .HasFilter("[RNC] IS NOT NULL");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("tickets.shared.Models.Clientes_Clasificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Descripcion")
                        .IsUnique();

                    b.ToTable("Clientes_Clasificaciones");
                });

            modelBuilder.Entity("tickets.shared.Models.Clientes_Contactos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cargo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Correo")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Departamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("Flota")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Clientes_Contactos");
                });

            modelBuilder.Entity("tickets.shared.Models.Generales_Departamentos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Descripcion")
                        .IsUnique();

                    b.ToTable("Generales_Departamentos");
                });

            modelBuilder.Entity("tickets.shared.Models.Generales_Empleados", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SucursalId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.HasIndex("SucursalId");

                    b.HasIndex("UserId");

                    b.ToTable("Generales_Empleados");
                });

            modelBuilder.Entity("tickets.shared.Models.Generales_Empresas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NombreComercial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RNC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URL_Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Generales_Empresas");
                });

            modelBuilder.Entity("tickets.shared.Models.Generales_Sucursales", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Generales_Sucursales");
                });

            modelBuilder.Entity("tickets.shared.Models.Tickets", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClasificacionId")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("ContactoId")
                        .HasColumnType("int");

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaArchivado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCorta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaCortaEntrega")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaEntrega")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("Hora")
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("HoraEntrega")
                        .HasColumnType("time");

                    b.Property<string>("IdenTicket")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NotasArchivado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Prioridad")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ClasificacionId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ContactoId");

                    b.HasIndex("EmpleadoId");

                    b.HasIndex("UserId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("tickets.shared.Models.Tickets_Clasificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Descripcion")
                        .IsUnique();

                    b.ToTable("Tickets_Clasificaciones");
                });

            modelBuilder.Entity("tickets.shared.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("URL_Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("tickets.shared.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("tickets.shared.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tickets.shared.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("tickets.shared.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("tickets.shared.Models.Clientes", b =>
                {
                    b.HasOne("tickets.shared.Models.Clientes_Clasificacion", "Clasificacion")
                        .WithMany("Clientes")
                        .HasForeignKey("ClasificacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clasificacion");
                });

            modelBuilder.Entity("tickets.shared.Models.Clientes_Contactos", b =>
                {
                    b.HasOne("tickets.shared.Models.Clientes", "Cliente")
                        .WithMany("Contactos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("tickets.shared.Models.Generales_Empleados", b =>
                {
                    b.HasOne("tickets.shared.Models.Generales_Departamentos", "Departamento")
                        .WithMany("Empleados")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tickets.shared.Models.Generales_Sucursales", "Sucursal")
                        .WithMany("Empleados")
                        .HasForeignKey("SucursalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tickets.shared.Models.User", "Usuario")
                        .WithMany("Empleados")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");

                    b.Navigation("Sucursal");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("tickets.shared.Models.Generales_Sucursales", b =>
                {
                    b.HasOne("tickets.shared.Models.Generales_Empresas", "Empresa")
                        .WithMany("Sucursales")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("tickets.shared.Models.Tickets", b =>
                {
                    b.HasOne("tickets.shared.Models.Tickets_Clasificacion", "Clasificacion")
                        .WithMany("Tickets")
                        .HasForeignKey("ClasificacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tickets.shared.Models.Clientes", "Cliente")
                        .WithMany("Tickets")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tickets.shared.Models.Clientes_Contactos", "Contacto")
                        .WithMany("Tickets")
                        .HasForeignKey("ContactoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tickets.shared.Models.Generales_Empleados", "Empleado")
                        .WithMany("Tickets")
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tickets.shared.Models.User", "Usuario")
                        .WithMany("Tickets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clasificacion");

                    b.Navigation("Cliente");

                    b.Navigation("Contacto");

                    b.Navigation("Empleado");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("tickets.shared.Models.Clientes", b =>
                {
                    b.Navigation("Contactos");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("tickets.shared.Models.Clientes_Clasificacion", b =>
                {
                    b.Navigation("Clientes");
                });

            modelBuilder.Entity("tickets.shared.Models.Clientes_Contactos", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("tickets.shared.Models.Generales_Departamentos", b =>
                {
                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("tickets.shared.Models.Generales_Empleados", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("tickets.shared.Models.Generales_Empresas", b =>
                {
                    b.Navigation("Sucursales");
                });

            modelBuilder.Entity("tickets.shared.Models.Generales_Sucursales", b =>
                {
                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("tickets.shared.Models.Tickets_Clasificacion", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("tickets.shared.Models.User", b =>
                {
                    b.Navigation("Empleados");

                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
