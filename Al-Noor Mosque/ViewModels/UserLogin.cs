namespace Al_Noor_Mosque.ViewModels
{
    public class UserLogin
    {
        [Required(ErrorMessage = "يجب ادخال اسم المستخدم")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "يجب ادخال اسم الباسورد")]
        [DataType(DataType.Password,ErrorMessage ="الباسورد غير صالح")]
        public string Password { get; set; }
        [Display(Name = "حفظ تسجيل الدخول")]
        public bool RememberMe { get; set; }
    }
}
