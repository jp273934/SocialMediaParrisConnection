using ParrisConnection.ServiceLayer.Models;

namespace ParrisConnection.ServiceLayer.ViewModelServices.ProfileView
{
    public interface IProfileViewService
    {
        ProfileViewModel GetViewModel(string userId);
    }
}