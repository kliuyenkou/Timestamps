using AutoMapper;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using TimestampsWeb.Dto;
using TimestampsWeb.Models;

namespace TimestampsWeb.Controllers.API
{
    [Authorize]
    public class TimesheetController : ApiController
    {
        ApplicationDbContext _context;
        public TimesheetController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<HourageDto> GetUsersRecords()
        {
            var userId = User.Identity.GetUserId();
            var usersRecords = _context.Hourages.Where(h => h.UserId == userId).Include(h => h.Project).Include(h => h.User).ToList();
            
            Mapper.Initialize(cfg => cfg.CreateMap<ApplicationUser, ApplicationUserDto>());
            Mapper.Initialize(cfg => cfg.CreateMap<Project, ProjectDto>());
            Mapper.Initialize(cfg => cfg.CreateMap<Hourage, HourageDto>());

            var usersRecordsDto = Mapper.Map<List<Hourage>, List<HourageDto>>(usersRecords);
            return usersRecordsDto;

        }

    }
}
