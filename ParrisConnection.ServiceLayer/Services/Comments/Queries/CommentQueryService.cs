using AutoMapper;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Wall;
using ParrisConnection.ServiceLayer.Data;
using System.Collections.Generic;

namespace ParrisConnection.ServiceLayer.Services.Comments.Queries
{
    public class CommentQueryService : ICommentQueryService
    {
        private readonly IDataAccess _dataAccess;
        private readonly IMapper _mapper;

        public CommentQueryService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;

            var config = new MapperConfiguration(m => m.CreateMap<Comment, CommentData>().ReverseMap());

            _mapper = new Mapper(config);
        }

        public IEnumerable<CommentData> GetComments()
        {
            return _mapper.Map<IEnumerable<CommentData>>(_dataAccess.Comments.GetAll());
        }
    }
}
