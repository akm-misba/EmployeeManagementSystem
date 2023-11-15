using MVC.Models;

namespace MVC.Repositories
{
    public class DesignationRepository : Repository<Designation>, IDesignationRepository
    {
        public DesignationRepository(MVCDBContext dbContext) : base(dbContext)
        {
        }
    }
}
