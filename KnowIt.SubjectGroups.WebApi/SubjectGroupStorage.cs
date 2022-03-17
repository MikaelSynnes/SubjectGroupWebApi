using KnowIt.SubjectGroups.WebApi.Abstractions;
using KnowIt.SubjectGroups.WebApi.Models;

namespace KnowIt.SubjectGroups.WebApi
{
    public class SubjectGroupStorage : ISubjectGroupStorage
    {
        private readonly List<SubjectGroup> _subjectGroup;
        public SubjectGroupStorage()
        {
            _subjectGroup = new List<SubjectGroup>();
        }
        public SubjectGroup? AddArrangement(Arrangement arrangement)
        {
            var group = _subjectGroup.SingleOrDefault(x => string.Equals(arrangement.SubjectGroupId, x.Id));
            if (group == null)
                return null;
            group.Arrangements.Add(arrangement);
            return group;
        }

        public void AddSubjectGroup(SubjectGroup grouop)
        {
            _subjectGroup.Add(grouop);
        }

        public List<Arrangement> GetArrangementsForGroup(string groupId)
        {
            var group = _subjectGroup.SingleOrDefault(x => string.Equals(x.Id, groupId));
            if (group == null)
                return null;
            return group.Arrangements;
        }

        public List<SubjectGroup> GetAllGroups()
        {
            return _subjectGroup;
        }

        public List<SubjectGroup> GetGroupsOfType(SubjectGroupType type)
        {
            return _subjectGroup.Where(x => x.Type == type).ToList();
        }

        public int NumberOfGroupsWhoHasHadArrangementWithParameters(int participants)
        {
            return _subjectGroup.Where(x => x.Arrangements.Any(arrangment => arrangment.MaxParticipants >= participants)).Count();
        }

        public List<Arrangement> GetArrangementsToCome(string groupId, DateTime from)
        {
            var group = _subjectGroup.SingleOrDefault(x => string.Equals(x.Id, groupId));
            if (group == null)
                return null;
            var list = group.Arrangements.Where(x => x.Date.Ticks > from.Ticks).ToList();
            list.Sort((a, b) => a.Date.Ticks.CompareTo(b.Date.Ticks));
            return list;
        }
    }
}
