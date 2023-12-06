using System.Collections.Generic;
using UowWithRepository.Repositories.Models;

namespace UowWithRepository.Repositories.Interfaces
{
    public interface IShopGroupRepository: IRepository
    {
        int GetCount();
        IEnumerable<ShopGroup> GetAll();
    }
}