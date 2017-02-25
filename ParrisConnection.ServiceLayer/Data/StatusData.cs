using System.Collections.Generic;

namespace ParrisConnection.ServiceLayer.Data
{
    public class StatusData
    {
        public int Id { get; set; }
        public string Post { get; set; }
        public List<CommentData> Comments { get; set; }
    }
}
