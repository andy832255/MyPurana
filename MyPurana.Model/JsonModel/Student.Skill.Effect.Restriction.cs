namespace MyPurana.Model.JsonModel
{
    public partial class Student
    {
        public partial class Skill
        {
            public partial class Effect
            {
                public partial class Restriction
                {
                    public string Property { get; set; } = string.Empty;
                    public string Operand { get; set; } = string.Empty;
                    public object? Value { get; set; } = null;
                }
            }
        }
    }
}
