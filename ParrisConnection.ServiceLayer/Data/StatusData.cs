using System.Collections.Generic;

namespace ParrisConnection.ServiceLayer.Data
{
    public class StatusData
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Post { get; set; }
        public IEnumerable<CommentData> Comments { get; set; }
        public string NewComment { get; set; }
        public string UserName { get; set; }
    }
}
