using KnowIt.SubjectGroups.WebApi.Models;

namespace KnowIt.SubjectGroups.WebApi
{
    public interface ISubjectGroupService
    {
        public void AddSubjectGroup(SubjectGroup grouop);

        public List<SubjectGroup> GetAllGroups();

        public SubjectGroup? AddArrangement(Arrangement arrangements);

        public List<SubjectGroup> GetGroupsOfType(SubjectGroupType type);

        public List<Arrangement> GetArrangementsForGroup(string groupId);

        public int NumberOfGroupsWhoHasHadArrangementWithParameters(int participants);

        public List<Arrangement> GetArrangementsToCome(string groupId);
    }
}