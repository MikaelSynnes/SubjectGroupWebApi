using KnowIt.SubjectGroups.WebApi.Abstractions;
using KnowIt.SubjectGroups.WebApi.Models;

namespace KnowIt.SubjectGroups.WebApi
{

    //Redundant for this assigment. Logic that does not directly have to do with Accessing storage will be put here
    public class SubjectGroupService : ISubjectGroupService
    {
        private ISubjectGroupStorage _storage;

        public SubjectGroupService(ISubjectGroupStorage storage)
        {
            _storage = storage;
        }
        public SubjectGroup? AddArrangement(Arrangement arrangements)
        {
            return _storage.AddArrangement(arrangements);
        }

        public void AddSubjectGroup(SubjectGroup group)
        {
            _storage.AddSubjectGroup(group);
        }

        public List<SubjectGroup> GetAllGroups()
        {
            return _storage.GetAllGroups();

        }
        public List<Arrangement> GetArrangementsForGroup(string groupId)
        {
            return _storage.GetArrangementsForGroup(groupId);
        }

        public List<Arrangement> GetArrangementsToCome(string groupId)
        {
            return _storage.GetArrangementsToCome(groupId, DateTime.Now);
        }

        public List<SubjectGroup> GetGroupsOfType(SubjectGroupType type)
        {
           return _storage.GetGroupsOfType(type);
        }

        public int NumberOfGroupsWhoHasHadArrangementWithParameters(int participants)
        {
            return _storage.NumberOfGroupsWhoHasHadArrangementWithParameters(participants);
        }
    }
}
