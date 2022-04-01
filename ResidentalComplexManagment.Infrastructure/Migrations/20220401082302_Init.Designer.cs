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
    [Migration("20220401082302_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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

            modelBuilder.Entity("ResidentalComplexManagment.Core.Entities.Accountment.AppartmentDebt", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("AppartmentId")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("PaymentCoefficientId")
                        .HasColumnType("text");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("AppartmentId");

                    b.HasIndex("PaymentCoefficientId");

                    b.ToTable("AppartmentDebts");
                });

            modelBuilder.Entity("ResidentalComplexManagment.Core.Entities.Accountment.PaymentCoefficient", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("PaymentCoefficients");
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
                        .HasColumnType("timestamp with time zone");

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

            modelBuilder.Entity("ResidentalComplexManagment.Core.Entities.Accountment.AppartmentDebt", b =>
                {
                    b.HasOne("ResidentalComplexManagment.Core.Entities.ComplexInfrastructure.Appartment", "Appartment")
                        .WithMany()
                        .HasForeignKey("AppartmentId");

                    b.HasOne("ResidentalComplexManagment.Core.Entities.Accountment.PaymentCoefficient", "PaymentCoefficient")
                        .WithMany()
                        .HasForeignKey("PaymentCoefficientId");

                    b.Navigation("Appartment");

                    b.Navigation("PaymentCoefficient");
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
#pragma warning restore 612, 618
        }
    }
}
