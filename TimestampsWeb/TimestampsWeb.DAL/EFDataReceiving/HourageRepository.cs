using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimestampsWeb.TimestampsWeb.DAL.Interfaces;
using TimestampsWeb.Models;
using System.Data.Entity;

namespace TimestampsWeb.TimestampsWeb.DAL.EFDataReceiving
{
    public class HourageRepository : Repository<Hourage>, IHourageRepository
    {
        public HourageRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}