using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParrisConnection.Models.Wall
{
    public class Status
    {
        public Status()
        {
            Comments = new List<Comment>();
        }
        public int Id { get; set; }
        [StringLength(255)]
        public string Post { get; set; }

        public List<Comment> Comments { get; set; }
    }
}