using System.Collections.Generic;
using AutoMapper;
using Omu.ValueInjecter;
using Timestamps.BLL.Interfaces;
using Timestamps.DAL.Interfaces;
using Hourage = Timestamps.BLL.Models.Hourage;
using HourageEntity = Timestamps.DAL.Entities.Hourage;
using Mapper = AutoMapper.Mapper;

namespace Timestamps.BLL.Services
{
    public class HourageService : IHourageService
    {
        private readonly IHourageRepository _hourageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HourageService(IUnitOfWork unitOfWork)
        {
            _hourageRepository = unitOfWork.Hourages;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Hourage> GetUserHourageRecordsWithProject(string userId)
        {
            var dbHourageRecords = _hourageRepository.GetUserHourageRecordsWithProject(userId);
            var records = Mapper.Map<IEnumerable<HourageEntity>, IEnumerable<Hourage>>(dbHourageRecords);
            return records;
        }

        public void Add(Hourage hourage)
        {
            var hourageEntity = new HourageEntity();
            hourageEntity.InjectFrom(hourage);
            _hourageRepository.Add(hourageEntity);
            _unitOfWork.SaveChangesWithErrors();
        }

        public Hourage GetHourageById(int hourageId)
        {
            var hourageDb = _hourageRepository.Get(hourageId);
            var hourage = new Hourage();
            hourage.InjectFrom(hourageDb);
            return hourage;
        }

        public void Delete(int hourageId)
        {
            _hourageRepository.RemoveById(hourageId);
            _unitOfWork.SaveChanges();
        }
    }
}