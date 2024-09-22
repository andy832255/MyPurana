namespace MyPurana.Data.Skill
{
    public class SkillData
    {
        public string StudentName { get; set; } = string.Empty;
        public string SkillName { get; set; } = string.Empty;
        public string SkillType { get; set; } = string.Empty;
        public string SkillDesc { get; set; } = string.Empty;
        public int SkillLevel { get; set; }
        public string EffectType { get; set; } = string.Empty;
        public string EffectStat { get; set; } = string.Empty;
        public int EffectCondition { get; set; }
        public int EffectValue { get; set; }
        public string? EffectRestrictionProperty { get; set; } = string.Empty;
        public string? EffectRestrictionOperand { get; set; } = string.Empty;
        public string? EffectRestrictionValue { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{this.StudentName} - {this.SkillName} - {this.SkillType} - {this.SkillDesc} - {this.SkillLevel} - {this.EffectType} - {this.EffectStat} - {this.EffectCondition} - {this.EffectValue} - {this.EffectRestrictionProperty} - {this.EffectRestrictionOperand} - {this.EffectRestrictionValue}";
        }
    }
}
