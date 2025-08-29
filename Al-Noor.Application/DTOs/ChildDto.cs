namespace Al_Noor.Application.DTOs
{
    public class ChildDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string ParentPhone { get; set; } = default!;
        public int Age { get; set; }
        public int ActivityId { get; set; }
        public string ActivityName { get; set; } = default!;
    }
}
