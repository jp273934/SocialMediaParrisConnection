using ParrisConnection.ServiceLayer.Models;
using ParrisConnection.ServiceLayer.Services.Status.Queries;

namespace ParrisConnection.ServiceLayer.Services.Wall
{
    public class WallService : IWallService
    {
        private readonly IStatusQueryService _statusQueryService;

        public WallService(IStatusQueryService statusQueryService)
        {
            _statusQueryService = statusQueryService;
        }


        public WallViewModel GetWallData()
        {
            var wall = new WallViewModel
            {
                Statuses = _statusQueryService.GetStatuses()
            };

            return wall;
        }   
    }
}
