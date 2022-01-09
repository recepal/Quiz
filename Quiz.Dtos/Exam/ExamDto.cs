namespace Quiz.Dtos
{
    public class ExamDto
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public int Counter { get; set; }
        public string Header { get; set; }
    }
}
