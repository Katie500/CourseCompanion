namespace CourseCompanion.Shared.Model
{
    public class CourseDetails
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Instructor { get; set; }
        public int Levels { get; set; }
        public int Credits { get; set; }
        public string? Category { get; set; }
        public string? Semester { get; set; }
        public string? Faculty { get; set; }
        public string? Prerequisites { get; set; }
        public string? Antirequisites { get; set; }
    }
}