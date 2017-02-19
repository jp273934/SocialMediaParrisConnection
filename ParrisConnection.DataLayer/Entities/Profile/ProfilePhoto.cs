using System.ComponentModel.DataAnnotations;

namespace ParrisConnection.DataLayer.Entities.Profile
{
    public class ProfilePhoto
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string FilePath { get; set; }
    }
}
