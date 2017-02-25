using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Wall;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ParrisConnection.ServiceLayer.Services
{
    public class StatusService : IStatusService
    {
        private readonly IDataAccess _context;

        public StatusService(IDataAccess context)
        {
            _context = context;
        }

        public List<StatusData> GetStatuses()
        {
            var statuses = _context.Statuses.GetAll();

            return statuses.Select(item => new StatusData
            {
                Id = item.Id,
                Post = item.Post,
                Comments = LoadComments(item.Comments)
            }).ToList();
        }

        public StatusData GetStatusById(int id)
        {
            var status = _context.Statuses.GetById(id);

            return new StatusData
            {
                Id = status.Id,
                Post = status.Post,
                Comments = LoadComments(status.Comments)
            };
        }

        private List<CommentData> LoadComments(List<Comment> comments)
        {
            return comments.Select(item => new CommentData
            {
                Id = item.Id, PostComment = item.PostComment
            }).ToList();
        }
    }
}
