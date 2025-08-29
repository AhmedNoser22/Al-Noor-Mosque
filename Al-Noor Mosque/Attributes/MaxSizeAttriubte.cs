namespace Al_Noor_Mosque.Attributes
{
    public class MaxSizeAttriubte:ValidationAttribute
    {
        private readonly int _maxSize;

        public MaxSizeAttriubte(int maxSize)
        {
            _maxSize = maxSize;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null && file.Length > _maxSize)
            {
                return new ValidationResult($"File size cannot exceed {_maxSize} bytes.");
            }
            return ValidationResult.Success;
        }
    }
}
