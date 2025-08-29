namespace Al_Noor_Mosque.ViewModels
{
    public class ChildVM
    {
        [Required,MaxLength(20)]
        public string Name { get; set; } = default!;
        [RegularExpression(@"^01[0-2,5]{1}[0-9]{8}$",ErrorMessage = "رقم الهاتف غير صالح")]
        public string ParentPhone { get; set; } = default!;
        [Required, Range(5, 13, ErrorMessage = "العمر يجب أن يكون بين 6 و 13 سنة")]
        public int Age { get; set; }
        [Display(Name = " النشاط الخاص بالطالب")]
        public int ActivityId { get; set; }
        public IEnumerable<SelectListItem> Activities { get; set; } =Enumerable.Empty<SelectListItem>();
    }
}
