namespace Al_Noor_Mosque.ViewModels
{
    public class TeacherVM: IHelperService
    {
        [Required(ErrorMessage = "من فضلك أدخل الاسم")]
        public string Name { get; set; } = default!;
        [Required(ErrorMessage = "يرجى اختيار العمر")]
        public int Age { get; set; }
        [Required(ErrorMessage = "رقم الهاتف مطلوب")]
        [RegularExpression(@"^01[0-2,5]{1}[0-9]{8}$", ErrorMessage = "رقم الهاتف غير صالح")]
        public string Phone { get; set; } = default!;
        [Required(ErrorMessage = "يرجى اختيار صورة المعلم")]
        [AllowExtensionAttriubte(FileSetting.AllowExtension)
            ,MaxSizeAttriubte(FileSetting.MaxSize)]
        public IFormFile image { get; set; } = default!;
        [Required(ErrorMessage = "التخصص مطلوب")]
        public string specialization { get; set; } = default!;
        [Required(ErrorMessage = "المؤهل مطلوب")]
        public string Qualification { get; set; } = default!;
        [Display(Name ="الدرس المسؤول عنه")]
        [Required(ErrorMessage = "يرجى اختيار النشاط")]
        public int ActivityId { get; set; }
        public IEnumerable<SelectListItem> Activities { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
