using System.ComponentModel.DataAnnotations;

namespace ParrisConnection.DataLayer.Entities.Profile
{
    public class Link
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Url { get; set; }

        [StringLength(50)]
        public string Type { get; set; }
    }
}
