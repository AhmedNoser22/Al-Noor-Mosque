namespace Al_Noor.Infrastructure.Data.EntitiesConfigurations
{
    public class TeacherConfg : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teachers");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.specialization)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x=>x.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(t => t.Qualification)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(t => t.Phone)
                .IsRequired()
                .HasMaxLength(15);
            builder.HasOne(t => t.Activity)
                .WithMany(a => a.Teachers)
                .HasForeignKey(t => t.ActivityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
