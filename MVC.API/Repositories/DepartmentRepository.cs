using MVC.API.Models;

namespace MVC.API.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(MVCDBContext dbContext) : base(dbContext)
        {
        }
    }
}
