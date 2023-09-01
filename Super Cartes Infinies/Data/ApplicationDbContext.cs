using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Models;
using System.Reflection.Emit;
using static System.Net.WebRequestMethods;

namespace Super_Cartes_Infinies.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // TODO: Générer le seed

        //Ajout de admin
        builder.Entity<IdentityRole>().HasData(
               new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" }
           );

        //Creation de l'utilisateur qui est admin
        PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();
        IdentityUser admin = new IdentityUser
        {
            Id = "11111111-1111-1111-1111-111111111111",
            UserName = "asd@gmail.",
            Email = "admin@admin.com",
            // La comparaison d'identity se fait avec les versions normalisés
            NormalizedEmail = "ADMIN@ADMIN.COM",
            NormalizedUserName = "ADMIN@ADMIN.COM",
            EmailConfirmed = true
        };
        // On encrypte le mot de passe
        admin.PasswordHash = hasher.HashPassword(admin, "Passw0rd!");
        builder.Entity<IdentityUser>().HasData(admin);

        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { UserId = admin.Id, RoleId = "1" }
        );



        builder.Entity<Match>()
            .HasOne(m => m.PlayerDataA)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Match>()
            .HasOne(m => m.PlayerDataB)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
    }

    public DbSet<Card> Cards { get; set; } = default!;

    public DbSet<Player> Players { get; set; } = default!;

    public DbSet<Match> Matches { get; set; } = default!;

    public DbSet<MatchPlayerData> MatchPlayersData { get; set; } = default!;
}

