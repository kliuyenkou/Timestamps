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
            var usersRecordsDto = usersRecords
                .Select(h => new HourageDto()
                {
                    Id = h.Id,
                    WorkDescripton = h.WorkDescripton,
                    Date = h.Date,
                    Hours = h.Hours,
                    ProjectId = h.ProjectId,
                    UserId = h.UserId
                });


            //Mapper.Initialize(cfg => cfg.CreateMap<ApplicationUser, ApplicationUserDto>());
            //Mapper.Initialize(cfg => cfg.CreateMap<Project, ProjectDto>());
            //Mapper.Initialize(cfg => cfg.CreateMap<Hourage, HourageDto>());

            //var usersRecordsDto = Mapper.Map<IEnumerable<Hourage>, IEnumerable<HourageDto>>(usersRecords);

            return usersRecordsDto;

        }

        [HttpPost]
        public IHttpActionResult AddRecord(HourageDto record)
        {
            if (!ModelState.IsValid) {
                return BadRequest();
            }


            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ApplicationUserDto, ApplicationUser>();
                cfg.CreateMap<ProjectDto, Project>();
                cfg.CreateMap<HourageDto, Hourage>();
            });

            var mapper = config.CreateMapper();
            var hourage = mapper.Map<HourageDto, Hourage>(record);

            hourage.UserId = User.Identity.GetUserId();
            _context.Hourages.Add(hourage);
            _context.SaveChangesWithErrors();
            return Ok(hourage);
        }

    }

}
