using ParrisConnection.ServiceLayer.Models;

namespace ParrisConnection.ServiceLayer.Services
{
    public interface IProfileViewService
    {
        ProfileViewModel GetViewModel(string userId);
    }
}