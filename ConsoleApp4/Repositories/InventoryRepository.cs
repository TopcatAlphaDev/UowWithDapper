using UowWithRepository.Repositories.Interfaces;

namespace UowWithRepository.Repositories
{
    public class InventoryRepository : BaseRepository, IInventoryRepository
    {
        public void Update()
        {
            ExecuteQuery("UPDATE system.Inventory SET [Name] = @Name WHERE Id = @Id ", new { Id = 1, Name = "Department" });
        }
    }
}