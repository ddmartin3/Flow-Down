namespace flowdown_backend.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Department { get; set; }
        public string? OwnerId { get; set; }
    }
}
