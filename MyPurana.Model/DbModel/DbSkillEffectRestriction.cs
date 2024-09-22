namespace MyPurana.Model.DbModel
{
    public class DbSkillEffectRestriction
    {
        public int Id { get; set; }
        public int EffectId { get; set; }

        public string Property { get; set; } = string.Empty;
        public string Operand { get; set; } = string.Empty;
        public object? Value { get; set; } = null;
    }
}
