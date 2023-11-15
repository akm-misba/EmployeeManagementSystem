using MVC.Models;

namespace MVC.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(MVCDBContext dbContext) : base(dbContext)
        {
        }

    }
    
}
