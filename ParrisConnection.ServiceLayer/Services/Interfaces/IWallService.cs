using ParrisConnection.DataLayer.Entities.Wall;
using ParrisConnection.ServiceLayer.Data;
using System.Collections.Generic;

namespace ParrisConnection.ServiceLayer.Services.Interfaces
{
    public interface IWallService
    {
        IEnumerable<CommentData> GetComments();
        void SaveComment(CommentData comment);
        IEnumerable<CommentData> ConvertCommentsToCommentData(IEnumerable<Comment> comments);
        IEnumerable<Comment> ConvertCommentsToEntity(IEnumerable<CommentData> comments);
        List<StatusData> GetStatuses();
        StatusData GetStatusById(int id);
        void SaveStatus(StatusData status);
    }
}