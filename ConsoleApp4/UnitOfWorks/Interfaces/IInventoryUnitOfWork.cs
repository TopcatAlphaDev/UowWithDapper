using UowWithRepository.Repositories.Interfaces;

namespace UowWithRepository.UnitOfWorks.Interfaces
{
    public interface IInventoryUnitOfWork: IUnitOfWork
    {
        IShopRepository ShopRepository { get; set; }
        IInventoryRepository InventoryRepository { get; set; }
    }
}