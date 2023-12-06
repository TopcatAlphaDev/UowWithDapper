using System;
using System.Collections.Generic;
using UowWithRepository.Repositories.Interfaces;
using UowWithRepository.UnitOfWorks.Interfaces;

namespace UowWithRepository.Repositories
{
    public class BaseRepository : IRepository
    {
        protected IUnitOfWork UnitOfWork;
        public void SetUnitOfWork(IUnitOfWork unitOfWork)
        {
            if (UnitOfWork != null && UnitOfWork != unitOfWork)
            {
                throw new Exception("Repository has already an active unit of work.");
            }
            UnitOfWork = unitOfWork;
        }
        public void ExecuteQuery(string query, object param = null)
        {
            UnitOfWork.ExecuteQuery(query, param);
        }
        public IEnumerable<T> ExecuteQuery<T>(string query, object param = null)
        {
            return UnitOfWork.ExecuteQuery<T>(query, param);
        }
        public void RemoveUnitOfWork()
        {
            UnitOfWork = null;
        }
    }
}