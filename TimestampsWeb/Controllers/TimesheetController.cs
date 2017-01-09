using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Omu.ValueInjecter;
using Timestamps.BLL.Interfaces;
using Timestamps.BLL.Models;
using TimestampsWeb.ViewModels;

namespace TimestampsWeb.Controllers
{
    public class TimesheetController : ApiController
    {
        private readonly IHourageService _hourageService;
        private readonly IProjectService _projectService;

        public TimesheetController(IHourageService hourageService, IProjectService projectService)
        {
            _hourageService = hourageService;
            _projectService = projectService;
        }

        [HttpGet]
        public IEnumerable<HourageViewModel> GetUsersRecords()
        {
            var userId = User.Identity.GetUserId();
            var usersRecords = _hourageService.GetUserHourageRecordsWithProject(userId);
            var records = usersRecords
                .Select(h => new HourageViewModel
                {
                    Id = h.Id,
                    WorkDescription = h.WorkDescription,
                    Project = h.Project,
                    Date = h.Date.Date,
                    Hours = h.Hours,
                    ProjectId = h.ProjectId,
                });

            return records;
        }

        [HttpPost]
        public IHttpActionResult AddRecord(HourageViewModel record)
        {
            if (!ModelState.IsValid) return BadRequest();

            var userId = User.Identity.GetUserId();
            var hourage = new Hourage();
            hourage.InjectFrom(record);
            hourage.UserId = userId;

            _hourageService.Add(hourage);
            //var houragSaved = _hourageService.GetHourageById(hourage.Id);
            //houragSaved.Project = _projectService.GetUserProjectById(userId, hourage.ProjectId);
            return Ok(hourage);
        }

        [HttpDelete]
        public void DeleteRecord(int id)
        {
            _hourageService.Delete(id);
        }
    }
}
