using System.Web;

namespace ParrisConnection.ServiceLayer.Services.ProfilePhoto.Save
{
    public interface IProfilePhotoSaveService
    {
        void UpdateProfilePhoto(HttpPostedFileBase file, string filePath, string userId);
    }
}