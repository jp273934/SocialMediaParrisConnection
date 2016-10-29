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
        public int StatusId { get; set; }
        [StringLength(255)]
        public string PostComment { get; set; }
    }
}