using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParrisConnection.DataLayer.Entities.Wall
{
    public class Comment
    {
        public int Id { get; set; }
        public string PostComment { get; set; }
        public virtual Status Status { get; set; }
    }
}
