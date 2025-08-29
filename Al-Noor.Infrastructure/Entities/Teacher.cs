namespace Al_Noor.Infrastructure.Entities
{
    public class Teacher:BaseClass2
    {
        public string specialization { get; set; } = default!;
        public string Qualification { get; set; } = default!;
        public int ActivityId { get; set; }
        public Activity Activity { get; set; } = default!;
    }
}
