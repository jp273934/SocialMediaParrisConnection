using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Models;
using System.Collections.Generic;

namespace ParrisConnection.ServiceLayer.Services.Interfaces
{
    public interface IWallService
    {
        WallViewModel GetWallData();
        void SaveComment(CommentData comment, int statusId);
        IEnumerable<StatusData> GetStatuses();
        void SaveStatus(StatusData status);
    }
}