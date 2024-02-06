using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Roadmap.Persistance.RoadmapCfg;

public class EmployeConfiguration : IEntityTypeConfiguration<Domain.Employe>
{
    public void Configure(EntityTypeBuilder<Domain.Employe> builder)
    {
        builder.HasKey(employee => employee.Id);
    }
    
}