namespace Al_Noor.Infrastructure.Entities
{
    public class Award
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime Date { get; set; }
    }
}
