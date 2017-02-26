using ParrisConnection.ServiceLayer.Data;
using System.Collections.Generic;
using System.Web;

namespace ParrisConnection.ServiceLayer.Services.Interfaces
{
    public interface IProfilePhotosService
    {
        IEnumerable<ProfilePhotoData> GetAllProfilePhotos();
        ProfilePhotoData GetProfilePhoto();
        void UpdateProfilePhoto(HttpPostedFileBase file, string filePath);
    }
}