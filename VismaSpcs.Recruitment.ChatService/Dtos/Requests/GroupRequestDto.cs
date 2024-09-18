namespace VismaSpcs.Recruitment.ChatService.Dtos
{
    public class GroupRequestDto
    {
        public string Name { get; set; }
        public List<Guid> ParticipantsIds { get; set; } = new List<Guid>();
    }
}
