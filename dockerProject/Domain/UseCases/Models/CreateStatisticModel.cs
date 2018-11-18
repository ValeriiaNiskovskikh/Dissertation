namespace UseCases.Models
{
    public class CreateStatisticModel
    {
        public string ResourceId { get; set; }
        public string SourceId { get; set; }
        public string UserId { get; set; }
        public double Value { get; set; }
    }
}