using System.Collections.Generic;
using ParrisConnection.ServiceLayer.Data;

namespace ParrisConnection.ServiceLayer.Services.Education.Queries
{
    public interface IEducationQueryService
    {
        IEnumerable<EducationData> GetAllEducation();
        EducationData GetEducationById(int id);
    }
}