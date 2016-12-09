using System;
using System.Collections.Generic;
using AutoMapper;
using Omu.ValueInjecter;
using Timestamps.BLL.Interfaces;
using Timestamps.BLL.Models;
using Timestamps.DAL.Entities;
using Timestamps.DAL.Interfaces;
using Hourage = Timestamps.BLL.Models.Hourage;
using HourageEntity = Timestamps.DAL.Entities.Hourage;
using Project = Timestamps.BLL.Models.Project;

namespace Timestamps.BLL.Services
{
    public class HourageService : IHourageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHourageRepository _hourageRepository;

        public HourageService(IUnitOfWork unitOfWork)
        {
            _hourageRepository = unitOfWork.Hourages;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Hourage> GetUserHourageRecordsWithProject(string userId)
        {
            var dbHourageRecords = _hourageRepository.GetUserHourageRecordsWithProject(userId);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ApplicationUser, User>();
                cfg.CreateMap<DAL.Entities.Project, Project>();
                cfg.CreateMap<DAL.Entities.Hourage, Hourage>();
            });
            var mapper = config.CreateMapper();
            var records = mapper.Map<IEnumerable<DAL.Entities.Hourage>, IEnumerable<Hourage>>(dbHourageRecords);
            return records;
        }

        public void Add(Hourage hourage)
        {
            HourageEntity hourageEntity = new HourageEntity();
            hourageEntity.InjectFrom(hourage);
            _hourageRepository.Add(hourageEntity);
            _unitOfWork.SaveChangesWithErrors();
        }

        public void Delete(int hourageId)
        {
            _hourageRepository.RemoveById(hourageId);

        }

        public void Dispose()
        {
            //_hourageRepository.Dispose();
        }
    }
}
