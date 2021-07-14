using System;
using System.Collections.Generic;
using System.Reflection;
using Films.DAL.MsSqlServer.Models;
using Microsoft.EntityFrameworkCore;

namespace Films.DAL.MsSqlServer.DataAccess
{
    public class FilmsDbContext : DbContext
    {
        public FilmsDbContext()
        {
        }

        public FilmsDbContext(DbContextOptions<FilmsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actor { get; set; }
        public virtual DbSet<Film> Film { get; set; }
        public virtual DbSet<FilmActor> FilmActor { get; set; }
        public virtual DbSet<FilmGenre> FilmGenre { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            modelBuilder.ApplyConfigurationsFromAssembly(currentAssembly);

            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Actor>()
                .HasData
                (
                    new List<Actor>
                    {
                        new Actor {ActorId = 1, ActorName = "Liam Neeson", ActorBirthday = new DateTime(1952, 07, 07)},
                        new Actor
                        {
                            ActorId = 2, ActorName = "Ewan McGregor", ActorBirthday = new DateTime(1971, 03, 31)
                        },
                        new Actor
                        {
                            ActorId = 3, ActorName = "Natalie Portman", ActorBirthday = new DateTime(1981, 07, 09)
                        },
                        new Actor {ActorId = 4, ActorName = "Jake Lloyd", ActorBirthday = new DateTime(1989, 03, 05)},
                        new Actor
                        {
                            ActorId = 5, ActorName = "Samuel L. Jackson", ActorBirthday = new DateTime(1948, 12, 21)
                        },
                        new Actor {ActorId = 6, ActorName = "Frank Oz", ActorBirthday = new DateTime(1944, 03, 25)},
                        new Actor
                        {
                            ActorId = 7, ActorName = "Ian McDiarmid", ActorBirthday = new DateTime(1944, 03, 11)
                        },
                        new Actor {ActorId = 8, ActorName = "Mark Hamill", ActorBirthday = new DateTime(1951, 09, 25)},
                        new Actor
                        {
                            ActorId = 9, ActorName = "Harrison Ford", ActorBirthday = new DateTime(1942, 07, 13)
                        },
                        new Actor
                        {
                            ActorId = 10, ActorName = "Carrie Fisher", ActorBirthday = new DateTime(1956, 10, 21)
                        },
                        new Actor
                        {
                            ActorId = 11, ActorName = "Alec Guinness", ActorBirthday = new DateTime(1914, 04, 02)
                        },
                        new Actor
                        {
                            ActorId = 12, ActorName = "Peter Mayhew", ActorBirthday = new DateTime(1944, 05, 19)
                        },
                        new Actor
                        {
                            ActorId = 13, ActorName = "David Prowse", ActorBirthday = new DateTime(1935, 08, 01)
                        },
                        new Actor
                        {
                            ActorId = 14, ActorName = "Jeremy Bulloch", ActorBirthday = new DateTime(1945, 02, 16)
                        },
                        new Actor {ActorId = 15, ActorName = "Adam Driver", ActorBirthday = new DateTime(1983, 11, 19)},
                        new Actor
                        {
                            ActorId = 16, ActorName = "Daisy Ridley", ActorBirthday = new DateTime(1992, 04, 10)
                        },
                        new Actor {ActorId = 17, ActorName = "John Boyega", ActorBirthday = new DateTime(1992, 03, 17)},
                        new Actor
                        {
                            ActorId = 18, ActorName = "Vasily Livanov", ActorBirthday = new DateTime(1935, 07, 19)
                        },
                        new Actor
                        {
                            ActorId = 19, ActorName = "Vitaly Solomin", ActorBirthday = new DateTime(1941, 12, 12)
                        },
                        new Actor
                        {
                            ActorId = 20, ActorName = "Rina Zelyonaya", ActorBirthday = new DateTime(1901, 11, 07)
                        }
                    });

            modelBuilder
                .Entity<Film>()
                .HasData
                (
                    new List<Film>
                    {
                        new Film
                        {
                            FilmId = 2, FilmDate = new DateTime(1999, 05, 16),
                            FilmDescription =
                                "After a millennia, an ancient evil returns seeking revenge. Meanwhile, Jedi Knight Qui-Gon Jinn discovers Anakin Skywalker: a young slave boy unusually strong with the Force.",
                            FilmName = "Star Wars: The Phantom Menace"
                        },
                        new Film
                        {
                            FilmId = 3, FilmDate = new DateTime(2002, 05, 16),
                            FilmDescription =
                                "Following an assassination attempt on Senator Padmé Amidala, Jedi Knights Anakin Skywalker and Obi-Wan Kenobi investigate a mysterious plot that could change the galaxy forever.",
                            FilmName = "Star Wars: Attack of the Clones "
                        },
                        new Film
                        {
                            FilmId = 4, FilmDate = new DateTime(2005, 05, 17),
                            FilmDescription =
                                "The evil Darth Sidious enacts his final plan for unlimited power -- and the heroic Jedi Anakin Skywalker must choose a side.",
                            FilmName = "Star Wars: Revenge of the Sith"
                        },
                        new Film
                        {
                            FilmId = 5, FilmDate = new DateTime(1977, 05, 25),
                            FilmDescription =
                                "With the planet-destroying power of the Death Star, the Empire looks to cement its grip on the galaxy. Meanwhile, farm boy Luke Skywalker rises to face his destiny.",
                            FilmName = "Star Wars: A New Hope"
                        },
                        new Film
                        {
                            FilmId = 6, FilmDate = new DateTime(1980, 05, 17),
                            FilmDescription =
                                "While the Death Star has been destroyed, the battle between the Empire and the Rebel Alliance rages on...and the evil Darth Vader continues his relentless search for Luke Skywalker.",
                            FilmName = "Star Wars: The Empire Strikes Back"
                        },
                        new Film
                        {
                            FilmId = 7, FilmDate = new DateTime(1983, 05, 25),
                            FilmDescription =
                                "Luke Skywalker leads a mission to rescue his friend Han Solo from the clutches of Jabba the Hutt, while the Emperor seeks to destroy the Rebellion once and for all with a second dreaded Death Star.",
                            FilmName = "Star Wars: Return of the Jedi"
                        },
                        new Film
                        {
                            FilmId = 8, FilmDate = new DateTime(2015, 12, 17),
                            FilmDescription =
                                "Thirty years after the Battle of Endor, a new threat has risen in the form of the First Order and the villainous Kylo Ren. Meanwhile, Rey, a young scavenger, discovers powers that will change her life -- and possibly save the galaxy.",
                            FilmName = "Star Wars: The Force Awakens"
                        },
                        new Film
                        {
                            FilmId = 10, FilmDate = new DateTime(1980, 03, 22),
                            FilmDescription =
                                "A cycle of Soviet television films from 1979-1986 directed by Igor Maslennikov, a film adaptation of the works of Arthur Conan Doyle about Sherlock Holmes. The cycle consists of five films (11 episodes with a total duration of 766 minutes},.",
                            FilmName = "Sherlock Holmes and Doctor Watson"
                        }
                    }
                );

            modelBuilder
                .Entity<FilmActor>()
                .HasData
                (
                    new List<FilmActor>
                    {
                        new FilmActor
                        {
                            Id = 1, FilmId = 2, ActorId = 1
                        },
                        new FilmActor {Id = 2, FilmId = 2, ActorId = 2},
                        new FilmActor {Id = 3, FilmId = 2, ActorId = 3},
                        new FilmActor {Id = 4, FilmId = 2, ActorId = 4},
                        new FilmActor {Id = 5, FilmId = 2, ActorId = 6},
                        new FilmActor {Id = 6, FilmId = 3, ActorId = 2},
                        new FilmActor {Id = 7, FilmId = 3, ActorId = 3},
                        new FilmActor {Id = 8, FilmId = 3, ActorId = 5},
                        new FilmActor {Id = 9, FilmId = 3, ActorId = 6},
                        new FilmActor {Id = 10, FilmId = 3, ActorId = 7},
                        new FilmActor {Id = 11, FilmId = 4, ActorId = 2},
                        new FilmActor {Id = 12, FilmId = 4, ActorId = 3},
                        new FilmActor {Id = 13, FilmId = 4, ActorId = 7},
                        new FilmActor {Id = 14, FilmId = 4, ActorId = 5},
                        new FilmActor {Id = 15, FilmId = 5, ActorId = 8},
                        new FilmActor {Id = 16, FilmId = 5, ActorId = 9},
                        new FilmActor {Id = 17, FilmId = 5, ActorId = 10},
                        new FilmActor {Id = 18, FilmId = 5, ActorId = 13},
                        new FilmActor {Id = 20, FilmId = 6, ActorId = 8},
                        new FilmActor {Id = 21, FilmId = 6, ActorId = 9},
                        new FilmActor {Id = 22, FilmId = 6, ActorId = 10},
                        new FilmActor {Id = 23, FilmId = 6, ActorId = 13},
                        new FilmActor {Id = 24, FilmId = 6, ActorId = 6},
                        new FilmActor {Id = 25, FilmId = 7, ActorId = 8},
                        new FilmActor {Id = 19, FilmId = 6, ActorId = 6},
                        new FilmActor {Id = 26, FilmId = 7, ActorId = 9},
                        new FilmActor {Id = 27, FilmId = 7, ActorId = 10},
                        new FilmActor {Id = 28, FilmId = 7, ActorId = 7},
                        new FilmActor {Id = 29, FilmId = 7, ActorId = 6},
                        new FilmActor {Id = 30, FilmId = 7, ActorId = 13},
                        new FilmActor {Id = 31, FilmId = 7, ActorId = 11},
                        new FilmActor {Id = 32, FilmId = 8, ActorId = 8},
                        new FilmActor {Id = 33, FilmId = 8, ActorId = 9},
                        new FilmActor {Id = 34, FilmId = 8, ActorId = 10},
                        new FilmActor {Id = 35, FilmId = 8, ActorId = 15},
                        new FilmActor {Id = 36, FilmId = 8, ActorId = 16},
                        new FilmActor {Id = 38, FilmId = 10, ActorId = 18},
                        new FilmActor {Id = 39, FilmId = 10, ActorId = 19},
                        new FilmActor {Id = 40, FilmId = 10, ActorId = 20}
                    }
                );

            modelBuilder
                .Entity<FilmGenre>()
                .HasData
                (
                    new List<FilmGenre>
                    {
                        new FilmGenre {Id = 1, GenreId = 1, FilmId = 2},
                        new FilmGenre {Id = 2, GenreId = 2, FilmId = 2},
                        new FilmGenre {Id = 3, GenreId = 3, FilmId = 2},
                        new FilmGenre {Id = 4, GenreId = 4, FilmId = 2},
                        new FilmGenre {Id = 5, GenreId = 5, FilmId = 2},
                        new FilmGenre {Id = 6, GenreId = 6, FilmId = 2},
                        new FilmGenre {Id = 7, GenreId = 7, FilmId = 2},
                        new FilmGenre {Id = 8, GenreId = 1, FilmId = 3},
                        new FilmGenre {Id = 9, GenreId = 2, FilmId = 3},
                        new FilmGenre {Id = 10, GenreId = 3, FilmId = 3},
                        new FilmGenre {Id = 11, GenreId = 4, FilmId = 3},
                        new FilmGenre {Id = 12, GenreId = 5, FilmId = 3},
                        new FilmGenre {Id = 13, GenreId = 6, FilmId = 3},
                        new FilmGenre {Id = 14, GenreId = 7, FilmId = 3},
                        new FilmGenre {Id = 15, GenreId = 1, FilmId = 4},
                        new FilmGenre {Id = 16, GenreId = 2, FilmId = 4},
                        new FilmGenre {Id = 17, GenreId = 3, FilmId = 4},
                        new FilmGenre {Id = 18, GenreId = 4, FilmId = 4},
                        new FilmGenre {Id = 19, GenreId = 5, FilmId = 4},
                        new FilmGenre {Id = 20, GenreId = 6, FilmId = 4},
                        new FilmGenre {Id = 21, GenreId = 7, FilmId = 4},
                        new FilmGenre {Id = 22, GenreId = 1, FilmId = 5},
                        new FilmGenre {Id = 23, GenreId = 2, FilmId = 5},
                        new FilmGenre {Id = 24, GenreId = 3, FilmId = 5},
                        new FilmGenre {Id = 25, GenreId = 4, FilmId = 5},
                        new FilmGenre {Id = 26, GenreId = 5, FilmId = 5},
                        new FilmGenre {Id = 27, GenreId = 6, FilmId = 5},
                        new FilmGenre {Id = 28, GenreId = 7, FilmId = 5},
                        new FilmGenre {Id = 29, GenreId = 1, FilmId = 6},
                        new FilmGenre {Id = 30, GenreId = 2, FilmId = 6},
                        new FilmGenre {Id = 31, GenreId = 3, FilmId = 6},
                        new FilmGenre {Id = 32, GenreId = 4, FilmId = 6},
                        new FilmGenre {Id = 33, GenreId = 5, FilmId = 6},
                        new FilmGenre {Id = 34, GenreId = 6, FilmId = 6},
                        new FilmGenre {Id = 35, GenreId = 7, FilmId = 6},
                        new FilmGenre {Id = 36, GenreId = 1, FilmId = 7},
                        new FilmGenre {Id = 37, GenreId = 2, FilmId = 7},
                        new FilmGenre {Id = 38, GenreId = 3, FilmId = 7},
                        new FilmGenre {Id = 39, GenreId = 4, FilmId = 7},
                        new FilmGenre {Id = 40, GenreId = 5, FilmId = 7},
                        new FilmGenre {Id = 41, GenreId = 6, FilmId = 7},
                        new FilmGenre {Id = 42, GenreId = 7, FilmId = 7},
                        new FilmGenre {Id = 43, GenreId = 1, FilmId = 8},
                        new FilmGenre {Id = 44, GenreId = 2, FilmId = 8},
                        new FilmGenre {Id = 45, GenreId = 3, FilmId = 8},
                        new FilmGenre {Id = 46, GenreId = 4, FilmId = 8},
                        new FilmGenre {Id = 47, GenreId = 5, FilmId = 8},
                        new FilmGenre {Id = 48, GenreId = 6, FilmId = 8},
                        new FilmGenre {Id = 49, GenreId = 7, FilmId = 8},
                        new FilmGenre {Id = 50, GenreId = 3, FilmId = 10},
                        new FilmGenre {Id = 51, GenreId = 5, FilmId = 10}
                    }
                );

            modelBuilder.Entity<Genre>()
                .HasData
                (
                    new List<Genre>
                    {
                        new Genre {GenreId = 1, GenreName = "Science fiction"},
                        new Genre {GenreId = 2, GenreName = "Film epic"},
                        new Genre {GenreId = 3, GenreName = "Detective film"},
                        new Genre {GenreId = 4, GenreName = "Action movie"},
                        new Genre {GenreId = 5, GenreName = "Adventures"},
                        new Genre {GenreId = 6, GenreName = "Space opera"},
                        new Genre {GenreId = 7, GenreName = "Fantasy"}
                    }
                );

            modelBuilder.Entity<Photo>()
                .HasData
                (
                    new Photo {PhotoId = 1, FilmId = 2, PhotoPath = "Star Wars - The Phantom Menace.webp"},
                    new Photo {PhotoId = 2, FilmId = 3, PhotoPath = "Star Wars - Attack of the Clones.webp"},
                    new Photo {PhotoId = 3, FilmId = 4, PhotoPath = "Star Wars - Revenge of the Sith.jpeg"},
                    new Photo {PhotoId = 4, FilmId = 5, PhotoPath = "Star Wars - A New Hope.webp"},
                    new Photo {PhotoId = 5, FilmId = 6, PhotoPath = "Star Wars - The Empire Strikes Back.jpeg"},
                    new Photo {PhotoId = 6, FilmId = 7, PhotoPath = "Star Wars - Return of the Jedi.jpeg"},
                    new Photo {PhotoId = 7, FilmId = 8, PhotoPath = "Star Wars - The Force Awakens.webp"},
                    new Photo {PhotoId = 8, FilmId = 10, PhotoPath = "Sherlock Holmes and Doctor Watson.jpg"}
                );

            modelBuilder.Entity<Rating>()
                .HasData
                (
                    new List<Rating>
                    {
                        new Rating {RatingId = 10, UserEmail = "admin@gmail.com", FilmId = 8},
                        new Rating {RatingId = 12, UserEmail = "admin@gmail.com", FilmId = 6},
                        new Rating {RatingId = 13, UserEmail = "vasya@gmail.com", FilmId = 2},
                        new Rating {RatingId = 15, UserEmail = "vasya@gmail.com", FilmId = 3}
                    }
                );
        }
    }
}