using System.Collections.Generic;
using ParrisConnection.ServiceLayer.Data;

namespace ParrisConnection.ServiceLayer.Services.ProfilePhoto.Queries
{
    public interface IProfilePhotoQueryService
    {
        IEnumerable<ProfilePhotoData> GetAllProfilePhotos();
        ProfilePhotoData GetProfilePhoto(string userId);
    }
}