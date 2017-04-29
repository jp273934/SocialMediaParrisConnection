using System.Collections.Generic;
using ParrisConnection.ServiceLayer.Data;

namespace ParrisConnection.ServiceLayer.Services.Interfaces
{
    public interface IStatusService
    {
        IEnumerable<StatusData> GetStatuses();
        StatusData GetStatusById(int id);
        void SaveStatus(StatusData status);
    }
}