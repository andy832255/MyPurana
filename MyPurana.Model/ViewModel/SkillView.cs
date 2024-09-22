using MyPurana.Data.Skill.Details;
using MyPurana.Data.Skill.Enums;
using System.Linq.Expressions;

namespace MyPurana.Data.Skill.ViewModel
{
    public class SkillView
    {
        public static Expression<Func<SkillData, SkillView>> FromSkillData
        {
            get => (x) => new SkillView
            {
                StudentName = x.StudentName,
                SkillName = x.SkillName,
                _SkillType = x.SkillType!,
                SkillDesc = x.SkillDesc,
                SkillLevel = x.SkillLevel,
                _EffectType = x.EffectType,
                _EffectStat = x.EffectStat,
                EffectCondition = x.EffectCondition,
                EffectValue = x.EffectValue,
                EffectRestrictionProperty = x.EffectRestrictionProperty,
                EffectRestrictionOperand = x.EffectRestrictionOperand,
                EffectRestrictionValue = x.EffectRestrictionValue,
            };
        }
        internal SkillTypeDetail _SkillType { get; set; } = null!;
        internal EffectTypeDetail? _EffectType { get; set; } = string.Empty;
        internal EffectStatDetail? _EffectStat { get; set; } = string.Empty;

        public string StudentName { get; set; } = string.Empty;
        public string SkillName { get; set; } = string.Empty;
        public SkillType SkillType => this._SkillType.Type;
        public SkillSubType SkillSubType => this._SkillType.SubType;
        public string SkillDesc { get; set; } = string.Empty;
        public int SkillLevel { get; set; }
        public EffectType EffectType => this._EffectType != null ? this._EffectType.Type : EffectType.None;
        public EffectSubType EffectSubType => this._EffectType != null ? this._EffectType.SubType : EffectSubType.None;
        public EffectStat EffectStat => this._EffectStat != null ? this._EffectStat.Stat : EffectStat.None;
        public EffectStatCalcType EffectStatType => this._EffectStat != null ? this._EffectStat.StatCalcType : EffectStatCalcType.None;
        public int EffectCondition { get; set; }
        public int EffectValue { get; set; }
        public string? EffectRestrictionProperty { get; set; } = string.Empty;
        public string? EffectRestrictionOperand { get; set; } = string.Empty;
        public string? EffectRestrictionValue { get; set; } = string.Empty;
    }
}
