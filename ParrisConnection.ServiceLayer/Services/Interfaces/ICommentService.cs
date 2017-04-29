using System.Collections.Generic;
using ParrisConnection.ServiceLayer.Data;

namespace ParrisConnection.ServiceLayer.Services.Interfaces
{
    public interface ICommentService
    {
        IEnumerable<CommentData> GetComments();
        void SaveComment(CommentData comment);
    }
}