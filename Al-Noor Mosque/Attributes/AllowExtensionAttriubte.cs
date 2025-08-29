namespace Al_Noor_Mosque.Attributes
{
    public class AllowExtensionAttriubte:ValidationAttribute
    {
        private readonly string _AllowedExtensions;

        public AllowExtensionAttriubte(string allowedExtensions)
        {
            _AllowedExtensions = allowedExtensions;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var fileName = value as IFormFile;
            if (fileName == null)
            {
                return new ValidationResult("File name cannot be null.");
            }
            var fileextension = Path.GetExtension(fileName.FileName);
            var IsAllowed = _AllowedExtensions.Split(",").Contains(fileextension, StringComparer.OrdinalIgnoreCase);
            if (IsAllowed)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($"File extension '{fileextension}' is not allowed. Allowed extensions are: {_AllowedExtensions}");
            }

        }
    }
}
