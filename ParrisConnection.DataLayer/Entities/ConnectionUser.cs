using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ParrisConnection.DataLayer.Entities
{
    public class ConnectionUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsyn(UserManager<ConnectionUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }
    }
}
