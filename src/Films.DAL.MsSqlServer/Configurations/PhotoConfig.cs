using Films.DAL.MsSqlServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Films.DAL.MsSqlServer.Configurations
{
    public class PhotoConfig : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.HasOne(d => d.Film)
                .WithMany(p => p.Photo)
                .HasForeignKey(d => d.FilmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Photo__FilmId__49C3F6B7");

            builder
                .Property(e => e.PhotoPath)
                .HasMaxLength(64);
        }
    }
}