using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParrisConnection.DataLayer.Entities.Profile
{
    public class Phone
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Number { get; set; }
        public string PhoneType { get; set; }
    }
}
