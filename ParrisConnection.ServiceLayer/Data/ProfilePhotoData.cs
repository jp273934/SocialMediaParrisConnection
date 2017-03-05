using ParrisConnection.DataLayer.Dtos;

namespace ParrisConnection.ServiceLayer.Data
{
    public class ProfilePhotoData : IProfilePhoto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FilePath { get; set; }
    }
}
