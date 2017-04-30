using ParrisConnection.ServiceLayer.Data;
using System.Collections.Generic;

namespace ParrisConnection.ServiceLayer.Services.Education.Queries
{
    public interface IEducationQueryService
    {
        IEnumerable<EducationData> GetAllEducation();
        IEnumerable<EducationData> GetEducationByUserId(string userId);
        EducationData GetEducationById(int id);
    }
}