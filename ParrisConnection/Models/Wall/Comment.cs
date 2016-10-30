using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParrisConnection.Models.Wall
{
    public class Comment
    {
        public int Id { get; set; }
        
        public string PostComment { get; set; }

        public virtual Status Status { get; set; }
    }
}