using Films.DAL.MsSqlServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Films.DAL.MsSqlServer.Configurations
{
    public class RatingConfig : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasOne(d => d.Film)
                .WithMany(p => p.Rating)
                .HasForeignKey(d => d.FilmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rating__FilmId__2F10007B");
            
            builder
                .Property(e=> e.UserEmail)
                .HasMaxLength(64)
                .IsRequired();
        }
    }
}