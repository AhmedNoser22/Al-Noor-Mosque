namespace Al_Noor.Infrastructure.Entities
{
    public class Activity : BaseClass
    {
        public string Description { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; } = default!;
        public ICollection<Child> children { get; set; } = new List<Child>();
        public ICollection<Young> Youngs { get; set; } = new List<Young>();
        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
