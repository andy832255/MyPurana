namespace MyPurana.Model.DbModel
{
    public class DbSkillEffect
    {
        public int Id { get; set; }
        public int SkillId { get; set; }

        public string Type { get; set; } = string.Empty;
        public string Stat { get; set; } = string.Empty;
        public string CriticalCheck { get; set; } = string.Empty;
    }
}
