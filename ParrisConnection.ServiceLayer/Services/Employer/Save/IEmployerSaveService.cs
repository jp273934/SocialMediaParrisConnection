using ParrisConnection.ServiceLayer.Data;

namespace ParrisConnection.ServiceLayer.Services.Employer.Save
{
    public interface IEmployerSaveService
    {
        void SaveEmployer(EmployerData employer);
    }
}