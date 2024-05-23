namespace StudentPortal.web.Models
{
    public class AddStudentViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public int PresenceCount { get; set; }

        public int AbsenceCount { get; set; }

        public float Average { get; set; }

        public string Class { get; set; }
    }
}
