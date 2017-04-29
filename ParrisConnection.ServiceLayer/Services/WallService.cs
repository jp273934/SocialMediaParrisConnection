using AutoMapper;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Wall;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Models;
using ParrisConnection.ServiceLayer.Services.Interfaces;
using System.Collections.Generic;

namespace ParrisConnection.ServiceLayer.Services
{
    public class WallService : IWallService
    {
        private readonly IDataAccess _dataAccess;
        private readonly IStatusService _statusService;
        private readonly IMapper _mapper;
        private readonly IMapper _statusMapper;

        public WallService(IDataAccess dataAccess, IStatusService statusService)
        {
            _dataAccess = dataAccess;
            _statusService = statusService;

            var config = new MapperConfiguration(m => m.CreateMap<Comment, CommentData>().ReverseMap());
            var statusConfig = new MapperConfiguration(m => m.CreateMap<Status, StatusData>().ReverseMap());

            _mapper = new Mapper(config);
            _statusMapper = new Mapper(statusConfig);
        }

        public WallViewModel GetWallData()
        {
            var wall = new WallViewModel
            {
                Statuses = _statusService.GetStatuses()
            };

            return wall;
        }

        #region Comments
        public IEnumerable<CommentData> GetComments()
        {
            return _mapper.Map<IEnumerable<CommentData>>(_dataAccess.Comments.GetAll());
        }

        public void SaveComment(CommentData comment, int statusId)
        {
            var status = _dataAccess.Statuses.GetById(statusId);

            status.Comments.Add(_mapper.Map<Comment>(comment));
            _dataAccess.Statuses.Save();
        }
        #endregion

        #region Statuses    
        public IEnumerable<StatusData> GetStatuses()
        {
            return _statusMapper.Map<IEnumerable<StatusData>>(_dataAccess.Statuses.GetAll());
        }

        public void SaveStatus(StatusData status)
        {
            _dataAccess.Statuses.Insert(_statusMapper.Map<Status>(status));
        }
        #endregion
    }
}
