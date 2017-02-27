using System.Collections.Generic;

namespace ParrisConnection.DataLayer.Entities.Wall
{
    public class Status
    {
        public Status()
        {
            Comments = new List<Comment>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string Post { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}
