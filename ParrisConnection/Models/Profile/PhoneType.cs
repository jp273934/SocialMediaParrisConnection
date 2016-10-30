using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ParrisConnection.Models.Profile
{
    public class PhoneType : IContactType
    {
        [ForeignKey("Phone")]
        public int Id { get; set; }
        [StringLength(50)]
        public string Type { get; set; }
        public virtual Phone Phone { get; set; }
        public string TypeDisplay  => Type + " :";
    }
}