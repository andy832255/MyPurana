using Cyh.Net;
using Cyh.Net.Data.Expressions;
using MyPurana.Data.Skill.Enums;
using MyPurana.Data.Skill.ViewModel;

namespace MyPurana.Model.ViewModel
{
    public class SkillSearchEnum : IExpressionMakerGenerator<SkillView>
    {
        static int[] _allLevel;
        static SkillType[] _allSkillTypes;
        static SkillSubType[] _allSkillSubTypes;
        static EffectType[] _allEffectTypes;
        static EffectSubType[] _allEffectSubTypes;
        static EffectStat[] _allEffectStats;
        static EffectStatCalcType[] _allEffectStatTypes;
        int[]? _skillLevels { get; set; }
        SkillType[]? _skillTypes { get; set; }
        SkillSubType[]? _skillSubTypes { get; set; }
        EffectType[]? _effectTypes { get; set; }
        EffectSubType[]? _effectSubTypes { get; set; }
        EffectStat[]? _effectStats { get; set; }
        EffectStatCalcType[]? _effectStatTypes { get; set; }

        static SkillSearchEnum()
        {
            int[]? _nullIntArray = null;
            _allLevel = new int[10];
            for (int i = 0; i < 10; i++)
            {
                _allLevel[i] = i + 1;
            }
            _allSkillSubTypes = _nullIntArray.GetEnumArray<SkillSubType>(true);
            _allSkillTypes = _nullIntArray.GetEnumArray<SkillType>(true);
            _allEffectTypes = _nullIntArray.GetEnumArray<EffectType>(true);
            _allEffectSubTypes = _nullIntArray.GetEnumArray<EffectSubType>(true);
            _allEffectStats = _nullIntArray.GetEnumArray<EffectStat>(true);
            _allEffectStatTypes = _nullIntArray.GetEnumArray<EffectStatCalcType>(true);
        }

        public int StudentId { get; set; }

        public string StudentName { get; set; } = String.Empty;

        public string SkillName { get; set; } = String.Empty;

        public int[] SkillLevels
        {
            get => this._skillLevels ?? _allLevel;
            set => this._skillLevels = value;
        }

        public SkillType[] SkillTypes
        {
            get => this._skillTypes ?? _allSkillTypes;
            set => this._skillTypes = value;
        }

        public SkillSubType[] SkillSubTypes
        {
            get => this._skillSubTypes ?? _allSkillSubTypes;
            set => this._skillSubTypes = value;
        }

        public EffectType[] EffectTypes
        {
            get => this._effectTypes ?? _allEffectTypes;
            set => this._effectTypes = value;
        }

        public EffectSubType[] EffectSubTypes
        {
            get => this._effectSubTypes ?? _allEffectSubTypes;
            set => this._effectSubTypes = value;
        }

        public EffectStat[] EffectStats
        {
            get => this._effectStats ?? _allEffectStats;
            set => this._effectStats = value;
        }

        public EffectStatCalcType[] EffectStatTypes
        {
            get => this._effectStatTypes ?? _allEffectStatTypes;
            set => this._effectStatTypes = value;
        }
    }
}
