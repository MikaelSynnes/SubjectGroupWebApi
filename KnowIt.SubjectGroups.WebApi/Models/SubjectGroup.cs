namespace KnowIt.SubjectGroups.WebApi.Models
{
    public class SubjectGroup
    {
        public string Id { get; }
        public string Name { get; }
        public SubjectGroupType Type { get; }

        public List<Arrangement> Arrangements { get; }

        public SubjectGroup(string name, SubjectGroupType type)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Type = type;
            Arrangements = new List<Arrangement>();
        }
    }
}
