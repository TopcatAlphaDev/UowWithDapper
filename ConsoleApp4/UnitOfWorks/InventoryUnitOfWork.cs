using System.Data;
using UowWithRepository.Repositories.Interfaces;
using UowWithRepository.UnitOfWorks.Interfaces;

namespace UowWithRepository.UnitOfWorks
{
    public class InventoryUnitOfWork: UnitOfWork, IInventoryUnitOfWork
    {
        public IShopRepository ShopRepository { get; set; }
        public IInventoryRepository InventoryRepository { get; set; }
        public InventoryUnitOfWork(IDbConnection connection, IShopRepository shopRepository, IInventoryRepository inventoryRepository): base(connection, shopRepository, inventoryRepository)
        {
            ShopRepository = shopRepository;
            InventoryRepository = inventoryRepository;
        }
    }
}
