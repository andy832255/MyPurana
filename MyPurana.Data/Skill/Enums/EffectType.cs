namespace MyPurana.Data.Skill.Enums
{
    public enum EffectType
    {
        None = 0,
        DMG,
        Buff,
        Heal,
        /// <summary>
        /// 擊退
        /// </summary>
        Knockback,
        CrowdControl,
        Shield,
        FormChange,
        /// <summary>
        /// 累積傷害
        /// </summary>
        Accumulation,
        Mask = 0b111111,
        RMask = ~Mask
    }
}
