using ParrisConnection.ServiceLayer.Data;

namespace ParrisConnection.ServiceLayer.Services.Education.Save
{
    public interface IEducationSaveService
    {
        void SaveEducation(EducationData education);
    }
}