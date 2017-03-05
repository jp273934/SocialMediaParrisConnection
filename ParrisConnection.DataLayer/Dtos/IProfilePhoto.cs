namespace ParrisConnection.DataLayer.Dtos
{
    public interface IProfilePhoto
    {
        int Id { get; set; }
        string UserId { get; set; }
        string FilePath { get; set; }
    }
}