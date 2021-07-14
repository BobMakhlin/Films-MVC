using Films.DAL.MsSqlServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Films.DAL.MsSqlServer.Configurations
{
    public class FilmGenreConfig :  IEntityTypeConfiguration<FilmGenre>
    {
        public void Configure(EntityTypeBuilder<FilmGenre> builder)
        {
            builder.HasOne(d => d.Film)
                .WithMany(p => p.FilmGenre)
                .HasForeignKey(d => d.FilmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FilmGenre__FilmI__5DCAEF64");

            builder.HasOne(d => d.Genre)
                .WithMany(p => p.FilmGenre)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FilmGenre__Genre__5CD6CB2B");
        }
    }
}