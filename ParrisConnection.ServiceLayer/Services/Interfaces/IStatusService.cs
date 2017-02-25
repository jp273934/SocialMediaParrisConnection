using ParrisConnection.ServiceLayer.Data;
using System.Collections.Generic;

namespace ParrisConnection.ServiceLayer.Services.Interfaces
{
    public interface IStatusService
    {
        List<StatusData> GetStatuses();
        StatusData GetStatusById(int id);
    }
}