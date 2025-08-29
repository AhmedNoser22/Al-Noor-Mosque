namespace Al_Noor.Application.DTOs
{
    public class TeacherDto
    {
        
        public string Name { get; set; } = default!;
        public int Age { get; set; }
        public string Phone { get; set; } = default!;
        public string image { get; set; } = default!;
        public string specialization { get; set; } = default!;
        public string Qualification { get; set; } = default!;
        public int ActivityId { get; set; }
        public string ActivityName { get; set; } = default!;

    }
}
