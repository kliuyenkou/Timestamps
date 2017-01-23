using System;
using System.Collections.Generic;
using Timestamps.DAL.DataInterfaces;
using Timestamps.DAL.Entities;
using Timestamps.DAL.Management.Interfaces;

namespace Timestamps.DAL.Management
{
    public class HourageManagement : IHourageManagement
    {
        private readonly IUnitOfWork _unitOfWork;

        public HourageManagement(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Hourage Create(Hourage hourage)
        {
            _unitOfWork.Hourages.Add(hourage);
            _unitOfWork.SaveChanges();
            return hourage;
        }

        public void Delete(string userId, int hourageId)
        {
            var hourage = _unitOfWork.Hourages.Get(hourageId);
            if (hourage.UserId == userId) {
                _unitOfWork.Hourages.RemoveById(hourageId);
                _unitOfWork.SaveChanges();
            }
            else {
                throw new ArgumentOutOfRangeException(nameof(userId), "This user cann't delete this record.");
            }

        }

        public IEnumerable<Hourage> GetUserHourageRecordsWithProject(string userId)
        {
            return _unitOfWork.Hourages.GetUserHourageRecordsWithProject(userId);
        }

        public Hourage Get(int hourageId)
        {
            return _unitOfWork.Hourages.Get(hourageId);
        }
    }
}