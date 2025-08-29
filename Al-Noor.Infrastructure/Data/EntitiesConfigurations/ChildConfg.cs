namespace Al_Noor.Infrastructure.Data.EntitiesConfigurations
{
    public class ChildConfg : IEntityTypeConfiguration<Child>
    {
        public void Configure(EntityTypeBuilder<Child> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c => c.Age)
                .IsRequired();
        }
    }
}
