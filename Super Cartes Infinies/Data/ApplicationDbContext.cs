using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Super_Cartes_Infinies.Models;
using System.Numerics;
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
            UserName = "asd@gmail.com",
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

        //Cartes de jeu
        const String imageUrlBase = "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png";

        Card C1 = new Card
        {
            Id = 1,
            Name = "Stickly Steve",
            Attack = 3,
            Defense = 3,
            ImageUrl = imageUrlBase
        };
        builder.Entity<Card>().HasData(C1);
        Card C2 = new Card
        {
            Id = 2,
            Name = "Sketchy Sarah",
            Attack = 2,
            Defense = 4,
            ImageUrl = imageUrlBase
        };
        builder.Entity<Card>().HasData(C2);
        Card C3 = new Card
        {
            Id = 3,
            Name = "Doodle Dave",
            Attack = 4,
            Defense = 2,
            ImageUrl = imageUrlBase
        };
        builder.Entity<Card>().HasData(C3);
        Card C4 = new Card
        {
            Id = 4,
            Name = "Pencil Pete",
            Attack = 3,
            Defense = 5,
            ImageUrl = imageUrlBase
        };
        builder.Entity<Card>().HasData(C4);
        Card C5 = new Card
        {
            Id = 5,
            Name = "Marker Mike",
            Attack = 4,
            Defense = 4,
            ImageUrl = imageUrlBase
        };
        builder.Entity<Card>().HasData(C5);
        Card C6 = new Card
        {
            Id = 6,
            Name = "Eraser Edith",
            Attack = 2,
            Defense = 6,
            ImageUrl = imageUrlBase
        };
        builder.Entity<Card>().HasData(C6);
        Card C7 = new Card
        {
            Id = 7,
            Name = "Crayon Carla",
            Attack = 5,
            Defense = 3,
            ImageUrl = imageUrlBase
        };
        builder.Entity<Card>().HasData(C7);
        Card C8 = new Card
        {
            Id = 8,
            Name = "Scribble Sam",
            Attack = 4,
            Defense = 5,
            ImageUrl = imageUrlBase
        };
        builder.Entity<Card>().HasData(C8);
        Card C9 = new Card
        {
            Id = 9,
            Name = "Inkwell Ivan",
            Attack = 6,
            Defense = 2,
            ImageUrl = imageUrlBase
        };
        builder.Entity<Card>().HasData(C9);
        Card C10 = new Card
        {
            Id = 10,
            Name = "Paintbrush Penny",
            Attack = 5,
            Defense = 4,
            ImageUrl = imageUrlBase
        };
        builder.Entity<Card>().HasData(C10);


    }
    public DbSet<Card> Cards { get; set; } = default!;

    public DbSet<Player> Players { get; set; } = default!;

    public DbSet<Match> Matches { get; set; } = default!;

    public DbSet<MatchPlayerData> MatchPlayersData { get; set; } = default!;
}

