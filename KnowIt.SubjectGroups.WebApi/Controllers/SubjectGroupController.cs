using KnowIt.SubjectGroups.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace KnowIt.SubjectGroups.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class SubjectGroupController : Controller
    {
        private ISubjectGroupService _subjectService;

        public SubjectGroupController(ISubjectGroupService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpPost(nameof(AddArrangement))]
        public IActionResult AddArrangement(Arrangement arrangements)
        {
            if (arrangements.Date < DateTime.Now)
            {
                return BadRequest("Arrangment is in the past");
            }
            try
            {
                var subjectGroup = _subjectService.AddArrangement(arrangements);
                if (subjectGroup == null)
                    return BadRequest("Subject Group does not exist");
                else
                    return Ok($"Arramgent added for {subjectGroup.Name}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost(nameof(AddSubjectGroup))]
        public void AddSubjectGroup(SubjectGroup group)
        {
            _subjectService.AddSubjectGroup(group);
        }

        [HttpGet(nameof(GetAllGroups))]
        public List<SubjectGroup> GetAllGroups()
        {
            return _subjectService.GetAllGroups();

        }
    }
}
