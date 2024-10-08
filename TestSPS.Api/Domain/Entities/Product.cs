namespace TestSPS.Api.Domain.Entities
{
    public class Product : EntityBase
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
