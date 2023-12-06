using UowWithRepository.UnitOfWorks;
using UowWithRepository.UnitOfWorks.Interfaces;

namespace UowWithRepository.Repositories.Interfaces
{
    public interface IRepository      
    {
        void SetUnitOfWork(IUnitOfWork unitOfWork);
        void RemoveUnitOfWork();
    }
}