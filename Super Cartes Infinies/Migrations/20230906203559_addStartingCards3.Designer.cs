﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Super_Cartes_Infinies.Data;

#nullable disable

namespace Super_Cartes_Infinies.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230906203559_addStartingCards3")]
    partial class addStartingCards3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
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

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
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

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "11111111-1111-1111-1111-111111111111",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "40b9e815-afd5-402c-ac1c-d353bcd9c660",
                            Email = "admin@admin.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN@ADMIN.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAELsKFvHALSba1PJ0odaXykDNSwNwYdiZuhl3KvwSC38kBpyr7XTVwrDCQ952fP6t+Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "bed9d666-9012-447b-9583-4ec055564cf8",
                            TwoFactorEnabled = false,
                            UserName = "asd@gmail.com"
                        });
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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

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

                    b.HasData(
                        new
                        {
                            UserId = "11111111-1111-1111-1111-111111111111",
                            RoleId = "1"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Attack = 3,
                            Defense = 3,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png",
                            Name = "Stickly Steve"
                        },
                        new
                        {
                            Id = 2,
                            Attack = 2,
                            Defense = 4,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png",
                            Name = "Sketchy Sarah"
                        },
                        new
                        {
                            Id = 3,
                            Attack = 4,
                            Defense = 2,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png",
                            Name = "Doodle Dave"
                        },
                        new
                        {
                            Id = 4,
                            Attack = 3,
                            Defense = 5,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png",
                            Name = "Pencil Pete"
                        },
                        new
                        {
                            Id = 5,
                            Attack = 4,
                            Defense = 4,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png",
                            Name = "Marker Mike"
                        },
                        new
                        {
                            Id = 6,
                            Attack = 2,
                            Defense = 6,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png",
                            Name = "Eraser Edith"
                        },
                        new
                        {
                            Id = 7,
                            Attack = 5,
                            Defense = 3,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png",
                            Name = "Crayon Carla"
                        },
                        new
                        {
                            Id = 8,
                            Attack = 4,
                            Defense = 5,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png",
                            Name = "Scribble Sam"
                        },
                        new
                        {
                            Id = 9,
                            Attack = 6,
                            Defense = 2,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png",
                            Name = "Inkwell Ivan"
                        },
                        new
                        {
                            Id = 10,
                            Attack = 5,
                            Defense = 4,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png",
                            Name = "Paintbrush Penny"
                        });
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EventIndex")
                        .HasColumnType("int");

                    b.Property<bool>("IsMatchCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPlayerATurn")
                        .HasColumnType("bit");

                    b.Property<int>("PlayerDataAId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerDataBId")
                        .HasColumnType("int");

                    b.Property<string>("UserAId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserBId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WinnerUserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlayerDataAId");

                    b.HasIndex("PlayerDataBId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.MatchPlayerData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MatchPlayersData");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.PlayableCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<int?>("MatchPlayerDataId")
                        .HasColumnType("int");

                    b.Property<int?>("MatchPlayerDataId1")
                        .HasColumnType("int");

                    b.Property<int?>("MatchPlayerDataId2")
                        .HasColumnType("int");

                    b.Property<int?>("MatchPlayerDataId3")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("MatchPlayerDataId");

                    b.HasIndex("MatchPlayerDataId1");

                    b.HasIndex("MatchPlayerDataId2");

                    b.HasIndex("MatchPlayerDataId3");

                    b.ToTable("PlayableCard");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("IdentityUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Money")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.SerializedMatchEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<int?>("MatchId")
                        .HasColumnType("int");

                    b.Property<string>("SerializedEvent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.ToTable("SerializedMatchEvent");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.StartingCards", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("StartingCards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CardId = 1
                        },
                        new
                        {
                            Id = 2,
                            CardId = 2
                        },
                        new
                        {
                            Id = 3,
                            CardId = 3
                        },
                        new
                        {
                            Id = 4,
                            CardId = 4
                        },
                        new
                        {
                            Id = 5,
                            CardId = 5
                        },
                        new
                        {
                            Id = 6,
                            CardId = 6
                        },
                        new
                        {
                            Id = 7,
                            CardId = 7
                        },
                        new
                        {
                            Id = 8,
                            CardId = 8
                        },
                        new
                        {
                            Id = 9,
                            CardId = 9
                        },
                        new
                        {
                            Id = 10,
                            CardId = 10
                        },
                        new
                        {
                            Id = 11,
                            CardId = 1
                        });
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.Match", b =>
                {
                    b.HasOne("Super_Cartes_Infinies.Models.MatchPlayerData", "PlayerDataA")
                        .WithMany()
                        .HasForeignKey("PlayerDataAId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Super_Cartes_Infinies.Models.MatchPlayerData", "PlayerDataB")
                        .WithMany()
                        .HasForeignKey("PlayerDataBId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("PlayerDataA");

                    b.Navigation("PlayerDataB");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.PlayableCard", b =>
                {
                    b.HasOne("Super_Cartes_Infinies.Models.Card", "Card")
                        .WithMany()
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Super_Cartes_Infinies.Models.MatchPlayerData", null)
                        .WithMany("BattleField")
                        .HasForeignKey("MatchPlayerDataId");

                    b.HasOne("Super_Cartes_Infinies.Models.MatchPlayerData", null)
                        .WithMany("CardsPile")
                        .HasForeignKey("MatchPlayerDataId1");

                    b.HasOne("Super_Cartes_Infinies.Models.MatchPlayerData", null)
                        .WithMany("Graveyard")
                        .HasForeignKey("MatchPlayerDataId2");

                    b.HasOne("Super_Cartes_Infinies.Models.MatchPlayerData", null)
                        .WithMany("Hand")
                        .HasForeignKey("MatchPlayerDataId3");

                    b.Navigation("Card");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.Player", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdentityUser");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.SerializedMatchEvent", b =>
                {
                    b.HasOne("Super_Cartes_Infinies.Models.Match", null)
                        .WithMany("SerializedEvents")
                        .HasForeignKey("MatchId");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.Match", b =>
                {
                    b.Navigation("SerializedEvents");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.MatchPlayerData", b =>
                {
                    b.Navigation("BattleField");

                    b.Navigation("CardsPile");

                    b.Navigation("Graveyard");

                    b.Navigation("Hand");
                });
#pragma warning restore 612, 618
        }
    }
}
