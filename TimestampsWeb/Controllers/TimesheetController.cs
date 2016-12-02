using AutoMapper;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Timestamps.BLL.Interfaces;
using Timestamps.BLL.Models;
using TimestampsWeb.Dto;

namespace TimestampsWeb.Controllers
{
    [Authorize]
    public class TimesheetController : ApiController
    {
        private readonly IHourageService _hourageService;
        public TimesheetController(IHourageService hourageService)
        {
            _hourageService = hourageService;
        }

        [HttpGet]
        public IEnumerable<HourageDto> GetUsersRecords()
        {
            var userId = User.Identity.GetUserId();
            var usersRecords = _hourageService.GetUserHourageRecordsWithProject(userId);
            var usersRecordsDto = usersRecords
                .Select(h => new HourageDto()
                {
                    Id = h.Id,
                    WorkDescription = h.WorkDescription,
                    ProjectTitle = h.Project.Title,
                    Date = h.Date,
                    Hours = h.Hours,
                    ProjectId = h.ProjectId,
                    UserId = h.UserId
                });

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
            _hourageService.Add(hourage);
            return Ok(hourage);
        }

    }

}
