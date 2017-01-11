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

        public HourageService(IHourageManagement hourageManagement)
        {
            _hourageManagement = hourageManagement;
        }

        public IEnumerable<Hourage> GetUserHourageRecordsWithProject(string userId)
        {
            var dbHourageRecords = _hourageManagement.GetUserHourageRecords(userId);
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
    }
}