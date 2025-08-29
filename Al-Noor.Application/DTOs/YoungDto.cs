namespace Al_Noor.Application.DTOs
{
    public class YoungDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int Age { get; set; }
        public string Phone { get; set; } = default!;
        public string image { get; set; } = default!;
        public string ActivityName { get; set; } = default!;
        public int ActivityId { get; set; }
    }
}
