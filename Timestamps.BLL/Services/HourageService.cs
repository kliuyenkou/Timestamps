using System;
using System.Collections.Generic;
using Omu.ValueInjecter;
using Timestamps.BLL.Interfaces;
using Timestamps.DAL.Management.Interfaces;
using Hourage = Timestamps.BLL.Models.Hourage;
using HourageEntity = Timestamps.DAL.Entities.Hourage;
using Mapper = AutoMapper.Mapper;

namespace Timestamps.BLL.Services
{
    public class HourageService : IHourageService
    {
        private readonly IHourageManagement _hourageManagement;
        private readonly IProjectManagement _projectManagement;

        public HourageService(IHourageManagement hourageManagement, IProjectManagement projectManagement)
        {
            _hourageManagement = hourageManagement;
            _projectManagement = projectManagement;
        }

        public IEnumerable<Hourage> GetUserHourageRecordsWithProject(string userId)
        {
            var dbHourageRecords = _hourageManagement.GetUserHourageRecordsWithProject(userId);
            var records = Mapper.Map<IEnumerable<HourageEntity>, IEnumerable<Hourage>>(dbHourageRecords);
            return records;
        }

        public void AddHourageRecord(Hourage hourage)
        {
            var hourageEntity = new HourageEntity();
            hourageEntity.InjectFrom(hourage);
            _hourageManagement.Create(hourageEntity);
        }

        public Hourage GetHourageById(int hourageId)
        {
            var hourageEntity = _hourageManagement.Get(hourageId);
            var hourage = new Hourage();
            hourage.InjectFrom(hourageEntity);
            return hourage;
        }

        public void DeleteHourageRecord(int hourageId)
        {
            _hourageManagement.Delete(hourageId);
        }

        public Hourage CreateHourageRecord(string workDescription, int projectId, DateTime date, double hours, string userId)
        {
            var hourageEntity = new HourageEntity()
            {
                WorkDescription = workDescription,
                ProjectId = projectId,
                Date = date,
                Hours = hours,
                UserId = userId
            };
            var savedHourage = _hourageManagement.Create(hourageEntity);
            savedHourage.Project = _projectManagement.GetProjectById(savedHourage.ProjectId);
            var hourage = Mapper.Map<HourageEntity, Hourage>(savedHourage);
            return hourage;
        }
    }
}