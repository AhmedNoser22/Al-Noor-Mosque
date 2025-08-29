namespace Al_Noor_Mosque.ViewModels
{
    public class UserRegister
    {
        [Required(ErrorMessage = "يجب ادخال اسم المستخدم")]
        [RegularExpression(@"^[a-zA-Z0-9]{6,15}$", ErrorMessage = "اسم المستخدم غير صالح")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "يجب ادخال الباسورد")]
        [DataType(DataType.Password, ErrorMessage = "الباسورد غير صالح")]
        public string Password { get; set; }
        [Required(ErrorMessage = "يجب ادخال الباسورد")]
        [DataType(DataType.Password, ErrorMessage = "الباسورد غير صالح")]
        [Compare("Password", ErrorMessage = "الباسورد غير مطابق")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        [UniqueEmailAttribute]
        [EmailAddress(ErrorMessage = "البريد الالكتروني غير صالح")]
        public string Email { get; set; }
 
    }
}
