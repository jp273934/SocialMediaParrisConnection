using ParrisConnection.ServiceLayer.Data;
using System.Collections.Generic;

namespace ParrisConnection.ServiceLayer.Services.Interfaces
{
    public interface ICommentService
    {
        IEnumerable<CommentData> GetComments();
        void SaveComment(CommentData comment, int statusId);
    }
}