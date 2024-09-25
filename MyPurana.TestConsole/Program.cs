using Cyh.Net;
using Cyh.Net.Data;
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
            Console.OutputEncoding = Encoding.UTF8;
            var skService = MyPurana.Service.Extensions.GetSkillService("D:\\Github\\students.json");

            SkillSearchEnum skillSearch = new SkillSearchEnum
            {
                SkillLevels = [5],
                SkillTypes = [SkillType.Ex],
                EffectStats = [EffectStat.DefensePower],
                EffectStatTypes = [EffectStatCalcType.Coefficient],
                EffectTypes = [EffectType.Buff],
            };

            IPredicateHolder<SkillView> skillViewPredicate = Predicate.NewPredicateHolder<SkillView>(x => true);

            if (!skillSearch.StudentName.IsNullOrEmpty())
            {
                skillViewPredicate.And(x => x.StudentName.Contains(skillSearch.StudentName));
            }
            if (!skillSearch.SkillName.IsNullOrEmpty())
            {
                skillViewPredicate.And(x => x.SkillName.Contains(skillSearch.SkillName));
            }
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

            var predicate = skillViewPredicate.GetPredicate();

            var pages = Pager.CreatePageList(skService.GetQueryable(), predicate, 100);

            var page1 = pages[0].ToList();

            Console.WriteLine("Hello, World!");
        }
    }
}
