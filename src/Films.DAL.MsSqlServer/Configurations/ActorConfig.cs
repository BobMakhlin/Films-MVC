using Films.DAL.MsSqlServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Films.DAL.MsSqlServer.Configurations
{
    public class ActorConfig :  IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder
                .Property(a => a.ActorName)
                .HasMaxLength(64)
                .IsRequired();
            
            builder
                .Property(a => a.ActorBirthday)
                .IsRequired();
        }
    }
}