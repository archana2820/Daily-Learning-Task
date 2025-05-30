namespace Repositorypattern
{
    public class Student
    {
        public int Id { get; set; }
        public string firstname { get; set; } = string.Empty;
        public string middlename { get; set; } = string.Empty;
        public string lastname { get; set; } = string.Empty;

        public string place { get; set; }

        public DateTime JoiningDate { get; set; }
    }
}
