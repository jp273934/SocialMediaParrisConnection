namespace ParrisConnection.DataLayer.Dtos
{
    public interface IQuote
    {
        int Id { get; set; }
        string UserId { get; set; }
        string Name { get; set; }
        string Author { get; set; }
    }
}