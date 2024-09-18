namespace VismaSpcs.Recruitment.ChatService.Dtos
{
    public abstract class BaseDto<T>
    {
        public T Id { get; set; }
        public DateTime Created { get; set; }
    }
}