namespace MyPurana.Data.Skill.Enums
{
    public enum EffectStat
    {
        None,
        CriticalDamageRate,
        CriticalPoint,
        HealEffectivenessRate,
        OppressionResist,
        MaxHP,
        AttackPower,
        AccuracyPoint,
        RegenCost,
        AttackSpeed,
        DefensePower,
        DodgePoint,
        Range,
        MoveSpeed,
        AmmoCount,
        OppressionPower,
        DamagedRatio,
        BlockRate,
        StabilityPoint,
        HealPower,
        CriticalChanceResistPoint,
        CriticalDamageResistRate,
        DefensePenetration,
        EnhanceExplosionRate,
        ExtendDebuffDuration,
        EnhanceMysticRate,
        ExtendBuffDuration,
        EnhancePierceRate,
        DamageRatio,
        EnhanceSonicRate,
        Mask = 0b111111,
        RMask = ~Mask
    }
}
