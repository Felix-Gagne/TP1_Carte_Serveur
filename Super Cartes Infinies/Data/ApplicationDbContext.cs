using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using NuGet.Protocol.Plugins;
using Super_Cartes_Infinies.Models;
using System.Drawing;
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
        const String serverURL = "https://localhost:7219/images/";
        const String iconPower = "https://static.thenounproject.com/png/1776468-200.png";

        #region Powers

        List<Power> powers = new List<Power>();

        Power Charge = new Power
        {
            Id = Power.CHARGE_ID,
            Name = "Charge",
            Icon = iconPower
        };
        powers.Add( Charge );
        builder.Entity<Power>().HasData(Charge);

        Power FirstStrike = new Power
        {
            Id = Power.FIRSTSTRIKE_ID,
            Name = "First Strike",
            Icon = iconPower
        };
        powers.Add( FirstStrike );
        builder.Entity<Power>().HasData(FirstStrike);

        Power Thorns = new Power
        {
            Id = Power.THORNS_ID,
            Name = "Thorns",
            Icon = iconPower
        };
        powers.Add( Thorns );
        builder.Entity<Power>().HasData(Thorns);

        Power Heal = new Power
        {
            Id = Power.HEAL_ID,
            Name = "Heal",
            Icon = iconPower
        };
        powers.Add(Heal);
        builder.Entity<Power>().HasData(Heal);

        Power Explosion = new Power
        {
            Id = Power.EXPLOSION_ID,
            Name = "Explosion",
            Icon = iconPower
        };
        powers.Add(Explosion);
        builder.Entity <Power>().HasData(Explosion);

        Power Greed = new Power
        {
            Id = Power.GREED_ID,
            Name = "Greed",
            Icon = iconPower
        };
        powers.Add(Greed);
        builder.Entity<Power>().HasData(Greed);

        #endregion

        #region SeedCarte


        List<Card> cards = new List<Card>();

        Card C1 = new Card
        {
            Id = 1,
            Name = "Stickly Steve",
            Attack = 3,
            Defense = 3,
            ManaCost = 2,
            ImageUrl = serverURL + "Stickly_Steve.png"
        };
        cards.Add( C1 );
        builder.Entity<Card>().HasData(C1);
        Card C2 = new Card
        {
            Id = 2,
            Name = "Sketchy Sarah",
            Attack = 2,
            Defense = 4,
            ManaCost = 1,
            ImageUrl = serverURL + "Sketchy_Sarah.png"
        };
        cards.Add(C2);
        builder.Entity<Card>().HasData(C2);
        Card C3 = new Card
        {
            Id = 3,
            Name = "Doodle Dave",
            Attack = 4,
            Defense = 2,
            ManaCost = 2,
            ImageUrl = serverURL + "Doodle_Dave.png"
        };
        cards.Add(C3);
        builder.Entity<Card>().HasData(C3);
        Card C4 = new Card
        {
            Id = 4,
            Name = "Pencil Pete",
            Attack = 3,
            Defense = 5,
            ManaCost = 3,
            ImageUrl = serverURL + "Pencil_Pete.png"
        };
        cards.Add(C4);
        builder.Entity<Card>().HasData(C4);
        Card C5 = new Card
        {
            Id = 5,
            Name = "Marker Mike",
            Attack = 4,
            Defense = 4,
            ManaCost = 3,
            ImageUrl = serverURL + "Marker_Mike.png"
        };
        cards.Add(C5);
        builder.Entity<Card>().HasData(C5);
        Card C6 = new Card
        {
            Id = 6,
            Name = "Eraser Edith",
            Attack = 2,
            Defense = 6,
            ManaCost = 2,
            ImageUrl = serverURL + "Eraser_Edith.png"
        };
        cards.Add(C6);
        builder.Entity<Card>().HasData(C6);
        Card C7 = new Card
        {
            Id = 7,
            Name = "Crayon Carla",
            Attack = 5,
            Defense = 3,
            ManaCost = 4,
            ImageUrl = serverURL + "Crayon_Carla.png"
        };
        cards.Add(C7);
        builder.Entity<Card>().HasData(C7);
        Card C8 = new Card
        {
            Id = 8,
            Name = "Scribble Sam",
            Attack = 4,
            Defense = 5,
            ManaCost = 3,
            ImageUrl = serverURL + "Scribble_Sam.png"
        };
        cards.Add(C8);
        builder.Entity<Card>().HasData(C8);
        Card C9 = new Card
        {
            Id = 9,
            Name = "Inkwell Ivan",
            Attack = 6,
            Defense = 2,
            ManaCost = 2,
            ImageUrl = serverURL + "Inkwell_Ivan.png"
        };
        cards.Add(C9);
        builder.Entity<Card>().HasData(C9);
        Card C10 = new Card
        {
            Id = 10,
            Name = "Paintbrush Penny",
            Attack = 5,
            Defense = 4,
            ManaCost = 3,
            ImageUrl = serverURL + "Paintbrush_Penny.png"
        };
        cards.Add(C10);
        builder.Entity<Card>().HasData(C10);

        Card C11 = new Card
        {
            Id = 11,
            Name = "Sketchpad Sally",
            Attack = 4,
            Defense = 6,
            ManaCost = 3,
            ImageUrl = serverURL + "Sketchpad_Sally.png"
        };
        cards.Add(C11);
        builder.Entity<Card>().HasData(C11);

        Card C12 = new Card
        {
            Id = 12,
            Name = "Chalkboard Chuck",
            Attack = 6,
            Defense = 3,
            ManaCost = 3,
            ImageUrl = serverURL + "Chalkboard_Chuck.png"
        };
        cards.Add(C12);
        builder.Entity<Card>().HasData(C12);

        Card C13 = new Card
        {
            Id = 13,
            Name = "Notebook Ned",
            Attack = 5,
            Defense = 5,
            ManaCost = 3,
            ImageUrl = serverURL + "Notebook_Ned.png"
        };
        cards.Add(C13);
        builder.Entity<Card>().HasData(C13);

        Card C14 = new Card
        {
            Id = 14,
            Name = "Penelope Pencil",
            Attack = 7,
            Defense = 2,
            ManaCost = 2,
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
            ManaCost = 4,
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
            ManaCost = 4,
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
            ManaCost = 2,
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
            ManaCost = 5,
            ImageUrl = serverURL + "Paperclip_Paula.png"
        };
        cards.Add(C18);
        builder.Entity<Card>().HasData(C18);

        Card C19 = new Card
        {
            Id = 19,
            Name = "Paint Paddy",
            Attack = 8,
            Defense = 2,
            ManaCost = 3,
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
            ManaCost = 4,
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
            ManaCost = 3,
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
            ManaCost = 7,
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
            ManaCost = 2,
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
            ManaCost = 5,
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
            ManaCost = 3,
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
            ManaCost = 4,
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
            ManaCost = 5,
            ImageUrl = serverURL + "Crayonbox_Casey.png"
        };
        cards.Add(C27);
        builder.Entity<Card>().HasData(C27);

        Card C28 = new Card
        {
            Id = 28,
            Name = "Sketchbook Simon",
            Attack = 8,
            Defense = 4,
            ManaCost = 5,
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
            ManaCost = 5,
            ImageUrl = serverURL + "Quill_Quentin.png"
        };
        cards.Add(C29);
        builder.Entity<Card>().HasData(C29);

        Card C30 = new Card
        {
            Id = 30,
            Name = "Sidewalk Chalk Chloe",
            Attack = 9,
            Defense = 3,
            ManaCost = 4,
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
            ManaCost = 4,
            ImageUrl = serverURL + "Canvas_Cathy.png"
        };
        cards.Add(C31);
        builder.Entity<Card>().HasData(C31);

        Card C32 = new Card
        {
            Id = 32,
            Name = "Fountain Pen Fred",
            Attack = 11,
            Defense = 10,
            ManaCost = 8,
            ImageUrl = serverURL + "Fountain_Pen_Fred.png"
        };
        cards.Add(C32);
        builder.Entity<Card>().HasData(C32);

        Card C33 = new Card
        {
            Id = 33,
            Name = "Sticky Note Steve",
            Attack = 6,
            Defense = 8,
            ManaCost = 6,
            ImageUrl = serverURL + "Sticky_Note_Steve.png"
        };
        cards.Add(C33);
        builder.Entity<Card>().HasData(C33);

        Card C34 = new Card
        {
            Id = 34,
            Name = "Doodle Pad Donna",
            Attack = 9,
            Defense = 4,
            ManaCost = 4,
            ImageUrl = imageUrlBase
        };
        cards.Add(C34);
        builder.Entity<Card>().HasData(C34);

        Card C35 = new Card
        {
            Id = 35,
            Name = "Spray Paint Patrick",
            Attack = 7,
            Defense = 7,
            ManaCost = 7,
            ImageUrl = serverURL + "Spray_Paint_Patrick.png"
        };
        cards.Add(C35);
        builder.Entity<Card>().HasData(C35);

        Card C36 = new Card
        {
            Id = 36,
            Name = "Marker Maze Max",
            Attack = 5,
            Defense = 9,
            ManaCost = 7,
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
            ManaCost = 4,
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
            ManaCost = 5,
            ImageUrl = imageUrlBase
        };
        cards.Add(C38);
        builder.Entity<Card>().HasData(C38);

        Card C39 = new Card
        {
            Id = 39,
            Name = "Graphite Gabby",
            Attack = 8,
            Defense = 9,
            ManaCost = 10,
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
            ManaCost = 5,
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
            ManaCost = 5,
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
            ManaCost = 7,
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
            ManaCost = 6,
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
            ManaCost = 5,
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
            ManaCost = 8,
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
            ManaCost = 5,
            ImageUrl = serverURL + "Glue_Gun_Garry.png"
        };
        cards.Add(C46);
        builder.Entity<Card>().HasData(C46);

        Card C47 = new Card
        {
            Id = 47,
            Name = "Markerboard Molly",
            Attack = 10,
            Defense = 6,
            ManaCost = 7,
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
            ManaCost = 7,
            ImageUrl = serverURL + "Pixel_Pete.png"
        };
        cards.Add(C48);
        builder.Entity<Card>().HasData(C48);

        Card C49 = new Card
        {
            Id = 49,
            Name = "Lithography Lily",
            Attack = 15,
            Defense = 15,
            ManaCost = 20,
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
            ManaCost = 8,
            ImageUrl = imageUrlBase
        };
        cards.Add(C50);
        builder.Entity<Card>().HasData(C50);

        foreach (var card in cards)
        {
            card.prixVente = 250;
        }

        #endregion

        #region Card Rarety

        foreach (var card in cards)
        {
            if(card.Id <= 20)
            {
                card.Rarity = Rarity.Common;

            } else if(card.Id <= 35)
            {
                card.Rarity = Rarity.Rare;

            }else if(card.Id <= 45)
            {
                card.Rarity = Rarity.Epic;

            }else if (card.Id <= 50)
            {
                card.Rarity = Rarity.Legendary;
            }
        }

        #endregion

        #region CardPower

        List<CardPower> cardPowers = new List<CardPower>();

        CardPower SticklySteveCharge = new CardPower
        {
            Id = 1,
            CardId = C1.Id,
            PowerId = Power.CHARGE_ID,
            value = 0
        };
        cardPowers.Add(SticklySteveCharge);
        builder.Entity<CardPower>().HasData(SticklySteveCharge);

        CardPower DoodleDaveFirstStrike = new CardPower
        {
            Id = 2,
            CardId = C3.Id,
            PowerId = Power.FIRSTSTRIKE_ID,
            value = 0
        };
        cardPowers.Add(DoodleDaveFirstStrike);
        builder.Entity<CardPower>().HasData(DoodleDaveFirstStrike);

        CardPower MarkerMikeHeal1 = new CardPower
        {
            Id = 3,
            CardId = C5.Id,
            PowerId = Power.HEAL_ID,
            value = 1
        };
        cardPowers.Add(MarkerMikeHeal1);
        builder.Entity<CardPower>().HasData(MarkerMikeHeal1);

        CardPower EraserEdithThorns2 = new CardPower
        {
            Id = 4,
            CardId = C6.Id,
            PowerId = Power.THORNS_ID,
            value = 2
        };
        cardPowers.Add(EraserEdithThorns2);
        builder.Entity<CardPower>().HasData(EraserEdithThorns2);

        CardPower CrayonCarlaCharge = new CardPower
        {
            Id = 5,
            CardId = C7.Id,
            PowerId = Power.CHARGE_ID,
            value = 0
        };
        cardPowers.Add(CrayonCarlaCharge);
        builder.Entity<CardPower>().HasData(CrayonCarlaCharge);

        CardPower CrayonCarlaGreed = new CardPower
        {
            Id = 6,
            CardId = C7.Id,
            PowerId = Power.GREED_ID,
            value = 0
        };
        cardPowers.Add(CrayonCarlaGreed);
        builder.Entity<CardPower>().HasData(CrayonCarlaGreed);

        
        CardPower InkwellIvanExplosion = new CardPower
        {
             Id = 7,
             CardId = C9.Id,
             PowerId = Power.EXPLOSION_ID,
             value = 0
        };
        cardPowers.Add(InkwellIvanExplosion);
        builder.Entity<CardPower>().HasData(InkwellIvanExplosion);

        CardPower SketchpadSallyThorns3 = new CardPower
        {
            Id = 8,
            CardId = C11.Id,
            PowerId = Power.THORNS_ID,
            value = 3
        };
        cardPowers.Add(SketchpadSallyThorns3);
        builder.Entity<CardPower>().HasData(SketchpadSallyThorns3);

        CardPower ChalkboardChuckHeal4 = new CardPower
        {
            Id = 9,
            CardId = C12.Id,
            PowerId = Power.HEAL_ID,
            value = 4
        };
        cardPowers.Add(ChalkboardChuckHeal4);
        builder.Entity<CardPower>().HasData(ChalkboardChuckHeal4);

        CardPower NotebookNedFirstStrike = new CardPower
        {
            Id = 10,
            CardId = C13.Id,
            PowerId = Power.FIRSTSTRIKE_ID,
            value = 0
        };
        cardPowers.Add(NotebookNedFirstStrike);
        builder.Entity<CardPower>().HasData(NotebookNedFirstStrike);

        CardPower NotebookNedGreed = new CardPower
        {
            Id = 11,
            CardId = C13.Id,
            PowerId = Power.GREED_ID,
            value = 0
        };
        cardPowers.Add(NotebookNedGreed);
        builder.Entity<CardPower>().HasData(NotebookNedGreed);

        CardPower HighlighterHankThorns2 = new CardPower
        {
            Id = 12,
            CardId = C15.Id,
            PowerId = Power.THORNS_ID,
            value = 2
        };
        cardPowers.Add(HighlighterHankThorns2);
        builder.Entity<CardPower>().HasData(HighlighterHankThorns2);

        CardPower HighlighterHankHeal2 = new CardPower
        {
            Id = 13,
            CardId = C15.Id,
            PowerId = Power.HEAL_ID,
            value = 2
        };
        cardPowers.Add(HighlighterHankHeal2);
        builder.Entity<CardPower>().HasData(HighlighterHankHeal2);

        CardPower PaperclipPaulaThorns3 = new CardPower
        {
            Id = 14,
            CardId = C18.Id,
            PowerId = Power.THORNS_ID,
            value = 3
        };
        cardPowers.Add(PaperclipPaulaThorns3);
        builder.Entity<CardPower>().HasData(PaperclipPaulaThorns3);

        CardPower CharcoaCharlieThorns10 = new CardPower
        {
            Id = 15,
            CardId = C22.Id,
            PowerId = Power.THORNS_ID,
            value = 10
        };
        cardPowers.Add(CharcoaCharlieThorns10);
        builder.Entity<CardPower>().HasData(CharcoaCharlieThorns10);

        CardPower NotebookNikkiFirstStrike = new CardPower
        {
            Id = 16,
            CardId = C24.Id,
            PowerId = Power.FIRSTSTRIKE_ID,
            value = 0
        };
        cardPowers.Add(NotebookNikkiFirstStrike);
        builder.Entity<CardPower>().HasData(NotebookNikkiFirstStrike);

        CardPower FountainPenFredThorns5 = new CardPower
        {
            Id = 17,
            CardId = C32.Id,
            PowerId = Power.THORNS_ID,
            value = 5
        };
        cardPowers.Add(FountainPenFredThorns5);
        builder.Entity<CardPower>().HasData(FountainPenFredThorns5);

        CardPower FountainPenFredFirstStrike = new CardPower
        {
            Id = 18,
            CardId = C32.Id,
            PowerId = Power.FIRSTSTRIKE_ID,
            value = 0
        };
        cardPowers.Add(FountainPenFredFirstStrike);
        builder.Entity<CardPower>().HasData(FountainPenFredFirstStrike);

        CardPower StickyNoteSteveThorns3 = new CardPower
        {
            Id = 19,
            CardId = C33.Id,
            PowerId = Power.THORNS_ID,
            value = 3
        };
        cardPowers.Add(StickyNoteSteveThorns3);
        builder.Entity<CardPower>().HasData(StickyNoteSteveThorns3);


        CardPower PaintCanPatrickExplosion = new CardPower
        {
            Id = 20,
            CardId = C35.Id,
            PowerId = Power.EXPLOSION_ID,
            value = 0
        };
        cardPowers.Add(PaintCanPatrickExplosion);
        builder.Entity<CardPower>().HasData(PaintCanPatrickExplosion);

        CardPower PaintCanPatrickHeal2 = new CardPower
        {
            Id = 21,
            CardId = C35.Id,
            PowerId = Power.HEAL_ID,
            value = 2
        };
        cardPowers.Add(PaintCanPatrickHeal2);
        builder.Entity<CardPower>().HasData(PaintCanPatrickHeal2);

        CardPower MarkerMazeMaxGreed = new CardPower
        {
            Id = 22,
            CardId = C36.Id,
            PowerId = Power.GREED_ID,
            value = 0
        };
        cardPowers.Add(MarkerMazeMaxGreed);
        builder.Entity<CardPower>().HasData(MarkerMazeMaxGreed);

        CardPower MarkerMazeMaxHeal2 = new CardPower
        {
            Id = 23,
            CardId = C36.Id,
            PowerId = Power.HEAL_ID,
            value = 2
        };
        cardPowers.Add(MarkerMazeMaxHeal2);
        builder.Entity<CardPower>().HasData(MarkerMazeMaxHeal2);

        CardPower GraphiteGabbyExplosion = new CardPower
        {
            Id = 24,
            CardId = C39.Id,
            PowerId = Power.EXPLOSION_ID,
            value = 0
        };
        cardPowers.Add(GraphiteGabbyExplosion);
        builder.Entity<CardPower>().HasData(GraphiteGabbyExplosion);

        CardPower GraphiteGabbyCharge = new CardPower
        {
            Id = 25,
            CardId = C39.Id,
            PowerId = Power.CHARGE_ID,
            value = 0
        };
        cardPowers.Add(GraphiteGabbyCharge);
        builder.Entity<CardPower>().HasData(GraphiteGabbyCharge);

        CardPower ChalkyCharlesGreed = new CardPower
        {
            Id = 26,
            CardId = C42.Id,
            PowerId = Power.GREED_ID,
            value = 0
        };
        cardPowers.Add(ChalkyCharlesGreed);
        builder.Entity<CardPower>().HasData(ChalkyCharlesGreed);

        CardPower ChalkyCharlesExplosion = new CardPower
        {
            Id = 27,
            CardId = C42.Id,
            PowerId = Power.EXPLOSION_ID,
            value = 0
        };
        cardPowers.Add(ChalkyCharlesExplosion);
        builder.Entity<CardPower>().HasData(ChalkyCharlesExplosion);

        CardPower StickerSueThorns5 = new CardPower
        {
            Id = 28,
            CardId = C45.Id,
            PowerId = Power.THORNS_ID,
            value = 5
        };
        cardPowers.Add(StickerSueThorns5);
        builder.Entity<CardPower>().HasData(StickerSueThorns5);

        CardPower StickerSueCharge = new CardPower
        {
            Id = 29,
            CardId = C45.Id,
            PowerId = Power.CHARGE_ID,
            value = 0
        };
        cardPowers.Add(StickerSueCharge);
        builder.Entity<CardPower>().HasData(StickerSueCharge);

        CardPower LithographyLilyFirstStrike = new CardPower
        {
            Id = 30,
            CardId = C49.Id,
            PowerId = Power.FIRSTSTRIKE_ID,
            value = 0
        };
        cardPowers.Add(LithographyLilyFirstStrike);
        builder.Entity<CardPower>().HasData(LithographyLilyFirstStrike);

        CardPower LithographyLilyCharge = new CardPower
        {
            Id = 31,
            CardId = C49.Id,
            PowerId = Power.CHARGE_ID,
            value = 0
        };
        cardPowers.Add(LithographyLilyCharge);
        builder.Entity<CardPower>().HasData(LithographyLilyCharge);

        CardPower LithographyLilyHeal5 = new CardPower
        {
            Id = 32,
            CardId = C49.Id,
            PowerId = Power.HEAL_ID,
            value = 5
        };
        cardPowers.Add(LithographyLilyHeal5);
        builder.Entity<CardPower>().HasData(LithographyLilyHeal5);

        #endregion

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

        //Store Cards
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

        StoreCard Sc15 = new StoreCard
        {
            Id = 15,
            BuyAmount = 250,
            SellAmount = 100,
            CardId = C15.Id,
        };
        StoreCards.Add(Sc15);
        builder.Entity<StoreCard>().HasData(Sc15);

        //Packs
        List<Pack> Packs = new List<Pack>();

        builder.Entity<Pack>()
        .HasMany(p => p.Probabilities)
        .WithOne(p => p.Pack)
        .HasForeignKey(p => p.PackId);

        //Pack 1
        Pack pack1 = new Pack
        {
            Id = 1,
            Name = "Pack Basic",
            Price = 100,
            ImageURL = serverURL + "BASIC_PACK.png",
            NbCards = 3,
            BaseRarity = Rarity.Common
        };
        Packs.Add(pack1);
        builder.Entity<Pack>().HasData(pack1);

        Probability probPack1 = new Probability
        {
            Id = 1,
            value = 0.3,
            rarity = Rarity.Rare,
            baseQty = 0,
            PackId = pack1.Id,
        };
        builder.Entity<Probability>().HasData(probPack1);


        //Pack 2
        Pack pack2 = new Pack
        {
            Id = 2,
            Name = "Pack Normal",
            Price = 300,
            ImageURL = serverURL + "NORMAL_PACK.png",
            NbCards = 4,
            BaseRarity = Rarity.Common
        };
        Packs.Add(pack2);
        builder.Entity<Pack>().HasData(pack2);

        Probability probPack2A = new Probability
        {
            Id = 2,
            value = 0.3,
            rarity = Rarity.Rare,
            baseQty = 1,
            PackId = pack2.Id,
        };
        builder.Entity<Probability>().HasData(probPack2A);
        Probability probPack2B = new Probability
        {
            Id = 3,
            value = 0.1,
            rarity = Rarity.Epic,
            baseQty = 0,
            PackId= pack2.Id,
        };
        builder.Entity<Probability>().HasData(probPack2B);
        Probability probPack2C = new Probability
        {
            Id = 4,
            value = 0.02,
            rarity = Rarity.Legendary,
            baseQty = 0,
            PackId= pack2.Id,
        };
        builder.Entity<Probability>().HasData(probPack2C);


        //Pack 3
        Pack pack3 = new Pack
        {
            Id = 3,
            Name = "Pack Super",
            Price = 500,
            ImageURL = serverURL + "SUPER_PACK.png",
            NbCards = 5,
            BaseRarity = Rarity.Rare
        };
        Packs.Add(pack3);
        builder.Entity<Pack>().HasData(pack3);

        Probability probPack3A = new Probability
        {
            Id = 5,
            value = 0.25,
            rarity = Rarity.Epic,
            baseQty = 1,
            PackId = pack3.Id,
        };
        builder.Entity<Probability>().HasData(probPack3A);
        Probability probPack3B = new Probability
        {
            Id = 6,
            value = 0.02,
            rarity = Rarity.Legendary,
            baseQty = 0,
            PackId= pack3.Id
        };
        builder.Entity<Probability>().HasData(probPack3B);
    }

    

    public DbSet<Card> Cards { get; set; } = default!;

    public DbSet<Power> Powers { get; set; } = default!;

    public DbSet<CardPower> CardPowers { get; set; } = default!;

    public DbSet<StartingCards> StartingCards { get; set; } = default!;

    public DbSet<Player> Players { get; set; } = default!;

    public DbSet<Match> Matches { get; set; } = default!;

    public DbSet<MatchPlayerData> MatchPlayersData { get; set; } = default!;

    public DbSet<StoreCard> StoreCards { get; set; } = default!;

    public DbSet<OwnedCard> OwnedCards { get; set;} = default!;

    public DbSet<Deck> Decks { get; set; } = default!;

    public DbSet<Pack> Packs { get; set; } = default;
    public DbSet<MatchTask> MatchTasks { get; set; } = default!;

}

