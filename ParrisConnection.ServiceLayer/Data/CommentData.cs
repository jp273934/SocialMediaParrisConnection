namespace ParrisConnection.ServiceLayer.Data
{
    public class CommentData
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string PostComment { get; set; }
        public StatusData Status { get; set; }
    }
}
