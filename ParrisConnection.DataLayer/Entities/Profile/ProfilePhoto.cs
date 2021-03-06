﻿using ParrisConnection.DataLayer.Dtos;
using System.ComponentModel.DataAnnotations;

namespace ParrisConnection.DataLayer.Entities.Profile
{
    public class ProfilePhoto : IProfilePhoto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [StringLength(255)]
        public string FilePath { get; set; }
    }
}
