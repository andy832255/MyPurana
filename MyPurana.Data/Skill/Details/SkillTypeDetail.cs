using MyPurana.Data.Skill.Enums;

namespace MyPurana.Data.Skill.Details
{
    public class SkillTypeDetail
    {
        public string StringValue { get; set; } = string.Empty;

        public SkillType Type { get; set; }
        public SkillSubType SubType { get; set; }

        public static implicit operator string?(SkillTypeDetail effectTypePair)
        {
            return effectTypePair.StringValue;
        }
        public static implicit operator SkillTypeDetail?(string str)
        {
            return Extensions.ParseSkillTypeFromRaw(str);
        }
    }
}
