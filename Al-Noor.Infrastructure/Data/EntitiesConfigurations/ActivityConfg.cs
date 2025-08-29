namespace Al_Noor.Infrastructure.Data.EntitiesConfigurations
{
    public class ActivityConfg : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.ToTable("Activities");
            builder.Property(x=>x.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(a => a.StartDate)
                .IsRequired();
            builder.Property(a => a.EndDate)
                .IsRequired();
            builder.Property(a => a.Location)
                .IsRequired()
                .HasMaxLength(200);
            builder.HasMany(a => a.children)
                .WithOne(c => c.Activity);
            builder.HasMany(a => a.Youngs)
                .WithOne(y => y.Activity);
            builder.HasMany(a => a.Teachers)
                .WithOne(t => t.Activity);
        }
    }
}
