namespace KnowIt.SubjectGroups.WebApi.Models
{
    public record Arrangement(DateTime Date, string SubjectGroupId, string Description, int MaxParticipants=0);

}
