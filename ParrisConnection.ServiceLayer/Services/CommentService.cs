using AutoMapper;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Wall;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Interfaces;
using System.Collections.Generic;

namespace ParrisConnection.ServiceLayer.Services
{
    public class CommentService : ICommentService
    {
        private readonly IDataAccess _dataAccess;
        private readonly IMapper _mapper;

        public CommentService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;

            var config = new MapperConfiguration(m => m.CreateMap<Comment, CommentData>().ReverseMap());

            _mapper = new Mapper(config);
        }

        public IEnumerable<CommentData> GetComments()
        {
            return _mapper.Map<IEnumerable<CommentData>>(_dataAccess.Comments.GetAll());
        }

        public void SaveComment(CommentData comment, int statusId)
        {
            var status = _dataAccess.Statuses.GetById(statusId);
            status.Comments.Add(_mapper.Map<Comment>(comment));

            _dataAccess.Comments.Insert(_mapper.Map<Comment>(comment));
        }
    }
}
