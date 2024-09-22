using MyPurana.Data.Skill.ViewModel;

namespace MyPurana.Service
{
    public interface ISkillService
    {
        IEnumerable<SkillView> GetSkillData(Func<SkillView, bool> expression);
        IQueryable<SkillView> GetQueryable();
    }
}
