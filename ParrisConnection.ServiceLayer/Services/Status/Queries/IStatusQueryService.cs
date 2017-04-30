using System.Collections.Generic;
using ParrisConnection.ServiceLayer.Data;

namespace ParrisConnection.ServiceLayer.Services.Status.Queries
{
    public interface IStatusQueryService
    {
        IEnumerable<StatusData> GetStatuses();
        StatusData GetStatusById(int id);
    }
}