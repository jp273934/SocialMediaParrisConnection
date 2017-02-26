using System.ComponentModel.DataAnnotations;
using ParrisConnection.DataLayer.Dtos;

namespace ParrisConnection.DataLayer.Entities.Profile
{
    public class ProfilePhoto : IProfilePhoto
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string FilePath { get; set; }
    }
}
