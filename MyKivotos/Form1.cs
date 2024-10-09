using Cyh.Net;
using Cyh.Net.Data.Pager;
using Cyh.Net.Data.Predicate;
using MyPurana.Data.Skill.Enums;
using MyPurana.Data.Skill.ViewModel;
using MyPurana.Model.ViewModel;

namespace MyKivotos
{
    public partial class Form1 : Form
    {
        public static string jsonpath = "D:\\Github\\students.json";

        public Form1()
        {
            InitializeComponent();
            BindToComboBox();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SkillSearchEnum skillSearch = new SkillSearchEnum
            {
                //SkillLevels = [5],
                //SkillTypes = [SkillType.Ex],
                //EffectStats = [EffectStat.DefensePower],
                //EffectStatTypes = [EffectStatCalcType.Coefficient],
                //EffectTypes = [EffectType.Buff],
            };

            dataGridView1.DataSource = skillViewPredicatefilter(skillSearch);
        }

        private void BindToComboBox()
        {
            cbSkillTypes.DataSource = Enum.GetValues(typeof(SkillType));
            cbEffectStats.DataSource = Enum.GetValues(typeof(EffectStat));
            cbEffectStatTypes.DataSource = Enum.GetValues(typeof(EffectStatCalcType));
            cbEffectTypes.DataSource = Enum.GetValues(typeof(EffectType));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var SkillLevel = new int[] { Convert.ToInt32(cbLevels.SelectedItem) };
            var SkillType = new SkillType[] { (SkillType)cbSkillTypes.SelectedItem };
            var EffectStat = new EffectStat[] { (EffectStat)cbEffectStats.SelectedItem };
            var EffectStatCalcType = new EffectStatCalcType[] { (EffectStatCalcType)cbEffectStatTypes.SelectedItem };
            var EffectType = new EffectType[] { (EffectType)cbEffectTypes.SelectedItem };
            SkillSearchEnum skillSearch = new SkillSearchEnum
            {
                SkillLevels = SkillLevel,
                SkillTypes = SkillType,
                EffectStats = EffectStat,
                EffectStatTypes = EffectStatCalcType,
                EffectTypes = EffectType,
            };

            dataGridView1.DataSource = skillViewPredicatefilter(skillSearch);
        }
        //¿z¿ï
        private static List<SkillView> skillViewPredicatefilter(SkillSearchEnum skillSearch, int count = 10000)
        {
            var skService = MyPurana.Service.Extensions.GetSkillService(jsonpath);

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

            var pages = Pager.CreatePageList(skService.GetQueryable(), predicate, count);

            return pages[0].ToList();
        }
    }
}
