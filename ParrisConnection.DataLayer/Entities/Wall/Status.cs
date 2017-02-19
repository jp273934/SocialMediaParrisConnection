using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParrisConnection.DataLayer.Entities.Wall
{
    public class Status
    {
        public Status()
        {
            Comments = new List<Comment>();
        }

        public int Id { get; set; }
        public string Post { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}
