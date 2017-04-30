using ParrisConnection.ServiceLayer.Data;

namespace ParrisConnection.ServiceLayer.Services.Status.Save
{
    public interface IStatusSaveService
    {
        void SaveStatus(StatusData status);
    }
}