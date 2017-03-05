using ParrisConnection.DataLayer.Dtos;
using System.ComponentModel.DataAnnotations;

namespace ParrisConnection.DataLayer.Entities.Profile
{
    public class Phone : IPhone
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [StringLength(255)]
        public string Number { get; set; }
        public string PhoneType { get; set; }
    }
}
