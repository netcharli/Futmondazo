using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Futmondazo.Data;

namespace Futmondazo.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160825121117_AddPuntuations")]
    partial class AddPuntuations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Futmondazo.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ChampionshipId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("ChampionshipId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Futmondazo.Models.Championship", b =>
                {
                    b.Property<string>("Id");

                    b.HasKey("Id");

                    b.ToTable("Championship");
                });

            modelBuilder.Entity("Futmondazo.Models.Player", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Name");

                    b.Property<string>("Photo");

                    b.Property<int>("Points");

                    b.Property<int>("Price");

                    b.Property<string>("TeamId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.HasIndex("UserId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Futmondazo.Models.PlayerHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("PlayerId")
                        .IsRequired();

                    b.Property<int>("Price");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerHistories");
                });

            modelBuilder.Entity("Futmondazo.Models.PlayerMovement", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("BuyerId");

                    b.Property<string>("ChampionshipId")
                        .IsRequired();

                    b.Property<DateTime>("Date");

                    b.Property<int>("NumberOfBids");

                    b.Property<string>("PlayerId");

                    b.Property<string>("PlayerName");

                    b.Property<int>("PlayerValue");

                    b.Property<int>("Price");

                    b.Property<string>("SellerId");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("ChampionshipId");

                    b.HasIndex("SellerId");

                    b.ToTable("PlayerMovements");
                });

            modelBuilder.Entity("Futmondazo.Models.Puntuation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Matchweek");

                    b.Property<int>("Points");

                    b.Property<int>("Reward");

                    b.Property<string>("TeamId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Puntuation");
                });

            modelBuilder.Entity("Futmondazo.Models.Team", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ChampionshipId")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.Property<int>("Points");

                    b.Property<string>("TeamId");

                    b.Property<string>("TeamName");

                    b.Property<int>("TeamValue");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ChampionshipId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Futmondazo.Models.ApplicationUser", b =>
                {
                    b.HasOne("Futmondazo.Models.Championship", "Championship")
                        .WithMany("Users")
                        .HasForeignKey("ChampionshipId");
                });

            modelBuilder.Entity("Futmondazo.Models.Player", b =>
                {
                    b.HasOne("Futmondazo.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");

                    b.HasOne("Futmondazo.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Futmondazo.Models.PlayerHistory", b =>
                {
                    b.HasOne("Futmondazo.Models.Player", "Player")
                        .WithMany("PlayerHistories")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Futmondazo.Models.PlayerMovement", b =>
                {
                    b.HasOne("Futmondazo.Models.Team", "Buyer")
                        .WithMany("PlayersBought")
                        .HasForeignKey("BuyerId");

                    b.HasOne("Futmondazo.Models.Championship", "Championship")
                        .WithMany("PlayerMovements")
                        .HasForeignKey("ChampionshipId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Futmondazo.Models.Team", "Seller")
                        .WithMany("PlayersSold")
                        .HasForeignKey("SellerId");
                });

            modelBuilder.Entity("Futmondazo.Models.Puntuation", b =>
                {
                    b.HasOne("Futmondazo.Models.Team", "Team")
                        .WithMany("Puntuations")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Futmondazo.Models.Team", b =>
                {
                    b.HasOne("Futmondazo.Models.Championship", "Championship")
                        .WithMany("Teams")
                        .HasForeignKey("ChampionshipId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Futmondazo.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Futmondazo.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Futmondazo.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
