namespace TestSPS.Api.Domain.Entities
{
    public class EventLog : EntityBase
    {
        public DateTimeOffset EventDate { get; set; } = DateTimeOffset.Now;
        public string? Description { get; set; }
    }
}
