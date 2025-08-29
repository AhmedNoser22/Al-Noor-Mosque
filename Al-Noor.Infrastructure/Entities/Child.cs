namespace Al_Noor.Infrastructure.Entities
{
    public class Child:BaseClass
    {
        public string ParentPhone { get; set; } = default!;
        public int Age { get; set; }
        public int ActivityId { get; set; }
        public Activity Activity { get; set; } = default!;
    }
}
