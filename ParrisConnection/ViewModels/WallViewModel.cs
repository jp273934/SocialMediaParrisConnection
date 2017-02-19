using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Status = ParrisConnection.DataLayer.Entities.Wall.Status;

namespace ParrisConnection.ViewModels
{
    public class WallViewModel
    {
        [Key]
        public int Id { get; set; }
        public List<Status> Statuses { get; set; }
    }
}