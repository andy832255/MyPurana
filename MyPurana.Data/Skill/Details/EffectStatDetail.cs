using MyPurana.Data.Skill.Enums;

namespace MyPurana.Data.Skill.Details
{
    public class EffectStatDetail
    {
        public string StringValue { get; set; } = string.Empty;
        public EffectStat Stat { get; set; } = EffectStat.None;
        public EffectStatCalcType StatCalcType { get; set; } = EffectStatCalcType.None;
        public EffectStatDetail() { }

        public static implicit operator string?(EffectStatDetail? effectTypePair)
        {
            return effectTypePair?.StringValue;
        }
        public static implicit operator EffectStatDetail?(string? str)
        {
            return Extensions.ParseEffStatFromRaw(str ?? string.Empty);
        }
    }
}
