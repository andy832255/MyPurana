namespace MyPurana.Model.JsonModel
{
    public partial class Student
    {
        public partial class Skill
        {
            /// <summary>
            /// 技能類型
            /// </summary>
            public string SkillType { get; set; } = string.Empty;
            /// <summary>
            /// 技能名稱
            /// </summary>
            public string Name { get; set; } = string.Empty;
            /// <summary>
            /// 技能描述
            /// </summary>
            public string Desc { get; set; } = string.Empty;
            public Effect[] Effects { get; set; } = Array.Empty<Effect>();
        }
    }
}
