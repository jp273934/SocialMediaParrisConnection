using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Profile;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParrisConnection.ServiceLayer.Services
{
    public class ProfilePhotosService : IProfilePhotosService
    {
        private readonly IDataAccess _dataAccess;

        public ProfilePhotosService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<ProfilePhotoData> GetAllProfilePhotos()
        {
            return _dataAccess.ProfilePhotoes.GetAll().Select(LoadData);
        }

        public ProfilePhotoData GetProfilePhoto()
        {
            var photos = _dataAccess.ProfilePhotoes.GetAll().ToList();

            return photos.Any() ? LoadData(photos[0]) : new ProfilePhotoData();
        }

        public void UpdateProfilePhoto(HttpPostedFileBase file, string filePath)
        {
            file.SaveAs(filePath);

            _dataAccess.ProfilePhotoes.GetAll().ToList().Clear();

            _dataAccess.ProfilePhotoes.Insert(new ProfilePhoto {FilePath = file.FileName});
        }

        private ProfilePhotoData LoadData(ProfilePhoto photo)
        {
            return new ProfilePhotoData
            {
                Id = photo.Id,
                FilePath = photo.FilePath
            };
        }
    }
}
