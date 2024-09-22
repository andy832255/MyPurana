namespace MyPurana.Data.Skill.Enums
{
    public enum SkillSubType
    {
        None = 0,
        Gear = 1 << EnumShift.ShiftSkillSubType,
        Weapon = 2 << EnumShift.ShiftSkillSubType,
    }
}
