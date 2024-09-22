namespace MyPurana.Model.JsonModel
{
    public partial class Student
    {
        public partial class Skill
        {
            public partial class Effect
            {
                /// <summary>
                /// 效果類型
                /// </summary>
                public string Type { get; set; } = string.Empty;
                /// <summary>
                /// 效果限制
                /// </summary>
                public Restriction[] Restrictions { get; set; } = Array.Empty<Restriction>();
                /// <summary>
                /// 效果作用
                /// </summary>
                public string Stat { get; set; } = string.Empty;
                /// <summary>
                /// 爆擊檢查
                /// </summary>
                public string CriticalCheck { get; set; } = string.Empty;
                /// <summary>
                /// 效果數值
                /// </summary>
                public int[] Scale { get; set; } = Array.Empty<int>();
                /// <summary>
                /// 效果數值(2)
                /// </summary>
                public int[][] Value { get; set; } = Array.Empty<int[]>();
            }
        }
    }
}
