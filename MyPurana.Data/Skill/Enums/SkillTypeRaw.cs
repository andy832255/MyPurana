namespace MyPurana.Data.Skill.Enums
{
    public enum SkillTypeRaw
    {
        None = 0,
        ex = SkillType.Ex,
        normal = SkillType.Normal,
        gearnormal = normal | SkillSubType.Gear,
        passive = SkillType.Passive,
        weaponpassive = passive | SkillSubType.Weapon,
        sub = SkillType.Sub,
        autoattack = SkillType.Auto
    }
}
