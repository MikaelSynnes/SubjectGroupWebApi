using KnowIt.SubjectGroups.WebApi;
using KnowIt.SubjectGroups.WebApi.Models;
using NUnit.Framework;
using System;
using System.Linq;

namespace KnowIt.SubjectGroups.Tests
{
    public class StorageTests
    {
        private SubjectGroupStorage _subjectGroupStorage;

        [SetUp]
        public void Setup()
        {
            _subjectGroupStorage = new SubjectGroupStorage();
        }

        [Test]
        public void AddGroup()
        {
            var name = "testGroup";
            var type = SubjectGroupType.Playground;
            _subjectGroupStorage.AddSubjectGroup(new SubjectGroup(name, type));

            var fromStorage = _subjectGroupStorage.GetAllGroups().SingleOrDefault(x => (string.Equals(x.Name, name)));
            Assert.IsNotNull(fromStorage);
            Assert.IsTrue(fromStorage.Name == name);
            Assert.IsTrue(fromStorage.Type == type);
            Assert.IsTrue(fromStorage.Id != null);
        }

        [Test]
        public void AddArrangement()
        {
            var name = "testGroup";
            var type = SubjectGroupType.Playground;
            _subjectGroupStorage.AddSubjectGroup(new SubjectGroup(name, type));

            var fromStorage = _subjectGroupStorage.GetAllGroups().SingleOrDefault(x => (string.Equals(x.Name, name)));
            var dateTime = DateTime.Now.AddMinutes(1);
            _subjectGroupStorage.AddArrangement(new Arrangement(dateTime, fromStorage.Id, "Some description", 5));

            var arrangmentsForGroup = _subjectGroupStorage.GetArrangementsForGroup(fromStorage.Id);

            //should have arrangement
            Assert.IsTrue(arrangmentsForGroup.Any());
        }

        [Test]
        public void GetNumberOfParicipants()
        {
            var name = "testGroup";
            var type = SubjectGroupType.Playground;
            _subjectGroupStorage.AddSubjectGroup(new SubjectGroup(name, type));

            var name2 = "testGroup2";
            _subjectGroupStorage.AddSubjectGroup(new SubjectGroup(name2, type));

            var fromStorage = _subjectGroupStorage.GetAllGroups().SingleOrDefault(x => (string.Equals(x.Name, name)));

            var fromStorage2 = _subjectGroupStorage.GetAllGroups().SingleOrDefault(x => (string.Equals(x.Name, name2)));

            var dateTime = DateTime.Now.AddMinutes(1);
            _subjectGroupStorage.AddArrangement(new Arrangement(dateTime, fromStorage.Id, "Some description", 5));
            _subjectGroupStorage.AddArrangement(new Arrangement(dateTime, fromStorage.Id, "Some description", 11));
            _subjectGroupStorage.AddArrangement(new Arrangement(dateTime, fromStorage2.Id, "Some description", 11));
            _subjectGroupStorage.AddArrangement(new Arrangement(dateTime, fromStorage.Id, "Some description", 132));

            var arrangmentsForGroup = _subjectGroupStorage.NumberOfGroupsWhoHasHadArrangementWithParameters(10);

            //should have arrangement
            Assert.IsTrue(arrangmentsForGroup == 2);
        }

        [Test]
        public void GetArrangementsToComeForGroup()
        {
            var name = "testGroup";
            var type = SubjectGroupType.Playground;
            _subjectGroupStorage.AddSubjectGroup(new SubjectGroup(name, type));

            var fromStorage = _subjectGroupStorage.GetAllGroups().SingleOrDefault(x => (string.Equals(x.Name, name)));

            _subjectGroupStorage.AddArrangement(new Arrangement(DateTime.Now.AddMinutes(1), fromStorage.Id, "Some description", 5));
            _subjectGroupStorage.AddArrangement(new Arrangement(DateTime.Now.AddMinutes(2), fromStorage.Id, "Some description", 11));
            _subjectGroupStorage.AddArrangement(new Arrangement(DateTime.Now.AddMinutes(-1), fromStorage.Id, "Some description", 11));
            var arrangementsToCome = _subjectGroupStorage.GetArrangementsToCome(fromStorage.Id, DateTime.Now);

            Assert.IsTrue(arrangementsToCome.Count == 2);
            Assert.IsTrue(arrangementsToCome[0].Date < arrangementsToCome[1].Date);
        }

        [Test]
        public void GetGroupsOfType()
        {
            var name = "testGroup";

            _subjectGroupStorage.AddSubjectGroup(new SubjectGroup(name, SubjectGroupType.Playground));
            _subjectGroupStorage.AddSubjectGroup(new SubjectGroup(name, SubjectGroupType.Playground));
            _subjectGroupStorage.AddSubjectGroup(new SubjectGroup(name, SubjectGroupType.Guild));
            _subjectGroupStorage.AddSubjectGroup(new SubjectGroup(name, SubjectGroupType.Chapter));
            var subjectGroupsOfType = _subjectGroupStorage.GetGroupsOfType(SubjectGroupType.Playground);
            Assert.IsTrue(subjectGroupsOfType.Count == 2);
        }
    }
}