using System.Data;
using UowWithRepository.Repositories.Interfaces;
using UowWithRepository.UnitOfWorks.Interfaces;

namespace UowWithRepository.UnitOfWorks
{
    public class ShopUnitOfWork : UnitOfWork, IShopUnitOfWork
    {
        public IShopRepository ShopRepository { get; set; }
        public IInventoryRepository InventoryRepository { get; set; }
        public IShopGroupRepository ShopGroupRepository { get; set; }
        public ShopUnitOfWork(IDbConnection connection, IShopRepository shopRepository, IInventoryRepository inventoryRepository, IShopGroupRepository shopGroupRepository): 
            base(connection, shopRepository, inventoryRepository, shopGroupRepository)
        {
            ShopRepository = shopRepository;
            InventoryRepository = inventoryRepository;
            ShopGroupRepository = shopGroupRepository;
        }
    }
}
