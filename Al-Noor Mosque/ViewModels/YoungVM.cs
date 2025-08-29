namespace Al_Noor_Mosque.ViewModels
{
    public class YoungVM : IHelperService
    {
        [Required,MaxLength(20)]
        public string Name { get; set; } = default!;
        [Required, Range(13, 20, ErrorMessage = "العمر يجب أن يكون من 13 الي 20")]
        public int Age { get; set; }
        [RegularExpression(@"^01[0-2,5]{1}[0-9]{8}$", ErrorMessage = "رقم الهاتف غير صالح")]
        public string Phone { get; set; } = default!;
        [AllowExtensionAttriubte(FileSetting.AllowExtension)
            ,MaxSizeAttriubte(FileSetting.MaxSize)]
        public IFormFile image { get; set; } = default!;
        [Display(Name = " النشاط الخاص بالطالب")]
        public int ActivityId { get; set; }
        public IEnumerable<SelectListItem> Activities { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
