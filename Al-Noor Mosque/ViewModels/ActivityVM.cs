namespace Al_Noor_Mosque.ViewModels
{
    public class ActivityVM
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; } = default!;
    }
}
