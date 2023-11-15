using MVC.Models;

namespace MVC.Repositories
{
    public interface ISalaryRepository: IRepository<Salary>
    {
        List<Salary> GetAttendanceSalaryListByCompanyId(int ComId, int month, int year);

    }
}
