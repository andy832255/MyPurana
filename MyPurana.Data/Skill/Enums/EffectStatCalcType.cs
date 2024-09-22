namespace MyPurana.Data.Skill.Enums
{
    public enum EffectStatCalcType
    {
        None,
        Base = 0b01 << EnumShift.ShiftEffectStatCalcType,
        Coefficient = 0b10 << EnumShift.ShiftEffectStatCalcType,
    }
}
