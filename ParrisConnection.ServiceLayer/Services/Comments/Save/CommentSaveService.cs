using AutoMapper;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Wall;
using ParrisConnection.ServiceLayer.Data;

namespace ParrisConnection.ServiceLayer.Services.Comments.Save
{
    public class CommentSaveService : ICommentSaveService
    {
        private readonly IDataAccess _dataAccess;
        private readonly IMapper _mapper;

        public CommentSaveService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;

            var config = new MapperConfiguration(m => m.CreateMap<Comment, CommentData>().ReverseMap());

            _mapper = new Mapper(config);
        }

        public void SaveComment(CommentData comment, int statusId)
        {
            var status = _dataAccess.Statuses.GetById(statusId);
            status.Comments.Add(_mapper.Map<Comment>(comment));

            _dataAccess.Comments.Insert(_mapper.Map<Comment>(comment));
        }
    }
}
