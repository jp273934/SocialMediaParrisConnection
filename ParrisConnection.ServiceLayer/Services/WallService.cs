using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Wall;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ParrisConnection.ServiceLayer.Services
{
    public class WallService : IWallService
    {
        private readonly IDataAccess _dataAccess;

        public WallService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        #region Comments
        public IEnumerable<CommentData> GetComments()
        {
            return ConvertCommentsToCommentData(_dataAccess.Comments.GetAll());
        }

        public void SaveComment(CommentData comment)
        {
            var status = _dataAccess.Statuses.GetById(comment.Status.Id);

            status.Comments.Add(ConvertToEntity(comment));
            _dataAccess.Statuses.Save();
        }

        public IEnumerable<CommentData> ConvertCommentsToCommentData(IEnumerable<Comment> comments)
        {
            return comments.Select(item => new CommentData
            {
                Id = item.Id,
                PostComment = item.PostComment
            }).ToList();
        }

        public IEnumerable<Comment> ConvertCommentsToEntity(IEnumerable<CommentData> comments)
        {
            return comments?.Select(ConvertToEntity) ?? new List<Comment>();
        }

        private Comment ConvertToEntity(CommentData comment)
        {
            return new Comment
            {
                PostComment = comment.PostComment,
            };
        }
        #endregion

        #region Statuses    
        public List<StatusData> GetStatuses()
        {
            var statuses = _dataAccess.Statuses.GetAll();

            return statuses.Select(item => new StatusData
            {
                Id = item.Id,
                Post = item.Post,
                Comments = ConvertCommentsToCommentData(item.Comments)
            }).ToList();
        }

        public StatusData GetStatusById(int id)
        {
            var status = _dataAccess.Statuses.GetById(id);

            return new StatusData
            {
                Id = status.Id,
                Post = status.Post,
                Comments = ConvertCommentsToCommentData(status.Comments)
            };
        }

        public void SaveStatus(StatusData status)
        {
            _dataAccess.Statuses.Insert(ConvertToEntity(status));
        }

        private Status ConvertToEntity(StatusData status)
        {
            return new Status
            {
                Id = status.Id,
                Post = status.Post,
                Comments = ConvertCommentsToEntity(status.Comments).ToList()
            };
        }
        #endregion
    }
}
