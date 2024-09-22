using MyPurana.Data.Skill.ViewModel;
using MyPurana.Data.Skill;
using MyPurana.Model.DbModel;
using MyPurana.Model.JsonModel;
using System.Text.Json;

namespace MyPurana.Service.Implement
{
    internal class SkillService : ISkillService
    {
        List<DbStudent> DbStudents { get; set; }
        List<DbStudentSkill> DbStudentSkills { get; set; }
        List<DbSkillEffect> DbSkillEffects { get; set; }
        List<DbSkillEffectRestriction> DbSkillEffectRestrictions { get; set; }
        List<DbSkillEffectValue> DbSkillEffectValues { get; set; }
        private void LoadJson(string json)
        {
            Student[]? students = JsonSerializer.Deserialize<Student[]>(json);
            if (students == null || students.Length == 0)
            {
                return;
            }
            int currentSkillId = 1;
            int currentEffectId = 1;
            int currentRestrictiontId = 1;

            foreach (Student student in students)
            {
                DbStudent dbStudent = new DbStudent
                {
                    Id = student.Id,
                    Name = student.Name,
                    DevName = student.DevName,
                    PathName = student.PathName,
                };
                this.DbStudents.Add(dbStudent);

                Student.Skill[] skills = student.Skills;
                if (skills != null && skills.Length != 0)
                {
                    foreach (Student.Skill skill in skills)
                    {
                        DbStudentSkill dbSkill = new DbStudentSkill
                        {
                            Id = currentSkillId,
                            StudentId = student.Id,
                            Name = skill.Name,
                            SkillType = skill.SkillType,
                            Desc = skill.Desc,
                        };
                        this.DbStudentSkills.Add(dbSkill);


                        Student.Skill.Effect[] effects = skill.Effects;
                        if (effects == null || effects.Length == 0)
                        {
                            continue;
                        }
                        foreach (Student.Skill.Effect effect in effects)
                        {
                            DbSkillEffect dbEffect = new DbSkillEffect
                            {
                                Id = currentEffectId,
                                SkillId = dbSkill.Id,
                                Type = effect.Type,
                                Stat = effect.Stat,
                                CriticalCheck = effect.CriticalCheck,
                            };
                            this.DbSkillEffects.Add(dbEffect);


                            int[][] effectValues = effect.Value;
                            for (int condition = 0; condition < effectValues.Length; ++condition)
                            {
                                int[] values = effectValues[condition];

                                for (int level = 0; level < values.Length; ++level)
                                {
                                    DbSkillEffectValue dbEffectValue = new DbSkillEffectValue
                                    {
                                        Id = currentEffectId,
                                        Level = level + 1,
                                        EffectId = currentEffectId,
                                        Condition = condition,
                                        Value = values[level],
                                    };
                                    this.DbSkillEffectValues.Add(dbEffectValue);
                                }
                            }

                            {
                                int[] scales = effect.Scale;
                                for (int level = 0; level < scales.Length; ++level)
                                {
                                    DbSkillEffectValue dbEffectValue = new DbSkillEffectValue
                                    {
                                        Id = currentEffectId,
                                        Level = level + 1,
                                        EffectId = currentEffectId,
                                        Condition = 0,
                                        Value = scales[level],
                                    };
                                    this.DbSkillEffectValues.Add(dbEffectValue);
                                }
                            }

                            Student.Skill.Effect.Restriction[] restrictions = effect.Restrictions;
                            if (restrictions != null && restrictions.Length != 0)
                            {
                                foreach (Student.Skill.Effect.Restriction restriction in restrictions)
                                {
                                    DbSkillEffectRestriction dbRestriction = new DbSkillEffectRestriction
                                    {
                                        Id = currentRestrictiontId,
                                        EffectId = dbEffect.Id,
                                        Property = restriction.Property,
                                        Operand = restriction.Operand,
                                        Value = restriction.Value,
                                    };
                                    this.DbSkillEffectRestrictions.Add(dbRestriction);
                                    ++currentRestrictiontId;
                                }
                            }
                            ++currentEffectId;
                        }
                        ++currentSkillId;
                    }
                }
            }
        }
        private IQueryable<SkillData> GetDTOQueryable()
        {
            return this.DbStudents
                .Join(this.DbStudentSkills, stu => stu.Id, ski => ski.StudentId, (stu, ski) => new { Student = stu, Skill = ski })
                .Join(this.DbSkillEffects, stuSki => stuSki.Skill.Id, eff => eff.SkillId, (stuSki, eff) => new { stuSki.Student, stuSki.Skill, Effect = eff })
                .GroupJoin(this.DbSkillEffectValues, stuSkiEffRes => stuSkiEffRes.Effect.Id, val => val.EffectId, (stuSkiEffRes, val) => new { stuSkiEffRes.Student, stuSkiEffRes.Skill, stuSkiEffRes.Effect, Value = val })
                .SelectMany(xy => xy.Value.DefaultIfEmpty(), (x, y) => new { x.Student, x.Skill, x.Effect, Value = y })
                .GroupJoin(this.DbSkillEffectRestrictions, stuSkiEff => stuSkiEff.Effect.Id, res => res.EffectId, (stuSkiEff, res) => new { stuSkiEff.Student, stuSkiEff.Skill, stuSkiEff.Effect, stuSkiEff.Value, Restriction = res })
                .SelectMany(xy => xy.Restriction.DefaultIfEmpty(), (x, y) => new { x.Student, x.Skill, x.Effect, x.Value, Restriction = y })
                .Select(x => new SkillData
                {
                    StudentName = x.Student.Name,
                    SkillName = x.Skill.Name,
                    SkillType = x.Skill.SkillType,
                    SkillDesc = x.Skill.Desc,
                    EffectType = x.Effect.Type,
                    EffectStat = x.Effect.Stat,
                    EffectCondition = x.Value!.Condition,
                    SkillLevel = x.Value!.Level,
                    EffectValue = x.Value.Value,
                    EffectRestrictionProperty = x.Restriction?.Property,
                    EffectRestrictionOperand = x.Restriction?.Operand,
                    EffectRestrictionValue = x.Restriction?.Value?.ToString(),
                }).AsQueryable();
        }

        public SkillService(string jsonPath)
        {
            this.DbStudents = new List<DbStudent>();
            this.DbStudentSkills = new List<DbStudentSkill>();
            this.DbSkillEffects = new List<DbSkillEffect>();
            this.DbSkillEffectRestrictions = new List<DbSkillEffectRestriction>();
            this.DbSkillEffectValues = new List<DbSkillEffectValue>();
            string jsonFile = File.ReadAllText("D:\\Github\\students.json");
            this.LoadJson(jsonFile);
        }

        public IEnumerable<SkillView> GetSkillData(Func<SkillView, bool> expression)
        {
            return this.GetQueryable().Where(expression);
        }

        public IQueryable<SkillView> GetQueryable()
        {
            return this.GetDTOQueryable().Select(SkillView.FromSkillData);
        }
    }
}
