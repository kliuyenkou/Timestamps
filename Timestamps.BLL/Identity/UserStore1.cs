using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Timestamps.DAL.Entities;

namespace Timestamps.BLL.Identity
{
    public class UserStore1 : UserStore<ApplicationUser>
    {
    }
}
