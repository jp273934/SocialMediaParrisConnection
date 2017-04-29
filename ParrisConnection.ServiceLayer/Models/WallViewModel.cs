using ParrisConnection.ServiceLayer.Data;
using System.Collections.Generic;

namespace ParrisConnection.ServiceLayer.Models
{
    public class WallViewModel
    {
        public int Id { get; set; }
        public IEnumerable<StatusData> Statuses { get; set; }
    }
}