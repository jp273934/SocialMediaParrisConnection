﻿using ParrisConnection.DataLayer.Dtos;

namespace ParrisConnection.DataLayer.Entities.Profile
{
    public class PhoneType : IPhoneType
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
