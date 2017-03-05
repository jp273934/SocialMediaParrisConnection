namespace ParrisConnection.DataLayer.Entities.Wall
{
    public class Comment
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string PostComment { get; set; }
        public virtual Status Status { get; set; }
    }
}
