using AutoMapper;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Profile;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ParrisConnection.ServiceLayer.Services
{
    public class ProfilePhotosService : IProfilePhotosService
    {
        private readonly IDataAccess _dataAccess;
        private readonly IMapper _mapper;

        public ProfilePhotosService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;

            var config = new MapperConfiguration(m => m.CreateMap<ProfilePhoto, ProfilePhotoData>().ReverseMap());

            _mapper = new Mapper(config);
        }

        public IEnumerable<ProfilePhotoData> GetAllProfilePhotos()
        {
            return _mapper.Map<IEnumerable<ProfilePhotoData>>(_dataAccess.ProfilePhotoes.GetAll());
        }

        public ProfilePhotoData GetProfilePhoto(string userId)
        {
            var photos = _dataAccess.ProfilePhotoes.GetAll().ToList();
            var photo = photos.SingleOrDefault(p => p.UserId == userId);

            return photo != null ? _mapper.Map<ProfilePhotoData>(photo) : new ProfilePhotoData();
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
            
            _dataAccess.ProfilePhotoes.Insert(new ProfilePhoto {FilePath = file.FileName, UserId = userId});
        }
    }
}
