namespace Al_Noor.Infrastructure.Data.EntitiesConfigurations
{
    public class WorkerConfg : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.ToTable("Workers");
            builder.HasKey(w => w.Id);
            builder.Property(x=>x.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x=>x.Phone)
                .IsRequired()
                .HasMaxLength(15);
            builder.Property(w => w.JopTitle)
                .IsRequired()
                .HasMaxLength(100);
                
        }
    }
}
