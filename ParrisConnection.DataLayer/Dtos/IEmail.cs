﻿namespace ParrisConnection.DataLayer.Dtos
{
    public interface IEmail
    {
        int Id { get; set; }
        string Address { get; set; }
        string Type { get; set; }
    }
}