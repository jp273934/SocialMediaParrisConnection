using AutoMapper;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Wall;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Interfaces;
using System.Collections.Generic;

namespace ParrisConnection.ServiceLayer.Services
{
    public class StatusService : IStatusService
    {
        private readonly IDataAccess _dataAccess;
        private readonly IMapper _mapper;
        private readonly IMapper _commentMapper;

        public StatusService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;

            var commentConfig = new MapperConfiguration(m => m.CreateMap<Comment, CommentData>().ReverseMap());
            _commentMapper= new Mapper(commentConfig);
            var config = new MapperConfiguration(m => m.CreateMap<StatusData, Status>().ReverseMap().ForMember(u => u.Comments, d => d.MapFrom( s => _commentMapper.Map<IEnumerable<CommentData>>(s.Comments))));

            _mapper = new Mapper(config);
        }

        public IEnumerable<StatusData> GetStatuses()
        {
            return _mapper.Map<IEnumerable<StatusData>>(_dataAccess.Statuses.GetAll());
        }

        public StatusData GetStatusById(int id)
        {
            return _mapper.Map<StatusData>(_dataAccess.Statuses.GetById(id));
        }

        public void SaveStatus(StatusData status)
        {
            _dataAccess.Statuses.Insert(_mapper.Map<Status>(status));
        }
    }
}
