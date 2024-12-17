﻿// <auto-generated />
using System;
using DefendersDeck.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DefendersDeck.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CardGame", b =>
                {
                    b.Property<int>("CardsId")
                        .HasColumnType("int");

                    b.Property<int>("GamesId")
                        .HasColumnType("int");

                    b.HasKey("CardsId", "GamesId");

                    b.HasIndex("GamesId");

                    b.ToTable("CardGame");
                });

            modelBuilder.Entity("CardUser", b =>
                {
                    b.Property<int>("CardsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("CardsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("CardUser");
                });

            modelBuilder.Entity("DefendersDeck.Domain.Entities.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Turns")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 25,
                            CreationDate = new DateTime(2024, 12, 17, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "When this card is placed, a one-time attack is activated, dealing 25 damage.",
                            ImageUrl = "",
                            Name = "Fire Arrows",
                            Price = 50,
                            Turns = 1,
                            Type = 0
                        },
                        new
                        {
                            Id = 2,
                            Amount = 25,
                            CreationDate = new DateTime(2024, 12, 17, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "When this card is placed, for the next three turns, an earthquake occurs, dealing 25 damage.",
                            ImageUrl = "",
                            Name = "Earthquake",
                            Price = 70,
                            Turns = 3,
                            Type = 0
                        },
                        new
                        {
                            Id = 3,
                            Amount = 30,
                            CreationDate = new DateTime(2024, 12, 17, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "When this card is placed, a one-time sound wave appears, dealing 30 damage.",
                            ImageUrl = "",
                            Name = "Sound Wave",
                            Price = 60,
                            Turns = 1,
                            Type = 0
                        },
                        new
                        {
                            Id = 4,
                            Amount = 20,
                            CreationDate = new DateTime(2024, 12, 17, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "When this card is placed, a metal wall is generated, protecting against 20 damage",
                            ImageUrl = "",
                            Name = "Fullmetal Alchemy",
                            Price = 80,
                            Turns = 1,
                            Type = 1
                        },
                        new
                        {
                            Id = 5,
                            Amount = 50,
                            CreationDate = new DateTime(2024, 12, 17, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "When this card is placed, a water shield appears for one turn, absorbing up to 50 attack damage.",
                            ImageUrl = "",
                            Name = "Water Shield",
                            Price = 100,
                            Turns = 1,
                            Type = 1
                        },
                        new
                        {
                            Id = 6,
                            Amount = 30,
                            CreationDate = new DateTime(2024, 12, 17, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "When this card is placed, the tower restores 30 health as a one-time effect.",
                            ImageUrl = "",
                            Name = "First Aid",
                            Price = 40,
                            Turns = 1,
                            Type = 2
                        },
                        new
                        {
                            Id = 7,
                            Amount = 20,
                            CreationDate = new DateTime(2024, 12, 17, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "When this card is placed, it restores 20 health per turn for three turns.",
                            ImageUrl = "",
                            Name = "Special Help",
                            Price = 70,
                            Turns = 3,
                            Type = 2
                        },
                        new
                        {
                            Id = 8,
                            Amount = 100,
                            CreationDate = new DateTime(2024, 12, 17, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "When this card is placed, the tower's entire health is restored as a one-time effect.",
                            ImageUrl = "",
                            Name = "Health Potion",
                            Price = 120,
                            Turns = 1,
                            Type = 2
                        },
                        new
                        {
                            Id = 9,
                            Amount = 0,
                            CreationDate = new DateTime(2024, 12, 17, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "When this card is placed, all dead enemies reappear as shadows and attack the living enemies. Shadows disappear when they kill an enemy.",
                            ImageUrl = "",
                            Name = "Shadow Army",
                            Price = 150,
                            Turns = 1,
                            Type = 3
                        });
                });

            modelBuilder.Entity("DefendersDeck.Domain.Entities.Difficulty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CardsPropability")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EnemiesCount")
                        .HasColumnType("int");

                    b.Property<int>("EnemyLevelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TowerLevelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");
                });

            modelBuilder.Entity("DefendersDeck.Domain.Entities.EnemyLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DesignUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DifficultyId")
                        .HasColumnType("int");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId")
                        .IsUnique();

                    b.ToTable("EnemyLevels");
                });

            modelBuilder.Entity("DefendersDeck.Domain.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DifficultyId")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("EnemiesKilled")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("UserId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("DefendersDeck.Domain.Entities.TowerLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DesignUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DifficultyId")
                        .HasColumnType("int");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId")
                        .IsUnique();

                    b.ToTable("TowerLevels");
                });

            modelBuilder.Entity("DefendersDeck.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CurrencyAmount")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CardGame", b =>
                {
                    b.HasOne("DefendersDeck.Domain.Entities.Card", null)
                        .WithMany()
                        .HasForeignKey("CardsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DefendersDeck.Domain.Entities.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CardUser", b =>
                {
                    b.HasOne("DefendersDeck.Domain.Entities.Card", null)
                        .WithMany()
                        .HasForeignKey("CardsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DefendersDeck.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DefendersDeck.Domain.Entities.EnemyLevel", b =>
                {
                    b.HasOne("DefendersDeck.Domain.Entities.Difficulty", "Difficulty")
                        .WithOne("EnemyLevel")
                        .HasForeignKey("DefendersDeck.Domain.Entities.EnemyLevel", "DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");
                });

            modelBuilder.Entity("DefendersDeck.Domain.Entities.Game", b =>
                {
                    b.HasOne("DefendersDeck.Domain.Entities.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DefendersDeck.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DefendersDeck.Domain.Entities.TowerLevel", b =>
                {
                    b.HasOne("DefendersDeck.Domain.Entities.Difficulty", "Difficulty")
                        .WithOne("TowerLevel")
                        .HasForeignKey("DefendersDeck.Domain.Entities.TowerLevel", "DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");
                });

            modelBuilder.Entity("DefendersDeck.Domain.Entities.Difficulty", b =>
                {
                    b.Navigation("EnemyLevel")
                        .IsRequired();

                    b.Navigation("TowerLevel")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
