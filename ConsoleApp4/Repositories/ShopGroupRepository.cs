using System;
using System.Collections.Generic;
using System.Linq;
using UowWithRepository.Repositories.Interfaces;
using UowWithRepository.Repositories.Models;

namespace UowWithRepository.Repositories
{
    public class ShopGroupRepository : BaseRepository, IShopGroupRepository
    {
        public int GetCount()
        {
            return ExecuteQuery<int>("SELECT count(*) FROM system.ShopGroup", new { DateTime.Now }).FirstOrDefault();
        }
        public IEnumerable<ShopGroup> GetAll()
        {
            return ExecuteQuery<ShopGroup>("SELECT * FROM system.ShopGroup", new { DateTime.Now });
        }
    }
}