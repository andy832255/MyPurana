using MyPurana.Data.Skill.Details;
using MyPurana.Data.Skill.Enums;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace MyPurana.Data
{
    public static partial class Extensions
    {
        internal static Dictionary<string, int> EffectStatDict;
        internal static Dictionary<string, int> EffectStatTypeDict;
        internal static Dictionary<string, int> EffectTypeDict;
        internal static Dictionary<string, int> EffectSubTypeDict;
        internal static Dictionary<string, int> SkillTypeRawDict;
        internal static void LoadEnumStrings<T>([NotNull] ref Dictionary<string, int>? dict) where T : Enum
        {
            dict ??= new();
            Type type = typeof(T);
            FieldInfo[] enumFieldInfos = type.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            for (int i = 0; i < enumFieldInfos.Length; i++)
            {
                FieldInfo field = enumFieldInfos[i];
#pragma warning disable CS8605 // Unboxing a possibly null value.
                dict[field.Name] = (int)Convert.ChangeType(field.GetValue(null), typeof(int));
#pragma warning restore CS8605 // Unboxing a possibly null value.
            }
        }
        internal static EffectStatDetail? ParseEffStatFromRaw(string str)
        {
            string[] segments = str.Split("_");

            if (segments.Length == 2)
            {
                if (!EffectStatDict.TryGetValue(segments[0], out int effStatVal))
                {
                    return null;
                }
                if (!EffectStatTypeDict.TryGetValue(segments[1], out int statType))
                {
                    return null;
                }

                return new EffectStatDetail
                {
                    StringValue = str,
                    Stat = (EffectStat)effStatVal,
                    StatCalcType = (EffectStatCalcType)statType
                };
            }

            return null;
        }
        internal static EffectTypeDetail? ParseEffTypeFromRaw(string str)
        {
            EffectTypeDetail? typePair = null;
            int subTypeBeginIndex = 0;
            foreach (KeyValuePair<string, int> kvPair in EffectTypeDict)
            {
                if (str.StartsWith(kvPair.Key, StringComparison.OrdinalIgnoreCase))
                {
                    typePair = new EffectTypeDetail
                    {
                        StringValue = str,
                        Type = (EffectType)kvPair.Value,
                    };
                    subTypeBeginIndex = kvPair.Key.Length;
                    break;
                }
            }
            if (typePair == null || subTypeBeginIndex < 1 || subTypeBeginIndex == str.Length) return null;
            string subTypeStr = str.Substring(subTypeBeginIndex);
            foreach (KeyValuePair<string, int> kvPair in EffectSubTypeDict)
            {
                if (subTypeStr.StartsWith(kvPair.Key, StringComparison.OrdinalIgnoreCase))
                {
                    typePair.SubType = (EffectSubType)kvPair.Value;
                    break;
                }
            }
            return typePair;
        }

        internal static SkillTypeDetail? ParseSkillTypeFromRaw(string str)
        {
            if (SkillTypeRawDict.TryGetValue(str, out int skillType))
            {
                return new SkillTypeDetail
                {
                    StringValue = str,
                    Type = (SkillType)(skillType & 0b111111),
                    SubType = (SkillSubType)(skillType & 0b000000)
                };
            }
            return null;
        }

        static Extensions()
        {
            LoadEnumStrings<EffectStat>(ref EffectStatDict);
            LoadEnumStrings<EffectStatCalcType>(ref EffectStatTypeDict);
            LoadEnumStrings<EffectType>(ref EffectTypeDict);
            LoadEnumStrings<EffectSubType>(ref EffectSubTypeDict);
            LoadEnumStrings<SkillTypeRaw>(ref SkillTypeRawDict);
        }

        public static bool IsAnyOf<T>(this T value, params T[] values) where T : Enum
        {
            for (int i = 0; i < values.Length; ++i)
            {
                if (value.Equals(values[i])) return true;
            }
            return false;
        }
        public static bool ContainsAny(this EffectTypeDetail? effectType, params EffectType[] values)
        {
            if (effectType == null) return false;
            if (values.Length == 0) return false;
            return values.Any(x => x == effectType.Type);
        }
        public static bool ContainsAny(this EffectTypeDetail? effectType, params EffectSubType[] values)
        {
            if (effectType == null) return false;
            if (values.Length == 0) return false;
            return values.Any(x => x == effectType.SubType);
        }
        public static bool ContainsAny(this EffectStatDetail? effectStat, params EffectStat[] values)
        {
            if (effectStat == null) return false;
            if (values.Length == 0) return false;
            return values.Any(x => x == effectStat.Stat);
        }
        public static bool ContainsAny(this EffectStatDetail? effectStat, params EffectStatCalcType[] values)
        {
            if (effectStat == null) return false;
            if (values.Length == 0) return false;
            return values.Any(x => x == effectStat.StatCalcType);
        }
    }
}
