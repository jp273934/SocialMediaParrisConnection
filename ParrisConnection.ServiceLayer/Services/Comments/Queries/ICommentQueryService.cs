using System.Collections.Generic;
using ParrisConnection.ServiceLayer.Data;

namespace ParrisConnection.ServiceLayer.Services.Comments.Queries
{
    public interface ICommentQueryService
    {
        IEnumerable<CommentData> GetComments();
    }
}