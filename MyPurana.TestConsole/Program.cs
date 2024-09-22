using Cyh.Net;
using Cyh.Net.Data.Expressions;
using Cyh.Net.Data.PageUtils;
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

            var exprMaker = ExpressionMaker.GetExpressionMaker<SkillView>(LinkType.And);

            var skvs = new List<IExpressionMaker<SkillView>>()
            {
                exprMaker.GetExpressionMakerContains("SkillLevel", skillSearch.SkillLevels),
                exprMaker.GetExpressionMakerContains("SkillType", skillSearch.SkillTypes),
                exprMaker.GetExpressionMakerContains("SkillSubType", skillSearch.SkillSubTypes),
                exprMaker.GetExpressionMakerContains("EffectType", skillSearch.EffectTypes),
                exprMaker.GetExpressionMakerContains("EffectSubType", skillSearch.EffectSubTypes),
                exprMaker.GetExpressionMakerContains("EffectStat", skillSearch.EffectStats),
                exprMaker.GetExpressionMakerContains("EffectStatType", skillSearch.EffectStatTypes),
                exprMaker.GetExpressionMaker("EffectValue", CompareType.LessThan, 0)
            }.ToArray();

            PageList<SkillView> skillPages = new PageList<SkillView>(
                skService.GetQueryable(),
                skvs.MakeExpression(),
                10);
            skillPages.OrderBy(x => x.EffectValue, 1);

            var p1 = skillPages[0];
            var p2 = skillPages[1];

            Console.WriteLine("Hello, World!");
        }
    }
}
