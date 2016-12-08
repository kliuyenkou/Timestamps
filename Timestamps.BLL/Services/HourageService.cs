using System;
using System.Collections.Generic;
using AutoMapper;
using Timestamps.BLL.Interfaces;
using Timestamps.BLL.Models;
using Timestamps.DAL.Entities;
using Timestamps.DAL.Interfaces;
using Hourage = Timestamps.BLL.Models.Hourage;
using Project = Timestamps.BLL.Models.Project;

namespace Timestamps.BLL.Services
{
    public class HourageService : IHourageService
    {
        private readonly IHourageRepository _hourageRepository;

        public HourageService(IUnitOfWork unitOfWork)
        {
            _hourageRepository = unitOfWork.Hourages;
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
            throw new NotImplementedException();
        }

        public void Delete(int hourageId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //_hourageRepository.Dispose();
        }
    }
}
