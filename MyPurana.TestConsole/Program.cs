using Cyh.Net;
using Cyh.Net.Data.Pager;
using Cyh.Net.Data.Predicate;
using MyPurana.Data.Skill.Enums;
using MyPurana.Data.Skill.ViewModel;
using MyPurana.Model.ViewModel;
using System.Text;

namespace MyPurana.TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool useReflection = false;
            Console.OutputEncoding = Encoding.UTF8;
            var skService = MyPurana.Service.Extensions.GetSkillService("D:\\Github\\students.json");

            SkillSearchEnum skillSearch = new SkillSearchEnum
            {
                StudentName = "亞",
                SkillLevels = [5],
                SkillTypes = [SkillType.Ex],
                EffectStats = [EffectStat.DefensePower],
                EffectStatTypes = [EffectStatCalcType.Coefficient],
                EffectTypes = [EffectType.Buff],
            };

            List<ExpressionData> predParameters = new List<ExpressionData>();
            {
                predParameters.Add(new ExpressionData()
                {
                    MemberName = "StudentName",
                    CompareType = CompareType.Contains,
                    ConstantValue = skillSearch.StudentName
                });
                predParameters.Add(new ExpressionData()
                {
                    MemberName = "SkillName",
                    CompareType = CompareType.Contains,
                    ConstantValue = skillSearch.SkillName,
                    LinkType = LinkType.And
                });
                predParameters.Add(new ExpressionData()
                {
                    MemberName = "SkillLevel",
                    CompareType = CompareType.IsAnyOf,
                    ConstantValue = skillSearch.SkillLevels,
                    LinkType = LinkType.And
                });
                predParameters.Add(new ExpressionData()
                {
                    MemberName = "SkillType",
                    CompareType = CompareType.IsAnyOf,
                    ConstantValue = skillSearch.SkillTypes,
                    LinkType = LinkType.And
                });
                predParameters.Add(new ExpressionData()
                {
                    MemberName = "EffectStat",
                    CompareType = CompareType.IsAnyOf,
                    ConstantValue = skillSearch.EffectStats,
                    LinkType = LinkType.And
                });
                predParameters.Add(new ExpressionData()
                {
                    MemberName = "EffectStatType",
                    CompareType = CompareType.IsAnyOf,
                    ConstantValue = skillSearch.EffectStatTypes,
                    LinkType = LinkType.And
                });
                predParameters.Add(new ExpressionData()
                {
                    MemberName = "EffectType",
                    CompareType = CompareType.IsAnyOf,
                    ConstantValue = skillSearch.EffectTypes,
                    LinkType = LinkType.And
                });
            }
           
            var exprs = Predicate.GetExpression<SkillView>(predParameters);

            IPredicateHolder<SkillView> skillViewPredicate = Predicate.NewPredicateHolder<SkillView>(x => true);

            if (!skillSearch.StudentName.IsNullOrEmpty())
            {
                skillViewPredicate.And(x => x.StudentName.Contains(skillSearch.StudentName));
            }
            if (!skillSearch.SkillName.IsNullOrEmpty())
            {
                skillViewPredicate.And(x => x.SkillName.Contains(skillSearch.SkillName));
            }

            if (useReflection)
            {
                //PropertyInfo[] notStringProperties = typeof(SkillSearchEnum).GetProperties(BindingFlags.Instance | BindingFlags.Public);
                //notStringProperties = notStringProperties
                //    .Where(x => x.PropertyType != typeof(string) && x.PropertyType.IsArray).ToArray();
                //for (int i = 0; i < notStringProperties.Length; i++)
                //{
                //    var notStringProperty = notStringProperties[i];
                //    var name = notStringProperty.Name;
                //    if (!name.EndsWith('s')) continue;
                //    var values = notStringProperty.GetValue(skillSearch);
                //    if ((values as IEnumerable).IsNullOrEmpty()) continue;
                //    var expr = Predicate.GetExpression<SkillView>(name.Substring(0, name.Length - 1), CompareType.IsAnyOf, values);
                //    if (expr != null)
                //    {
                //        skillViewPredicate.And(expr);
                //    }
                //}
            }
            else
            {
                if (!skillSearch.SkillLevels.IsNullOrEmpty())
                {
                    skillViewPredicate.And(x => skillSearch.SkillLevels.Contains(x.SkillLevel));
                }
                if (!skillSearch.SkillTypes.IsNullOrEmpty())
                {
                    skillViewPredicate.And(x => skillSearch.SkillTypes.Contains(x.SkillType));
                }
                if (!skillSearch.SkillSubTypes.IsNullOrEmpty())
                {
                    skillViewPredicate.And(x => skillSearch.SkillSubTypes.Contains(x.SkillSubType));
                }
                if (!skillSearch.EffectStats.IsNullOrEmpty())
                {
                    skillViewPredicate.And(x => skillSearch.EffectStats.Contains(x.EffectStat));
                }
                if (!skillSearch.EffectSubTypes.IsNullOrEmpty())
                {
                    skillViewPredicate.And(x => skillSearch.EffectSubTypes.Contains(x.EffectSubType));
                }
            }

            var predicate = skillViewPredicate.GetPredicate();

            var pages = Pager.CreatePageList(skService.GetQueryable(), exprs, 100);

            var page1 = pages[0].ToList();

            Console.WriteLine("Hello, World!");
        }
    }
}
