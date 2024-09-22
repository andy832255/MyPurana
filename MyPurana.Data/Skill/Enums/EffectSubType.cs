namespace MyPurana.Data.Skill.Enums
{
    public enum EffectSubType
    {
        None = 0,
        Self = 1 << EnumShift.ShiftEffectSubType,
        Single = 2 << EnumShift.ShiftEffectSubType,
        Multi = 3 << EnumShift.ShiftEffectSubType,
        Dot = 4 << EnumShift.ShiftEffectSubType,
        Echo = 5 << EnumShift.ShiftEffectSubType,
        Zone = 6 << EnumShift.ShiftEffectSubType,
        Ally = 7 << EnumShift.ShiftEffectSubType,
        Target = 8 << EnumShift.ShiftEffectSubType,
        WithScaling = 9 << EnumShift.ShiftEffectSubType,
    }
}
