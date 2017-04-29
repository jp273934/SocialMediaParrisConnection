using ParrisConnection.ServiceLayer.Data;

namespace ParrisConnection.ServiceLayer.Services.Comments.Save
{
    public interface ICommentSaveService
    {
        void SaveComment(CommentData comment, int statusId);
    }
}