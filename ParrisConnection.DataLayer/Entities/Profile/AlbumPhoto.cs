﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParrisConnection.DataLayer.Entities.Profile
{
    public class AlbumPhoto
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string FilePath { get; set; }
    }
}
