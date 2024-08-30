﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskBox.Infra.Data.Context;

#nullable disable

namespace TaskBox.Infra.Data.Migrations
{
    [DbContext(typeof(TaskBoxDbContext))]
    [Migration("20240830024033_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaskBox.Domain.Models.Board", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1000)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CreatorUserId");

                    b.ToTable("Board");
                });

            modelBuilder.Entity("TaskBox.Domain.Models.ListTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BoardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1000)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.HasIndex("CreatorUserId");

                    b.ToTable("ListTask");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7c8f701b-9626-421d-b338-ffc8800e7b22"),
                            CreatedAt = new DateTime(2024, 8, 30, 2, 40, 33, 151, DateTimeKind.Utc).AddTicks(8055),
                            Description = "Tarefas pendentes",
                            IsActive = false,
                            IsArchived = false,
                            Title = "A fazer"
                        },
                        new
                        {
                            Id = new Guid("90fce5c8-c143-4921-af04-bc3355168d87"),
                            CreatedAt = new DateTime(2024, 8, 30, 2, 40, 33, 151, DateTimeKind.Utc).AddTicks(8058),
                            Description = "Tarefas em andamento",
                            IsActive = false,
                            IsArchived = false,
                            Title = "Fazendo"
                        },
                        new
                        {
                            Id = new Guid("cf8a8c3b-6352-4777-8922-49066bf9d9e0"),
                            CreatedAt = new DateTime(2024, 8, 30, 2, 40, 33, 151, DateTimeKind.Utc).AddTicks(8059),
                            Description = "Tarefas realizadas",
                            IsActive = false,
                            IsArchived = false,
                            Title = "Feito"
                        });
                });

            modelBuilder.Entity("TaskBox.Domain.Models.Marker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1000)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CreatorUserId");

                    b.ToTable("Marker");
                });

            modelBuilder.Entity("TaskBox.Domain.Models.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1000)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<Guid>("ListTaskId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ResponsibleUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("TargetDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CreatorUserId");

                    b.HasIndex("ListTaskId");

                    b.HasIndex("ResponsibleUserId");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("TaskBox.Domain.Models.TaskMarker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("MarkerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TaskId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MarkerId");

                    b.HasIndex("TaskId");

                    b.ToTable("TaskMarker");
                });

            modelBuilder.Entity("TaskBox.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CreatorUserId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a42f41dc-843a-47aa-b4a2-af6ea00aab4c"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "test+1@mail.com",
                            IsActive = false,
                            Name = "Pedro"
                        },
                        new
                        {
                            Id = new Guid("007b5363-9085-40bc-b40d-cf276170921a"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "test+2@mail.com",
                            IsActive = false,
                            Name = "Tiago"
                        },
                        new
                        {
                            Id = new Guid("8d5a1c35-ab41-4222-9216-7a879ead6143"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "test+3@mail.com",
                            IsActive = false,
                            Name = "João"
                        });
                });

            modelBuilder.Entity("TaskBox.Domain.Models.Board", b =>
                {
                    b.HasOne("TaskBox.Domain.Models.User", "CreatorUser")
                        .WithMany("Boards")
                        .HasForeignKey("CreatorUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatorUser");
                });

            modelBuilder.Entity("TaskBox.Domain.Models.ListTask", b =>
                {
                    b.HasOne("TaskBox.Domain.Models.Board", null)
                        .WithMany("ListTasks")
                        .HasForeignKey("BoardId");

                    b.HasOne("TaskBox.Domain.Models.User", "CreatorUser")
                        .WithMany("ListTasks")
                        .HasForeignKey("CreatorUserId");

                    b.Navigation("CreatorUser");
                });

            modelBuilder.Entity("TaskBox.Domain.Models.Marker", b =>
                {
                    b.HasOne("TaskBox.Domain.Models.User", "CreatorUser")
                        .WithMany("Markers")
                        .HasForeignKey("CreatorUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatorUser");
                });

            modelBuilder.Entity("TaskBox.Domain.Models.Task", b =>
                {
                    b.HasOne("TaskBox.Domain.Models.User", "CreatorUser")
                        .WithMany("TasksForCreatorUser")
                        .HasForeignKey("CreatorUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TaskBox.Domain.Models.ListTask", "ListTask")
                        .WithMany("Tasks")
                        .HasForeignKey("ListTaskId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TaskBox.Domain.Models.User", "ResponsibleUser")
                        .WithMany("TasksForResponsibleUser")
                        .HasForeignKey("ResponsibleUserId");

                    b.Navigation("CreatorUser");

                    b.Navigation("ListTask");

                    b.Navigation("ResponsibleUser");
                });

            modelBuilder.Entity("TaskBox.Domain.Models.TaskMarker", b =>
                {
                    b.HasOne("TaskBox.Domain.Models.Marker", "Marker")
                        .WithMany("TaskMarkers")
                        .HasForeignKey("MarkerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TaskBox.Domain.Models.Task", "Task")
                        .WithMany("TaskMarkers")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Marker");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("TaskBox.Domain.Models.User", b =>
                {
                    b.HasOne("TaskBox.Domain.Models.User", "CreatorUser")
                        .WithMany("Users")
                        .HasForeignKey("CreatorUserId");

                    b.Navigation("CreatorUser");
                });

            modelBuilder.Entity("TaskBox.Domain.Models.Board", b =>
                {
                    b.Navigation("ListTasks");
                });

            modelBuilder.Entity("TaskBox.Domain.Models.ListTask", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("TaskBox.Domain.Models.Marker", b =>
                {
                    b.Navigation("TaskMarkers");
                });

            modelBuilder.Entity("TaskBox.Domain.Models.Task", b =>
                {
                    b.Navigation("TaskMarkers");
                });

            modelBuilder.Entity("TaskBox.Domain.Models.User", b =>
                {
                    b.Navigation("Boards");

                    b.Navigation("ListTasks");

                    b.Navigation("Markers");

                    b.Navigation("TasksForCreatorUser");

                    b.Navigation("TasksForResponsibleUser");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
