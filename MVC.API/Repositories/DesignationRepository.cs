using MVC.API.Models;

namespace MVC.API.Repositories
{
    public class DesignationRepository : Repository<Designation>, IDesignationRepository
    {
        public DesignationRepository(MVCDBContext dbContext) : base(dbContext)
        {
        }
    }
}
