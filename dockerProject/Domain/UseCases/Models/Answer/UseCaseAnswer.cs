namespace UseCases.Models
{
    public class UseCaseAnswer
    {
        public string Comment { get; set; }
        public bool Success { get; set; }
    }

    public class UseCaseAnswer<TData> : UseCaseAnswer
    {
        public TData Data { get; set; }
    }
}