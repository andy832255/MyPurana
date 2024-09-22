namespace MyPurana.Model.DbModel
{
    public class DbStudentSkill
    {
        public int Id { get; set; }
        public int StudentId { get; set; }

        public string SkillType { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;
    }
}
