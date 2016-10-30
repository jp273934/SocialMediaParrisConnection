using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParrisConnection.Models.Profile
{
    interface IContactType
    {
         int Id { get; set; }
         string Type { get; set; }
    }
}
