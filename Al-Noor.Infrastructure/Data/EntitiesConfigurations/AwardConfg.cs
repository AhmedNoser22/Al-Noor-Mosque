namespace Al_Noor.Infrastructure.Data.EntitiesConfigurations
{
    public class AwardConfg : IEntityTypeConfiguration<Award>
    {
        public void Configure(EntityTypeBuilder<Award> builder)
        {
            builder.ToTable("Awards");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(a => a.Date)
                .IsRequired();
        }
    }
}
