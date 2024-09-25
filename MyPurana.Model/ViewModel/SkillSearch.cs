using Cyh.Net;
using MyPurana.Data.Skill.Enums;
using System.Text.Json.Serialization;

namespace MyPurana.Model.ViewModel
{
    public class SkillSearch
    {

        [JsonPropertyName("student_id")]
        public int StudentId { get; set; }

        [JsonPropertyName("student_name")]
        public string StudentName { get; set; } = String.Empty;

        [JsonPropertyName("skill_name")]
        public string SkillName { get; set; } = String.Empty;

        [JsonPropertyName("skill_level")]
        public int[]? SkillLevels { get; set; }

        [JsonPropertyName("skill_types")]
        public int[]? SkillTypes { get; set; }

        [JsonPropertyName("skill_sub_types")]
        public int[]? SkillSubTypes { get; set; }

        [JsonPropertyName("effect_types")]
        public int[]? EffectTypes { get; set; }

        [JsonPropertyName("effect_sub_types")]
        public int[]? EffectSubTypes { get; set; }

        [JsonPropertyName("effect_stats")]
        public int[]? EffectStats { get; set; }
        [JsonPropertyName("effect_stat_type")]
        public int[]? EffectStatTypes { get; set; }

        public SkillSearchEnum GetEnumVersion()
        {
            int[] allLevel = new int[90];
            for (int i = 0; i < 90; i++)
            {
                allLevel[i] = i + 1;
            }
            return new SkillSearchEnum
            {
                SkillLevels = this.SkillLevels ?? allLevel,
                SkillName = this.SkillName,
                SkillSubTypes = this.SkillSubTypes.GetEnumArray<SkillSubType>(true),
                SkillTypes = this.SkillTypes.GetEnumArray<SkillType>(true),
                EffectStats = this.EffectStats.GetEnumArray<EffectStat>(true),
                EffectStatTypes = this.EffectStatTypes.GetEnumArray<EffectStatCalcType>(true),
                EffectSubTypes = this.EffectSubTypes.GetEnumArray<EffectSubType>(true),
                EffectTypes = this.EffectTypes.GetEnumArray<EffectType>(true),
                StudentId = this.StudentId,
                StudentName = this.StudentName
            };
        }
    }
}
