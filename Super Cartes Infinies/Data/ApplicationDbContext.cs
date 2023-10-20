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

        // TODO: G?n?rer le seed

        //Ajout de admin
        builder.Entity<IdentityRole>().HasData(
               new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" }
           );

        //Creation de l'utilisateur qui est admin
        PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();
        IdentityUser admin = new IdentityUser
        {
            Id = "11111111-1111-1111-1111-111111111111",
            UserName = "admin@admin.com",
            Email = "admin@admin.com",
            // La comparaison d'identity se fait avec les versions normalis?s
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

        List<Card> cards = new List<Card>();

        Card C1 = new Card
        {
            Id = 1,
            Name = "Stickly Steve",
            Attack = 3,
            Defense = 3,
            ImageUrl = imageUrlBase
        };
        cards.Add( C1 );
        builder.Entity<Card>().HasData(C1);
        Card C2 = new Card
        {
            Id = 2,
            Name = "Sketchy Sarah",
            Attack = 2,
            Defense = 4,
            ImageUrl = imageUrlBase
        };
        cards.Add(C2);
        builder.Entity<Card>().HasData(C2);
        Card C3 = new Card
        {
            Id = 3,
            Name = "Doodle Dave",
            Attack = 4,
            Defense = 2,
            ImageUrl = imageUrlBase
        };
        cards.Add(C3);
        builder.Entity<Card>().HasData(C3);
        Card C4 = new Card
        {
            Id = 4,
            Name = "Pencil Pete",
            Attack = 3,
            Defense = 5,
            ImageUrl = imageUrlBase
        };
        cards.Add(C4);
        builder.Entity<Card>().HasData(C4);
        Card C5 = new Card
        {
            Id = 5,
            Name = "Marker Mike",
            Attack = 4,
            Defense = 4,
            ImageUrl = imageUrlBase
        };
        cards.Add(C5);
        builder.Entity<Card>().HasData(C5);
        Card C6 = new Card
        {
            Id = 6,
            Name = "Eraser Edith",
            Attack = 2,
            Defense = 6,
            ImageUrl = imageUrlBase
        };
        cards.Add(C6);
        builder.Entity<Card>().HasData(C6);
        Card C7 = new Card
        {
            Id = 7,
            Name = "Crayon Carla",
            Attack = 5,
            Defense = 3,
            ImageUrl = imageUrlBase
        };
        cards.Add(C7);
        builder.Entity<Card>().HasData(C7);
        Card C8 = new Card
        {
            Id = 8,
            Name = "Scribble Sam",
            Attack = 4,
            Defense = 5,
            ImageUrl = imageUrlBase
        };
        cards.Add(C8);
        builder.Entity<Card>().HasData(C8);
        Card C9 = new Card
        {
            Id = 9,
            Name = "Inkwell Ivan",
            Attack = 6,
            Defense = 2,
            ImageUrl = imageUrlBase
        };
        cards.Add(C9);
        builder.Entity<Card>().HasData(C9);
        Card C10 = new Card
        {
            Id = 10,
            Name = "Paintbrush Penny",
            Attack = 5,
            Defense = 4,
            ImageUrl = imageUrlBase
        };
        cards.Add(C10);
        builder.Entity<Card>().HasData(C10);

        Card C11 = new Card
        {
            Id = 11,
            Name = "Sketchpad Sally",
            Attack = 4,
            Defense = 6,
            ImageUrl = imageUrlBase
        };
        cards.Add(C11);
        builder.Entity<Card>().HasData(C11);

        Card C12 = new Card
        {
            Id = 12,
            Name = "Chalkboard Chuck",
            Attack = 6,
            Defense = 3,
            ImageUrl = imageUrlBase
        };
        cards.Add(C12);
        builder.Entity<Card>().HasData(C12);

        Card C13 = new Card
        {
            Id = 13,
            Name = "Notebook Ned",
            Attack = 5,
            Defense = 5,
            ImageUrl = imageUrlBase
        };
        cards.Add(C13);
        builder.Entity<Card>().HasData(C13);

        Card C14 = new Card
        {
            Id = 14,
            Name = "Penelope Pencil",
            Attack = 7,
            Defense = 2,
            ImageUrl = imageUrlBase
        };
        cards.Add(C14);
        builder.Entity<Card>().HasData(C14);

        Card C15 = new Card
        {
            Id = 15,
            Name = "Highlighter Hank",
            Attack = 3,
            Defense = 7,
            ImageUrl = imageUrlBase
        };
        cards.Add(C15);
        builder.Entity<Card>().HasData(C15);

        Card C16 = new Card
        {
            Id = 16,
            Name = "Marker Mary",
            Attack = 6,
            Defense = 4,
            ImageUrl = imageUrlBase
        };
        cards.Add(C16);
        builder.Entity<Card>().HasData(C16);

        Card C17 = new Card
        {
            Id = 17,
            Name = "Crayola Carl",
            Attack = 7,
            Defense = 3,
            ImageUrl = imageUrlBase
        };
        cards.Add(C17);
        builder.Entity<Card>().HasData(C17);

        Card C18 = new Card
        {
            Id = 18,
            Name = "Paperclip Paula",
            Attack = 5,
            Defense = 6,
            ImageUrl = imageUrlBase
        };
        cards.Add(C18);
        builder.Entity<Card>().HasData(C18);

        Card C19 = new Card
        {
            Id = 19,
            Name = "Paint Paddy",
            Attack = 8,
            Defense = 2,
            ImageUrl = imageUrlBase
        };
        cards.Add(C19);
        builder.Entity<Card>().HasData(C19);

        Card C20 = new Card
        {
            Id = 20,
            Name = "Pencil Shavings Pete",
            Attack = 6,
            Defense = 5,
            ImageUrl = imageUrlBase
        };
        cards.Add(C20);
        builder.Entity<Card>().HasData(C20);

        Card C21 = new Card
        {
            Id = 21,
            Name = "Sticky Stan",
            Attack = 7,
            Defense = 4,
            ImageUrl = imageUrlBase
        };
        cards.Add(C21);
        builder.Entity<Card>().HasData(C21);

        Card C22 = new Card
        {
            Id = 22,
            Name = "Charcoal Charlie",
            Attack = 5,
            Defense = 7,
            ImageUrl = imageUrlBase
        };
        cards.Add(C22);
        builder.Entity<Card>().HasData(C22);

        Card C23 = new Card
        {
            Id = 23,
            Name = "Watercolor Wendy",
            Attack = 8,
            Defense = 3,
            ImageUrl = imageUrlBase
        };
        cards.Add(C23);
        builder.Entity<Card>().HasData(C23);

        Card C24 = new Card
        {
            Id = 24,
            Name = "Notebook Nikki",
            Attack = 6,
            Defense = 6,
            ImageUrl = imageUrlBase
        };
        cards.Add(C24);
        builder.Entity<Card>().HasData(C24);

        Card C25 = new Card
        {
            Id = 25,
            Name = "Etch-a-Sketch Eddie",
            Attack = 9,
            Defense = 2,
            ImageUrl = imageUrlBase
        };
        cards.Add(C25);
        builder.Entity<Card>().HasData(C25);

        Card C26 = new Card
        {
            Id = 26,
            Name = "Glitter Glenda",
            Attack = 4,
            Defense = 8,
            ImageUrl = imageUrlBase
        };
        cards.Add(C26);
        builder.Entity<Card>().HasData(C26);

        Card C27 = new Card
        {
            Id = 27,
            Name = "Crayonbox Casey",
            Attack = 7,
            Defense = 5,
            ImageUrl = imageUrlBase
        };
        cards.Add(C27);
        builder.Entity<Card>().HasData(C27);

        Card C28 = new Card
        {
            Id = 28,
            Name = "Sketchbook Simon",
            Attack = 8,
            Defense = 4,
            ImageUrl = imageUrlBase
        };
        cards.Add(C28);
        builder.Entity<Card>().HasData(C28);

        Card C29 = new Card
        {
            Id = 29,
            Name = "Quill Quentin",
            Attack = 6,
            Defense = 7,
            ImageUrl = imageUrlBase
        };
        cards.Add(C29);
        builder.Entity<Card>().HasData(C29);

        Card C30 = new Card
        {
            Id = 30,
            Name = "Sidewalk Chalk Chloe",
            Attack = 9,
            Defense = 3,
            ImageUrl = imageUrlBase
        };
        cards.Add(C30);
        builder.Entity<Card>().HasData(C30);

        Card C31 = new Card
        {
            Id = 31,
            Name = "Canvas Cathy",
            Attack = 7,
            Defense = 6,
            ImageUrl = imageUrlBase
        };
        cards.Add(C31);
        builder.Entity<Card>().HasData(C31);

        Card C32 = new Card
        {
            Id = 32,
            Name = "Fountain Pen Fred",
            Attack = 8,
            Defense = 5,
            ImageUrl = imageUrlBase
        };
        cards.Add(C32);
        builder.Entity<Card>().HasData(C32);

        Card C33 = new Card
        {
            Id = 33,
            Name = "Sticky Note Steve",
            Attack = 6,
            Defense = 8,
            ImageUrl = imageUrlBase
        };
        cards.Add(C33);
        builder.Entity<Card>().HasData(C33);

        Card C34 = new Card
        {
            Id = 34,
            Name = "Doodle Pad Donna",
            Attack = 9,
            Defense = 4,
            ImageUrl = imageUrlBase
        };
        cards.Add(C34);
        builder.Entity<Card>().HasData(C34);

        Card C35 = new Card
        {
            Id = 35,
            Name = "Paint Can Patrick",
            Attack = 7,
            Defense = 7,
            ImageUrl = imageUrlBase
        };
        cards.Add(C35);
        builder.Entity<Card>().HasData(C35);

        Card C36 = new Card
        {
            Id = 36,
            Name = "Marker Maze Max",
            Attack = 5,
            Defense = 9,
            ImageUrl = imageUrlBase
        };
        cards.Add(C36);
        builder.Entity<Card>().HasData(C36);

        Card C37 = new Card
        {
            Id = 37,
            Name = "Etch-a-Sketch Emma",
            Attack = 8,
            Defense = 6,
            ImageUrl = imageUrlBase
        };
        cards.Add(C37);
        builder.Entity<Card>().HasData(C37);

        Card C38 = new Card
        {
            Id = 38,
            Name = "Charcoal Chip",
            Attack = 9,
            Defense = 5,
            ImageUrl = imageUrlBase
        };
        cards.Add(C38);
        builder.Entity<Card>().HasData(C38);

        Card C39 = new Card
        {
            Id = 39,
            Name = "Graphite Gabby",
            Attack = 6,
            Defense = 9,
            ImageUrl = imageUrlBase
        };
        cards.Add(C39);
        builder.Entity<Card>().HasData(C39);

        Card C40 = new Card
        {
            Id = 40,
            Name = "Inkwell Ike",
            Attack = 10,
            Defense = 4,
            ImageUrl = imageUrlBase
        };
        cards.Add(C40);
        builder.Entity<Card>().HasData(C40);

        Card C41 = new Card
        {
            Id = 41,
            Name = "Sketchbook Skyler",
            Attack = 7,
            Defense = 8,
            ImageUrl = imageUrlBase
        };
        cards.Add(C41);
        builder.Entity<Card>().HasData(C41);

        Card C42 = new Card
        {
            Id = 42,
            Name = "Chalky Charles",
            Attack = 10,
            Defense = 5,
            ImageUrl = imageUrlBase
        };
        cards.Add(C42);
        builder.Entity<Card>().HasData(C42);

        Card C43 = new Card
        {
            Id = 43,
            Name = "Color Wheel Casey",
            Attack = 8,
            Defense = 7,
            ImageUrl = imageUrlBase
        };
        cards.Add(C43);
        builder.Entity<Card>().HasData(C43);

        Card C44 = new Card
        {
            Id = 44,
            Name = "Canvas Cleo",
            Attack = 9,
            Defense = 6,
            ImageUrl = imageUrlBase
        };
        cards.Add(C44);
        builder.Entity<Card>().HasData(C44);

        Card C45 = new Card
        {
            Id = 45,
            Name = "Sticker Sue",
            Attack = 6,
            Defense = 10,
            ImageUrl = imageUrlBase
        };
        cards.Add(C45);
        builder.Entity<Card>().HasData(C45);

        Card C46 = new Card
        {
            Id = 46,
            Name = "Glue Gun Gary",
            Attack = 7,
            Defense = 9,
            ImageUrl = imageUrlBase
        };
        cards.Add(C46);
        builder.Entity<Card>().HasData(C46);

        Card C47 = new Card
        {
            Id = 47,
            Name = "Markerboard Molly",
            Attack = 10,
            Defense = 6,
            ImageUrl = imageUrlBase
        };
        cards.Add(C47);
        builder.Entity<Card>().HasData(C47);

        Card C48 = new Card
        {
            Id = 48,
            Name = "Pixel Pete",
            Attack = 8,
            Defense = 8,
            ImageUrl = imageUrlBase
        };
        cards.Add(C48);
        builder.Entity<Card>().HasData(C48);

        Card C49 = new Card
        {
            Id = 49,
            Name = "Lithography Lily",
            Attack = 9,
            Defense = 7,
            ImageUrl = imageUrlBase
        };
        cards.Add(C49);
        builder.Entity<Card>().HasData(C49);

        Card C50 = new Card
        {
            Id = 50,
            Name = "Silkscreening Simon",
            Attack = 10,
            Defense = 7,
            ImageUrl = imageUrlBase
        };
        cards.Add(C50);
        builder.Entity<Card>().HasData(C50);


        for (int i = 1; i <= 10; i++){
            StartingCards startingCards = new StartingCards
                {
                    Id = i,
                    CardId = i
                };
            builder.Entity<StartingCards>().HasData(startingCards);
        }
        StartingCards startingCards2 = new StartingCards
        {
            Id = 11,
            CardId = C1.Id
        };
        builder.Entity<StartingCards>().HasData(startingCards2);

        List<StoreCard> StoreCards = new List<StoreCard>();

        StoreCard Sc1 = new StoreCard
        {
            Id = 1,
            BuyAmount = 500,
            SellAmount = 200,
            CardId = C1.Id,
        };
        StoreCards.Add(Sc1);
        builder.Entity<StoreCard>().HasData(Sc1);

        StoreCard Sc2 = new StoreCard
        {
            Id = 2,
            BuyAmount = 500,
            SellAmount = 200,
            CardId = C2.Id,
            
        };
        StoreCards.Add(Sc2);
        builder.Entity<StoreCard>().HasData(Sc2);
        
        StoreCard Sc3 = new StoreCard
        {
            Id = 3,
            BuyAmount = 500,
            SellAmount = 200,
            CardId = C3.Id,
        };
        StoreCards.Add(Sc3);
        builder.Entity<StoreCard>().HasData(Sc3);
    }



    public DbSet<Card> Cards { get; set; } = default!;

    public DbSet<StartingCards> StartingCards { get; set; } = default!;

    public DbSet<Player> Players { get; set; } = default!;

    public DbSet<Match> Matches { get; set; } = default!;

    public DbSet<MatchPlayerData> MatchPlayersData { get; set; } = default!;

    public DbSet<StoreCard> StoreCards { get; set; } = default!;

}

