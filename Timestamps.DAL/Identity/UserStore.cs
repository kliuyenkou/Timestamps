using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Timestamps.DAL.Entities;
using Timestamps.DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Timestamps.DAL.Identity
{
    public class UserStore : UserStore<ApplicationUser>
    {

    }
}
