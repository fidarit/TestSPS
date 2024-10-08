using System.ComponentModel.DataAnnotations.Schema;

namespace TestSPS.Api.Domain.Entities
{
    public class ProductVersion : EntityBase
    {
        [ForeignKey("ProductID")]
        public required Product Product { get; set; }

        public required string Name { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset CreatingDate { get; set; } = DateTimeOffset.Now;

        public double Width { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }
    }
}
