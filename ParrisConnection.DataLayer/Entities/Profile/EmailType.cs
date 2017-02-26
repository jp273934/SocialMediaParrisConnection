using ParrisConnection.DataLayer.Dtos;
using System.ComponentModel.DataAnnotations;

namespace ParrisConnection.DataLayer.Entities.Profile
{
    public class EmailType : IEmailType
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Type { get; set; }
    }
}
