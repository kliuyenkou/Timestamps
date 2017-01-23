using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Timestamps.BLL.Interfaces;
using TimestampsWeb.Dto;

namespace TimestampsWeb.Controllers.Hourage
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
        public IEnumerable<HourageDto> GetUsersRecords()
        {
            var userId = User.Identity.GetUserId();
            var usersRecords = _hourageService.GetUserHourageRecordsWithProject(userId);
            var records = Mapper.Map<IEnumerable<HourageDto>>(usersRecords);
            return records;
        }

        [HttpPost]
        public HourageDto AddRecord(HourageDto record)
        {
            if (!ModelState.IsValid)
                return null;

            var userId = User.Identity.GetUserId();
            var hourage = _hourageService.CreateHourageRecord(record.WorkDescription, record.ProjectId, record.Date,
                record.Hours, userId);
            var hourageDto = Mapper.Map<Timestamps.BLL.DataContracts.Hourage, HourageDto>(hourage);
            return hourageDto;
        }

        [HttpDelete]
        public IHttpActionResult DeleteRecord(int id)
        {
            var userId = User.Identity.GetUserId();
            try {
                _hourageService.DeleteHourageRecord(userId, id);
            }
            catch (Exception) {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            return Ok();
        }
    }
}