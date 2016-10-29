using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ParrisConnection.Models.Wall;

namespace ParrisConnection.Models
{
    public class WallViewModel
    {
        [Key]
        public int Id { get; set; }
        public List<Status> Statuses { get; set; }
    }
}