using System.Collections.Generic;
using Timestamps.DAL.Entities;
using Timestamps.DAL.Interfaces;
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
        public void Create(Hourage hourage)
        {
            _unitOfWork.Hourages.Add(hourage);
            _unitOfWork.SaveChanges();
        }

        public void Delete(int hourageId)
        {
            _unitOfWork.Hourages.RemoveById(hourageId);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<Hourage> GetUserHourageRecords(string userId)
        {
            return _unitOfWork.Hourages.GetUserHourageRecordsWithProject(userId);
        }

        public Hourage Get(int hourageId)
        {
            return _unitOfWork.Hourages.Get(hourageId);
        }
    }
}
