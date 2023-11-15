using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Repositories
{
    public interface IAttendanceSummaryRepository :  IRepository<AttendanceSummary>
    {
      List<AttendanceSummary> GetAttendanceSummaryListByCompanyId(int ComId,int month,int year);
       
    }
}
