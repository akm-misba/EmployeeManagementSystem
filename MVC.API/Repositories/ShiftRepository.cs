using MVC.API.Models;


namespace MVC.API.Repositories
{
    public class ShiftRepository: Repository<Shift>, IShiftRepository
    {
        public ShiftRepository(MVCDBContext dbContext) : base(dbContext)
        {
        }
    }
}
