using UowWithRepository.Repositories.Interfaces;

namespace UowWithRepository.UnitOfWorks.Interfaces
{
    public interface IShopUnitOfWork : IUnitOfWork
    {
        IShopRepository ShopRepository { get; set; }
        IInventoryRepository InventoryRepository { get; set; }
        IShopGroupRepository ShopGroupRepository { get; set; }
    }
}