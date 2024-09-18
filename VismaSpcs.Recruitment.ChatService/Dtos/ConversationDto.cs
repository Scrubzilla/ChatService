namespace VismaSpcs.Recruitment.ChatService.Dtos
{
    public class ConversationDto : BaseDto<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public bool IsGroup { get; set; }
        public List<UserDto> Participants { get; set; } = new List<UserDto>();
        public List<MessageDto> Messages { get; set; } = new List<MessageDto>();
    }
}