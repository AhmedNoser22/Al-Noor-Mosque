namespace Al_Noor_Mosque.ViewModels
{
    public class WorkerVM:IHelperService
    {
        [Required,MaxLength(20)]
        public string Name { get; set; } = default!;
        public int Age { get; set; }
        [RegularExpression(@"^01[0-2,5]{1}[0-9]{8}$", ErrorMessage = "رقم الهاتف غير صالح")]
        public string Phone { get; set; } = default!;
        [AllowExtensionAttriubte(FileSetting.AllowExtension)
            , MaxSizeAttriubte(FileSetting.MaxSize)]
        public IFormFile image { get; set; } = default!;
        [Required, MaxLength(20)]   
        public string JopTitle { get; set; } = default!;
    }
}
