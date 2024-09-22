using MyPurana.Data.Skill.Enums;

namespace MyPurana.Data.Skill.Details
{
    public class EffectTypeDetail
    {
        public string StringValue { get; set; } = string.Empty;
        public EffectType Type { get; set; } = EffectType.None;
        public EffectSubType SubType { get; set; } = EffectSubType.None;
        public EffectTypeDetail() { }

        public static implicit operator string?(EffectTypeDetail effectTypePair)
        {
            return effectTypePair.StringValue;
        }
        public static implicit operator EffectTypeDetail?(string str)
        {
            return Extensions.ParseEffTypeFromRaw(str);
        }
    }
}
