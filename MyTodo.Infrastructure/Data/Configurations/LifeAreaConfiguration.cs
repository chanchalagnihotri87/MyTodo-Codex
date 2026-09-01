using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTodo.Domain.Entities;

namespace MyTodo.Data.Configurations;

public class LifeAreaConfiguration : IEntityTypeConfiguration<LifeArea>
{
    public void Configure(EntityTypeBuilder<LifeArea> builder)
    {
        builder.ToTable("LifeAreas");

        builder.HasKey(lifeArea => lifeArea.Id);

        builder.Property(lifeArea => lifeArea.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(lifeArea => lifeArea.Description)
            .HasMaxLength(1_000);

        builder.Property(lifeArea => lifeArea.CreatedAtUtc)
            .IsRequired();
    }
}
