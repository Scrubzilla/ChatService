namespace VismaSpcs.Recruitment.ChatService.Entities
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
        public DateTime Created { get; set; }
    }
}