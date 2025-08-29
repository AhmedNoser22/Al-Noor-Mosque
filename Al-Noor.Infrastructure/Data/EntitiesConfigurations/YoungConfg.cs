namespace Al_Noor.Infrastructure.Data.EntitiesConfigurations
{
    public class YoungConfg : IEntityTypeConfiguration<Young>
    {
        public void Configure(EntityTypeBuilder<Young> builder)
        {
            builder.HasOne(y => y.Activity)
                .WithMany(a => a.Youngs)
                .HasForeignKey(y => y.ActivityId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(y => y.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(y => y.Phone)
                .IsRequired()
                .HasMaxLength(15);


        }
    }
}
