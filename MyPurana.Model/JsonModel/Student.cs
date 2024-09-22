namespace MyPurana.Model.JsonModel
{
    public partial class Student
    {
        public int Id { get; set; }
        public string PathName { get; set; } = string.Empty;
        public string DevName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public Skill[] Skills { get; set; } = Array.Empty<Skill>();
    }
}
