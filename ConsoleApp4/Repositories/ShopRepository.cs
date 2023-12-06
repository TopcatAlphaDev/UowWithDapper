using UowWithRepository.Repositories.Interfaces;

namespace UowWithRepository.Repositories
{
    public class ShopRepository : BaseRepository, IShopRepository
    {
        public void Insert()
        {
            ExecuteQuery("INSERT INTO system.Shop (@ShopNbr) ", new { ShopNbr = 1 });
        }
    }
}