using ParrisConnection.DataLayer.DataAccess;
using System.IO;
using System.Linq;
using System.Web;

namespace ParrisConnection.ServiceLayer.Services.ProfilePhoto.Save
{
    public class ProfilePhotoSaveService : IProfilePhotoSaveService
    {
        private readonly IDataAccess _dataAccess;

        public ProfilePhotoSaveService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public void UpdateProfilePhoto(HttpPostedFileBase file, string filePath, string userId)
        {
            var photos = _dataAccess.ProfilePhotoes.GetAll();
            var currentPhoto = photos.SingleOrDefault(p => p.UserId == userId);

            if (currentPhoto != null)
            {
                var newFile = new FileInfo(currentPhoto.FilePath);
                newFile.Delete();
                _dataAccess.ProfilePhotoes.Delete(currentPhoto);
            }

            file.SaveAs(filePath);

            _dataAccess.ProfilePhotoes.Insert(new DataLayer.Entities.Profile.ProfilePhoto { FilePath = file.FileName, UserId = userId });
        }
    }
}
