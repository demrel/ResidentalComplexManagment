﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ResidentalComplexManagment.Infrastructure.Data;

#nullable disable

namespace ResidentalComplexManagment.Infrastructure.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20220419093658_DetItemSystem")]
    partial class DetItemSystem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("NottificationResident", b =>
                {
                    b.Property<string>("NottificationsId")
                        .HasColumnType("text");

                    b.Property<string>("RecipientsId")
                        .HasColumnType("text");

                    b.HasKey("NottificationsId", "RecipientsId");

                    b.HasIndex("RecipientsId");

                    b.ToTable("NottificationResident");
                });

            modelBuilder.Entity("ResidentalComplexManagment.Core.Entities.Accountment.ResidentDebt", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("ResidentId")
                        .HasColumnType("text");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("ResidentId");

                    b.ToTable("ResidentDebt");
                });

            modelBuilder.Entity("ResidentalComplexManagment.Core.Entities.Accountment.ResidentPayment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Detail")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("ResidentId")
                        .HasColumnType("text");

                    b.Property<string>("TransactionId")
                        .HasColumnType("text");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("ResidentId");

                    b.ToTable("ResidentPayments");
                });

            modelBuilder.Entity("ResidentalComplexManagment.Core.Entities.ComplexInfrastructure.Appartment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<decimal>("Area")
                        .HasColumnType("numeric");

                    b.Property<string>("BuildingId")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<int>("DoorNumber")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("Appartments");
                });

            modelBuilder.Entity("ResidentalComplexManagment.Core.Entities.ComplexInfrastructure.Building", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("MKTId")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MKTId");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("ResidentalComplexManagment.Core.Entities.ComplexInfrastructure.MKT", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("IBAN")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MKTs");
                });

            modelBuilder.Entity("ResidentalComplexManagment.Core.Entities.ResidentNotifications.Nottification", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime?>("AutomaticSendingPeriod")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<bool>("IsAutomatic")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Sender")
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Nottifications");
                });

            modelBuilder.Entity("ResidentalComplexManagment.Core.Entities.Users.Resident", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("AppartmentId")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("Date");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("FIN")
                        .HasColumnType("text");

                    b.Property<bool>("IsCurrentResident")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AppartmentId");

                    b.ToTable("Residents");
                });

            modelBuilder.Entity("ResidentalComplexManagment.Domain.Entities.Accountment.CalculationValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("From")
                        .HasColumnType("numeric");

                    b.Property<bool>("IsCurrent")
                        .HasColumnType("boolean");

                    b.Property<int>("Method")
                        .HasColumnType("integer");

                    b.Property<string>("PaymentItemId")
                        .HasColumnType("text");

                    b.Property<decimal>("To")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("PaymentItemId");

                    b.ToTable("CalculationValues");
                });

            modelBuilder.Entity("ResidentalComplexManagment.Domain.Entities.Accountment.DebtItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateOnly?>("From")
                        .HasColumnType("date");

                    b.Property<bool>("IsComplusory")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateOnly?>("To")
                        .HasColumnType("date");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("DebtItems");
                });

            modelBuilder.Entity("ResidentalComplexManagment.Domain.Entities.Accountment.ResidentDebtItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("DiscountPercent")
                        .HasColumnType("numeric");

                    b.Property<string>("PaymentItemId")
                        .HasColumnType("text");

                    b.Property<string>("ResidentId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PaymentItemId");

                    b.HasIndex("ResidentId");

                    b.ToTable("ResidentDebtItems");
                });

            modelBuilder.Entity("ResidentalComplexManagment.Infrastructure.IdentityEntity.AppRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("ResidentalComplexManagment.Infrastructure.IdentityEntity.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MktId")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<string>("SurName")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("MktId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("ResidentalComplexManagment.Infrastructure.IdentityEntity.AppUserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.Property<int>("ID")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("ResidentalComplexManagment.Infrastructure.IdentityEntity.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ResidentalComplexManagment.Infrastructure.IdentityEntity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ResidentalComplexManagment.Infrastructure.IdentityEntity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ResidentalComplexManagment.Infrastructure.IdentityEntity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NottificationResident", b =>
                {
                    b.HasOne("ResidentalComplexManagment.Core.Entities.ResidentNotifications.Nottification", null)
                        .WithMany()
                        .HasForeignKey("NottificationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResidentalComplexManagment.Core.Entities.Users.Resident", null)
                        .WithMany()
                        .HasForeignKey("RecipientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ResidentalComplexManagment.Core.Entities.Accountment.ResidentDebt", b =>
                {
                    b.HasOne("ResidentalComplexManagment.Core.Entities.Users.Resident", "Resident")
                        .WithMany()
                        .HasForeignKey("ResidentId");

                    b.Navigation("Resident");
                });

            modelBuilder.Entity("ResidentalComplexManagment.Core.Entities.Accountment.ResidentPayment", b =>
                {
                    b.HasOne("ResidentalComplexManagment.Core.Entities.Users.Resident", "Resident")
                        .WithMany()
                        .HasForeignKey("ResidentId");

                    b.Navigation("Resident");
                });

            modelBuilder.Entity("ResidentalComplexManagment.Core.Entities.ComplexInfrastructure.Appartment", b =>
                {
                    b.HasOne("ResidentalComplexManagment.Core.Entities.ComplexInfrastructure.Building", "Building")
                        .WithMany("Appartments")
                        .HasForeignKey("BuildingId");

                    b.Navigation("Building");
                });

            modelBuilder.Entity("ResidentalComplexManagment.Core.Entities.ComplexInfrastructure.Building", b =>
                {
                    b.HasOne("ResidentalComplexManagment.Core.Entities.ComplexInfrastructure.MKT", "MKT")
                        .WithMany("Buildings")
                        .HasForeignKey("MKTId");

                    b.Navigation("MKT");
                });

            modelBuilder.Entity("ResidentalComplexManagment.Core.Entities.Users.Resident", b =>
                {
                    b.HasOne("ResidentalComplexManagment.Core.Entities.ComplexInfrastructure.Appartment", "Appartment")
                        .WithMany("Residents")
                        .HasForeignKey("AppartmentId");

                    b.Navigation("Appartment");
                });

            modelBuilder.Entity("ResidentalComplexManagment.Domain.Entities.Accountment.CalculationValue", b =>
                {
                    b.HasOne("ResidentalComplexManagment.Domain.Entities.Accountment.DebtItem", "PaymentItem")
                        .WithMany("CalculationValues")
                        .HasForeignKey("PaymentItemId");

                    b.Navigation("PaymentItem");
                });

            modelBuilder.Entity("ResidentalComplexManagment.Domain.Entities.Accountment.ResidentDebtItem", b =>
                {
                    b.HasOne("ResidentalComplexManagment.Domain.Entities.Accountment.DebtItem", "PaymentItem")
                        .WithMany()
                        .HasForeignKey("PaymentItemId");

                    b.HasOne("ResidentalComplexManagment.Core.Entities.Users.Resident", "Resident")
                        .WithMany("ResidentDebtItems")
                        .HasForeignKey("ResidentId");

                    b.Navigation("PaymentItem");

                    b.Navigation("Resident");
                });

            modelBuilder.Entity("ResidentalComplexManagment.Infrastructure.IdentityEntity.AppUser", b =>
                {
                    b.HasOne("ResidentalComplexManagment.Core.Entities.ComplexInfrastructure.MKT", "Mkt")
                        .WithMany()
                        .HasForeignKey("MktId");

                    b.Navigation("Mkt");
                });

            modelBuilder.Entity("ResidentalComplexManagment.Infrastructure.IdentityEntity.AppUserRole", b =>
                {
                    b.HasOne("ResidentalComplexManagment.Infrastructure.IdentityEntity.AppRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResidentalComplexManagment.Infrastructure.IdentityEntity.AppUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ResidentalComplexManagment.Core.Entities.ComplexInfrastructure.Appartment", b =>
                {
                    b.Navigation("Residents");
                });

            modelBuilder.Entity("ResidentalComplexManagment.Core.Entities.ComplexInfrastructure.Building", b =>
                {
                    b.Navigation("Appartments");
                });

            modelBuilder.Entity("ResidentalComplexManagment.Core.Entities.ComplexInfrastructure.MKT", b =>
                {
                    b.Navigation("Buildings");
                });

            modelBuilder.Entity("ResidentalComplexManagment.Core.Entities.Users.Resident", b =>
                {
                    b.Navigation("ResidentDebtItems");
                });

            modelBuilder.Entity("ResidentalComplexManagment.Domain.Entities.Accountment.DebtItem", b =>
                {
                    b.Navigation("CalculationValues");
                });

            modelBuilder.Entity("ResidentalComplexManagment.Infrastructure.IdentityEntity.AppRole", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("ResidentalComplexManagment.Infrastructure.IdentityEntity.AppUser", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
