using MVC.Models;

namespace MVC.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(MVCDBContext dbContext) : base(dbContext)
        {
        }
    }
}
