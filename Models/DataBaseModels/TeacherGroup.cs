namespace University.Models.DataBaseModels
{
    public class TeacherGroup
    {
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public Guid GroupId { get; set; }
        public Group Group { get; set; }
    }
}
