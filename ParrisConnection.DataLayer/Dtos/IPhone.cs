﻿namespace ParrisConnection.DataLayer.Dtos
{
    public interface IPhone
    {
        int Id { get; set; }
        string Number { get; set; }
        string PhoneType { get; set; }
    }
}