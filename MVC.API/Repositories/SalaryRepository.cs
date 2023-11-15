using MVC.API.Models;


namespace MVC.API.Repositories
{
    public class SalaryRepository: Repository<Salary>, ISalaryRepository
    {
        public SalaryRepository(MVCDBContext dbContext) : base(dbContext)
        {
        }
        public List<Salary> GetAttendanceSalaryListByCompanyId(int ComId, int month, int year)
        {
            //var list = _dbContext.SalarySummaries
            //     //.Include(x => x.Company)
            //     // .Include(x => x.Employee)
            //     .Where(x => x.ComId == ComId && x.dtMonth == month && x.dtYear == year)
            //    .ToList();


            var list = _dbContext.SalarySummaries
                .Where(x => x.ComId == ComId && x.dtMonth == month && x.dtYear == year)
                .ToList();
            return list;
            
        }
    }
}
