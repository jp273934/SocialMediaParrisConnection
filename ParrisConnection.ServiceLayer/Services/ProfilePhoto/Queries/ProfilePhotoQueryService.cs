using AutoMapper;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.ServiceLayer.Data;
using System.Collections.Generic;
using System.Linq;

namespace ParrisConnection.ServiceLayer.Services.ProfilePhoto.Queries
{
    public class ProfilePhotoQueryService : IProfilePhotoQueryService
    {
        private readonly IDataAccess _dataAccess;
        private readonly IMapper _mapper;

        public ProfilePhotoQueryService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;

            var config = new MapperConfiguration(m => m.CreateMap<DataLayer.Entities.Profile.ProfilePhoto, ProfilePhotoData>().ReverseMap());

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
    }
}
