using ParrisConnection.DataLayer.Dtos;
using System.ComponentModel.DataAnnotations;

namespace ParrisConnection.DataLayer.Entities.Profile
{
    public class Quote : IQuote
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Author { get; set; }
    }
}
