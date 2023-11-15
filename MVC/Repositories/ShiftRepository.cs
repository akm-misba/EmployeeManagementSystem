using MVC.Models;

namespace MVC.Repositories
{
    public class ShiftRepository: Repository<Shift>, IShiftRepository
    {
        public ShiftRepository(MVCDBContext dbContext) : base(dbContext)
        {
        }
    }
}
