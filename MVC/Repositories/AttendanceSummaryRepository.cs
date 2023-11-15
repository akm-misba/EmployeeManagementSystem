using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Repositories
{
    public class AttendanceSummaryRepository: Repository<AttendanceSummary>, IAttendanceSummaryRepository
    {
        public AttendanceSummaryRepository(MVCDBContext dbContext) : base(dbContext)
        {
            
           
        }

        public List<AttendanceSummary> GetAttendanceSummaryListByCompanyId(int ComId, int month, int year)
        {
            var list = _dbContext.AttendanceSummaries
                //.Include(x => x.Company)
                // .Include(x => x.Employee)
                 .Where(x=>x.ComId==ComId&& x.dtMonth==month&& x.dtYear==year)
                .ToList();
            return list;
        }
    }
}
