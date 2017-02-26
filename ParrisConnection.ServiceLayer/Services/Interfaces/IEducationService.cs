using System.Collections.Generic;
using ParrisConnection.ServiceLayer.Data;

namespace ParrisConnection.ServiceLayer.Services.Interfaces
{
    public interface IEducationService
    {
        IEnumerable<EducationData> GetAllEducation();
        EducationData GetEducationById(int id);
        void SaveEducation(EducationData education);
    }
}