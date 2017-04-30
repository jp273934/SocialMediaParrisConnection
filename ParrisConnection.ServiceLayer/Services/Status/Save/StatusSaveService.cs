using AutoMapper;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Wall;
using ParrisConnection.ServiceLayer.Data;
using System.Collections.Generic;

namespace ParrisConnection.ServiceLayer.Services.Status.Save
{
    public class StatusSaveService : IStatusSaveService
    {
        private readonly IDataAccess _dataAccess;
        private readonly IMapper _mapper;
        private readonly IMapper _commentMapper;

        public StatusSaveService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;

            var commentConfig = new MapperConfiguration(m => m.CreateMap<Comment, CommentData>().ReverseMap());
            _commentMapper = new Mapper(commentConfig);
            var config = new MapperConfiguration(m => m.CreateMap<StatusData, DataLayer.Entities.Wall.Status>().ReverseMap().ForMember(u => u.Comments, d => d.MapFrom(s => _commentMapper.Map<IEnumerable<CommentData>>(s.Comments))));

            _mapper = new Mapper(config);
        }

        public void SaveStatus(StatusData status)
        {
            _dataAccess.Statuses.Insert(_mapper.Map<DataLayer.Entities.Wall.Status>(status));
        }
    }
}
