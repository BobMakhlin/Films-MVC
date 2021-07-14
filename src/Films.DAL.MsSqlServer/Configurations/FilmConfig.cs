using Films.DAL.MsSqlServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Films.DAL.MsSqlServer.Configurations
{
    public class FilmConfig : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder
                .Property(e=> e.FilmDate)
                .IsRequired();

            builder
                .Property(e => e.FilmDescription)
                .HasMaxLength(256);
            
            builder
                .Property(e=> e.FilmName)
                .HasMaxLength(64)
                .IsRequired();
        }
    }
}