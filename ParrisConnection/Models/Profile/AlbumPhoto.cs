using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParrisConnection.Models.Profile
{
    public class AlbumPhoto
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string FilePath { get; set; }
    }
}