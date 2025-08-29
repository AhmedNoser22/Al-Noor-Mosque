namespace Al_Noor.Infrastructure.Entities
{
    public class Young:BaseClass2
    {
        public int ActivityId { get; set; }
        public Activity Activity { get; set; } = default!;
    }
}
