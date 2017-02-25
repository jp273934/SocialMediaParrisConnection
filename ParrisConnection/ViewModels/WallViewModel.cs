using ParrisConnection.ServiceLayer.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParrisConnection.ViewModels
{
    public class WallViewModel
    {
        [Key]
        public int Id { get; set; }
        public List<StatusData> Statuses { get; set; }
    }
}