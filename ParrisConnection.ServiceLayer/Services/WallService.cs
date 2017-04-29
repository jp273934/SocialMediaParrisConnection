using ParrisConnection.ServiceLayer.Models;
using ParrisConnection.ServiceLayer.Services.Interfaces;

namespace ParrisConnection.ServiceLayer.Services
{
    public class WallService : IWallService
    {
        private readonly IStatusService _statusService;
      

        public WallService(IStatusService statusService)
        {
            _statusService = statusService;
        }

        public WallViewModel GetWallData()
        {
            var wall = new WallViewModel
            {
                Statuses = _statusService.GetStatuses()
            };

            return wall;
        }   
    }
}
