using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Roadmap.Persistance.RoadmapCfg
{
    public class RoadmapConfiguration : IEntityTypeConfiguration<Domain.Roadmap>
    {
        public void Configure(EntityTypeBuilder<Domain.Roadmap> builder)
        {
            builder.HasKey(roadmap => roadmap.Id);
            builder.HasIndex(roadmap => roadmap.Id).IsUnique();
            builder.Property(roadmap => roadmap.Title).IsRequired();
            builder.Property(roadmap => roadmap.Description).IsRequired();
        }
    }
}