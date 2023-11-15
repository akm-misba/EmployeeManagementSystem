using MVC.API.Models;

namespace MVC.API.Repositories
{ 
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(MVCDBContext dbContext) : base(dbContext)
        {
        }

    }
    
}
