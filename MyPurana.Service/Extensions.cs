namespace MyPurana.Service
{
    public static class Extensions
    {
        public static ISkillService GetSkillService(string jsonPath)
        {
            return new Implement.SkillService(jsonPath);
        }
    }
}
