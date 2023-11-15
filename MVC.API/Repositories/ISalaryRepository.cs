using MVC.API.Models;
using MVC.API.Repositories;


namespace MVC.API.Repositories
{
    public interface ISalaryRepository: IRepository<Salary>
    {
        List<Salary> GetAttendanceSalaryListByCompanyId(int ComId, int month, int year);

    }
}
