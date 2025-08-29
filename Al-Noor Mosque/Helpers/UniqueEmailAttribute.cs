namespace Al_Noor_Mosque.Helpers
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return null;
            var name = value.ToString();
            var context = (AppDbContext)validationContext.GetService(typeof(AppDbContext));
            var entity = context.Users.Any(x => x.Email == value);
            if (entity != null)
            {
                return new ValidationResult(" الايميل موجود بالفعل");
            }
            return ValidationResult.Success;
        }
    }

}
