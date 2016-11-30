using AutoMapper;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using TimestampsWeb.Dto;
using TimestampsWeb.Models;
using TimestampsWeb.TimestampsWeb.DAL.EFDataReceiving;
using TimestampsWeb.TimestampsWeb.DAL.Interfaces;

namespace TimestampsWeb.Controllers
{
    [Authorize]
    public class TimesheetController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public TimesheetController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<HourageDto> GetUsersRecords()
        {
            var userId = User.Identity.GetUserId();
            var usersRecords = _unitOfWork.Hourages.GetUserHourageRecordsWithProject(userId);
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
            _unitOfWork.Hourages.Add(hourage);
            _unitOfWork.SaveChangesWithErrors();
            return Ok(hourage);
        }

    }

}
